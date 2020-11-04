using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ERObjekt : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool selected = false;

    private void Update()
    {
        if (selected)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    private void OnMouseUp()
    {
        selected = false;
    }

}

/*private bool selected;

// Start is called before the first frame update
void Start()
{


}
// Update is called once per frame
void Update()
{
    Debug.Log("Start!");
    if (selected == true)
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, 0);

    }
}

void OnMouseOver()
{
    Debug.Log("Test!");
    if (Input.GetMouseButtonDown(0))
    {
        selected = true;

    }

    if (Input.GetMouseButtonUp(0))
    {
        selected = false;
    }
}*/
