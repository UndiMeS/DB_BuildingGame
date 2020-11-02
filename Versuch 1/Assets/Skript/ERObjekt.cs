using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ERObjekt : MonoBehaviour
{
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
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
    }
}
