using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
//Hilfsvariablen
    int x = 0;
    int y = 0;

//Missionsfenster Objekte
    public GameObject missionText;
    public GameObject teilZiel1;
    public GameObject teilZiel2;
    public GameObject teilZiel3;
    public GameObject teilZiel4;

//Hacken und Kreuz an Buttonleiste rechts
    public GameObject masterHacken;
    public GameObject masterKreuz;

//Hacken in Missionsfenster an Teilzielen
    public GameObject hacken1;
    public GameObject hacken2;
    public GameObject hacken3;
    public GameObject hacken4;

//Missionstexte für Fenster
    private string[][] mission = {                  // "Missionstext", TZ1, TZ2, TZ3, TZ4, Ziel für TZ1, Ziel für TZ2, Ziel für TZ3, Ziel für TZ4
                                        new string[] { "Wir brauchen Astronauten!", "Fliege 1 Astronauten ein.", "aus", "aus", "aus", "1", " ", " ", " " },
                                        new string[] { "Wir brauchen Erträge! Du kannst nun Feldsphären errichten. Dafür werden jedoch auch Feldastronauten benötigt.", "Erreiche einen Ertrag von 50.", "Fliege 8 Feldastronauten ein.", "aus", "aus", "50", "8", " ", " " },
                                        new string[] { "Mission 2", "Teilziel 12", "Teilziel 22", "Teilziel 32", "Teilziel 42", "1", "2", "3", "4" },
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
    }
    // Update is called once per frame
    void Update()
    {
        //Gib alle Texte der Mission aus.
        setMission(setLevel());
        //Prüfe ob Mission von Level erfolgreich ist
        checkMission();
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
            return 4; //X Feldarbeiter und Ertrag
        }
    }

    public void checkMission()
    {
        //Level 0
        if(setLevel() == 0){
            if(Testing.feldarbeiter == System.Convert.ToInt32(mission[0][5]) || Testing.forscher == System.Convert.ToInt32(mission[0][5]) || Testing.tierpfleger == System.Convert.ToInt32(mission[0][5])){
                Debug.Log("Easy");
                hacken1.SetActive(true);
                masterKreuz.SetActive(false);
                masterHacken.SetActive(true);
                ERAufgabe.missionCheck = true;
            }
        //Level 1    
        }else if(setLevel() == 1){
                hacken1.SetActive(false);
                masterKreuz.SetActive(true);
                masterHacken.SetActive(false);
           if(Testing.umsatz >= System.Convert.ToInt32(mission[1][5])){
                Debug.Log("Easy");
                hacken1.SetActive(true);
                x = 1;
            }
            if(Testing.feldarbeiter == System.Convert.ToInt32(mission[1][6])){
                Debug.Log("Easy");
                hacken2.SetActive(true);
                y = 1; 
            }
            if(x==1 && y==1){
                masterKreuz.SetActive(false);
                masterHacken.SetActive(true);
                ERAufgabe.missionCheck = true;
            }
        //Level 2     
        }else if(setLevel() == 2){
                hacken1.SetActive(false);
                masterKreuz.SetActive(true);
                masterHacken.SetActive(false);

                //ERAufgabe.missionCheck = true;  
        }
    }

}
