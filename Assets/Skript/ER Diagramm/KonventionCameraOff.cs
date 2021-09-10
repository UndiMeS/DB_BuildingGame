using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonventionCameraOff : MonoBehaviour
{

    public RTS_Cam.RTS_Camera RTS_Camera;
    // Start is called before the first frame update
    void Start()
    {
        RTS_Camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
