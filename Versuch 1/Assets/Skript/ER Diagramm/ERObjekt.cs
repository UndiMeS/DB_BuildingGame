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
        markiert();

        if(Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition))
        {
            selected = true;
            ERErstellung.changeSelectedGameobjekt(gameObject);
        }

    }

    private void markiert()
    {
        if (selected)
        {
            
        }
    }

    private void bewegen()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0) && checkMausIn(Input.mousePosition))
            {
                moveSelected = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                moveSelected = false;
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

