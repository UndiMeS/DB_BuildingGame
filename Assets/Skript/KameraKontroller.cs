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

    public static int hintergrund;

    public GameObject mars;
    public GameObject erModell;

    public Vector3 oldPos;
    public Vector3 oldZoom;

    private Vector3 testPos;

    public RectTransform aufgabentext;

    public Vector2 panLimit;

    public float scrollSpeed = 20f;

    public float minY = -520f;
    public float maxY = -50f;

    // Start is called before the first frame update
    void Awake()
    {
        aktiviert = true;
        hintergrund = 0;
        transform.position = newPosition;
        newZoom = cameraTransform.localPosition;

        oldPos = new Vector3(370, 200, 0); //für ER-Modell; Mars: (60,-10,5);
        oldZoom = new Vector3(0, 50, -40); // für ER-Modell; Mars: (0,-40,-140);
    }

    // Update is called once per frame
    void Update()
    {
        if (aktiviert)
        {
            testPos = newPosition;
            HandleMouseInput();     //speichert Daten des Touch Inputs in newPosition und newZoom
            //HandleMovementInput();  //speichert Daten der Tastaur in newPosition und newZoom
            prevaktiviert = true;   // im Moment wo pausiert sollen Daten nicht weiter verarbeittet werden

            Grenze();// Grenzen der Karte

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            newZoom.y -= scroll * scrollSpeed * 100f * Time.deltaTime;


            newPosition.x = Mathf.Clamp(newPosition.x, - panLimit.x, panLimit.x);
            newZoom.z = Mathf.Clamp(newZoom.z, minY, maxY);
            newZoom.y = Mathf.Clamp(newZoom.z, minY, maxY);
            newPosition.y = Mathf.Clamp(newPosition.y, -panLimit.y, panLimit.y);

            //Verschiebung der KameraVerankerung und Kamera 
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
        }
        else
        {
            //Debug.Log("Bewegeung pausiert");
        }
   

    }

    // Wechsel zwischen Marslandschaft und ER-Diagramm
    // 0 Mars 1 ER-Dia
    public void changeHintergrund(int newHintergrund)
    {
        Vector3 tempPos;
        Vector3 tempZoom;
        if (newHintergrund == hintergrund)
        {
            return;
        }else if (newHintergrund == 0)//Mars
        {
            hintergrund = 0;
            erModell.SetActive(false);
            mars.SetActive(true);
            cameraTransform.rotation = Quaternion.Euler(-45, 0, 0);//Kamerawinkel
            zoomAmount = new Vector3(0, 1, 1);

            tempPos = transform.position;               //Zwischenspeichern der Zoom und Pos Daten
            tempZoom = cameraTransform.localPosition;

            aktiviert = true;
        }
        else{ //ER-Dia
            hintergrund =1;
            erModell.SetActive(true);
            mars.SetActive(false);
            cameraTransform.rotation = Quaternion.Euler(0, 0, 0);
            zoomAmount = new Vector3(0, 0, 1);

            tempPos = transform.position;
            tempZoom = cameraTransform.localPosition;

            aktiviert = true;
        }

        dragCurrentPosition = Vector3.zero; //0, da sonst allten Koordinaten von anderen Hintergrund
        dragStartPosition = Vector3.zero;

        // newPosition = oldPos;
        // transform.position = newPosition;   //KameraVerankerung auf alte Position setzen
        // newZoom = oldZoom;
        // cameraTransform.localPosition= newZoom; //Kamera auf alte Position setzen

        oldPos = tempPos;       //Daten von vorherigen Hintergrund
        oldZoom = tempZoom;
    }

    //Touch Input
    private void HandleMouseInput()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(aufgabentext, Input.mousePosition, Camera.main))
        {


            if (Input.mouseScrollDelta.y != 0)      //Mausrad
            {
                newZoom += Input.mouseScrollDelta.y * zoomAmount * 10;
            }
            if (Input.GetMouseButtonDown(0))        //Beginn des Ziehens
            {
                dragStartPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
            }
            if (Input.touchCount == 2)  //multitouch
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                Vector2 prevTouchPos1 = touch1.position - touch1.deltaPosition;
                Vector2 prevTouchPos2 = touch2.position - touch2.deltaPosition;

                float prevMagnitude = (prevTouchPos1 - prevTouchPos2).magnitude;
                float cureentMagnitude = (touch1.position - touch2.position).magnitude;

                float differenz = cureentMagnitude - prevMagnitude;
                newZoom += differenz * zoomAmount * 0.1f;
            }
            else if (!aktiviert && prevaktiviert && Input.GetMouseButton(0))    // wenn vorher an und jetzt aus verarbeite Daten nicht mehr
            {
                prevaktiviert = false;
            }
            else if (Input.GetMouseButton(0)) //aktuelle position des Ziehens
            {
                dragCurrentPosition = Utilitys.GetMouseWorldPosition(Input.mousePosition);
                newPosition = transform.position + dragStartPosition - dragCurrentPosition; //start-aktuelle Position des ziehens  (wie viel gezogen) addiert auf aktuelle position
            }
        }
    }


    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.up * movementSpeed);
        }
        if ( Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if ( Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.up * -movementSpeed);
        }
        if ( Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        /*if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }*/
        
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

            minY = -520;
            maxY = -50;
        }
        else  //ER-Diagramm
        {
            rechteGrenze = 800;
            obereGrenze = 400;
            linkeGrenze = 10;
            untereGrenze = 10;
            zoomMin = -20;
            zoomMax = -230;

            minY = -20;
            maxY = -230;

        }
        // if (Utilitys.GetMouseWorldPosition(new Vector2(0,0)).x < linkeGrenze)
        // {
        //     Debug.Log("linkeGrenze");
        //     movementTime = 50;
        //     newPosition.x = transform.position.x+0.2f;
        // }
        // if (Utilitys.GetMouseWorldPosition(new Vector2(Screen.width,Screen.height)).x > rechteGrenze)
        // {
        //     Debug.Log("rechte Grenze");
        //     movementTime = 50;
        //     newPosition.x = transform.position.x-0.2f;
        // }
        // if (Utilitys.GetMouseWorldPosition(new Vector2(0, 0)).y < untereGrenze)
        // {
        //     Debug.Log("untere Grenze");
        //     movementTime = 50;
        //     newPosition.y = transform.position.y+0.2f;
        // }
        // if (Utilitys.GetMouseWorldPosition(new Vector2(Screen.width, Screen.height)).y > obereGrenze)
        // {
        //     Debug.Log("oberer Grenze");
        //     movementTime = 50;
        //     newPosition.y = transform.position.y-0.2f;
        // }
        // if (zoomMax > newZoom.z || zoomMin < newZoom.z)
        // {
        //     Debug.Log("zoom");
        //     movementTime = 50;
        //     newZoom = cameraTransform.localPosition;
        // }
    }

}
