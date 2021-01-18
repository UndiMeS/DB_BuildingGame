using System;
using UnityEngine;


/*Prefab der Objekte im ERD besitzten das Skript
 Bewegung des ER objektes*/
public class ERObjekt : MonoBehaviour
{
    private float width;
    private float height;
    private bool moveSelected = false;
    public bool selected = true;
    public String nameVonObjekt;
    private RectTransform rectTransform;

    public void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;
    }

    private void Update()
    {
        Utilitys.TextInTMP(gameObject.transform.GetChild(0).gameObject, nameVonObjekt); //Setzt Objektnamen mit angezeigten Namen des Objektes
        gameObject.name = nameVonObjekt;
        
        if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition)&&ERErstellung.testAufGleicherPosition(Input.mousePosition).Equals(gameObject))//wenn Maus gedrückt, dann kann bewegen beim nächsten Aufruf von Update ausgeführt werden
        {
            if (!selected) //wenn neu selected, dann wird Objekt zu aktuellen ER-Objekt
            {
                
                ERErstellung.changeSelectedGameobjekt(gameObject);

                //setzt Pivot des Objektes auf die Position der Maus
                float pivotX = (Input.mousePosition.x - gameObject.transform.position.x) * (1 / width) + rectTransform.pivot.x;
                float pivotY = (Input.mousePosition.y - gameObject.transform.position.y) * (1 /height) + rectTransform.pivot.y;
                rectTransform.pivot = new Vector2(pivotX, pivotY);
            }
            selected = true;
            moveSelected = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveSelected = false;

            //setzt Pivot zurueck in die Mitte, wenn Maus losgelassen wird
            float x = (0.5f - rectTransform.pivot.x) * width + gameObject.transform.position.x;
            float y = (0.5f - rectTransform.pivot.y) * height + gameObject.transform.position.y;
            gameObject.transform.position = new Vector2(x, y);
            gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        }
        if (moveSelected)//bewegen des Objekts
        {
            Vector3 cursorPos = Input.mousePosition;
            cursorPos = imSichtfeld(cursorPos);
            transform.position = cursorPos;
        }

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
        Vector3 position = gameObject.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < width / 2 && abstandY < height / 2;
        return drin;
    }


}

