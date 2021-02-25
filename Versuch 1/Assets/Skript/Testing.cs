﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Grundlegende Methoden
public class Testing : MonoBehaviour
{
    public GameObject boden;
    public GameObject fehlermeldung;

    //Grundlegende Werte, die verändert werden können
    public static int weite=20;
    public static int hoehe=13;
    public static int zellengroesse = 10;
    public static Gitter grid;

    public static int objektGebaut;
    public static GameObject gebautesObjekt;

    public static int geld = 100000;
    public static int umsatz = 10;

    public static int forscher=0;
    public static int feldarbeiter = 0;
    public static int tierpfleger = 0;
    public static int tiere = 0;

    public static int summeAnzMenschen = 0;
    public static int summeTiere = 0;
    public static int summeForschungen = 0;

    public GameObject erstellfenster;
    public GameObject infofesnter;



    // Start is called before the first frame update
    void Start()
    {
        grid = new Gitter(weite, hoehe, zellengroesse);

        //Hintergrund und Camera
        boden.transform.Translate(weite / 2 * zellengroesse , hoehe / 2 * zellengroesse , 1);
        boden.transform.localScale += new Vector3(weite +20 , 1, hoehe+20 );
        boden.transform.Rotate(90f, 180f, 0);
        FehlerAnzeige.fehlertext = "";

        ObjektBewegung.erstellfenster = erstellfenster;
        ObjektBewegung.infoAnzeige = infofesnter;
        


     }

    // Update is called once per frame
    void Update()
    {
        if (geld < 0)
        {
            ZuWenigGeld();
        }
            }

    public void ZuWenigGeld()
    {
        Utilitys.TextInTMP(fehlermeldung, "Du hast zu wenig Geld!");
    }
  






}



