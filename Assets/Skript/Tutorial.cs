using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    
    public bool tutorialOff = false; //Bool, um Tutorial in der Entwicklung auszuschalten

    //Tutorial Hilfselemente
    public GameObject pfeilSpiel;
    public GameObject pfeilER;
    private bool firstTime = true;
    private static bool missionClick = false;
    private static bool zusatzClick = false;
    private static bool beschreibungClick = false;
    private bool rotationTemp = true;
    public GameObject containerKiller;
    public GameObject wohncontainerHilfe;

    //Elemente aus Spiel
    public GameObject buttonER;
    public GameObject buttonSpiel;
    public GameObject textER;
    public GameObject buttonMission;
    Button bMission;
    public GameObject container;
    public GameObject feld;
    public GameObject buttonZusatz;
    Button bZusatz;
    public GameObject beschreibungER;
    public GameObject wohncontainerGebaeudeanzeige;

    // Start is called before the first frame update
    void Start()
    {
        if(tutorialOff){
            OffTutorial(); 
        }
        pfeilER.SetActive(false);
        pfeilSpiel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialOff == false){
            ShowTutorial(); 
        }
    }
    private void OffTutorial()
    {
        bZusatz = buttonZusatz.GetComponent<Button>();
        bZusatz.interactable = true;
        bMission = buttonMission.GetComponent<Button>();
        bMission.interactable = true;
        containerKiller.SetActive(false);
        pfeilER.SetActive(false);
        pfeilSpiel.SetActive(false);
        wohncontainerHilfe.SetActive(false);
    }
    private void ShowTutorial()
    {
        //Vorbereitung der Komponenten
        bZusatz = buttonZusatz.GetComponent<Button>();
        bZusatz.interactable = true;
        bMission = buttonMission.GetComponent<Button>();
        bMission.interactable = true;
        containerKiller.SetActive(false);
        wohncontainerHilfe.SetActive(false);
        

        //Zeitpunkt: Neues Spiel gestartet und Wechsel in ER-Editor
        if(Story.lvl[0] == false && Mission.missionsLevel[6] == false){
            bZusatz = buttonZusatz.GetComponent<Button>();
            bZusatz.interactable = false;
            bMission.interactable = false;
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, folge dem roten Pfeil und öffne zuerst den ER-Editor!";
            if(beschreibungClick == false){
                FehlerAnzeige.tutorialtext_ER = "Erstelle ein ER-Diagramm mit der Leiste am unteren Bildschrimrand anhand der ER-Beschreibung (scrollbar!). Öffne die Beschreibung (roter Pfeil)";
            }
            
            if(beschreibungClick){
                if(!FehlerAnzeige.tutorialtext_ER.Equals("Du kannst für dieses Teildiagramm auf noch 10 Wörter klicken, um richtige Schlüsselwörter herauszufinden und zu markieren!")){
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt. 'Primärschlüssel' wird abgehakt, wenn die entsprechenden Attribute richtig gekennzeichnet sind.\n Tipp: Klicke in das Beschreibungsfeld!";
                }   
            }
            
            
            if(beschreibungER.activeSelf){
                pfeilER.SetActive(false);
                //pfeilER.transform.localPosition = new Vector3(166,20.5f,0);
            }else{
                pfeilER.SetActive(true);
                pfeilER.transform.localPosition = new Vector3(844,132,0);
            }
            

            
            pfeilSpiel.SetActive(true);
            missionClick = false;
        
        //Zeitpunkt: ER-Level 0 (Wohncontainer) fertig und öffnen des Missionsfensters
        }else if(Story.lvl[0] == true && Mission.missionsLevel[6] == false){
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            pfeilER.SetActive(true);
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            containerKiller.SetActive(true);
            bZusatz.interactable = false;
            bMission.interactable = true;
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Tipp: Halte das Diagramm durch Verschiebung per Drag'n'Drop übersichtlich!\n Wechsel zurück in die Siedlung!"; 
            
            //Prüfe, ob Missionsbutten gedrückt wurde
            if(missionClick){
                if(rotationTemp){
                    pfeilSpiel.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    popUpGameObject(container);
                    rotationTemp = false;
                }
                containerKiller.SetActive(false);
                pfeilSpiel.transform.localPosition = new Vector3(-635,-215,0);
                FehlerAnzeige.tutorialtext_Spiel = "Errichte nun einen Wohncontainer! Zum Bauen hast du ein Startguthaben von "+Testing.geld+". Du kannst dieses in der oberen Infoleiste sehen.";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
            }         
        
        //Zeitpunkt: Mission 0 (Wohncontainer) fertig und Wechsel in ER-Editor
        }else if((Story.lvl[0] == true && Story.lvl[1] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            if(rotationTemp == false){
                    pfeilSpiel.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    rotationTemp = true;
            }
            pfeilSpiel.transform.localPosition = new Vector3(637,177,0);
            FehlerAnzeige.tutorialtext_Spiel = "Sehr gut! Um nun auch Astronauten einzufliegen, erweitere dein ER-Diagramm!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung! \n Hinweis: Wird eine Entitymenge als 'schwach' gekennzeichnet, wird automatisch auch eine schwache Relation erzeugt! ";
            if(beschreibungER.activeSelf){
                pfeilER.SetActive(false);
                //pfeilER.transform.localPosition = new Vector3(166,20.5f,0);
            }else{
                pfeilER.SetActive(true);
                pfeilER.transform.localPosition = new Vector3(844,132,0);
            }
            missionClick = false;
            bZusatz.interactable = false;
        
        //Zeitpunkt: ER-Level 1 fertig (Astronauten) und wechsel zur Mission (Astronauten)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";
            pfeilER.SetActive(true);
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            //Prüfe, ob Missionsbutten gedrückt wurde
            if(missionClick){
                FehlerAnzeige.tutorialtext_Spiel = "Neue Astronauten können über die Buttons im Wohncontainer eingeflogen werden. Klicke dort für den Namen auf 'Alle Astronauten'!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
                pfeilSpiel.SetActive(false);
                if(wohncontainerGebaeudeanzeige.activeSelf){
                    wohncontainerHilfe.SetActive(true);
                }
            }
            
            bZusatz.interactable = false;
        
        //Zeitpunkt: Mission 1 (Astronauten einfliegen) fertig und Wechsel in ER-Editor (Feldsphäre)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Die Anzahl der zur Verfügung stehenden Astronauten kannst du in der Infoleiste ganz rechts sehen. Wechsel, wie nach jeder Mission in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere nun erneut dein ER-Diagramm, führe den gleichen Kreislauf aus ER- u. Spielmodus fort und erweitere deine Siedlung! \n Hinweis: Beim Anlegen einer Relationship musst du die entsprechenden Entitymengen noch auswählen und die gewünschte Kardinalität setzen.";
            pfeilER.SetActive(false);
            pfeilSpiel.transform.localPosition = new Vector3(637,177,0);
            pfeilSpiel.SetActive(true);
            bZusatz.interactable = false;
            missionClick = false;
        
        //Zeitpunkt: ER-Level 2 fertig (Feldsphäre) und Wechsel zum Spiel für Zusatzaufgabe
        }else if((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            if(zusatzClick == false && missionClick == false){
                missionClick = false;
                FehlerAnzeige.tutorialtext_Spiel = "Bei knappen Ressourcen kannst du auch eine Zusatzaufgabe lösen, um weiter zu bauen! Öffne eine Zusatzaufgabe!";
                FehlerAnzeige.tutorialtext_ER = "Super! Im Baumenü sind nun Feldsphären freigeschaltet. Auch Feldastronauten leben bereits in der Siedlung. Auf geht's in die neue Mission!";
                bZusatz.interactable = true;
                pfeilSpiel.transform.localPosition = new Vector3(637,23,0);
                pfeilER.transform.localPosition = new Vector3(844,221,0);
                if(firstTime == true){
                    popUpGameObject(buttonZusatz);
                    firstTime = false;
                }
            }
            //Prüfe ob Zusatzfenster geklickt wurde
            if(zusatzClick){
                FehlerAnzeige.tutorialtext_Spiel = "Versuche nun die nächste Mission zu erfüllen! \n Tipp: Im Pausemenü findest du auch eine Spielhilfe!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen und mit Feldspähren Erträge erwirtschaften! \nTipp: Du benötigst 4 Feldsphären!";
                pfeilSpiel.SetActive(false);
                pfeilER.SetActive(false);
                //Prüfe, ob Missionsfenster geklickt wurde
                if(missionClick){
                    FehlerAnzeige.tutorialtext_Spiel = "Für Feldsphären benötigst du Feldastronauten. Hinweis: Rechts neben der Guthabenanzeige in der Infoleiste am oberen Bildschirmrand siehst du den Ertrag, der dir alle "+SpielInfos.neuerUmsatz+" Sol (Marstage) ausgezahlt wird.";
                    zusatzClick = false;
                    missionClick = false;
                }
            }
        
        //Zeitpunkt: Hinweis zum Bau von Forschungsstationen       
        }else if((Story.lvl[3] == true && Story.lvl[4] == false) && (Mission.missionsLevel[1] == true && Mission.missionsLevel[7] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Erfülle nun die Mission!";
            FehlerAnzeige.tutorialtext_ER = "Check deine neue Mission!"; 
            if(missionClick){
                    FehlerAnzeige.tutorialtext_Spiel = "Beachte, dass für jede Forschungsstation genau ein Forschungsastronaut (Symbol Reagenzglas) verantwortlich ist!";
                    zusatzClick = false;
                }
        
        //Falls kein Tutorialhinweis geplant ist, so gib bei erfülltem ER-Level einen Standarttext aus
        }else if((Story.lvl[4] == true && Story.lvl[5] == false) && (Mission.missionsLevel[7] == true && Mission.missionsLevel[8] == false)){
            FehlerAnzeige.tutorialtext_Spiel = " Spezialisiere die Forschungsstation auf Wohncontainer! In der Forschungsstationsanzeige findest du anschließend ein Fragezeichen. Klicke dieses, um Hilfe bei der Erstellung von Projekten zu erhalten.";
            FehlerAnzeige.tutorialtext_ER = "Los geht's mit den ersten Forschungen! Check deine Mission!"; 
        
        //Falls kein Tutorialhinweis geplant ist, so gib bei erfülltem ER-Level einen Standarttext aus
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Klasse! Erfülle nun die Mission!";
        
        //alle ER und Missions Level erfolgreich
        }else if (Story.lvl[7] == true && Mission.missionsLevel[5] == true){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
            FehlerAnzeige.tutorialtext_ER = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
        //Sonst: setzte alle Texte zurück
        }else{
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "";
        }
    }

    //Methode, die GameObject aufblopen lässt
    private void popUpGameObject(GameObject gameObject)
    {
        LeanTween.scale(gameObject,new Vector3(2 , 2),5).setEasePunch();
    }

    //Methode, die Bool true setzt, falls Missionsbutten gedrückt wurde
    public void ClickOnMission()
    {
        missionClick = true;
    }
    //Methode, die Bool true setzt, falls Zusatzaufgabenbutten gedrückt wurde
    public void ClickOnZusatz()
    {
        zusatzClick = true;
    }

    public void ClickOnBeschreibung()
    {
        beschreibungClick = true;
    }

}
