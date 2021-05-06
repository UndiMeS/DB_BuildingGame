using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public static int level=0;
    public static bool[] lvl = new bool[] {false,false,false,false,false,false,false,false};
    public GameObject level0;
    public GameObject level1;

    //Level 0 Objekte
    public GameObject transparentWohncontainer;

    //Level 1 Objecte
    public GameObject buttonForscher;// = GetComponent<Button>();
    public GameObject buttonFeld;
    public GameObject buttonWeide;
    public GameObject buttonAlleAstronauten;
    public GameObject buttonWohnendeAstronauten;

    /*
        public GameObject o;
        o = GetComponent<Button>();
        o.interactable = false;
    */

    void Start()
    {
        transparentWohncontainer.SetActive(true);
    }
    void Update()
    {
        if (lvl[0])
        {
            Debug.Log("Level 0 korrekt");
            level0.SetActive(false);    
        }
        if(lvl[1])
        {
            Debug.Log("Level 1 korrekt");
            level1.SetActive(false);
        }
        if(lvl[2])
        {
            Debug.Log("Level 2 korrekt");
        }
        if(lvl[3])
        {
            Debug.Log("Level 3 korrekt");
        }
        if(lvl[4])
        {
            Debug.Log("Level 4 korrekt");
        }
        if(lvl[5])
        {
            Debug.Log("Level 5 korrekt");
        }
        if(lvl[6])
        {
            Debug.Log("Level 6 korrekt");
        }
        if(lvl[7])
        {
            Debug.Log("Level 7 korrekt");
        }
    }

}
