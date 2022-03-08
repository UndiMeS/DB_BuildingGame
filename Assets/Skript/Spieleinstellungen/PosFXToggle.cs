using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PosFXToggle : MonoBehaviour
{

    public GameObject Landschaft;
    public PostProcessVolume PostFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Landschaft.activeSelf == true)
        {
            PostFX.enabled = true;
        }
        if(Landschaft.activeSelf == false)
        {
            PostFX.enabled = false;
        }
        
    }
}
