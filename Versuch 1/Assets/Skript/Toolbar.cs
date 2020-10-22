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
    //für Grid
    public static int objektGebaut;

    public void KleinesHausBauen()
    {
        objektGebaut = 11;
        int preis = 1000;
        if (Testing.geld < preis)
        {
            ZuWenigGeld();
            return;
        }
        Testing.geld -= preis;
        Instantiate(haus1,transform.position,transform.rotation);
        }
    public void MittleresHausBauen()
    {
        objektGebaut = 12;
        int preis = 2500;
        if (Testing.geld < preis)
        {
            ZuWenigGeld();
            return;
        }
        Testing.geld -= preis;
        Instantiate(haus2);
    }
    public void GroßesHausBauen()
    {
        objektGebaut = 13;
        int preis = 5000;
        if (Testing.geld < preis)
        {
            ZuWenigGeld();
            return;
        }
        Testing.geld -= preis;
        GameObject haus = Instantiate(haus3);
    }
    public void MenschErzeugen()
    {
        Debug.Log("Du möchtest einen Mensch erzeugen?");
    }

    //später für Aufgaben
    public void ZuWenigGeld()
    {
        Debug.Log("Du hast zu wenig Geld!");
    }

 }
