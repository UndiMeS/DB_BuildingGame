using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    public GameObject leisteBottom;
    public GameObject checkliste;
    public GameObject aufgabe;
    public GameObject leisteRechts;

    public static bool HitUI;


    

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


        if (inBox() ||moveselected())
        {

            Camera.main.GetComponent<RTS_Cam.RTS_Camera>().InBox = true;

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

            Camera.main.GetComponent<RTS_Cam.RTS_Camera>().touchStart = Camera.main.GetComponent<RTS_Cam.RTS_Camera>().GetWorldPostion(0);

            //Camera.main.GetComponent<RTS_Cam.RTS_Camera>().enabled = true;
            Camera.main.GetComponent<RTS_Cam.RTS_Camera>().InBox = false;

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
        //return false;
    }

    // private bool IsMouseOverUI(){
    //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //      if(Physics.Raycast(ray, out hit))
    //      {
    //          if(hit.collider != null)
    //          {
    //             if(hit.transform.tag ==  "StopMovement")
    //             {
    //                 return true;
    //             }
    //             else
    //             {
    //                 return false;
    //             }
                
    //          }
    //          else
    //          return false;
    //      }
    //      else
    //      return false;
    // }
}
