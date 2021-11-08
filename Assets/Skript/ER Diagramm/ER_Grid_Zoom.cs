using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_Grid_Zoom : MonoBehaviour
{
    Vector3 lastPos;
    public Camera RTS_Camera;
    Transform obj;
    public float CameraZoom;
    public float offset;
    public float lastZoom;

    float threshold = 0.0f;
    public UIGridRenderer UI_Grid;
    public UIGridRenderer UI_Grid_Big;

    public Color BigGridColor;
    public Color GridColor;
    // Start is called before the first frame update
    void Start()
    {
        //obj = RTS_Camera.gameObject.transform;
        
        lastZoom = CameraZoom;
        //lastPos = obj.position;
        GridColor = UI_Grid.color;
        BigGridColor = UI_Grid_Big.color;
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom = RTS_Camera.gameObject.transform.position.z;
        // offset = CameraZoom - lastZoom;
        // if (offset <= -20f && GridColor.a >= 0 && BigGridColor.a <= 80){
        //     GridColor.a = GridColor.a - 0.20f;
        //     BigGridColor.a = BigGridColor.a + 0.20f;
        //     lastZoom = CameraZoom; // update lastPos
        //     Debug.Log("moving up");
        //     // code to execute when X is getting bigger
        //     UI_Grid_Big.color = BigGridColor;
        //     UI_Grid.color = GridColor;
        // }
        // else
        // if (offset >= +20f && GridColor.a <= 80 && BigGridColor.a >= 0){
        //     GridColor.a = GridColor.a + 0.20f;
        //     BigGridColor.a = BigGridColor.a - 0.20f;
        //     lastZoom = CameraZoom; // update lastPos
        //     Debug.Log("moving down");
        //     // code to execute when X is getting smaller
        //     UI_Grid_Big.color = BigGridColor;
        //     UI_Grid.color = GridColor;
        // }

        if (CameraZoom > -25.0f){
            GridColor.a = 0.20f;
            BigGridColor.a = 0.0f;
            //lastZoom = CameraZoom; // update lastPos
            //Debug.Log("moving up");
            // code to execute when X is getting bigger
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        else
        if (CameraZoom >= -40.0f && CameraZoom <= -25.0f){
            GridColor.a = 0.15f;
            BigGridColor.a = 0.05f;
            //Debug.Log("moving down");
            // code to execute when X is getting smaller
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        else
        if (CameraZoom >= -60.0f && CameraZoom <= -41.0f){
            GridColor.a = 0.10f;
            BigGridColor.a = 0.10f;
            //Debug.Log("moving down");
            // code to execute when X is getting smaller
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        else
        if (CameraZoom >= -80.0f && CameraZoom <= -61.0f){
            GridColor.a = 0.05f;
            BigGridColor.a = 0.15f;
            //Debug.Log("moving down");
            // code to execute when X is getting smaller
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        else
        if (CameraZoom >= -100.0f && CameraZoom <= -81.0f){
            GridColor.a = 0.0f;
            BigGridColor.a = 0.20f;
            //Debug.Log("moving down");
            // code to execute when X is getting smaller
            UI_Grid_Big.color = BigGridColor;
            UI_Grid.color = GridColor;
        }
        
    }
}
