using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErsteSchritte : MonoBehaviour
{
    public GameObject Willkommen;
    public GameObject MissionsButton;
    public GameObject ERButton;
    public GameObject Schritt1;
    public GameObject Schritt2;
    public GameObject Schritt3;
    public int clicked = 0;
    private bool firstTime = true;
    private bool firstSteps = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Story.level == 0){
            Willkommen.SetActive(true);
        }else{
            Willkommen.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstSteps)
        {
            Schritteanzeigen();
        }
    }

    public void popUpKreis(GameObject kreis)
    {
        if (firstTime)
        {
            LeanTween.scale(kreis,new Vector3(2 , 2),5).setEasePunch();
        }
        firstTime = false;

    }

    public void SetTrue()
    {
        clicked++;
        firstTime = true;
    }

    public void SetFirstStepsFalse()
    {
        firstSteps = false;
    }

    public void SetFirstStepsTrue()
    {
        firstSteps = true;
    }

    public void Schritteanzeigen()
    {
        if(clicked == 0){
            popUpKreis(MissionsButton);
            firstSteps = true;
        }
        else if(clicked == 1){
            Schritt2.SetActive(true);
            Schritt1.SetActive(false);
            firstTime = false;
        }else if(clicked == 2){
            Schritt2.SetActive(false);
            Schritt3.SetActive(true);
            popUpKreis(ERButton);
            firstTime = false;
        }
    }
}
