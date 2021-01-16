using System;
using UnityEngine;


/*Prefab der Objekte im ERD besitzten das Skript
 Bewegung des ER objektes*/
public class ERObjekt : MonoBehaviour
{
    private int width = 200;
    private int height = 50;
    private bool moveSelected = false;
    public bool selected = true;
    public String nameVonObjekt;
    private RectTransform rectTransform;

    public TMPro.TMP_Text eingabe;

    public void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        Utilitys.TextInTMP(gameObject.transform.GetChild(0).gameObject, nameVonObjekt); //Setzt Objektnamen mit angezeigten Namen des Objektes
        gameObject.name = nameVonObjekt;
        bewegen();

        if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition))//wenn Maus gedrückt, dann kann bewegen beim nächsten Aufruf von Update ausgeführt werden
        {
            if (!selected) //wenn neu selected, dann wird Objekt zu aktuellen ER-Objekt
            {
                ERErstellung.changeSelectedGameobjekt(gameObject);
            }
            selected = true;

        }

    }

    private void bewegen()
    {
        if (selected && ERErstellung.selectedGameObjekt.Equals(gameObject))
        {
            if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition) && !moveSelected)
            {
                moveSelected = true;

                //setzt Pivot des Objektes auf die Position der Maus
                float pivotX = (Input.mousePosition.x - gameObject.transform.position.x) * (1 / rectTransform.sizeDelta.x) + rectTransform.pivot.x;
                float pivotY = (Input.mousePosition.y - gameObject.transform.position.y) * (1 / rectTransform.sizeDelta.y) + rectTransform.pivot.y;
                rectTransform.pivot = new Vector2(pivotX, pivotY);

            }
            if (Input.GetMouseButtonUp(0))
            {
                //setzt Pivot zurueck in die Mitte, wenn Maus losgelassen wird
                float x = (0.5f - rectTransform.pivot.x) * rectTransform.sizeDelta.x + gameObject.transform.position.x;
                float y = (0.5f - rectTransform.pivot.y) * rectTransform.sizeDelta.y + gameObject.transform.position.y;
                gameObject.transform.position = new Vector2(x, y);
                gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

                moveSelected = false;
            }
            if (moveSelected)//bewegen des Objekts
            {
                Vector3 cursorPos = Input.mousePosition;
                cursorPos = imSichtfeld(cursorPos);
                transform.position = cursorPos;
            }
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

