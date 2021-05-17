using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
//Hilfsvariablen
    int zwischenziel1 = 0;
    int zwischenziel2 = 0;
    int zwischenziel3 = 0;
    int zwischenziel4 = 0;    
    int temp_baukosten_lvl2 = 0;
    int temp_bettenzahl_lvl2 = 0;
    int temp_ertrag_lvl2 = 0;
    int temp_arbeiterzahl_lvl2 = 0;

//Missionsfenster Objekte
    public GameObject missionText;
    public GameObject teilZiel1;
    public GameObject teilZiel2;
    public GameObject teilZiel3;
    public GameObject teilZiel4;

//Hacken und Kreuz an Buttonleiste rechts
    public GameObject masterHacken;
    public GameObject masterKreuz;
    public GameObject ERkreisHacken;
    public GameObject ERkreisKreuz;

//Hacken in Missionsfenster an Teilzielen
    public GameObject hacken1;
    public GameObject hacken2;
    public GameObject hacken3;
    public GameObject hacken4;

    //Kreise
    public GameObject ERkreis;
    private bool firstTime=true;//nur beim ersten mal PopUp

//Missionstexte für Fenster
    private string[][] mission = {                  // "Missionstext", TZ1, TZ2, TZ3, TZ4, Ziel für TZ1, Ziel für TZ2, Ziel für TZ3, Ziel für TZ4
                                        new string[] { "Um eine Siedlung zu gründen, müssen Astronauten eingeflogen werden. Dafür müssen jedoch Wohncontainer erichtet werden.", "Fliege 2 belibigen Astronauten ein.", "aus", "aus", "aus", "2", " ", " ", " " },
                                        new string[] { "Du kannst nun Feldsphären errichten, die in regelmäßigen Abständen Erträge erwirtschaften. Dafür werden jedoch Feldastronauten benötigt.", "Erreiche einen Ertrag von 50.", "Fliege 8 Feldastronauten ein.", "aus", "aus", "50", "8", " ", " " },
                                        new string[] { "Wir können nun mit dem Forschen beginnen. Erforsche je eine Verbesserung der Baukosten und Bettenzahl von Wohncontainern und Arbeiterzahl und Ertrag von Feldsphären. Denk daran, dass es sich lohnen könnte auch die Methoden der Forschungsstationen zu verbessern. ", "Verbessere die Baukosten von Wohncontainern.", "Verbessere die Bettenzahl von Wohncontainern", "Verbessere den Ertrag von Feldsphären.", "Verbessere die Arbeiterzahl von Feldsphären.", "", "", "", "" },
                                        new string[] { "Mission 3", "Teilziel 13", "Teilziel 23", "Teilziel 33", "Teilziel 43", "1", "2", "3", "4" },
                                        new string[] { "Mission 4", "Teilziel 14", "Teilziel 24", "Teilziel 34", "Teilziel 44", "1", "2", "3", "4" },
                                        new string[] { "Mission 5", "Teilziel 15", "Teilziel 25", "Teilziel 35", "Teilziel 45", "1", "2", "3", "4" },
                                        new string[] { "Mission 6", "Teilziel 16", "Teilziel 26", "Teilziel 36", "Teilziel 46", "1", "2", "3", "4" },
                                        new string[] { "Mission 7", "Teilziel 17", "Teilziel 27", "Teilziel 37", "Teilziel 47", "1", "2", "3", "4" }
                                        };
    // Start is called before the first frame update
    void Start()
    {
        masterKreuz.SetActive(true);
        masterHacken.SetActive(false);
        zwischenziel1 = 0;
        zwischenziel2 = 0;
        zwischenziel3 = 0;
        zwischenziel4 = 0; 
    }
    // Update is called once per frame
    void Update()
    {
        
    //Gib alle Texte der Mission aus.
        setMission(setLevel());
        //setMission(2);


    //Prüfe ob Mission von Level erfolgreich ist
        checkMission(setLevel());
        //checkMission(2);
        //Debug.Log(temp_ertrag_lvl2);
        //Debug.Log(Feld.neuErtrag);
    }

    //Schreibe Missionstexte ins Fenster. Bei "aus" blende Teilziel aus
    public void setMission(int lvl)
    {
        Utilitys.TextInTMP(missionText, mission[lvl][0]);

        if(mission[lvl][1]=="aus"){
            teilZiel1.SetActive(false);
        }else{
            teilZiel1.SetActive(true);
            Utilitys.TextInTMP(teilZiel1, mission[lvl][1]);
        }
        if(mission[lvl][2]=="aus"){
            teilZiel2.SetActive(false);           
        }else{
            teilZiel2.SetActive(true);
            Utilitys.TextInTMP(teilZiel2, mission[lvl][2]);        
        }
        if(mission[lvl][3]=="aus"){
            teilZiel3.SetActive(false);
        }else{
            teilZiel3.SetActive(true);
            Utilitys.TextInTMP(teilZiel3, mission[lvl][3]);
        }
        if(mission[lvl][4]=="aus"){
            teilZiel4.SetActive(false);
        }else{
            teilZiel4.SetActive(true);
            Utilitys.TextInTMP(teilZiel4, mission[lvl][4]);
        }
    }

    //Setzte das Level für die Mission in Abhängigkeit vom Story Level. Manchmal sind mehrere Storylevel in einem Missionslevel
    public int setLevel()
    {
        if(Story.level == 0 || Story.level == 1|| Story.level == 2){
            return 0; //X Astronauten einfliegen
        }else if(Story.level == 3){
            return 1; //Ertrag auf X setzten
        }else if(Story.level == 4|| Story.level == 5|| Story.level == 6){
            return 2; //Verbessern von Containern und Feldern
        }else if(Story.level == 7){
            return 3; //X Nutztiere einfliegen
        }else {
            return 4; //X Weidearbeiter und Ertrag
        }
    }

    public void checkMission(int level)
    {
        //Level 0
        if(level == 0){
            if(Testing.forscher == System.Convert.ToInt32(mission[0][5])|| Testing.feldarbeiter == System.Convert.ToInt32(mission[0][5])|| Testing.tierpfleger == System.Convert.ToInt32(mission[0][5]))
            {
                hacken1.SetActive(true);
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
        //Level 1    
        }else if(level == 1){
                hacken1.SetActive(false);
                masterKreuz.SetActive(true);
                masterHacken.SetActive(false);
           if(Testing.umsatz >= System.Convert.ToInt32(mission[1][5])){
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Testing.feldarbeiter >= System.Convert.ToInt32(mission[1][6])){
                hacken2.SetActive(true);
                zwischenziel2 = 1; 
            }
            if(zwischenziel1==1 && zwischenziel2==1){
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
            //Level 2     
        }
        else if(level == 2){
                hacken1.SetActive(false);
                hacken2.SetActive(false);
                hacken3.SetActive(false);
                hacken4.SetActive(false);
                if(temp_arbeiterzahl_lvl2 == 0 && temp_baukosten_lvl2 == 0 && temp_bettenzahl_lvl2 == 0 && temp_ertrag_lvl2 == 0)
                {
                    temp_ertrag_lvl2 = Feld.neuErtrag;
                    temp_bettenzahl_lvl2 = Wohncontainer.betten;
                    temp_baukosten_lvl2 = Wohncontainer.preis;
                    temp_arbeiterzahl_lvl2 = Feld.arbeiterzahl;

                }
            if(Wohncontainer.preis < temp_baukosten_lvl2){
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Wohncontainer.betten > temp_bettenzahl_lvl2){
                hacken2.SetActive(true);
                zwischenziel2 = 1; 
            }
            if(Feld.neuErtrag > temp_ertrag_lvl2){
                hacken3.SetActive(true);
                zwischenziel3 = 1;
            }
            if(Feld.arbeiterzahl < temp_arbeiterzahl_lvl2){
                hacken4.SetActive(true);
                zwischenziel4 = 1; 
            }
            if(zwischenziel1==1 && zwischenziel2==1 && zwischenziel3==1 && zwischenziel4==1){
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
        }
    }

    private void popUpKreis(GameObject kreis)
    {
        if (firstTime)
        {
            LeanTween.scale(kreis,new Vector3(2 , 2),5).setEasePunch();
        }
        firstTime = false;
    }

    //Hilfsmethode die bei efolgreicher Mission sich um Hacken/Kreuz kümmert
    private void KreuzHacken()
    {
        masterKreuz.SetActive(false);
        masterHacken.SetActive(true);
        ERAufgabe.missionCheck = true;
        ERkreisHacken.SetActive(false);
        ERkreisKreuz.SetActive(true);
        popUpKreis(ERkreis);
        zwischenziel1 = 0;
        zwischenziel2 = 0;
        zwischenziel3 = 0;
        zwischenziel4 = 0;
    }

}
