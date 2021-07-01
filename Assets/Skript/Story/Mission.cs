using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    //Test Mission ein bool
    public static bool[] missionsLevel = new bool[] {false,false,false,false,false,false,false,false,false};

    //Je Teilziel ein Bool
    public static bool[] missionsTeilLevel0 = new bool[] {false,false};
    public static bool[] missionsTeilLevel1 = new bool[] {false};
    public static bool[] missionsTeilLevel2 = new bool[] {false,false,false,false};
    public static bool[] missionsTeilLevel3 = new bool[] {false,false,false};
    public static bool[] missionsTeilLevel4 = new bool[] {false,false,false,false};
    public static bool[] missionsTeilLevel5 = new bool[] {false,false};
    public static bool[] missionsTeilLevel6 = new bool[] {false}; //Das ist für das Level VOR Level 0
    public static bool[] missionsTeilLevel7 = new bool[] {false}; //Das ist für das Level zwischen 1 und 2
    public static bool[] missionsTeilLevel8 = new bool[] {false, false, false}; //Das ist für das Level zwischen 2 und 3
    
    //Hilfsvariablen
    int zwischenziel1 = 0;
    int zwischenziel2 = 0;
    int zwischenziel3 = 0;
    int zwischenziel4 = 0; 
    public static int temp_baukosten_lvl2 = 0;
    public static int temp_ertrag_lvl2 = 0;
    public static int temp_arbeiterzahl_lvl2 = 0;
    public static int temp_arbeiterzahl_lvl4 = 0;
    public static int temp_tierzahl_lvl4 = 0;
    public static int temp_baukosten_lvl4 = 0;
    public static int temp_anzahl_lvl4 = 0;
    public static int temp_geld_lvl6 = 0;
    public static int temp_forscher_lvl7 = 0;
    public static int temp_baukosten_lvl3 = 0;
    public static int temp_baukosten_lvl8 = 0;
    public static int temp_bettenzahl_lvl8 = 0;
    public static int temp_ertrag_lvl8 = 0;

    bool finale = false;
    public static bool mission1 = false;
    public static bool mission3 = false;

    public GameObject sound;

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
                                        new string[] { "Um eine Siedlung zu gründen, müssen Astronautinnen und Astronauten eingeflogen werden. Gib weiterhin den Namen des ersten Menschen der Siedlung ein.\nHinweis: Du kannst dir alle Astronauten im Fenster eines beliebigen Wohncontainer anzeigen lassen!", "Fliege 5 Feldastronauten ('Weizenähre') ein.", "Gib den Namen des Menschen der Siedlung an.", "aus", "aus", "5", " ", " ", " " },
                                        new string[] { "Du kannst nun Feldsphären errichten, die in regelmäßigen Abständen Erträge erwirtschaften. Dafür werden jedoch Feldastronauten benötigt.", "Erreiche einen Ertrag von 200.", "aus", "aus", "aus", "200", "", " ", " " },
                                        new string[] { "Wir können nun auch Feldsphären und Stationen verbessern. Erforsche je eine Verbesserung der Merkmale Baukosten, Arbeiterzahl und Ertrag von Feldsphären. Erforsche gleichzeitig neue Methoden in der Station mit Stationsnummer 2. ", "Verbessere die Baukosten von Feldsphären.", "Verbessere die Arbeiterzahl von Feldsphären.", "Verbessere den Ertrag von Feldsphären.", "Verbessere die Projektkosten von der Station mit SNr. 2.", "", "", "", "" },
                                        new string[] { "Neben Feldsphären können bald auch Weidesphären errichtet werden. Darin werden Tiere bewirtschaftet. Diese leben in Stallcontainern. Genau wie Wohncontainer, sollten auch diese mehr erforscht werden.", "Fliege 8 Tiere ein.", "Gib den Namen des 1. Tier der Seidlung an.", "aus", "Verbessere die Baukosten von Stallcontainern.", "8", "", "", "" },
                                        new string[] { "Nun können auch Weidesphären konstruiert werden, um Erträge zu erwirtschaften. Verbessere deinen regelmäßigen Ertrag durch den Bau von Weidesphären und forsche an deren Verbesserung.", "Erbaue 3 Weidesphären.", "Verbessere die Baukosten von Weidesphären.", "Verbessere die Tieranzahl von Weidesphären.", "Verbessere die Arbeiterzahl von Weidesphären.", "3", "", "", "" },
                                        new string[] { "Du hast es geschafft! Die Grundversorgung der ersten Marsseidlung ist aufgebaut und das ER-Diagramm, als Gerüst für die Datenbank, wurde erstellt. Nun ist es an der Zeit mehr zu forschen, um die Grundsteine für zukünftige Missionen auf dem Mars zu legen. Investiere daher in mehr Forschungsprojekt und erweitere die Bevölkerung deiner Siedlung.", "Erweitere deine Bevölkerung auf 50 Astronauten.", "Forsche in der Siedlung an 15 Projekten.", "aus", "aus", "50", "15", "", "" },
                                        
                                        //Folgendes Level ist das erste Level. Da es nachträglich hinzukam, wurde es hintendran gehangen.
                                        new string[] { "Damit Astronauten auf dem Mars leben können, werden Wohncontainer benötigt. Beginne deine Siedlung mit dem Bau dieser Wohncontainer.", "Errichte 1 Wohncontainer!", "aus", "aus", "aus", "", "", "", "" },
                                        //Folgendes Level ist das Level zwischen 1 und 2. Da es nachträglich hinzukam, wurde es hintendran gehangen.
                                        new string[] { "Um Forschung auf dem Mars zu betreiben werden Forschungsstationen benötigt. Jeder Sphären- und Containertyp hat eine eigene Forschungsstationstypen.", "Errichte 1 Forschungsstation!", "aus", "aus", "aus", "", "", "", "" },
                                        //Folgendes Level ist das Level zwischen 2 und 3. Da es nachträglich hinzukam, wurde es hintendran gehangen.
                                        new string[] { "Wir können nun mit ersten Forschungen beginnen und Wohncontainer verbessern. Erforsche mindestens eine Verbesserung der Baukosten und Bettenzahl von Wohncontainern. Steigere gleichzeitig deinen Ertrag, um die Forschung zu finanzieren!", "Verbessere die Baukosten von Wohncontainern.", "Verbessere die Bettenzahl von Wohncontainern.", "Erhöhe den Ertrag um 150.", "aus", "", "", "150", "" }
                                        };

    public GameObject missionshintergrund;
    
    // Start is called before the first frame update
    void Start()
    {
        masterKreuz.SetActive(true);
        masterHacken.SetActive(false);  
        textInput.SetActive(false);
        missionText.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        //Gib alle Texte der Mission aus.
        setMission(setLevel());
        //setMission(5);

        //Prüfe ob Mission von Level erfolgreich ist
        checkMission(setLevel());
        //checkMission(3);

        setSize();
        
        //Bedingung, damit nach Speichern/Laden die richtigen Icons ausgegeben werden
        if(ERAufgabe.missionCheck == false){
            ERkreisHacken.SetActive(true);
            ERkreisKreuz.SetActive(false);
        }

    }
    //Schreibe Missionstexte ins Fenster. Bei "aus" blende Teilziel aus
    public void setMission(int lvl)
    {
        //Utilitys.TextInTMP(missionText, mission[lvl][0]);

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
            missionshintergrund.transform.localPosition = new Vector3(-16,150.0f,0.0f);
        }else
        {
            if(Story.level == 2){
                return 0; //X Astronauten einfliegen
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else if(Story.level == 0 || Story.level == 1){
                return 6; //Wohncontainer bauen
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 3){
                return 1; //Ertrag auf X setzten
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 4){
                return 7; //Forschungsstation bauen
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 5){
                return 8; //Verbessern von Wohncontainern
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else if(Story.level == 6){
                return 2; //Verbessern von Feldern
                missionshintergrund.transform.localPosition = new Vector3(-16,11.0f,0.0f);
            }else if(Story.level == 7){
                return 3; //X Nutztiere einfliegen
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else {
                return 4; //X Weidearbeiter und Ertrag und Verbesserung
                missionshintergrund.transform.localPosition = new Vector3(-16,11.0f,0.0f);
            }
        }
    }

    public void setSize()
    {
        if(finale){
            missionshintergrund.transform.localPosition = new Vector3(-16,150.0f,0.0f);
        }else
        {
            if(Story.level == 2){
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else if(Story.level == 0 || Story.level == 1){
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 3){
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 4){
                missionshintergrund.transform.localPosition = new Vector3(-16,196.0f,0.0f);
            }else if(Story.level == 5){
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else if(Story.level == 6){
                missionshintergrund.transform.localPosition = new Vector3(-16,11.0f,0.0f);
            }else if(Story.level == 7){
                missionshintergrund.transform.localPosition = new Vector3(-16,105.0f,0.0f);
            }else {
                missionshintergrund.transform.localPosition = new Vector3(-16,11.0f,0.0f);
            }
        }
    }

    public void checkMission(int level)
    {
    //Level vor 0
        if(level == 6){
            if(missionsLevel[6]){
                hacken1.SetActive(true);
                KreuzHacken();
            }else{ 
                //missionTeilLevel checkt ob Teilzeil bereits fertig war
                if(missionsTeilLevel6[0]){
                    hacken1.SetActive(true);
                    zwischenziel1 = 1;
                    missionsTeilLevel6[0] = true;
                }else{
                    if(temp_geld_lvl6 < Testing.geld){
                        temp_geld_lvl6 = Testing.geld;
                    }
                    if(temp_geld_lvl6 > Testing.geld){
                        KreuzHacken();
                        missionsLevel[6] = true;
                    }else{
                            firstTime = true;
                    }
                }
            }           
    //Level 0
        }else if(level == 0){
            textInput.SetActive(true);
            hacken2.SetActive(false);
            hacken1.SetActive(false);

                //Zuerst wird gecheckt, ob ganzes Level bereits fertig war
                if(missionsLevel[0]){
                    hacken1.SetActive(true);
                    hacken2.SetActive(true);
                    KreuzHacken();
                }else{ 

                    //missionTeilLevel[X][X] checkt ob Teilzeil bereits fertig war
                    if(missionsTeilLevel0[0] || Testing.feldarbeiter == System.Convert.ToInt32(mission[0][5]))
                    {
                        hacken1.SetActive(true);
                        zwischenziel1 = 1;
                        missionsTeilLevel0[0] = true;
                    }
                    if(Testing.feldarbeiter > 0)
                    {
                        if((missionsTeilLevel0[1]|| Testing.menschen.Count>0 )&& lvl1_text.text == Testing.menschen[0].name)
                        {
                            hacken2.SetActive(true);
                            textInput.GetComponent<InputField>().interactable = false;
                            zwischenziel2 = 1;
                            missionsTeilLevel0[1] = true;
                        }
                    }
                    if(zwischenziel1 == 1 && zwischenziel2 == 1){
                        KreuzHacken();
                        missionsLevel[0] = true;
                    }
                    else
                    {
                        firstTime = true;
                    }
                }
    //Level 1    
        }else if(level == 1){
                hacken2.SetActive(false);
                hacken1.SetActive(false);
                textInput.SetActive(false);
                textInput.GetComponent<InputField>().text = "";

                if(missionsLevel[1]){
                    hacken1.SetActive(true);
                    hacken2.SetActive(true);
                    KreuzHacken();
                }else{
                    if(missionsTeilLevel1[0] || Testing.umsatz >= System.Convert.ToInt32(mission[1][5])){
                        hacken1.SetActive(true);
                        zwischenziel1 = 1;
                        missionsTeilLevel1[0] = true;
                    } 
                    if(zwischenziel1 == 1){
                        KreuzHacken();
                        missionsLevel[1] = true;
                    }
                    else
                    {
                        firstTime = true;
                    } 
                }               
    //Level vor 2 und nach 1     
        }else if(level == 7){
               hacken1.SetActive(false);
               hacken2.SetActive(false);
               hacken3.SetActive(false);
               hacken4.SetActive(false);
               if(missionsLevel[7]){
                    hacken1.SetActive(true);
                    KreuzHacken();
                }else{ 
                    //missionTeilLevel checkt ob Teilzeil bereits fertig war
                    if(missionsTeilLevel7[0])
                    {
                        hacken1.SetActive(true);
                        zwischenziel1 = 1;
                        missionsTeilLevel7[0] = true;
                    }else{
                        if(temp_forscher_lvl7 < Testing.forscher){
                            temp_forscher_lvl7 = Testing.forscher;
                        }
                        if(temp_forscher_lvl7 > Testing.forscher){
                            KreuzHacken();
                            mission1 = true;
                            missionsLevel[7] = true;
                        }
                        else
                        {
                            firstTime = true;
                        }
                    }
                }           
        //Level 8
        }else if(level == 8){
                hacken1.SetActive(false);
                hacken2.SetActive(false);
                hacken3.SetActive(false);
                hacken4.SetActive(false);

                if(missionsLevel[8]){
                    hacken1.SetActive(true);
                    hacken2.SetActive(true);
                    hacken3.SetActive(true);
                    hacken4.SetActive(true);
                    KreuzHacken();
                }else{

                    if(temp_baukosten_lvl8 == 0 && temp_bettenzahl_lvl8 == 0)
                    {
                        temp_bettenzahl_lvl8 = Wohncontainer.betten;
                        temp_baukosten_lvl8 = Wohncontainer.preis;
                        temp_ertrag_lvl8 = Testing.umsatz;
                    }
                    if(
                        missionsTeilLevel8[0] || Wohncontainer.preis < temp_baukosten_lvl8){
                        hacken1.SetActive(true);
                        zwischenziel1 = 1;
                        missionsTeilLevel8[0] = true;
                    }
                    if(missionsTeilLevel8[1] || Wohncontainer.betten > temp_bettenzahl_lvl8){
                        hacken2.SetActive(true);
                        zwischenziel2 = 1;
                        missionsTeilLevel8[1] = true; 
                    }
                    if(missionsTeilLevel8[2] || Testing.umsatz >= (temp_ertrag_lvl8 + System.Convert.ToInt32(mission[8][7]))){
                        hacken3.SetActive(true);
                        zwischenziel3 = 1;
                        missionsTeilLevel8[2] = true;
                    }
                    if(zwischenziel1==1 && zwischenziel2==1 && zwischenziel3==1){
                        KreuzHacken();
                        missionsLevel[8] = true;
                    }
                    else
                    {
                        firstTime = true;
                    }
                }
    //Level 2
        }else if(level == 2){
                hacken1.SetActive(false);
                hacken2.SetActive(false);
                hacken3.SetActive(false);
                hacken4.SetActive(false);

                if(missionsLevel[2]){
                    hacken1.SetActive(true);
                    hacken2.SetActive(true);
                    hacken3.SetActive(true);
                    hacken4.SetActive(true);
                    KreuzHacken();
                }else{

                    if(temp_arbeiterzahl_lvl2 == 0 && temp_baukosten_lvl2 == 0 && temp_ertrag_lvl2 == 0)
                    {
                        temp_baukosten_lvl2 = Feld.preis;
                        temp_arbeiterzahl_lvl2 = Feld.arbeiterzahl;
                        temp_ertrag_lvl2 = Feld.neuErtrag;
                    }
                    if(missionsTeilLevel2[0] || Feld.preis < temp_baukosten_lvl2){
                        hacken1.SetActive(true);
                        zwischenziel1 = 1;
                        missionsTeilLevel2[0] = true;
                    }
                    if(missionsTeilLevel2[1] || Feld.arbeiterzahl < temp_arbeiterzahl_lvl2){
                        hacken2.SetActive(true);
                        zwischenziel2 = 1; 
                        missionsTeilLevel2[1] = true;
                    }
                    if(missionsTeilLevel2[2] || Feld.neuErtrag > temp_ertrag_lvl2){
                        hacken3.SetActive(true);
                        zwischenziel3 = 1;
                        missionsTeilLevel2[2] = true;
                    }
                    if(missionsTeilLevel2[3]){
                        hacken4.SetActive(true);
                        zwischenziel4 = 1; 
                        missionsTeilLevel2[3] = true;
                        zwischenziel4 = 1;
                    }else{
                        foreach(Forschung forschung in Testing.forschungsstationen){
                            if(forschung.stationsnummer == 2){
                                foreach(Projekt projekt in forschung.projekte){
                                    if(projekt.merkmal == "Projektkosten"){
                                        hacken4.SetActive(true);
                                        zwischenziel4 = 1; 
                                        missionsTeilLevel2[3] = true;
                                    }    
                                }
                            }
                        }
                    }
                    if(zwischenziel1==1 && zwischenziel2==1 && zwischenziel3==1 && zwischenziel4==1){
                        KreuzHacken();
                        missionsLevel[2] = true;
                    }
                    else
                    {
                        firstTime = true;
                    }
                }
    //Level 3     
        }else if(level == 3){
            hacken1.SetActive(false);
            hacken2.SetActive(false);
            textInput.SetActive(true);
            textInput.GetComponent<InputField>().interactable = true;

            if(missionsLevel[3]){
                hacken1.SetActive(true);
                hacken2.SetActive(true);
                KreuzHacken();
            }else{
                if(Testing.tiere > 0)
                {
                    if(missionsTeilLevel3[0] || mission3 || lvl1_text.text == Testing.tier[0].tiername)
                    {
                        mission3 = true;
                        hacken2.SetActive(true);
                        textInput.GetComponent<InputField>().interactable = false;
                        zwischenziel1 = 1;
                        missionsTeilLevel3[0] = true;
                    }
                }else {lvl1_text.text = "";}
                if(missionsTeilLevel3[1] || Testing.tiere >= System.Convert.ToInt32(mission[3][5])){
                    hacken1.SetActive(true);
                    zwischenziel2 = 1;
                    missionsTeilLevel3[1] = true;
                }
                if(temp_baukosten_lvl3 == 0){
                    temp_baukosten_lvl3 = Stallcontainer.preis;
                }
                if(temp_baukosten_lvl3 > Stallcontainer.preis){
                    hacken4.SetActive(true);
                    zwischenziel3 = 1;
                    missionsTeilLevel3[2] = true;
                }

                if(zwischenziel1 == 1 && zwischenziel2 == 1 && zwischenziel3 == 1){
                    KreuzHacken();
                    missionsLevel[3] = true;
                }
                else
                {
                    firstTime = true;
                }
            }
    //Level 4     
        }else if(level == 4){
                hacken1.SetActive(false);
                hacken2.SetActive(false);
                hacken3.SetActive(false);
                hacken4.SetActive(false);
                textInput.SetActive(false);

                if(missionsLevel[4]){
                    hacken1.SetActive(true);
                    hacken2.SetActive(true);
                    hacken3.SetActive(true);
                    hacken4.SetActive(true);
                    KreuzHacken();
                }else{
                        if(temp_anzahl_lvl4 == 0 && temp_arbeiterzahl_lvl4 == 0 && temp_baukosten_lvl4 == 0 && temp_tierzahl_lvl4 == 0)
                        {
                            temp_arbeiterzahl_lvl4 = Weide.arbeiterzahl;
                            temp_baukosten_lvl4 = Weide.preis;
                            temp_tierzahl_lvl4 = Weide.tierAnzahl;
                            temp_anzahl_lvl4 = Testing.weiden.Count;
                        }
                        if(missionsTeilLevel4[0] || Testing.weiden.Count >= temp_anzahl_lvl4 + System.Convert.ToInt32(mission[4][5])){
                            hacken1.SetActive(true);
                            zwischenziel1 = 1;
                            missionsTeilLevel4[0] = true;
                        }
                        if(missionsTeilLevel4[1] || Weide.preis < temp_baukosten_lvl4){
                            hacken2.SetActive(true);
                            zwischenziel2 = 1; 
                            missionsTeilLevel4[1] = true;
                        }
                        if(missionsTeilLevel4[2] || Weide.tierAnzahl < temp_tierzahl_lvl4){
                            hacken3.SetActive(true);
                            zwischenziel3 = 1;
                            missionsTeilLevel4[2] = true;
                        }
                        if(missionsTeilLevel4[3] || Weide.arbeiterzahl < temp_arbeiterzahl_lvl4){
                            hacken4.SetActive(true);
                            zwischenziel4 = 1; 
                            missionsTeilLevel4[3] = true;
                        }
                        if(zwischenziel1==1 && zwischenziel2==1 && zwischenziel3==1 && zwischenziel4==1){
                            KreuzHacken();
                            finale = true;
                            missionsLevel[4] = true;
                        }
                        else
                        {
                            firstTime = true;
                        }
                }
        }else if (level == 5)
        {
            hacken1.SetActive(false);
            hacken2.SetActive(false);
            hacken3.SetActive(false);
            hacken4.SetActive(false);

            if(missionsLevel[5]){
                hacken1.SetActive(true);
                hacken2.SetActive(true);
                KreuzHacken();
            }else{
                if(missionsTeilLevel5[0] || Testing.summeMenschen >= System.Convert.ToInt32(mission[5][5]))
                {
                    hacken1.SetActive(true);
                    zwischenziel1 = 1;
                    missionsTeilLevel5[0] = true;
                }
                if(missionsTeilLevel5[1] || Testing.summeForschungen >= System.Convert.ToInt32(mission[5][6]))
                {
                    hacken2.SetActive(true);
                    zwischenziel2 = 1; 
                    missionsTeilLevel5[1] = true;
                }
                if(zwischenziel1==1 && zwischenziel2==1){
                    KreuzHacken();
                    missionsLevel[5] = true;

                }
                else
                {
                    firstTime = true;
                }
            }
        }
    }

    private void popUpKreis(GameObject kreis)
    {
        if (firstTime)
        {
            LeanTween.scale(kreis,new Vector3(2 , 2),5).setEasePunch();
            
            //Check-Sound wenn PopUpKreis auf geht
            AudioSource x = sound.GetComponent<AudioSource>();
            x.Play(0);
        }
        firstTime = false;
    }

    //Hilfsmethode die bei erfolgreicher Mission sich um Hacken/Kreuz kümmert
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

        if(FehlerAnzeige.tutorialtext_Spiel.Equals("")){
            FehlerAnzeige.tutorialtext_Spiel = "Mission erfolgreich! Du kannst nun wieder dein ER-Diagramm erweitern!";
        }      
    }

    public void FinaleAnzeige()
    {
        Debug.Log("Du hast gewonnen!");
    }
}
