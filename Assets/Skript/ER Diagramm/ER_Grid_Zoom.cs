using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_Grid_Zoom : MonoBehaviour
{
    Vector3 lastPos;
    public Camera RTS_Camera;
    Transform obj;

    float threshold = 0.0f;
    public UIGridRenderer UI_Grid;
    public UIGridRenderer UI_Grid_Big;

    public Color BigGridColor;
    public Color GridColor;
    // Start is called before the first frame update
    void Start()
    {
        obj = RTS_Camera.gameObject.transform;
        lastPos = obj.position;
        GridColor = UI_Grid.color;
        BigGridColor = UI_Grid_Big.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = obj.position - lastPos;
        if (offset.z < threshold && offset.z < -10f && GridColor.a >= 0 && BigGridColor.a <= 70){
            GridColor.a = GridColor.a - 0.15f;
            BigGridColor.a = BigGridColor.a + 0.15f;
            lastPos = obj.position; // update lastPos
            Debug.Log("moving up");
            // code to execute when X is getting bigger
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        else
        if (offset.z > threshold && offset.z > +10f && GridColor.a <= 70 && BigGridColor.a >= 0){
            GridColor.a = GridColor.a + 0.15f;
            BigGridColor.a = BigGridColor.a - 0.15f;
            lastPos = obj.position; // update lastPos
            Debug.Log("moving down");
            // code to execute when X is getting smaller
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }

        // if(lastPos.z ==  - 100.0f)
        // {
        //     GridColor.a = 0.0f;
        //     BigGridColor.a = 70.0f;
        // }
        // else if(lastPos.z == -20.0f)
        // {
        //     GridColor.a = 70.0f;
        //     BigGridColor.a = 0.0f;
        // }
        
    }
}
