﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Grundlegende Methoden
public class Testing : MonoBehaviour
{
    public static bool laden = false;
    public GameObject speichermenue;

    public GameObject boden;
    public GameObject fehlermeldung;

    //Grundlegende Werte, die verändert werden können
    public static int weite=19;
    public static int hoehe=13;
    public static int zellengroesse = 10;
    public static Gitter grid;

    public static int objektGebaut;
    public static GameObject gebautesObjekt;

    public static int geld = 8800;//800


    public static int umsatz = 0;

    public static int forscher=0;
    public static int feldarbeiter =0;
    public static int tierpfleger = 0;
    public static int tiere =0;

    public static int summeMenschen = 0;
    public static int summeTiere = 0;
    public static int summeForschungen = 0;

    private bool zuvorNichtAn;

    public GameObject erstellfenster;
    public GameObject infofesnter;

    public PauseMenu pausemenu;
    public GameObject zusatz;

    public static bool Mars = true;

    public static List<Wohncontainer> wohncontainer = new List<Wohncontainer>();
    public static List<Mensch> menschen = new List<Mensch>();
    public static List<Feld> felder = new List<Feld>();
    public static List<Forschung> forschungsstationen = new List<Forschung>();
    public static List<Projekt> forschungsprojekte = new List<Projekt>();
    public static List<Weide> weiden = new List<Weide>();
    public static List<Stallcontainer> stallcontainer = new List<Stallcontainer>();
    public static List<GameObject> gebauedeListe = new List<GameObject>();
    public static List<Tiere> tier = new List<Tiere>();

    public KameraKontroller KameraScript;
    public GameObject canvas;

    public PauseMenu PauseScript;

    public static GameObject GebaeudeTemp;
    public GameObject ShowGebaeude;
    public static bool NeuesGebaeude;
    public static bool neuesgebaeude;
    public static int gebaeudeNummer;
    public int showNummer;


  
    // Start is called before the first frame update
    void Start()
    {
        Spielwerte.Werte();
        grid = new Gitter(weite, hoehe, zellengroesse);

        //Hintergrund und Camera
        //boden.transform.localPosition = new Vector3(140, 21, -150);
        //boden.transform.localScale = new Vector3(20000,20000,200);
        //boden.transform.localRotation = Quaternion.Euler(42, 222, -148);
        FehlerAnzeige.fehlertext = "";
        boden.SetActive(true);
        ObjektBewegung.erstellfenster = erstellfenster;
        ObjektBewegung.infoAnzeige = infofesnter;
        objektGebaut = 0;

        if (laden)
        {
            laden = false;
            speichermenue.GetComponent<SaveLoad>().laden();
        }

        // KameraScript = GameObject.FindGameObjectWithTag("KameraAnker").GetComponent<KameraKontroller>();
        // PauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
        PauseScript.changeHintergrund(0);
    }

    private void Update()
    {
        ShowGebaeude = GebaeudeTemp;
        showNummer = objektGebaut;
        /*
        if (geld < 25 && zuvorNichtAn)
        {
            pausemenu.ObjectAnzeigenTimeStop(zusatz);
            zusatz.GetComponent<Aufgaben>().openAufgabe();
            zuvorNichtAn = false;
        }
        else if(geld>=25)
        {
            zuvorNichtAn = true;
        }
        */
    }


    public static void resetAll()
    {
        geld = 0;
        umsatz = 0;
        forscher = 0;
        feldarbeiter = 0;
        tiere = 0;
        tierpfleger = 0;
        summeForschungen = 0;
        summeMenschen = 0;
        summeTiere = 0;

        wohncontainer.Clear();
        Wohncontainer.resetStatics();
        menschen.Clear();
        felder.Clear();
        Feld.resetStatics();
        forschungsstationen.Clear();
        Forschung.resetStatics();
        forschungsprojekte.Clear();
        weiden.Clear();
        Weide.resetStatics();
        stallcontainer.Clear();
        Stallcontainer.resetStatics();
        gebauedeListe.Clear();
        for(int i=0;i<ERErstellung.modellObjekte.Count;)
        {
            GameObject temp= ERErstellung.modellObjekte[0];
            ERErstellung.modellObjekte.Remove(temp);
            Destroy(temp);
        }
        if (ERAufgabe.gespeicherteObjekte != null)
        {
            ERAufgabe.gespeicherteObjekte.Clear();
        }

        SpielInfos.marsTag = 0;
        SpielInfos.currenttime=0;
        SpielInfos.erdenTag=0;
        SpielInfos.marsTag=0;

        SpielInfos.deltaErdenTag=0;
        SpielInfos.deltaMarsTag=0;

        SpielInfos.lasttime=0;
        SpielInfos.pausedtime=0;

        Story.lvl = new bool[] { false, false, false, false, false, false, false, false };
        Story.level = 0;
        Mission.missionsLevel = new bool[] { false, false, false, false, false, false, false, false, false, false }; ;
        Mission.missionsTeilLevel0 = new bool[] {false,false};
        Mission.missionsTeilLevel1 = new bool[] {false};
        Mission.missionsTeilLevel2 = new bool[] {false,false,false,false};
        Mission.missionsTeilLevel3 = new bool[] {false,false,false};
        Mission.missionsTeilLevel4 = new bool[] {false,false,false,false};
        Mission.missionsTeilLevel5 = new bool[] {false,false,false};
        Mission.missionsTeilLevel6 = new bool[] {false}; 
        Mission.missionsTeilLevel7 = new bool[] {false}; 
        Mission.missionsTeilLevel8 = new bool[] {false, false, false}; 
        Mission.mission1 = false;
        Mission.mission3 = false;
        
        ERAufgabe.missionCheck = true;
        
        Mission.temp_baukosten_lvl2 = 0;
        Mission.temp_ertrag_lvl2 = 0;
        Mission.temp_arbeiterzahl_lvl2 = 0;
        Mission.temp_arbeiterzahl_lvl4 = 0;
        Mission.temp_tierzahl_lvl4 = 0;
        Mission.temp_baukosten_lvl4 = 0;
        Mission.temp_anzahl_lvl4 = 0;
        Mission.temp_geld_lvl6 = 0;
        Mission.temp_forscher_lvl7 = 0;
        Mission.temp_baukosten_lvl3 = 0;
        Mission.temp_baukosten_lvl8 = 0;
        Mission.temp_bettenzahl_lvl8 = 0;
        Mission.temp_ertrag_lvl8 = 0;
        
    }


    // public void screenshotMachen()
    // {
    //     KameraScript.ScreenshotZoom();
        
        
    //     Invoke("screenshotErstellen", 0.3f);
        
    //     Invoke("allesAn", 0.1f);
        

    //     //StartCoroutine(screenshotErstellen());

        
        
    // }

    // public void screenshotErstellen()
    // {
    //     canvas.SetActive(false);
    //     //yield return new WaitForSeconds(0.2f);
    //     ScreenCapture.CaptureScreenshot(Application.dataPath + "/Zertifikatsbilder/Spiel.png",2); //Größe mit Faktor 2 multipliziert, damit wir es im Zertifikat verkleinern können
    //     Debug.Log("Screenshot gemacht");
        
    //     //Wichtiger Bool, damit letzte Mission erfüllt werden kann
    //     Mission.screenshotSpiel = true;
    //     Invoke("allesAn", 1.1f);
        
        
    // }

    //     private void allesAn()
    // {
    //     canvas.SetActive(true);
    //     FehlerAnzeige.fehlertext = "Screenshot wurde gemacht. Er befindet sich in deinen Speicherdaten.";
    //     PauseScript.Weiterspielen();
    // }



}



