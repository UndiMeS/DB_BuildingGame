using System;
using UnityEngine;



public class ERObjekt : MonoBehaviour
{
    private int width = 200;
    private int height = 50;
    private bool moveSelected = false;
    public bool selected = true;
    public String nameVonObjekt;


    public void Start()
    {
    }

    private void Update()
    {
        Utilitys.TextInTMP(gameObject.transform.GetChild(0).gameObject, nameVonObjekt);
        gameObject.name = nameVonObjekt;
        bewegen();

        if(Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition))
        {
            if (!selected)
            {
                ERErstellung.changeSelectedGameobjekt(gameObject);
            }
            selected = true;
        }

    }

    private void bewegen()
    {
        if (selected&&ERErstellung.selectedGameObjekt.Equals(gameObject))
        {
            if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition)&&!moveSelected)
            {
                moveSelected = true;

                RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
                float pivotX = (Input.mousePosition.x - gameObject.transform.position.x) * (1 / rectTransform.sizeDelta.x) + rectTransform.pivot.x;
                float pivotY = (Input.mousePosition.y - gameObject.transform.position.y) * (1 / rectTransform.sizeDelta.y) + rectTransform.pivot.y;

                rectTransform.pivot = new Vector2(pivotX, pivotY);
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                moveSelected = false;
                gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
            }
            if (moveSelected)
            {
                Vector3 cursorPos = Input.mousePosition;
                cursorPos = imSichtfeld(cursorPos);
                transform.position = cursorPos;
            }
        }
    }

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

    private bool checkMausIn(Vector3 mousePosition)
    {
        Vector3 position = gameObject.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < width / 2 && abstandY < height / 2;
        return drin;
    }


}

