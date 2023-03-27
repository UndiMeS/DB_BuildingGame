using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    public GameObject leisteBottom;
    public GameObject checkliste;
    public GameObject aufgabe;
    public GameObject leisteRechts;

    // Update is called once per frame
    void Update()
    {

        //
        // if (inBox()||moveselected())
        // {
        //     Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = false;
        //     Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useScrollwheelZooming = false;
        // }
        // else
        // {
        //     Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = true;
        //     Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useScrollwheelZooming = true;
        // }


        if (inBox()||moveselected())
        {
            //Camera.main.GetComponent<RTS_Cam.RTS_Camera>().enabled = false;
            if(PlatformManager.touch == true)
            {
                Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useTouchInput = false;

                
            }
            else
            {
                Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = false;
            }
        }
        else
        {
            //Camera.main.GetComponent<RTS_Cam.RTS_Camera>().enabled = true;

            if(PlatformManager.touch == true)
            {
                Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useTouchInput = true;
            }
            else
            {
                Camera.main.GetComponent<RTS_Cam.RTS_Camera>().usePanning = true;
            }
        }
    }

    private bool moveselected()
    {
        foreach(GameObject game in ERErstellung.modellObjekte)
        {
            if (game.GetComponent<ERObjekt>().moveSelected)
            {
                return true;
            }
        }
        return false;
    }

    private bool inBox()
    {
        bool drin = RectTransformUtility.RectangleContainsScreenPoint(leisteBottom.GetComponent<RectTransform>(), Input.mousePosition, null);
        if (checkliste.transform.parent.gameObject.activeSelf)
        {
            drin = drin || RectTransformUtility.RectangleContainsScreenPoint(checkliste.GetComponent<RectTransform>(), Input.mousePosition, null);
            drin = drin || RectTransformUtility.RectangleContainsScreenPoint(aufgabe.GetComponent<RectTransform>(), Input.mousePosition, null);
        }
        drin = drin || RectTransformUtility.RectangleContainsScreenPoint(leisteRechts.GetComponent<RectTransform>(), Input.mousePosition, null);
        return drin;
    }
}
