using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortschritt : MonoBehaviour
{
    public GameObject fortschrittsanzeige;
    public GameObject transparent_0;
    public GameObject transparent_1;
    public GameObject transparent_2;
    public GameObject transparent_3;
    public GameObject transparent_4;
    public GameObject transparent_5;
    public GameObject transparent_6;
    public GameObject transparent_7;   

    public GameObject hacken_0;
    public GameObject hacken_1;
    public GameObject hacken_2;
    public GameObject hacken_3;
    public GameObject hacken_4;
    public GameObject hacken_5;
    public GameObject hacken_6;
    public GameObject hacken_7;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Story.level == 0)
        {
            transparent_0.SetActive(false);
        }else if(Story.level == 1)
        {
            hacken_0.SetActive(true);
            transparent_1.SetActive(false);
        }else if(Story.level == 2)
        {
            hacken_1.SetActive(true);
            transparent_2.SetActive(false);
        }else if(Story.level == 3)
        {   
            hacken_2.SetActive(true);
            transparent_3.SetActive(false);
        }else if(Story.level == 4)
        {
            hacken_3.SetActive(true);
            transparent_4.SetActive(false);
        }else if(Story.level == 5)
        {   
            hacken_4.SetActive(true);
            transparent_5.SetActive(false);
        }else if(Story.level == 6)
        {   
            hacken_5.SetActive(true);
            transparent_6.SetActive(false);
        }else if(Story.level == 7)
        {
            hacken_6.SetActive(true);
            transparent_7.SetActive(false);
        }else
        {
            hacken_7.SetActive(true);
        }
    }
}
