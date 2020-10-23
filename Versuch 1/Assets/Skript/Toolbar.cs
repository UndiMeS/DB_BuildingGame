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



}
