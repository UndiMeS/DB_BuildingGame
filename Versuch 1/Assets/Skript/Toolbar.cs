using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Toolbar : MonoBehaviour
{
    //Prefabs
    public GameObject haus1;
    public GameObject haus2;
    public GameObject haus3;
    public GameObject weide1;
    public GameObject weide2;
    public GameObject weide3;
    public GameObject feld1;
    public GameObject feld2;
    public GameObject feld3;

    //für Grid
    public static int objektGebaut;
   

    public void KleinesHausBauen()
    {
        
        objektGebaut = 10;
        Instantiate(haus1);
        }
    public void MittleresHausBauen()
    {
        
        objektGebaut = 11;
        Instantiate(haus2);
    }
    public void GroßesHausBauen()
    {
       
        objektGebaut = 12;
        Instantiate(haus3);
    }

    public void KleineWeideBauen()
    {

        objektGebaut = 20;
        Instantiate(weide1);
    }

    public void MittlereWeideBauen()
    {
        objektGebaut = 21;
        Instantiate(weide2);
    }

    public void GroßeWeideBauen()
    {
        objektGebaut = 22;
        Instantiate(weide3);
    }


    public void KleinesFeldBauen()
    {

        objektGebaut = 30;
        Instantiate(feld1);
    }

    public void MittleresFeldBauen()
    {
        objektGebaut = 31;
        Instantiate(feld2);
    }

    public void GroßesFeldBauen()
    {
        objektGebaut = 32;
        Instantiate(feld3);
    }

}
