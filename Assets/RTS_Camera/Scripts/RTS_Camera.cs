using UnityEngine;
using System.Collections;

namespace RTS_Cam
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("RTS Camera")]
    public class RTS_Camera : MonoBehaviour
    {

        #region Foldouts

#if UNITY_EDITOR

        

        public int lastTab = 0;

        public bool movementSettingsFoldout;
        public bool zoomingSettingsFoldout;
        public bool rotationSettingsFoldout;
        public bool heightSettingsFoldout;
        public bool mapLimitSettingsFoldout;
        public bool targetingSettingsFoldout;
        public bool inputSettingsFoldout;

#endif

        #endregion

        private Transform m_Transform; //camera tranform
        public bool useFixedUpdate = false; //use FixedUpdate() or Update()

        #region Movement

        public float keyboardMovementSpeed = 5f; //speed with keyboard movement
        public float screenEdgeMovementSpeed = 3f; //spee with screen edge movement
        public float followingSpeed = 5f; //speed when following a target
        public float rotationSped = 3f;
        public float panningSpeed = 10f;
        public float mouseRotationSpeed = 10f;

        #endregion

        #region Height

        public bool autoHeight = true;
        public LayerMask groundMask = -1; //layermask of ground or other objects that affect height

        public float maxHeight = 10f; //maximal height
        public float minHeight = 15f; //minimnal height
        public float heightDampening = 5f; 
        public float keyboardZoomingSensitivity = 2f;
        public float scrollWheelZoomingSensitivity = 25f;

        public float zoomPos = 0; //value in range (0, 1) used as t in Matf.Lerp

        #endregion

        #region MapLimits

        public bool limitMap = true;
        public float limitXMin = -50f; //x limit of map
        public float limitXMax = 50f;
        public float limitYMin = -50f; //z limit of map
        public float limitYMax = 50f;

        #endregion

        #region Targeting

        public Transform targetFollow; //target to follow
        public Vector3 targetOffset;

        /// <summary>
        /// are we following target
        /// </summary>
        public bool FollowingTarget
        {
            get
            {
                return targetFollow != null;
            }
        }

        #endregion

        #region Input

        public bool useScreenEdgeInput = true;
        public float screenEdgeBorder = 25f;

        public bool useTouchInput = true;
        public bool useKeyboardInput = true;
        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";

        public Vector3 touchStart;

        public bool usePanning = true;
        public KeyCode panningKey = KeyCode.Mouse2;

        public bool useKeyboardZooming = true;
        public KeyCode zoomInKey = KeyCode.E;
        public KeyCode zoomOutKey = KeyCode.Q;

        public bool useScrollwheelZooming = true;
        public string zoomingAxis = "Mouse ScrollWheel";

        public bool useKeyboardRotation = true;
        public KeyCode rotateRightKey = KeyCode.X;
        public KeyCode rotateLeftKey = KeyCode.Z;

        public bool useMouseRotation = true;
        public KeyCode mouseRotationKey = KeyCode.Mouse1;

        public bool InBox;
        

        Ray ray;
        RaycastHit hit;


        bool checkit;

        private Vector2 KeyboardInput
        {
            get { return useKeyboardInput ? new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis)) : Vector2.zero; }
        }

        private Vector2 MouseInput
        {
            get { return Input.mousePosition; }
        }
        private Vector2 TouchInput
        {
            get{ return Input.GetTouch(0).position; }
        }

        private float ScrollWheel
        {
            get { return Input.GetAxis(zoomingAxis); }
        }

        private Vector2 MouseAxis
        {
            get { return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); }
        }

        private Vector2 TouchAxis
        {
            get { return new Vector2(Input.touches[0].deltaPosition.x, Input.touches[0].deltaPosition.y); }
        }

        private int ZoomDirection
        {
            get
            {
                bool zoomIn = Input.GetKey(zoomInKey);
                bool zoomOut = Input.GetKey(zoomOutKey);
                if (zoomIn && zoomOut)
                    return 0;
                else if (!zoomIn && zoomOut)
                    return 1;
                else if (zoomIn && !zoomOut)
                    return -1;
                else 
                    return 0;
            }
        }

        private int RotationDirection
        {
            get
            {
                bool rotateRight = Input.GetKey(rotateRightKey);
                bool rotateLeft = Input.GetKey(rotateLeftKey);
                if(rotateLeft && rotateRight)
                    return 0;
                else if(rotateLeft && !rotateRight)
                    return -1;
                else if(!rotateLeft && rotateRight)
                    return 1;
                else 
                    return 0;
            }
        }

        #endregion

        #region Unity_Methods

        private void Start()
        {
            m_Transform = transform;
            
        }

        private void Update()
        {
            if (!useFixedUpdate)
                CameraUpdate();
        }

        private void FixedUpdate()
        {
            if (useFixedUpdate)
                CameraUpdate();
        }

        #endregion

        #region RTSCamera_Methods

        /// <summary>
        /// update camera movement and rotation
        /// </summary>
        private void CameraUpdate()
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(hit.collider != null)
             {
                Debug.Log("RacatHit Collider");
                if(hit.transform.tag ==  "StopMovement")
                {
                    StopMoving.HitUI = true;
                }
                
             }
         }


            
            if (FollowingTarget)
                FollowTarget();
            else
                Move();

            HeightCalculation();
            Rotation();
            LimitPosition();
        }

        /// <summary>
        /// move camera with keyboard or with screen edge
        /// </summary>
        private void Move()
        {
            if (useKeyboardInput)
            {
                Vector3 desiredMove = new Vector3(KeyboardInput.x, KeyboardInput.y,0 );

                desiredMove *= keyboardMovementSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, 0f, transform.eulerAngles.y)) * desiredMove;
                desiredMove = m_Transform.InverseTransformDirection(desiredMove);

                m_Transform.Translate(desiredMove, Space.Self);
            }

            if (useScreenEdgeInput)
            {
                Vector3 desiredMove = new Vector3();

                Rect leftRect = new Rect(0, 0, screenEdgeBorder, Screen.height);
                Rect rightRect = new Rect(Screen.width - screenEdgeBorder, 0, screenEdgeBorder, Screen.height);
                Rect upRect = new Rect(0, Screen.height - screenEdgeBorder, Screen.width, screenEdgeBorder);
                Rect downRect = new Rect(0, 0, Screen.width, screenEdgeBorder);

                desiredMove.x = leftRect.Contains(MouseInput) ? -1 : rightRect.Contains(MouseInput) ? 1 : 0;
                desiredMove.y = upRect.Contains(MouseInput) ? 1 : downRect.Contains(MouseInput) ? -1 : 0;

                desiredMove *= screenEdgeMovementSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, 0f, transform.eulerAngles.y)) * desiredMove;
                desiredMove = m_Transform.InverseTransformDirection(desiredMove);

                m_Transform.Translate(desiredMove, Space.Self);
            }       
        
            if(usePanning && Input.GetKey(panningKey) && MouseAxis != Vector2.zero)
            {
                Vector3 desiredMove = new Vector3(-MouseAxis.x, -MouseAxis.y, 0);

                desiredMove *= panningSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, 0f, transform.eulerAngles.y)) * desiredMove;
                desiredMove = m_Transform.InverseTransformDirection(desiredMove);

                m_Transform.Translate(desiredMove, Space.Self);
            }

            if(useTouchInput && Input.touchCount == 1 && InBox == false)
            {
                // Vector3 desiredMove = new Vector3(-TouchAxis.x, -TouchAxis.y, 0);

                // desiredMove *= panningSpeed;
                // desiredMove *= Time.deltaTime;
                // desiredMove = Quaternion.Euler(new Vector3(0f, 0f, transform.eulerAngles.y)) * desiredMove;
                // desiredMove = m_Transform.InverseTransformDirection(desiredMove);

                // m_Transform.Translate(desiredMove, Space.Self);


                
                

                    if(Input.GetMouseButtonDown(0)){

                            // if(InBox == false)
                            // {
                            //     Vector3 temp = RTS_Camera.transform.position;
                            //     RTS_Camera.transform.position = lastpos;
                            //     lastpos = temp;
                            // }

                        
                            touchStart = GetWorldPostion(0);
                        
                    
                            


                        
                        

                        // if(targetFollow == null)
                        // {
                        //     touchStart = GetWorldPostion(0);
                        // }
                        // else
                        // {
                        //     Camera.main.transform.position = new Vector3(targetFollow.position.x, targetFollow.position.y , m_Transform.position.z);
                        // }
                        
                    }
                    if(Input.GetMouseButton(0)){
                        Vector3 direction = touchStart - GetWorldPostion(0);

                            
                            Camera.main.transform.position += direction;
                        
                    }
                
                
            }
        }

        /// <summary>
        /// calcualte height
        /// </summary>
        private void HeightCalculation()
        {
            float distanceToGround = DistanceToGround();
            if(Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float Difference = currentMagnitude - prevMagnitude;

                zoomPos -= Difference * 0.01f;



            //     zoomPos = Mathf.Clamp01(zoomPos);

            // float TargetHeight = Mathf.Lerp(minHeight, maxHeight, zoomPos);
            // float DistanceDifference = 0; 

            // if(distanceToGround != TargetHeight)
            //     DistanceDifference = TargetHeight - distanceToGround;


            //     if(DistanceDifference != 0)
            //     m_Transform.position = Vector3.Lerp(m_Transform.position, 
            //     new Vector3(m_Transform.position.x, m_Transform.position.y + Difference, m_Transform.position.z), Time.deltaTime * heightDampening);


                
            }
            else
            {
                if(useScrollwheelZooming)
                zoomPos += ScrollWheel * Time.deltaTime * scrollWheelZoomingSensitivity;
            if (useKeyboardZooming)
                zoomPos += ZoomDirection * Time.deltaTime * keyboardZoomingSensitivity;
            }
            

            zoomPos = Mathf.Clamp01(zoomPos);

            float targetHeight = Mathf.Lerp(minHeight, maxHeight, zoomPos);
            float difference = 0; 

            float ZoomYPosition = 0;

            if(distanceToGround != targetHeight)
                difference = targetHeight - distanceToGround;

                if(Testing.Mars == true)
                {
                    ZoomYPosition = m_Transform.position.y - (m_Transform.position.z - (targetHeight + difference));
                }
                else
                {
                    ZoomYPosition = m_Transform.position.y;
                }

            m_Transform.position = Vector3.Lerp(m_Transform.position, 
                new Vector3(m_Transform.position.x, ZoomYPosition, targetHeight + difference), Time.deltaTime * heightDampening);
        

        
        
        
        }

        /// <summary>
        /// rotate camera
        /// </summary>
        private void Rotation()
        {
            if(useKeyboardRotation)
                transform.Rotate(Vector3.up, RotationDirection * Time.deltaTime * rotationSped, Space.World);

            if (useMouseRotation && Input.GetKey(mouseRotationKey))
                m_Transform.Rotate(Vector3.up, -MouseAxis.x * Time.deltaTime * mouseRotationSpeed, Space.World);
        }

        /// <summary>
        /// follow targetif target != null
        /// </summary>
        private void FollowTarget()
        {
            // custom code

            // target in the middle of view

            if(Testing.Mars == true)
            {
                targetOffset.y = this.transform.position.z;
            }
            else
            {
                //touchStart = targetFollow.position;
                
                targetOffset.y = 0;
            }

            

            // custom code



            Vector3 targetPos = new Vector3(targetFollow.position.x, targetFollow.position.y , m_Transform.position.z) + targetOffset;
            m_Transform.position = Vector3.MoveTowards(m_Transform.position, targetPos, Time.deltaTime * followingSpeed);
        }

        /// <summary>
        /// limit camera position
        /// </summary>
        private void LimitPosition()
        {
            if (!limitMap)
                return;
                
            m_Transform.position = new Vector3(Mathf.Clamp(m_Transform.position.x, limitXMin, limitXMax),Mathf.Clamp(m_Transform.position.y, limitYMin, limitYMax),
                m_Transform.position.z);
        }

        /// <summary>
        /// set the target
        /// </summary>
        /// <param name="target"></param>
        public void SetTarget(Transform target)
        {
            targetFollow = target;
        }

        /// <summary>
        /// reset the target (target is set to null)
        /// </summary>
        public void ResetTarget()
        {
            targetFollow = null;
        }

        /// <summary>
        /// calculate distance to ground
        /// </summary>
        /// <returns></returns>
        private float DistanceToGround()
        {
            Ray ray = new Ray(m_Transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, groundMask.value))
                return (hit.point - m_Transform.position).magnitude;

            return 0f;
        }

        #endregion

        public Vector3 GetWorldPostion(float z){
        Ray mousePos = this.gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        //Ray mousePos = this.gameObject.GetComponent<Camera>().ScreenPointToRay(m_Transform.position);
        Plane ground = new Plane(Vector3.forward, new Vector3(0,0,z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
    }

    
}