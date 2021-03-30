using System;
using UnityEngine;
using UnityEngine.UI;


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

    public void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;

    }

    private void Update()
    {       
        changeSprite(selected);
        
        if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition))
        // && ERErstellung.testAufGleicherPosition(Utilitys.GetMouseWorldPosition(Input.mousePosition)).Equals(gameObject)
        //wenn Maus gedrückt, dann kann bewegen beim nächsten Aufruf von Update ausgeführt werden
        {
  
            if (inBox())
            {
                return;
            }
            if (!selected) //wenn neu selected, dann wird Objekt zu aktuellen ER-Objekt
            {
                //setzt Pivot des Objektes auf die Position der Maus
                float pivotX = (Utilitys.GetMouseWorldPosition(Input.mousePosition).x - gameObject.transform.position.x) * (1 / width) + rectTransform.pivot.x;
                float pivotY = (Utilitys.GetMouseWorldPosition(Input.mousePosition).y - gameObject.transform.position.y) * (1 / height) + rectTransform.pivot.y;
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
            float x = (0.5f - rectTransform.pivot.x) * width + gameObject.transform.position.x;
            float y = (0.5f - rectTransform.pivot.y) * height + gameObject.transform.position.y;
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
        
        Vector3[] v = new Vector3[4];
        LeisteBottom.leiste_bottom.GetComponent<RectTransform>().GetWorldCorners(v);
        return Input.mousePosition.y< v[2].y;
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
        mousePosition = Utilitys.GetMouseWorldPosition(mousePosition);
        gameObject.GetComponent<RectTransform>().GetLocalCorners(v);*/


        Vector3 position = gameObject.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < width / 2 && abstandY < height / 2;
        return drin;
    }

    public void nameAendern(string str)
    {
        gameObject.name = str;
    }


}

