using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontroller : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;

    public Vector3 newPosition;
    public Vector3 newZoom;
    public Vector3 zoomAmount;

    public Transform cameraTransform;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public static bool aktiviert=true;
    private bool prevaktiviert = true;

    public int hintergrund;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = newPosition;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (aktiviert)
        {
            HandleMouseInput();
            HandleMovementInput();
            prevaktiviert = true;
        }
        

    }

    private void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount*10;
        }
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
        }
        if (Input.touchCount == 2)  //multitouch--> testen!!!
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 prevTouchPos1 = touch1.position - touch1.deltaPosition;
            Vector2 prevTouchPos2 = touch2.position - touch2.deltaPosition;

            float prevMagnitude = (prevTouchPos1 - prevTouchPos2).magnitude;
            float cureentMagnitude = (touch1.position - touch2.position).magnitude;

            float differenz = cureentMagnitude - prevMagnitude;
            newZoom += differenz *zoomAmount* 0.1f;
        }
        else if (!aktiviert && prevaktiviert&& Input.GetMouseButton(0))
        {
            prevaktiviert = false;
        }
        else if (Input.GetMouseButton(0))
        {
            dragCurrentPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
            newPosition = transform.position + dragStartPosition - dragCurrentPosition;
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.up * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.up * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }
        Grenze();
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }

    private void Grenze()
    {
        int rechteGrenze;
        int obereGrenze;
        int linkeGrenze;
        int untereGrenze;
        int zoomMax;
        int zoomMin;

        movementSpeed=1;
        movementTime = 5;

        if (hintergrund == 0) //baumenue
        {
            rechteGrenze = Testing.weite * Testing.zellengroesse+10;
            obereGrenze = Testing.hoehe * Testing.zellengroesse+10;
            linkeGrenze = -10;
            untereGrenze = -40;

            zoomMax = -520;
            zoomMin = -50;
        }
        else  //ER-Diagramm
        {
            rechteGrenze = Screen.width-10;
            obereGrenze = Screen.height-10;
            linkeGrenze = 10;
            untereGrenze = 10;
            zoomMin = -20;
            zoomMax = -999;

        }
        if (Utilitys.GetMouseWorldPosition(new Vector2(0,0)).x < linkeGrenze)
        {
            
            movementTime = 50;
            newPosition.x = transform.position.x+0.2f;
        }
        if (Utilitys.GetMouseWorldPosition(new Vector2(Screen.width,Screen.height)).x > rechteGrenze)
        {
            
            movementTime = 50;
            newPosition.x = transform.position.x-0.2f;
        }
        if (Utilitys.GetMouseWorldPosition(new Vector2(0, 0)).y < untereGrenze)
        {
            
            movementTime = 50;
            newPosition.y = transform.position.y+0.2f;
        }
        if (Utilitys.GetMouseWorldPosition(new Vector2(Screen.width, Screen.height)).y > obereGrenze)
        {
            
            movementTime = 50;
            newPosition.y = transform.position.y-0.2f;
        }
        if (zoomMax > newZoom.z || zoomMin < newZoom.z)
        {
            movementTime = 50;
            newZoom = cameraTransform.localPosition;
        }
    }

}
