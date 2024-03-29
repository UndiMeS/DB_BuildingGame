﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* erstetzte Wörter:
    W = Wohncontainer
    A = Astronaut
    F = Feldspähre
    S = Forschungsstation
    P = Forschungsprojekt
*/
public class ERAufgabe : MonoBehaviour
{
    public bool testModus = true ;
    public static bool beziehungKardRichtig;



    //Welche EM je Level
    private string[][] listeEntity;
    private string[][] listeEntityPlural;
    //in diesen Lvl befinden sich schwache Entitys, muss an erster Stelle von listeEntity stehen
    public bool[] listeSchwacheEntity = { false, true, false, false, true, false, true, false };

    //für Rechtschreibprüfung
    private bool rechtschreibPrueferAktiv = false;
    private List<string> falschGeschriebeneNamen = new List<string>();
    private float BeginningTime;
    public static float zeitZumLoesen=0; //nach 5min erscheint erst Hilfestellung für Rechtschreibfehler
    public SpellChecking spellChecking;

    //Welche Attribute je EM
    private string[][] wohncontainer = {
                                        new string[] { "1", "Kosten", "Baukosten", "Preis", "Baupreis"},
                                        new string[] { "2", "Containernummer", "Cnr","Cnr.","CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer","Cnr" },
                                        new string[] { "3", "Bettenzahl", "Bettenanzahl", "Betten", "Kapazität" },
                                        new string[] { "4", "freie Betten", "freieBetten", "Freie Betten", "FreieBetten", "BettenFrei", "Bettenfrei" }
                                        };
    private string[][] astronaut = {
                                        new string[] { "1","Anreisegebühr","Anreisegebühren","Anreisekosten", "Kosten", "Gebühren"},
                                        new string[] { "2","Aufgabe","Aufgaben"},
                                        new string[] { "3", "Name", "Namen"},
                                        new string[] { "4", "Geburtsdatum", "Geburtstag"}
                                    };
    private string[][] feldspaehre = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis" },
                                        new string[] { "2","Arbeiterzahl","Feldarbeiter", "Arbeiteranzahl"},
                                        new string[] { "3","Ertrag"},
                                        new string[] { "4", "Feldnummer", "FNR", "Fnr", "Fnr.", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Nummer" }
                                    };
    private string[][] weidespaehre = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis" },
                                        new string[] { "2","Arbeiterzahl", "Weidenarbeiter", "Weidearbeiter", "Anzahl Arbeiter", "Arbeiteranzahl"},
                                        new string[] { "3","Ertrag"},
                                        new string[] { "4","Weidennummer", "Weidenummer", "Wnr", "Wnr.", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.","Weidenr.", "Nummer" },
                                        new string[] { "5","Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere"}
                                    };
    private string[][] nutztier = {
                                        new string[] { "1","Name", "Namen" },
                                        new string[] { "2","Anreisegebühr", "Kosten", "Preis", "Transportkosten", "Transportpreis" },
                                        new string[] { "3","Art", "Tierart"},
                                    };
    private string[][] stallcontainer = {
                                        new string[] {"1","Kosten", "Baukosten", "Preis", "Baupreis" },
                                        new string[] {"2","Containernummer", "Cnr", "Cnr.", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "Stallnummer", "SNR","Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Containernr."},
                                        new string[] {"3","Gehegezahl", "Gehegeanzahl", "Gehege", "Kapazität" },
                                        new string[] {"4","freie Gehege", "freieGehege", "Gehege frei" }
                                        };
    private string[][] forschungsstation ={
                                        new string[] {"1","Kosten", "Baukosten", "Preis", "Baupreis"},
                                        new string[] {"2","Stationsnummer", "SNR", "Snr", "Snr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Stationsnr.", "Nummer"},
                                        new string[] {"3","Spezialisierung"},
                                        };
    private string[][] forschungsprojekt = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis", "Projektkosten", "Forschungskosten" },
                                        new string[] { "2","Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Forschungsarbeiter", "Forschungsastronauten", "Anzahl","Anzahl Arbeiter", "Arbeiteranzahl"},
                                        new string[] { "3","Verbesserungsfaktor", "Faktor", "Verbesserung"},
                                        new string[] { "4","Stufe", "Forschungsstufe"},
                                        new string[] { "5","Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal"}
                                    };

    //Relationen
    //EM1_EM2 = {Realtionsnamensvarianten}#
    //EM1_EM2_Eig = {EM1, EM2, EM2_schwach(1 ja), Kard1, Kard2}

    private string[] astronaut_forschungsstation = { "arbeitet","verantwortet","verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für","istverantwortlich","istVerantwortlich","ist verantwortlich" };
    private string[] astronaut_forschungsstation_Eig;

    private string[] wohncontainer_astronaut = { "wohnt in","wohntIn", "wohnt", "wohnenIn", "wohnenIn", "wohnen" };
    public string[] wohncontainer_astronaut_Eig;

    private string[] astronaut_forschungsprojekt = { "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht" };
    private string[] astronaut_forschungsprojekt_Eig;

    private string[] astronaut_feldsphaere = {"arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf"};
    private string[] astronaut_feldsphaere_Eig;

    private string[] astronaut_weidesphaere = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf" };
    private string[] astronaut_weidesphaere_Eig;

    private string[] stallcontainer_nutztier = { "leben", "lebt", "wohnen","wohntIn","wohnt in", "wohnt", "wohnenIn", "wohnenIn" };
    public string[] stallcontainer_nutztier_Eig;

    private string[] weidesphaere_nutztier = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "helfen", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf"};
    private string[] weidesphaere_nutztier_Eig;

    private string[] forschungsprojekt_wohncontainer = { "forschen", "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_wohncontainer_Eig;

    private string[] forschungsprojekt_feldsphaere = {"forschen" ,"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_feldsphaere_Eig;

    private string[] forschungsprojekt_stallcontainer = { "forschen", "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_stallcontainer_Eig;

    private string[] forschungsprojekt_weidesphaere = {"forschen", "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_weidesphaere_Eig;

    private string[] forschungsprojekt_forschungsprojekt = {"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "MethodenVerbessern", "verbessertMethodenVon", "verbessertMethoden","forscht" };
    private string[] forschungsprojekt_forschungsprojekt_Eig;

    private string[] forschungsstation_forschungsprojekt = { "organisiert", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für" };
    public string[] forschungsstation_forschungsprojekt_Eig;

    //PS Attribut mit 1 setzten für das jeweilige Level
    // Reihenfolge von Attributen 0 kein Ps, 1 PS
    private int[][][] primarschluessel = {  
                     /*LvL 0*/            new int[][] { new int[] { 0, 1, 0, 0 } },
                     /*LvL 1*/            new int[][] { new int[] { 0, 0, 1, 1 } }, 
                     /*LvL 2*/            new int[][] { new int[] { 0, 0, 0, 1 } },
                     /*LvL 3*/            new int[][] { new int[] { 0, 1, 0, 0 } },                
                     /*LvL 4*/            new int[][] { new int[] { 0, 0, 0, 1, 1 } },
                     /*LvL 5*/            new int[0][],
                     /*LvL 6*/            new int[][] { new int[] { 1, 0, 1 }, new int[]{0, 1, 0, 0} },
                     /*LvL 7*/            new int[][] { new int[] { 0, 0, 0, 1, 0 } },
                                        };

    private string[][][][] listeAttribute = new string[8][][][]; //[Level][Entity][Attribnut][Namen]
    public string[][][] listeBeziehungen = new string[8][][]; //[Level][Beziehung][Namen]
    public string[][][] listeBeziehungsEigenschaften = new string[8][][];

    //Anzahl der Elemente pro Level      lvl{ 0, 1, 2, 3, 4, 5, 6, 7 }
    private int[] entitysRichtig = { 1, 1, 1, 1, 1, 0, 2, 1 };
    private int[] attributeRichtig ;//{ 4, 4, 4, 3, 5, 0, 7, 5 };
    private int[] primaerschluesselRichtig;//{ 1, 2, 1, 1, 2, 0, 3, 1 };
    private int[] beziehungenRichtig = { 0, 1, 1, 1, 3, 2, 2, 3 };
    private int[] kardRichtig = { 0, 2, 2, 2, 6, 4, 4, 6 }; //2 pro Relation

    private int[] entitysHat;
    private int[] attributeHat;
    private int[] primaerschluesselHat;
    private int[] beziehungenHat;
    private int[] kardHat;

    //Anzahl der Objekte, die im LvL sind (#EM + #Attribute + #Relationen)
    private int[] anzahlObjekte; //{ 5, 6, 6, 5, 9, 2, 11, 9 };

    public GameObject dasIstSchonFertig;
    public GameObject aufgabenText;
    public List<GameObject> checkliste;
    public List<TMPro.TextMeshProUGUI> checkliste_Namen;
    private Color gruen = new Color32(39, 174, 96, 255); //noch anpassen
    public static List<GameObject> gespeicherteObjekte;
    public GameObject checkboxOhneRelation;
    public GameObject checkboxOhneEntity;

    public static bool missionCheck = true;
    public GameObject aufgabenFenster;
    public GameObject aufgabeButton;
    public GameObject checkbox;
    public GameObject bottomLeiste;

    public GameObject kreisHacken;
    public GameObject kreisKreuz;
    public GameObject missionHacken;
    public GameObject missionKreuz;

    private bool firsttime = true;

    public ERAufgabenText ERAufgabenText;
    public GameObject infobox;

    //Audio
    public GameObject lvl_true;

    public GameObject levelGeschafft;


    public GameObject[] AttributeTag;
    public int AttributeCount;
    public static int AttributeCountTemp;

    public GameObject[] EntityTag;
    public int EntityCount;
    public static int EntityCountTemp;

    public GameObject[] RelationTag;
    public int RelationCount;
    public static int RelationCountTemp;

    


    // Start is called before the first frame update
    void Awake()
    {
        //Testen:
        if (testModus)
        {
            Debug.Log("TESTMODUS:");
               Debug.Log("Wohncontainer - W; Astronaut - A; Feldsphäre - F; Forschungsstation - S; Projekt - P; Nutztiere - N; Stallcontainer -St; Weide - We");
            listeEntity = new string[][]{
                                        new string[] { "W" },               /*LvL 0*/
                                        new string[] { "A" },                   /*LvL 1*/
                                        new string[] { "F" },                  /*LvL 2*/
                                        new string[] { "S" },           /*LvL 3*/
                                        new string[] { "P" },           /*LvL 4*/
                                        new string[] {  },                              /*LvL 5*/
                                        new string[] { "N", "St" },  /*LvL 6*/
                                        new string[] { "We" },                 /*LvL 7*/   
                                    };
            listeEntityPlural = new string[][]{
                                        new string[] { "W" },               /*LvL 0*/
                                        new string[] { "A" },                   /*LvL 1*/
                                        new string[] { "F" },                  /*LvL 2*/
                                        new string[] { "S" },           /*LvL 3*/
                                        new string[] { "P" },           /*LvL 4*/
                                        new string[] {  },                              /*LvL 5*/
                                        new string[] { "N", "St" },  /*LvL 6*/
                                        new string[] { "We" },                 /*LvL 7*/   
                                    };


            attributeRichtig = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };//{ 4, 4, 4, 3, 5, 0, 7, 5 };
            primaerschluesselRichtig = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };//{ 1, 2, 1, 1, 2, 0, 3, 1 };

            astronaut_forschungsstation_Eig = new string[] { "A", "S", "0", "1", "1" };
            wohncontainer_astronaut_Eig = new string[] { "W", "A", "1", "1", "1" };
            astronaut_forschungsprojekt_Eig = new string[] { "A", "P", "0", "1", "n" };
            astronaut_feldsphaere_Eig = new string[] { "A", "F", "0", "1", "n" };
            astronaut_weidesphaere_Eig = new string[] { "A", "We", "0", "1", "n" };
            stallcontainer_nutztier_Eig = new string[] { "St", "N", "1", "n", "1" };
            weidesphaere_nutztier_Eig = new string[] { "We", "N", "0", "n", "1" };
            forschungsprojekt_wohncontainer_Eig = new string[] { "P", "W", "0", "n", "n" };
            forschungsprojekt_feldsphaere_Eig = new string[] { "P", "F", "0", "n", "n" };
            forschungsprojekt_stallcontainer_Eig = new string[] { "P", "St", "0", "n", "n" };
            forschungsprojekt_weidesphaere_Eig = new string[] { "P", "We", "0", "n", "n" };
            forschungsprojekt_forschungsprojekt_Eig = new string[] { "P", "P", "0", "1", "n" };
            forschungsstation_forschungsprojekt_Eig = new string[] { "S", "P", "1", "n", "1" };

            anzahlObjekte = new int[]{ 1, 2, 2, 2, 4, 2, 4, 4 }; //{ 5, 6, 6, 5, 9, 2, 11, 9 };
        }
        else
        {
            Debug.Log("TESTMODUS ausgeschalten");
            listeEntity = new string[][]{
                                        new string[] { "Wohncontainer" },               /*LvL 0*/
                                        new string[] { "Astronaut" },                   /*LvL 1*/
                                        new string[] { "Feldsphäre" },                  /*LvL 2*/
                                        new string[] { "Forschungsstation" },           /*LvL 3*/
                                        new string[] { "Forschungsprojekt" },           /*LvL 4*/
                                        new string[] {  },                              /*LvL 5*/
                                        new string[] { "Nutztier", "Stallcontainer" },  /*LvL 6*/
                                        new string[] { "Weidesphäre" },                 /*LvL 7*/   
                                    };
            listeEntityPlural = new string[][]{
                                        new string[] { "Wohncontainer" },               /*LvL 0*/
                                        new string[] { "Astronauten" },                   /*LvL 1*/
                                        new string[] { "Feldsphären" },                  /*LvL 2*/
                                        new string[] { "Forschungsstationen" },           /*LvL 3*/
                                        new string[] { "Forschungsprojekte" },           /*LvL 4*/
                                        new string[] {  },                              /*LvL 5*/
                                        new string[] { "Nutztiere", "Stallcontainer" },  /*LvL 6*/
                                        new string[] { "Weidesphären" },                 /*LvL 7*/   
                                    };
            attributeRichtig = new int[] { 4, 4, 4, 3, 5, 0, 7, 5 };
            primaerschluesselRichtig = new int[] { 1, 2, 1, 1, 2, 0, 3, 1 };

            astronaut_forschungsstation_Eig = new string[] { "Astronaut", "Forschungsstation", "0", "1", "1" };
            wohncontainer_astronaut_Eig = new string[] { "Wohncontainer", "Astronaut", "1", "n", "1" };
            astronaut_forschungsprojekt_Eig = new string[] { "Astronaut", "Forschungsprojekt", "0", "1", "n" };
            astronaut_feldsphaere_Eig = new string[] { "Astronaut", "Feldsphäre", "0", "1", "n" };
            astronaut_weidesphaere_Eig = new string[] { "Astronaut", "Weidesphäre", "0", "1", "n" };
            stallcontainer_nutztier_Eig = new string[] { "Stallcontainer", "Nutztier", "1", "n", "1" };
            weidesphaere_nutztier_Eig = new string[] { "Weidesphäre", "Nutztier", "0", "n", "1" };
            forschungsprojekt_wohncontainer_Eig = new string[] { "Forschungsprojekt", "Wohncontainer", "0", "n", "n" };
            forschungsprojekt_feldsphaere_Eig = new string[] { "Forschungsprojekt", "Feldsphäre", "0", "n", "n" };
            forschungsprojekt_stallcontainer_Eig = new string[] { "Forschungsprojekt", "Stallcontainer", "0", "n", "n" };
            forschungsprojekt_weidesphaere_Eig = new string[] { "Forschungsprojekt", "Weidesphäre", "0", "n", "n" };
            forschungsprojekt_forschungsprojekt_Eig = new string[] { "Forschungsprojekt", "Forschungsprojekt", "0", "1", "n" };
            forschungsstation_forschungsprojekt_Eig = new string[] { "Forschungsstation", "Forschungsprojekt", "1", "n", "1" };

            anzahlObjekte = new int[] { 5, 6, 6, 5, 9, 2, 11, 9 };
        }


        // Level 0
        listeAttribute[0] = new string[][][] { wohncontainer };
        listeBeziehungen[0] = new string[0][];
        listeBeziehungsEigenschaften[0] = new string[0][];
        // Level 1
        listeAttribute[1] = new string[][][] { astronaut };
        listeBeziehungen[1] = new string[][] { wohncontainer_astronaut };
        listeBeziehungsEigenschaften[1] = new string[][] { wohncontainer_astronaut_Eig };
        // Level 2
        listeAttribute[2] = new string[][][] { feldspaehre };
        listeBeziehungen[2] = new string[][] { astronaut_feldsphaere };
        listeBeziehungsEigenschaften[2] = new string[][] { astronaut_feldsphaere_Eig };
        // Level 3
        listeAttribute[3] = new string[][][] { forschungsstation };
        listeBeziehungen[3] = new string[][] { astronaut_forschungsstation };
        listeBeziehungsEigenschaften[3] = new string[][] { astronaut_forschungsstation_Eig };
        // Level 4
        listeAttribute[4] = new string[][][] { forschungsprojekt };
        listeBeziehungen[4] = new string[][] { astronaut_forschungsprojekt, forschungsstation_forschungsprojekt, forschungsprojekt_wohncontainer };
        listeBeziehungsEigenschaften[4] = new string[][] { astronaut_forschungsprojekt_Eig, forschungsstation_forschungsprojekt_Eig, forschungsprojekt_wohncontainer_Eig };
        // Level 5
        listeAttribute[5] = new string[0][][];
        listeBeziehungen[5] = new string[][] { forschungsprojekt_feldsphaere, forschungsprojekt_forschungsprojekt };
        listeBeziehungsEigenschaften[5] = new string[][] { forschungsprojekt_feldsphaere_Eig, forschungsprojekt_forschungsprojekt_Eig };
        // Level 6
        listeAttribute[6] = new string[][][] { nutztier, stallcontainer };
        listeBeziehungen[6] = new string[][] { stallcontainer_nutztier, forschungsprojekt_stallcontainer };
        listeBeziehungsEigenschaften[6] = new string[][] { stallcontainer_nutztier_Eig, forschungsprojekt_stallcontainer_Eig };
        // Level 7
        listeAttribute[7] = new string[][][] { weidespaehre };
        listeBeziehungen[7] = new string[][] { forschungsprojekt_weidesphaere, weidesphaere_nutztier, astronaut_weidesphaere };
        listeBeziehungsEigenschaften[7] = new string[][] { forschungsprojekt_weidesphaere_Eig, weidesphaere_nutztier_Eig, astronaut_weidesphaere_Eig };

        gespeicherteObjekte = new List<GameObject>();

        gespeicherteObjekteAus();
    

    }

    // Update is called once per frame
    void Update()
    {


        if (Story.level < 8)
        {
                ERAufgabenText.textAnzeigen(Story.level);

            

                AttributeTag = GameObject.FindGameObjectsWithTag("Attribut");
                EntityTag = GameObject.FindGameObjectsWithTag("Entitaet");
                RelationTag = GameObject.FindGameObjectsWithTag("Beziehung");

            
            


            //wenn die Mission erfolgreich absolviert wurde, kann wieder im ER gebastelt werden und es wird chckObjekte() ausgeführt
            if (missionCheck)
            {

                

             
                AttributeCount = AttributeTag.Length - AttributeCountTemp;
                EntityCount = EntityTag.Length - EntityCountTemp;
                RelationCount = RelationTag.Length - RelationCountTemp;

                

                //infobox.transform.localPosition = new Vector3(0, 0, 0);
                bottomLeiste.SetActive(true);
                aufgabeButton.SetActive(true);
                kreisHacken.SetActive(false);
                kreisKreuz.SetActive(true);
                if (firsttime)
                {
                    BeginningTime = Time.time;
                    //aufgabenFenster.SetActive(true);
                    //checkbox.SetActive(true);
                }
                checkObjekte();
                firsttime = false;
                //Ist die Mission noch nciht erfüllt, bleibt alles verdeckt.
            }
            else
            {
                AttributeCountTemp = AttributeTag.Length;
                EntityCountTemp = EntityTag.Length;
                RelationCountTemp = RelationTag.Length;


                bottomLeiste.SetActive(false);
                aufgabenFenster.SetActive(false);
                checkbox.SetActive(false);
                aufgabeButton.SetActive(false);
                firsttime = true;
            }
        }
        else
        {
            //FehlerAnzeige.tutorialtext_ER = "Du hast es geschafft. Dein ER-Diagramm ist für diese Siedlung komplett! Auf zu deinen letzten Missionen!";
            //infobox.transform.localPosition = new Vector3(0, -82, 0);
            infobox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-92,0);
            bottomLeiste.SetActive(false);
            aufgabenFenster.SetActive(false);
            checkbox.SetActive(false);
            aufgabeButton.SetActive(false);
        }
        //Checkbox für Level 0 anpassen
        if (Story.level == 0)
        {
            checkboxOhneRelation.SetActive(true);
            checkliste[3].SetActive(false);
            checkliste[4].SetActive(false);
        }
        else
        {
            checkboxOhneRelation.SetActive(false);
        }
        //Checkbox für Level 5 anpassen
        if (Story.level == 5)
        {
            checkboxOhneEntity.SetActive(true);
            checkliste[0].SetActive(false);
            checkliste[1].SetActive(false);
            checkliste[2].SetActive(false);
        }
        else
        {
            checkboxOhneEntity.SetActive(false);
        }

    }

    private void checkObjekte()
    {
        entitysHat = new int[entitysRichtig.Length];
        attributeHat = new int[attributeRichtig.Length];
        primaerschluesselHat = new int[primaerschluesselRichtig.Length];
        beziehungenHat = new int[beziehungenRichtig.Length];
        kardHat = new int[kardRichtig.Length];

        int indexEntity = 0;
        checkBeziehung();
        for(int i=0;i<listeEntity[Story.level].Length;i++)
        {
            foreach (GameObject entity in ERErstellung.modellObjekte)
            {
                string name = entity.name.Trim(' ');
                if (name.Equals("Forschungsprojekt"))
                {
                    Debug.Log("Forschungsprojekt");
                }


                if (name.ToLower().Contains("spähre"))
                {
                    FehlerAnzeige.fehlertext = "Achte auf korrekte Rechtschreibung. Sp<b>h</b>äre statt Spä<b>h</b>re!";
                }
                if (name.Equals(listeEntity[Story.level][i])|| name.Equals(listeEntityPlural[Story.level][i]))
                {                  
                    if (listeSchwacheEntity[Story.level] && i==0 && entity.GetComponent<Entitaet>().schwach)
                    {
                        entitysHat[Story.level]++;
                    }
                    else if (!listeSchwacheEntity[Story.level]||(Story.level==6&&indexEntity==1&& !entity.GetComponent<Entitaet>().schwach))
                    {
                        entitysHat[Story.level]++;
                    }
                    entity.GetComponent<Entitaet>().singularName = listeEntity[Story.level][i];
                    checkAttribute(indexEntity, entity);
                }

                if (rechtschreibPrueferAktiv&&(!entity.GetComponent<TMPro.TMP_InputField>().isFocused))
                {
                    if (SpellChecking.ueberpruefteWoerterFalsch.Contains(name)&& entity.GetComponent<TMPro.TMP_InputField>().textComponent.color == Color.black)
                    {
                        Debug.Log("EM+ \""+name+"\"");
                        entity.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.red;
                    }else if (SpellChecking.ueberpruefteWoerterKorrekt.Contains(name)|| SpellChecking.ueberpruefteWoerterFalsch.Contains(name))
                    {

                    }
                    else if (spellChecking.rechtschreibPruefer(name))
                    {
                          entity.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.black;
                    }
                    

                }


            }
            indexEntity++;
        }
        

        if (checkAllesRichtig())
        {
            rechtschreibPrueferAktiv = false;
            falschGeschriebeneNamen.Clear();

            //Check Sound wenn alles richtig ist
            AudioSource x = lvl_true.GetComponent<AudioSource>();
            x.Play(0);

            //Level geschafft Anzeige
            levelGeschafft.SetActive(true);


            //wenn alles richtig ist wird default alles auf aus gesetzt (in Update wird es aber wieder auf true gesetzt, wenn missioncheck == true ist)
            infobox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-92,0);
            
            bottomLeiste.SetActive(false);
            aufgabeButton.SetActive(false);
            //FehlerAnzeige.fehlertext = "Du hast alles richtig gemacht!";
            Story.lvl[Story.level] = true; //Markiere Level als erfüllt

            ERAufgabenText.werteGesetzt = false; //Erlaubt nun das neu setzen der Werte des Klickzählers
            
            if (missionCheck == false)
            {
                kreisHacken.SetActive(true);
                kreisKreuz.SetActive(false);
            }

            //ER bleibt bei dem Level stehen, wo Mission bearbeitet werden kann. Ist Mission erfolgreich (missionCheck = true), dann geht es weiter.
            if ((Story.level == 0 || Story.level == 1 || Story.level == 2 || Story.level == 3 || Story.level == 4 || Story.level == 5 || Story.level == 6 || Story.level == 7) && missionCheck == true)
            {
                missionCheck = false;
                kreisHacken.SetActive(true);
                kreisKreuz.SetActive(false);
                missionKreuz.SetActive(true);
                missionHacken.SetActive(false);
            }


            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                if (!gespeicherteObjekte.Contains(obj))
                {
                    gespeicherteObjekte.Add(obj);
                    obj.GetComponent<TMPro.TMP_InputField>().DeactivateInputField();
                    obj.transform.GetChild(1).gameObject.SetActive(false);
                    
                    obj.transform.GetChild(0).gameObject.SetActive(true);
                    Utilitys.TextInTMP(obj.transform.GetChild(0).gameObject, obj.name);
                    if (obj.CompareTag("Attribut") && obj.GetComponent<Attribut>().primaerschluessel)
                    {
                        obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
                    }
                }
            }
            Story.level++;
        }
        else
        {
            infobox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
        }
    }

    private void checkBeziehung()
    {
        
        List<GameObject> erfolgreichbetrachtet = new List<GameObject>();
        for (int i = 0; i < listeBeziehungen[Story.level].Length; i++)
        {

            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                bool allesDa = true;
                bool kardinalitaeten = true;
                if (obj.CompareTag("Beziehung") && !gespeicherteObjekte.Contains(obj) && !erfolgreichbetrachtet.Contains(obj))
                {
                    string nameAnderesEnitity = "";
                    int einsoderZwei = 0;
                    int dreiodervier = 0;

                    GameObject ob1 = null;
                    GameObject ob2 = null;
                    GameObject ob12 = null;
                    string name1 = obj.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().singularName;
                    string name2 = obj.GetComponent<Beziehung>().objekt2.GetComponent<Entitaet>().singularName;
                    //Entitäten und Kardinalität prüfen
                    if (obj.GetComponent<Beziehung>().objekt1 != null && listeBeziehungsEigenschaften[Story.level][i][0].Equals(name1))
                    {
                        if (obj.GetComponent<Beziehung>().objekt2 != null)
                        {
                            ob1 = obj.GetComponent<Beziehung>().objekt1;
                            ob12 = obj.GetComponent<Beziehung>().objekt2;
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt2.GetComponent<Entitaet>().singularName;
                        }
                        if (checkKard(obj, 1, i, 4))
                        {
                            einsoderZwei = 2;
                            dreiodervier = 3;
                            kardinalitaeten &= true;
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }
                    }
                    else if (obj.GetComponent<Beziehung>().objekt2 != null && listeBeziehungsEigenschaften[Story.level][i][0].Equals(name2))
                    {
                        if (obj.GetComponent<Beziehung>().objekt1 != null)
                        {
                            ob2 = obj.GetComponent<Beziehung>().objekt2;
                            ob12 = obj.GetComponent<Beziehung>().objekt1;
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().singularName;
                        }
                        if (checkKard(obj, 2, i, 4))
                        {
                            einsoderZwei = 1;
                            dreiodervier = 3;
                            kardinalitaeten &= true;
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }
                    }
                    if (i == 2)
                    {
                        //Debug.Log("1");
                    }
                    if (listeBeziehungsEigenschaften[Story.level][i][1].Equals(nameAnderesEnitity))
                    {
                        allesDa &= true;
                        if (checkKard(obj, einsoderZwei, i, dreiodervier))
                        {
                            kardinalitaeten &= true;
                        }
                        else if ((ob1 != null && ob1.Equals(ob12) || ob2 != null && ob2.Equals(ob12)) && Story.level == 5)
                        {
                            if (obj.GetComponent<Beziehung>().kard1.Equals("1") && obj.GetComponent<Beziehung>().kard2.Equals("n"))
                            {
                                kardinalitaeten = true;
                            }
                            else if (obj.GetComponent<Beziehung>().kard2.Equals("1") && obj.GetComponent<Beziehung>().kard1.Equals("n"))
                            {
                                kardinalitaeten = true;
                            }
                            else
                            {
                                kardinalitaeten = false;
                            }
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }

                    }
                    else
                    {
                        ob12 = null;
                        allesDa &= false;
                        kardinalitaeten &= false;
                    }
                    if (kardinalitaeten)
                    {
                        kardHat[Story.level] += 2;
                    }
                    //name prüfen
                    bool temp = true;
                    foreach (string name in listeBeziehungen[Story.level][i])
                    {
                       
                        if ((obj.name.Trim(' ')).Equals(name))
                        {
                            allesDa &= true;
                            temp = false;
                            break;
                        }
                        if (rechtschreibPrueferAktiv && (!obj.GetComponent<TMPro.TMP_InputField>().isFocused))
                        {
                            if (SpellChecking.ueberpruefteWoerterFalsch.Contains(name) && obj.GetComponent<TMPro.TMP_InputField>().textComponent.color == Color.black)
                            {
                                Debug.Log("Beziehung");
                                obj.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.red;
                            }
                            else if (SpellChecking.ueberpruefteWoerterKorrekt.Contains(name) || SpellChecking.ueberpruefteWoerterFalsch.Contains(name))
                            {

                            }
                            else if (spellChecking.rechtschreibPruefer(name))
                            {
                                obj.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.black;
                            }

                        }



                    }
                    if (temp)
                    {
                        allesDa &= false;
                    }

                    //schwache Entity
                    if (obj.GetComponent<Beziehung>().schwach && listeBeziehungsEigenschaften[Story.level][i][2].Equals("1"))
                    {
                        if (ob12 != null && ob12.GetComponent<Entitaet>().schwach)
                        {

                            allesDa &= true;

                        }
                        else { allesDa &= false; }

                    }
                    else if (!obj.GetComponent<Beziehung>().schwach && listeBeziehungsEigenschaften[Story.level][i][2].Equals("0"))
                    {
                        allesDa &= true;
                    }
                    else
                    {
                        allesDa &= false;
                    }
                    if (allesDa)
                    {
                        erfolgreichbetrachtet.Add(obj);
                        beziehungenHat[Story.level]++;
                        break;
                    }
                    
                }
            }
        }

    }

    private bool checkKard(GameObject obj, int einsOderZwei, int i, int dreiOdervier)
    {
        string kard = "";
        if (einsOderZwei == 1)
        {
            kard = obj.GetComponent<Beziehung>().kard1;       
        }
        else
        {
            kard = obj.GetComponent<Beziehung>().kard2;
        }

        if (kard.Equals(listeBeziehungsEigenschaften[Story.level][i][dreiOdervier]))
        {
            
            return true;
        }
        
        else
        {
            
            return false;
        }
    }

    private bool checkAllesRichtig()
    {
        for(int k=0; k< checkliste.Count;k++)
        {
            checkliste[k].SetActive(false);
            checkliste_Namen[k].color = Color.black;
        }
        bool ausgabe = true;
        int i = Story.level;
        ausgabe &= entitysHat[i] == entitysRichtig[i];
        if (entitysHat[i] == entitysRichtig[i])// && entitysRichtig[Story.level] == EntityCount)
        {
            checkliste[0].SetActive(true);
            checkliste_Namen[0].color = gruen;
        }
        else
        {
            checkliste[0].SetActive(false);
            checkliste_Namen[0].color = Color.black;
        }
        ausgabe &= attributeHat[i] == attributeRichtig[i];
        if (attributeHat[i] == attributeRichtig[i])// attributeRichtig[Story.level] == AttributeCount)
        {
            checkliste[1].SetActive(true);
            checkliste_Namen[1].color = gruen;
        }
        else
        {
            checkliste[1].SetActive(false);
            checkliste_Namen[1].color = Color.black;
        }
        ausgabe &= primaerschluesselHat[i] == primaerschluesselRichtig[i];
        if (primaerschluesselHat[i] == primaerschluesselRichtig[i])
        {
            checkliste[2].SetActive(true);
            checkliste_Namen[2].color = gruen;
        }
        else
        {
            checkliste[2].SetActive(false);
            checkliste_Namen[2].color = Color.black;
        }
        ausgabe &= beziehungenRichtig[i] == beziehungenHat[i];
        if (beziehungenRichtig[i] == beziehungenHat[i])// beziehungenRichtig[Story.level] == RelationCount)
        {
            checkliste[3].SetActive(true);
            checkliste_Namen[3].color = gruen;
        }
        else
        {
            checkliste[3].SetActive(false);
            checkliste_Namen[3].color = Color.black;
        }
        ausgabe &= kardHat[i] == kardRichtig[i];
        if (kardRichtig[i] == kardHat[i])
        {
            checkliste[4].SetActive(true);
            checkliste_Namen[4].color = gruen;
        }
        else
        {
            checkliste[4].SetActive(false);
            checkliste_Namen[4].color = Color.black;
        }

        beziehungKardRichtig = (beziehungenRichtig[i] == beziehungenHat[i]) && (kardHat[i] == kardRichtig[i]);

        //(beziehungenRichtig[i]+1 == beziehungenHat[i]||  ( attributeRichtig[i]- attributeHat[i]<=2 && attributeRichtig[i] != attributeHat[i]))&&
        if (Time.time-BeginningTime>zeitZumLoesen)
        {
            rechtschreibPrueferAktiv = true;
        }
        else { rechtschreibPrueferAktiv = false; }


        int count = 0;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (!gespeicherteObjekte.Contains(obj))
            {
                count++;
            }
        }
        
        if (count == anzahlObjekte[Story.level])
        {
            ausgabe &= true;
            if(FehlerAnzeige.fehlertext.Equals("Es sind zu viele Objekte.")){
                FehlerAnzeige.fehlertext = "trigger";
            }
            
        }
        else if (count > anzahlObjekte[Story.level])
        {
            FehlerAnzeige.fehlertext="Es sind zu viele Objekte.";
            ausgabe &= false;
        }
        else
        {
            ausgabe &= false;
            if(FehlerAnzeige.fehlertext.Equals("Es sind zu viele Objekte.")){
                FehlerAnzeige.fehlertext = "trigger";
            }
        }
        


        return ausgabe;
    }

    private void checkAttribute(int indexEntity, GameObject entity)
    {
        int indexattribute = 0;
        bool schonGefunden = false;
        foreach (string[] attributNamesMoeglichkeiten in listeAttribute[Story.level][indexEntity])
        {
            foreach (GameObject attribut in entity.GetComponent<Entitaet>().attribute)
            {
                foreach (string attributName in attributNamesMoeglichkeiten)
                {
                    string name = attribut.name.Trim(' ');
                    

                    if (name.Equals(attributName))
                    {
                        attributeHat[Story.level]++;
                        if (primarschluessel[Story.level][indexEntity][indexattribute] == 1 && entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            primaerschluesselHat[Story.level]++;

                        }else if(primarschluessel[Story.level][indexEntity][indexattribute] == 1 || entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            primaerschluesselHat[Story.level]--;
                        }
                        schonGefunden = true;
                        break;

                    }
                    if (rechtschreibPrueferAktiv && (!attribut.GetComponent<TMPro.TMP_InputField>().isFocused))
                    {
                        if (SpellChecking.ueberpruefteWoerterFalsch.Contains(name) && attribut.GetComponent<TMPro.TMP_InputField>().textComponent.color == Color.black)
                        {
                            Debug.Log("Attribut: :"+name+":");
                            attribut.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.red;
                        }
                        else if (SpellChecking.ueberpruefteWoerterKorrekt.Contains(name) || SpellChecking.ueberpruefteWoerterFalsch.Contains(name))
                        {

                        }
                        else if (spellChecking.rechtschreibPruefer(name))
                        {
                            attribut.GetComponent<TMPro.TMP_InputField>().textComponent.color = Color.black;
                        }


                    }
                }

                if (schonGefunden)
                {
                    schonGefunden = false;
                    break;
                }

            }
            indexattribute++;

        }


    }
    public static void gespeicherteObjekteAus()
    {
        foreach (GameObject game in ERAufgabe.gespeicherteObjekte)
        {
            game.transform.GetChild(1).gameObject.SetActive(false);
            game.transform.GetChild(0).gameObject.SetActive(true);
            Utilitys.TextInTMP(game.transform.GetChild(0).gameObject, game.name);
            if (game.CompareTag("Attribut") && game.GetComponent<Attribut>().primaerschluessel)
            {
                game.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
            }
        }
    }


}