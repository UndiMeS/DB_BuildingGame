﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/*Prefab der Objekte im ERD besitzten das Skript
 Bewegung des ER objektes*/
public class ERObjekt : MonoBehaviour
{
    private float width;
    private float height;
    private bool moveSelected = false;
    public bool selected = false;
    private RectTransform rectTransform;

    public bool schreibenSelected = false;

    public Sprite selectedSprite;
    public Sprite originalSprite;

    public GameObject leisteBottom;
    public GameObject leisteRechts;

    public Canvas canvas;

    public void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;

    }

   
    private void Update()
    {
        if (ERErstellung.selectedGameObjekt != null)
        {
            changeSprite(ERErstellung.selectedGameObjekt.Equals(gameObject));
        }
        
        if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition)&& ERErstellung.testAufGleicherPosition(Input.mousePosition).Equals(gameObject))
        //wenn Maus gedrückt, dann kann bewegen beim nächsten Aufruf von Update ausgeführt werden
        {
  
            if (inBox())
            {
                return;
            }
            if (!selected) //wenn neu selected, dann wird Objekt zu aktuellen ER-Objekt
            {
                //setzt Pivot des Objektes auf die Position der Maus
                
                Vector3[] v= new Vector3[4];
                rectTransform.GetWorldCorners(v);

                float pivotX =rectTransform.pivot.x* (Utilitys.GetMouseWorldPosition(Input.mousePosition).x-v[0].x)/(gameObject.transform.position.x-v[0].x);
                float pivotY = rectTransform.pivot.y * (Utilitys.GetMouseWorldPosition(Input.mousePosition).y - v[0].y) / (gameObject.transform.position.y - v[0].y);
                rectTransform.pivot = new Vector2(pivotX, pivotY);
                ERErstellung.changeSelectedGameobjekt(gameObject);
            }
            selected = true;
            moveSelected = true;
            KameraKontroller.aktiviert = false;
            schreibenSelected = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveSelected = false;
            selected = false;
            KameraKontroller.aktiviert = true;
            //setzt Pivot zurueck in die Mitte, wenn Maus losgelassen wird
            Vector3[] v = new Vector3[4];
            rectTransform.GetWorldCorners(v);

            float x = v[0].x+(gameObject.transform.position.x-v[0].x)/(2* rectTransform.pivot.x);
            float y = v[0].y + (gameObject.transform.position.y - v[0].y) / (2 * rectTransform.pivot.y);
            gameObject.transform.position = new Vector2(x, y);
            gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);


        }
        if (moveSelected)//bewegen des Objekts
        {
            Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
            cursorPos = imSichtfeld(cursorPos);
            transform.position = cursorPos;
        }

    }

    private bool inBox()
    {
        bool drin = RectTransformUtility.RectangleContainsScreenPoint(leisteBottom.GetComponent<RectTransform>(), Input.mousePosition, Camera.main);
        drin = drin || RectTransformUtility.RectangleContainsScreenPoint(leisteRechts.GetComponent<RectTransform>(), Input.mousePosition, Camera.main);
        /*Vector3[] v = new Vector3[4];
        leisteBottom.GetComponent<RectTransform>().GetLocalCorners(v);
        Debug.Log(Input.mousePosition+" y:" + v[0].x);
        bool drin = Input.mousePosition.y < v[2].y;
        leisteRechts.GetComponent<RectTransform>().GetLocalCorners(v);
        Debug.Log("x:"+v[0].x);
        Debug.Log(drin + " " + (Input.mousePosition.x > v[0].x));
        drin =drin || Input.mousePosition.x > v[0].x;*/

        return drin;
    }

    public void changeSprite(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<Image>().sprite = selectedSprite;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = originalSprite;
        }
    }

    public void ChangeSchreibenselected()
    {
        selected = false;
        schreibenSelected = true;
    }


    //Begrenzung der Bewegung des Objektes
    private Vector3 imSichtfeld(Vector3 cursorPos)
    {
        if (cursorPos.y > (425 * Screen.height / 530) - height / 2)
        {
            cursorPos.y = 425 * Screen.height / 530 - height / 2;
        }
        if (cursorPos.y < (60 * Screen.height / 530) + height / 2)
        {
            cursorPos.y = 60 * Screen.height / 530 + height / 2;
        }
        if (cursorPos.x < width / 2) { cursorPos.x = width / 2; }
        if (cursorPos.x > Screen.width - width / 2) { cursorPos.x = Screen.width - width / 2; }
        return cursorPos;
    }
    //Überprüft ob der Mausklick auf dem Objket ist
    private bool checkMausIn(Vector3 mousePosition)
    {
        /*Vector3[] v = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(v);
        
        gameObject.GetComponent<RectTransform>().GetLocalCorners(v);*/

        /*mousePosition = Utilitys.GetMouseWorldPosition(mousePosition);
        Vector3 position = gameObject.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < width / 2 && abstandY < height / 2;*/

        bool drin = RectTransformUtility.RectangleContainsScreenPoint(gameObject.GetComponent<RectTransform>(), Input.mousePosition, Camera.main);
        return drin;
    }

    public void nameAendern(string str)
    {
        gameObject.name = str;
    }


}

