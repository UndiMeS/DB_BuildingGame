using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontroller : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;

    public float MarsMaxZoomZ;
    public float MarsMaxZoomY;

    public float MarsMinZoomZ;
    public float MarsMinZoomY;

    public float ERMaxZoomZ;
    public float ERMinZoomZ;

    public Vector3 newPosition = new Vector3(90, 120, 5);
    public Vector3 newZoom = new Vector3(0, -200, -200);
    public Vector3 zoomAmount;

    public Transform cameraTransform;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public static bool aktiviert = true;
    private bool prevaktiviert = true;

    public static int hintergrund;

    public GameObject mars;
    public GameObject erModell;

    public Vector3 oldPos;
    public Vector3 oldZoom;

    //private Vector3 testPos;

    public RectTransform aufgabentext;

    private bool mouseInAufgabe = false;

    //public Vector2 panLimit;

    //public Vector2 erXLimit;
    //public Vector2 erYLimit;

    //public Vector2 marsLimit;
    //public float scrollSpeed = 20f;

    //public float minY = -520f;
    //public float maxY = -50f;

    public bool[] grenzen = { false, false, false, false };//oben links unten rechts

    // Start is called before the first frame update
    void Awake()
    {
        aktiviert = true;
        hintergrund = 0;
        

        

     
    }

    // Update is called once per frame
    void Update()
    {            
        //Debug.Log(Utilitys.GetMouseWorldPosition(new Vector3(0, 50, 0)) + " " + Utilitys.GetMouseWorldPosition(new Vector3(Screen.width, Screen.height - 50, 0)));
        if (aktiviert)
        {
            Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = true;
            //testPos = newPosition;
            //HandleMouseInput();     //speichert Daten des Touch Inputs in newPosition und newZoom
            //HandleMovementInput();  //speichert Daten der Tastaur in newPosition und newZoom
            prevaktiviert = true;   // im Moment wo pausiert sollen Daten nicht weiter verarbeittet werden

            //Grenze();// Grenzen der Karte

            //float scroll = Input.GetAxis("Mouse ScrollWheel");
            //newZoom.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

         /*   if (hintergrund == 0)
            {
                //newPosition.x = Mathf.Clamp(newPosition.x, marsLimit.x, marsLimit.y);
                //newPosition.x = Mathf.Clamp(newPosition.x, Testing.weite * Testing.zellengroesse-110, panLimit.x);
                

                //newPosition.y = Mathf.Clamp(newPosition.y, Testing.hoehe * Testing.zellengroesse-40, panLimit.y);
            }
            else
            {
                
                //newZoom.y = Mathf.Clamp(newZoom.z, 0, 0);
            }*/




            //Verschiebung der KameraVerankerung und Kamera 
            //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
            //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
        }
        else
        {
            Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = false;
            Debug.Log("Bewegeung pausiert");
        }


        

    }

    // Wechsel zwischen Marslandschaft und ER-Diagramm
    // 0 Mars 1 ER-Dia
    public void changeHintergrund(int newHintergrund)
    {
        if (newHintergrund == hintergrund)
        {
            return;
        }
        else if (newHintergrund == 0)//Mars
        {
            hintergrund = 0;
            erModell.SetActive(false);
            mars.SetActive(true);
        }
        else
        { //ER-Dia
            hintergrund = 1;
            erModell.SetActive(true);
            mars.SetActive(false);
        }
    }

    //Touch Input
//     private void HandleMouseInput()
//     {
//         if (!inBox())
//         {
//             if (Input.mouseScrollDelta.y != 0)      //Mausrad
//             {
//                 newZoom += Input.mouseScrollDelta.y * zoomAmount * 10;
//             }
//             if (Input.GetMouseButtonDown(0))        //Beginn des Ziehens
//             {
//                 dragStartPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
//                 mouseInAufgabe = false;
//             }
//             if (Input.touchCount == 2&&!mouseInAufgabe)  //multitouch
//             {
//                 Touch touch1 = Input.GetTouch(0);
//                 Touch touch2 = Input.GetTouch(1);

//                 Vector2 prevTouchPos1 = touch1.position - touch1.deltaPosition;
//                 Vector2 prevTouchPos2 = touch2.position - touch2.deltaPosition;

//                 float prevMagnitude = (prevTouchPos1 - prevTouchPos2).magnitude;
//                 float cureentMagnitude = (touch1.position - touch2.position).magnitude;

//                 float differenz = cureentMagnitude - prevMagnitude;
//                 newZoom += differenz * zoomAmount * 0.1f;
//             }
//             else if (!aktiviert && prevaktiviert && Input.GetMouseButton(0))    // wenn vorher an und jetzt aus verarbeite Daten nicht mehr
//             {
//                 prevaktiviert = false;
//             }
//             else if (Input.GetMouseButton(0)&&!mouseInAufgabe) //aktuelle position des Ziehens
//             {
//                 dragCurrentPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
//                 newPosition = transform.position + dragStartPosition - dragCurrentPosition; //start-aktuelle Position des ziehens  (wie viel gezogen) addiert auf aktuelle position
//             }
//         }
//         else
//         {
//             mouseInAufgabe = true;
//         }
//     }


//     private bool inBox()
//     {
//         bool drin = false;
//         if (aufgabentext.gameObject.activeSelf&&hintergrund==1)
//         {
//             drin = drin || RectTransformUtility.RectangleContainsScreenPoint(aufgabentext, Input.mousePosition, null);
//         }
//         return drin;
//     }

//     void HandleMovementInput()
//     {
//         if (Input.GetKey(KeyCode.UpArrow))
//         {
//             newPosition += (transform.up * movementSpeed);
//         }
//         if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             newPosition += (transform.right * -movementSpeed);
//         }
//         if (Input.GetKey(KeyCode.DownArrow))
//         {
//             newPosition += (transform.up * -movementSpeed);
//         }
//         if (Input.GetKey(KeyCode.RightArrow))
//         {
//             newPosition += (transform.right * movementSpeed);
//         }
//         /*if (Input.GetKey(KeyCode.R))
//         {
//             newZoom += zoomAmount;
//         }
//         if (Input.GetKey(KeyCode.F))
//         {
//             newZoom -= zoomAmount;
//         }*/

//     }


//     public void ScreenshotZoom()
//     {
//         if(hintergrund == 0)
//         {
//             newZoom.y = -469.9f;
//             newZoom.z = -469.9f;
//         }
//         else
//         {
//             newZoom.z = -700.0f;
//         }

//         // yield return new WaitForSeconds(0.2f);
//         // ScreenCapture.CaptureScreenshot(Application.dataPath + "/Zertifikatsbilder/Spiel.png",2); //Größe mit Faktor 2 multipliziert, damit wir es im Zertifikat verkleinern können
//         // Debug.Log("Screenshot gemacht");
        
//         // //Wichtiger Bool, damit letzte Mission erfüllt werden kann
//         // Mission.screenshotSpiel = true;
        
//     }

//     private void Grenze()
//     {
//         /*int rechteGrenze;
//         int obereGrenze;
//         int linkeGrenze;
//         int untereGrenze;
//         int zoomMax;
//         int zoomMin;

//         movementSpeed = 1;
//         movementTime = 5;*/

//         if (hintergrund == 0) //baumenue
//         {
//             /*rechteGrenze = Testing.weite * Testing.zellengroesse + 10;
//             obereGrenze = Testing.hoehe * Testing.zellengroesse + 10;
//             linkeGrenze = -10;
//             untereGrenze = -40;

//             panLimit.x = rechteGrenze;
//             panLimit.y = obereGrenze;


//             zoomMax = -520;
//             zoomMin = -50;

//             minY = -520;
//             maxY = -50;*/

//             newZoom.y = Mathf.Clamp(newZoom.y, MarsMinZoomY,MarsMaxZoomY);
//             newZoom.z = Mathf.Clamp(newZoom.z, MarsMinZoomZ, MarsMaxZoomZ);

//             int x, y;
//             Testing.grid.GetXY(Utilitys.GetMouseWorldPosition(new Vector3(0, 0, 0)), out x, out y);
//             if (x < -1 && !grenzen[1])
//             {
//                 float delta = Testing.grid.GetWorldPosition(x,0).x - Testing.grid.GetWorldPosition(-1,0).x;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(delta, 0, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[1] = true;
//                 Invoke("links", 2);
//                 //Debug.Log("links");
//             }
//             else if (x < -1 && grenzen[1] && newPosition.x < transform.position.x)
//             {
//                 newPosition = transform.position;
//             }
//             if (y < -1 && !grenzen[2])
//             {
//                 float delta = Testing.grid.GetWorldPosition(0,y).y - Testing.grid.GetWorldPosition(0,-1).y;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(0,delta,0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[2] = true;
//                 Invoke("unten", 2);
//                 //Debug.Log("unten");
//             }
//             else if (y < -1 && grenzen[2] && newPosition.y< transform.position.y)
//             {
//                 newPosition = transform.position;
//             }
//             Testing.grid.GetXY(Utilitys.GetMouseWorldPosition(new Vector3(Screen.width, Screen.height, 0)), out x, out y);
//             if (x > Testing.weite && !grenzen[3])
//             {
//                 float delta = Testing.grid.GetWorldPosition(x, 0).x - Testing.grid.GetWorldPosition(Testing.weite, 0).x;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(delta, 0, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[3] = true;
//                 Invoke("rechts", 2);
//                 //Debug.Log("rechts");
//             }
//             else if (x > Testing.weite && grenzen[3] && newPosition.x > transform.position.x)
//             {
//                 newPosition = transform.position;
//             }
//             if (y > Testing.hoehe+1 && !grenzen[0])
//             {
//                 float delta = Testing.grid.GetWorldPosition(0, y).y - Testing.grid.GetWorldPosition(0, Testing.hoehe+1).y;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(0, delta, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[0] = true;
//                 Invoke("oben", 2);
//                 //Debug.Log("oben");
//             }
//             else if (y> Testing.hoehe + 1 && grenzen[0] && newPosition.y > transform.position.y)
//             {
//                 newPosition = transform.position;
//             }
//             if (grenzen[1] && grenzen[3])
//             {
//                 newZoom += 0.1f*zoomAmount;
//             }
//             if (grenzen[0] && grenzen[2])
//             {
//                 newZoom += 0.1f * zoomAmount;
//             }

//         }
//         else  //ER-Diagramm
//         {
//             /*rechteGrenze = 800;
//             obereGrenze = 400;
//             linkeGrenze = 10;
//             untereGrenze = 10;

//             // zoomMin = -20;
//             // zoomMax = -230;

//             minY = -230;
//             maxY = -20;
// */

            
//             newZoom.z = Mathf.Clamp(newZoom.z, ERMinZoomZ, ERMaxZoomZ);
//             int minX = -40;
//             int maxX =240;
//             int minY = 235;
//             int maxY = 380;
//             //Grenzen mit ... herausfinden
//             //auch in ER-Objekt sichtfeld eintragen
//             //Debug.Log(Utilitys.GetMouseWorldPosition(new Vector3(0, 50, 0)) + " " + Utilitys.GetMouseWorldPosition(new Vector3(Screen.width, Screen.height - 50, 0)));

//             Vector3 xyVektor=Utilitys.GetMouseWorldPosition(new Vector3(0, 50, 0));
//             //Debug.Log(newZoom.z + " " + cameraTransform.localPosition.z);
//             if (xyVektor.x < minX && !grenzen[1] )
//             {
//                 float delta = xyVektor.x - minX;
//                 newPosition=Vector3.Lerp(newPosition, newPosition - new Vector3(delta, 0, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[1] = true;
//                 Invoke("links",2);
//                 Debug.Log("links");
//             }
//             else if (xyVektor.x < minX && grenzen[1] && newPosition.x < transform.position.x)
//             {
//                 newPosition = transform.position;
//             }
//             if (xyVektor.y < minY && !grenzen[2])
//             {
//                 float delta = xyVektor.y - minY;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(0,delta,  0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[2] = true;
//                 Invoke("unten", 2);
//                 Debug.Log("unten");
//             }
//             else if (xyVektor.y < minY && grenzen[2] && newPosition.y < transform.position.y)
//             {
//                 newPosition = transform.position;
//             }
//             xyVektor = Utilitys.GetMouseWorldPosition(new Vector3(Screen.width, Screen.height-50, 0));
//             if (xyVektor.x > maxX && !grenzen[3])
//             {
//                 float delta = xyVektor.x - maxX;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(delta, 0, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[3] = true;
//                 Invoke("rechts", 2);
//                 Debug.Log("rechts");
//             }
//             else if (xyVektor.x > maxX && grenzen[3] && newPosition.x > transform.position.x)
//             {
//                 newPosition = transform.position;
//             }
//             if (xyVektor.y > maxY && !grenzen[0])
//             {
//                 float delta = xyVektor.y - maxY;
//                 newPosition = Vector3.Lerp(newPosition, newPosition - new Vector3(0, delta, 0), 2);
//                 //newPosition.x = transform.position.x + 5 * movementSpeed;
//                 grenzen[0] = true;
//                 Invoke("oben", 2);
//                 Debug.Log("oben");
//             }
//             else if (xyVektor.y > maxY && grenzen[0] && newPosition.y > transform.position.y)
//             {
//                 newPosition = transform.position;
//             }
//             if (grenzen[1] && grenzen[3])
//             {
//                 newZoom += 0.25f*zoomAmount;
//             }
//             if (grenzen[0] && grenzen[2])
//             {
//                 newZoom += 0.25f * zoomAmount;
//             }


//             /*//zum Werte heraufinden
//             if (cameraTransform.position.z < -449)
//             {
//                 Debug.Log(Utilitys.GetMouseWorldPosition(new Vector3(0, 0, 0)));
//                 Debug.Log(Utilitys.GetMouseWorldPosition(new Vector3(Screen.width,Screen.height, 0)));
//             }*/
//         }


        
//     }

//     private void links()
//     {
//         grenzen[1] = false;
//     }
//     private void rechts()
//     {
//         grenzen[3] = false;
//     }
//     private void oben()
//     {
//         grenzen[0] = false;
//     }
//     private void unten()
//     {
//         grenzen[2] = false;
//     }

}
