using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
//Hilfsvariablen
    int zwischenziel1 = 0;
    int zwischenziel2 = 0;
    int zwischenziel3 = 0;
    int zwischenziel4 = 0; 
    int temp_feldarbeiter_lvl1 = 0;   
    int temp_baukosten_lvl2 = 0;
    int temp_bettenzahl_lvl2 = 0;
    int temp_ertrag_lvl2 = 0;
    int temp_arbeiterzahl_lvl2 = 0;
    int temp_arbeiterzahl_lvl4 = 0;
    int temp_tierzahl_lvl4 = 0;
    int temp_baukosten_lvl4 = 0;
    int temp_anzahl_lvl4 = 0;
    bool finale = false;
//Texteingaben für Missionen
    public Text lvl1_text;
    public GameObject textInput;
    InputField t;

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
                                        new string[] { "Um eine Siedlung zu gründen, müssen Astronauten eingeflogen werden. Dafür müssen jedoch Wohncontainer erichtet werden. Gib weiterhin den Namen des ersten Astronauten ein.", "Fliege 2 belibige Astronauten ein.", "Gib den Namen des 1. Astronauten der Siedlung an.", "aus", "aus", "2", " ", " ", " " },
                                        new string[] { "Du kannst nun Feldsphären errichten, die in regelmäßigen Abständen Erträge erwirtschaften. Dafür werden jedoch Feldastronauten benötigt.", "Erreiche einen Ertrag von 50.", "Fliege 8 Feldastronauten ein.", "aus", "aus", "50", "8", " ", " " },
                                        new string[] { "Wir können nun mit dem Forschen beginnen. Erforsche je eine Verbesserung der Baukosten und Bettenzahl von Wohncontainern und Arbeiterzahl und Ertrag von Feldsphären. Denk daran, dass es sich lohnen könnte auch die Methoden der Forschungsstationen zu verbessern. ", "Verbessere die Baukosten von Wohncontainern.", "Verbessere die Bettenzahl von Wohncontainern", "Verbessere den Ertrag von Feldsphären.", "Verbessere die Arbeiterzahl von Feldsphären.", "", "", "", "" },
                                        new string[] { "Neben Feldsphären können bald auch Weidesphären errichtet werden. Darin werden Tiere bewirtschaftet. Diese leben in Stallcontainern.", "Fliege 8 Tiere ein.", "Gib den Namen des 1. Tier der Seidlung an.", "aus", "aus", "8", "", "", "" },
                                        new string[] { "Nun können auch Weidesphären konstruiert werden, um Erträge zu erwirtschaften. Verbessere deinen regelmäßigen Ertrag durch den Bau von Weidesphären und forsche an deren Verbesserung.", "Erbaue 3 Weidesphären.", "Verbessere die Baukosten von Weidesphären.", "Verbessere die Tieranzahl von Weidesphären.", "Verbessere die Arbeiterzahl von Weidesphären.", "3", "", "", "" },
                                        new string[] { "Du hast es geschafft! Die Grundversorgung der ersten Marsseidlung ist aufgebaut und das ER-Diagramm, als Gerüst für die Datenbank, wurde erstellt. Nun ist es an der Zeit mehr zu forschen, um die Grundsteine für zukünftige Missionen auf dem Mars zu legen. Investiere daher in mehr Forschungsprojekt und erweitere die Bevölkerung deiner Siedlung.", "Erweitere deine Siedlungsbevölkerung auf 50 Astronauten.", "Forsche in der Siedlung an 15 Projekten.", "aus", "aus", "50", "15", "", "" }
                                        };
    // Start is called before the first frame update
    void Start()
    {
        masterKreuz.SetActive(true);
        masterHacken.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        
    //Gib alle Texte der Mission aus.
        setMission(setLevel());
        //setMission(3);

    //Prüfe ob Mission von Level erfolgreich ist
        checkMission(setLevel());
        //checkMission(3);

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
        if(finale){
            return 5;
        }else
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
                return 4; //X Weidearbeiter und Ertrag und Verbesserung
            }
        }
        
    }

    public void checkMission(int level)
    {
    //Level 0
        if(level == 0){ 
            if((Testing.forscher + Testing.feldarbeiter + Testing.tierpfleger) == System.Convert.ToInt32(mission[0][5]))
            {
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Testing.forscher + Testing.feldarbeiter + Testing.tierpfleger > 0)
            {
                if(Testing.menschen.Count>0&&lvl1_text.text == Testing.menschen[0].name)
                {
                    hacken2.SetActive(true);
                    textInput.GetComponent<InputField>().interactable = false;
                    zwischenziel2 = 1;
                }
            }
            if(zwischenziel1 == 1 && zwischenziel2 == 1){
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
    //Level 1    
        }else if(level == 1){
                hacken2.SetActive(false);
                hacken1.SetActive(false);
                textInput.SetActive(false);
                textInput.GetComponent<InputField>().text = "";
            if(Testing.umsatz >= System.Convert.ToInt32(mission[1][5])){
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Testing.feldarbeiter >= System.Convert.ToInt32(mission[1][6]) || temp_feldarbeiter_lvl1 >= System.Convert.ToInt32(mission[1][6])){
                hacken2.SetActive(true);
                zwischenziel2 = 1; 
                if(temp_feldarbeiter_lvl1 == 0)
                {
                    temp_feldarbeiter_lvl1 = Testing.feldarbeiter;
                }
            }
            if(zwischenziel1 == 1 && zwischenziel2 == 1){
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
    //Level 2     
        }else if(level == 2){
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
    //Level 3     
        }else if(level == 3){
            hacken1.SetActive(false);
            hacken2.SetActive(false);
            textInput.SetActive(true);
            textInput.GetComponent<InputField>().interactable = true;
            if(Testing.tiere > 0)
            {
                if(lvl1_text.text == Testing.tier[0].tiername)
                {
                    hacken2.SetActive(true);
                    textInput.GetComponent<InputField>().interactable = false;
                    zwischenziel1 = 1;
                }
            }else {lvl1_text.text = "";}
            if(Testing.tiere >= System.Convert.ToInt32(mission[3][5])){
                hacken1.SetActive(true);
                zwischenziel2 = 1;
            }
            if(zwischenziel1 == 1 && zwischenziel2 == 1){
                KreuzHacken();
            }
            else
            {
                firstTime = true;
            }
    //Level 4     
        }else if(level == 4){
                hacken1.SetActive(false);
                hacken2.SetActive(false);
                hacken3.SetActive(false);
                hacken4.SetActive(false);
                textInput.SetActive(false);
                if(temp_anzahl_lvl4 == 0 && temp_arbeiterzahl_lvl4 == 0 && temp_baukosten_lvl4 == 0 && temp_tierzahl_lvl4 == 0)
                {
                    temp_arbeiterzahl_lvl4 = Weide.arbeiterzahl;
                    temp_baukosten_lvl4 = Weide.preis;
                    temp_tierzahl_lvl4 = Weide.tierAnzahl;
                    temp_anzahl_lvl4 = Testing.weiden.Count;
                }
           if(Testing.weiden.Count >= temp_anzahl_lvl4 + System.Convert.ToInt32(mission[4][5])){
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Weide.preis < temp_baukosten_lvl4){
                hacken2.SetActive(true);
                zwischenziel2 = 1; 
            }
            if(Weide.tierAnzahl < temp_tierzahl_lvl4){
                hacken3.SetActive(true);
                zwischenziel3 = 1;
            }
            if(Weide.arbeiterzahl < temp_arbeiterzahl_lvl4){
                hacken4.SetActive(true);
                zwischenziel4 = 1; 
            }
            if(zwischenziel1==1 && zwischenziel2==1 && zwischenziel3==1 && zwischenziel4==1){
                KreuzHacken();
                finale = true;
            }
            else
            {
                firstTime = true;
            }
        }else if (level == 5)
        {
            hacken1.SetActive(false);
            hacken2.SetActive(false);
            hacken3.SetActive(false);
            hacken4.SetActive(false);
            if(Testing.summeMenschen >= System.Convert.ToInt32(mission[5][5]))
            {
                hacken1.SetActive(true);
                zwischenziel1 = 1;
            }
            if(Testing.summeForschungen >= System.Convert.ToInt32(mission[5][6]))
            {
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

    public void FinaleAnzeige()
    {
        Debug.Log("Du hast gewonnen!");
    }
}
