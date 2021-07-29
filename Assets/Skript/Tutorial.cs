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
    private static bool missionTemp = false;
    private static bool zusatzClick = false;
    private static bool beschreibungClick = false;
    private static bool zurErdeClick = false;
    private static bool KonventionsClick = false;
    private bool rotationTemp = true;
    public GameObject containerKiller;
    public GameObject wohncontainerHilfe;
    public GameObject wohncontainerHilfeAlle;
    public GameObject pfeilLeisteUnten;
    public GameObject klickPfeil;
    public GameObject pfeilErtrag;

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
    public GameObject konventionsFenster;
    public GameObject buttonHilfeInGame;
    

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
        WohncontainerTutorialPfeil.anzeigen = false;
        konventionsFenster.SetActive(false);
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
        pfeilLeisteUnten.SetActive(false);
        klickPfeil.SetActive(false);
        konventionsFenster.SetActive(false);        

        //Zeitpunkt: Neues Spiel gestartet und Wechsel in ER-Editor
        if(Story.lvl[0] == false && Mission.missionsLevel[6] == false){
            if(KonventionsClick == false){
                konventionsFenster.SetActive(true);
            }else{
                konventionsFenster.SetActive(false);        
            }
            bZusatz = buttonZusatz.GetComponent<Button>();
            bZusatz.interactable = false;
            bMission.interactable = false;
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, folge dem roten Pfeil und öffne zuerst den ER-Editor!";
            if(beschreibungClick == false){
                FehlerAnzeige.tutorialtext_ER = "Erstelle ein ER-Diagramm mit der Leiste am unteren Bildschrimrand anhand der ER-Beschreibung (scrollbar!). Öffne die Beschreibung (roter Pfeil)";
                pfeilLeisteUnten.SetActive(true);
                klickPfeil.SetActive(false);

            }
            
            if(beschreibungClick){
                if(!FehlerAnzeige.tutorialtext_ER.Equals("Du kannst für dieses Teildiagramm auf noch 10 Wörter klicken, um richtige Schlüsselwörter herauszufinden und zu markieren!")){
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt. 'Primärschlüssel' wird abgehakt, wenn die entsprechenden Attribute richtig gekennzeichnet sind.\n Tipp: Klicke in das Beschreibungsfeld!";
                    pfeilLeisteUnten.SetActive(false);
                    klickPfeil.SetActive(true);
                }   
            }
            
            
            if(beschreibungER.activeSelf){
                pfeilER.SetActive(false);
            }else{
                pfeilER.SetActive(true);
                klickPfeil.SetActive(false);
            }
            

            
            pfeilSpiel.SetActive(true);
            missionClick = false;
        
        //Zeitpunkt: ER-Level 0 (Wohncontainer) fertig und öffnen des Missionsfensters
        }else if(Story.lvl[0] == true && Mission.missionsLevel[6] == false){
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            pfeilER.SetActive(true);
            pfeilER.transform.localPosition = new Vector3(612,177,0);
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
            pfeilER.transform.localPosition = new Vector3(612,100,0);

            if(beschreibungER.activeSelf){
                pfeilER.SetActive(false);
                //pfeilER.transform.localPosition = new Vector3(166,20.5f,0);
            }else{
                pfeilER.SetActive(true);
                
            }
            missionClick = false;
            bZusatz.interactable = false;
        
        //Zeitpunkt: ER-Level 1 fertig (Astronauten) und wechsel zur Mission (Astronauten)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";
            pfeilER.SetActive(true);
            pfeilER.transform.localPosition = new Vector3(612,177,0);
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            //Prüfe, ob Missionsbutten gedrückt wurde
            if(missionClick){

                FehlerAnzeige.tutorialtext_Spiel = "Klicke auf den eben erbauten Wohncontainer. Neue Astronauten können über die Buttons mit entsprechenden Symbol eingeflogen werden. Den Namen erhälst du über 'Alle Astronauten'!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
                pfeilSpiel.SetActive(false);
                WohncontainerTutorialPfeil.anzeigen = true;
                if(wohncontainerGebaeudeanzeige.activeSelf){
                    wohncontainerHilfe.SetActive(true);
                    WohncontainerTutorialPfeil.anzeigen = false;
                    if(Testing.feldarbeiter >= 1){
                        wohncontainerHilfeAlle.SetActive(true);
                        WohncontainerTutorialPfeil.anzeigen = false;
                        
                    }
                }
            }
            
            bZusatz.interactable = false;
        
        //Zeitpunkt: Mission 1 (Astronauten einfliegen) fertig und Wechsel in ER-Editor (Feldsphäre)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            WohncontainerTutorialPfeil.anzeigen = false;
            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Die Anzahl der zur Verfügung stehenden Astronauten kannst du in der Infoleiste ganz rechts sehen. Wechsel, wie nach jeder Mission in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere nun erneut dein ER-Diagramm, führe den gleichen Kreislauf aus ER- u. Spielmodus fort und erweitere deine Siedlung! \n Hinweis: Beim Anlegen einer Relationship musst du die entsprechenden Entitymengen noch auswählen und die gewünschte Kardinalität setzen.";
            pfeilER.SetActive(false);
            pfeilSpiel.transform.localPosition = new Vector3(637,177,0);
            pfeilSpiel.SetActive(true);
            bZusatz.interactable = false;
            missionClick = false;
        
        //Zeitpunkt: ER-Level 2 fertig (Feldsphäre) und Wechsel zum Spiel für Zusatzaufgabe
        }else if((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            bZusatz.interactable = true;
            if(zusatzClick == false && missionClick == false && missionTemp == false){
                FehlerAnzeige.tutorialtext_Spiel = "Bei knappen Ressourcen kannst du auch eine Zusatzaufgabe lösen, um weiter zu bauen! Öffne eine Zusatzaufgabe!";
                FehlerAnzeige.tutorialtext_ER = "Super! Im Baumenü sind nun Feldsphären freigeschaltet. Auch Feldastronauten leben bereits in der Siedlung. Auf geht's in die neue Mission!";
                pfeilSpiel.transform.localPosition = new Vector3(637,23,0);
                pfeilER.transform.localPosition = new Vector3(612,177,0);
                
            }
            //Prüfe ob Zusatzfenster geklickt wurde
            if(zusatzClick){
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen und mit Feldspähren Erträge erwirtschaften! \nTipp: Du benötigst 4 Feldsphären!";
                pfeilSpiel.SetActive(false);
                pfeilER.SetActive(false);
                missionTemp = true;
                //Prüfe, ob Missionsfenster geklickt wurde
                if(missionClick){
                    FehlerAnzeige.tutorialtext_Spiel = "Für Feldsphären benötigst du Feldastronauten. Hinweis: Rechts neben der Guthabenanzeige in der Infoleiste am oberen Bildschirmrand siehst du den Ertrag, der dir alle "+SpielInfos.neuerUmsatz+" Sol (Marstage) ausgezahlt wird.";
                    pfeilErtrag.SetActive(true);
                }else{
                    FehlerAnzeige.tutorialtext_Spiel = "Versuche nun die nächste Mission zu erfüllen! \n Tipp: Unten links und im Pausemenü findest du auch eine Spielhilfe!";
                    if(firstTime == true){
                        popUpGameObject(buttonHilfeInGame);
                        firstTime = false;
                    }
                }
            }
        }else if((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[1] == true && Mission.missionsLevel[7] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Erweitere erneut dein ER-Diagramm!";
            FehlerAnzeige.tutorialtext_ER = "";
            pfeilErtrag.SetActive(false);
                
        //Zeitpunkt: Hinweis zum Bau von Forschungsstationen       
        }else if((Story.lvl[3] == true && Story.lvl[4] == false) && (Mission.missionsLevel[1] == true && Mission.missionsLevel[7] == false)){
            if(missionTemp){
                missionClick = false;
                missionTemp = false;
            }
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Erfülle nun die Mission!";
            FehlerAnzeige.tutorialtext_ER = "Du kannst nun Forschungsstationen errichten! Check deine neue Mission!"; 
            if(missionClick){
                    FehlerAnzeige.tutorialtext_Spiel = "Beachte, dass für jede Forschungsstation genau ein Forschungsastronaut (Symbol Reagenzglas) verantwortlich ist!";
                    zusatzClick = false;
                }
        
        }else if((Story.lvl[4] == true && Story.lvl[5] == false) && (Mission.missionsLevel[7] == true && Mission.missionsLevel[8] == false)){
            FehlerAnzeige.tutorialtext_Spiel = " Spezialisiere die Forschungsstation auf Wohncontainer! In der Forschungsstationsanzeige findest du anschließend ein Fragezeichen. Klicke dieses, um Hilfe bei der Erstellung von Projekten zu erhalten.";
            FehlerAnzeige.tutorialtext_ER = "Los geht's mit den ersten Forschungen! Check deine Mission!"; 
        
        }else if((Story.lvl[5] == true && Story.lvl[6] == false) && (Mission.missionsLevel[7] == true && Mission.missionsLevel[8] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Tipp: \n Lass dir die Tabelle aller Wohncontainer anzeigen, um Container mit noch freien Betten anhand der Containernummer in der Siedlung zu finden.";
            FehlerAnzeige.tutorialtext_ER = ""; 

        /*
        //Falls kein Tutorialhinweis geplant ist, so gib bei erfülltem ER-Level einen Standarttext aus
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Erfülle nun die Mission!";
         */      
        
        }else if (Story.lvl[7] == true && Mission.missionsLevel[4] == true && Mission.missionsLevel[5] == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Deine Siedlung ist nun grundsätzlich aufgebaut, muss jedoch noch umfangreich erweitert werden. Los geht's mit der letzten Mission!";
            FehlerAnzeige.tutorialtext_ER = "Du hast es geschafft. Dein ER-Diagramm ist für diese Siedlung komplett! Auf zu deinen letzten Missionen!";
        
        //Screenshots erstellen
        }else if (Story.lvl[7] == true && Mission.missionsLevel[5] == true && Mission.missionsLevel[9] == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Für eine vollumfängliche Dokumentation des Siedlungsbaus, erstelle sowohl für die Siedlung, als auch für das ER-Diagramm einen Screenshot (im jeweiligen Menü).";
            FehlerAnzeige.tutorialtext_ER = "Klasse! Für eine vollumfängliche Dokumentation des Siedlungsbaus, erstelle sowohl für die Siedlung, als auch für das ER-Diagramm einen Screenshot.";
            pfeilSpiel.SetActive(true);
            pfeilSpiel.transform.localPosition = new Vector3(637,253,0);

        //Zur Erde zurückkehren
        }else if (Story.lvl[7] == true && Mission.missionsLevel[9] == true){
            pfeilER.SetActive(false);
            pfeilSpiel.SetActive(false);

            if(zurErdeClick == false){
                FehlerAnzeige.tutorialtext_Spiel = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
                FehlerAnzeige.tutorialtext_ER = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
            }else{
                FehlerAnzeige.tutorialtext_Spiel = "Herzlichen Glückwunsch zu deinem Missionszertifikat! Das Spiel wird nun automatisch beendet!";
            }
        
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
    
    public void ClickOnZurErde()
    {
        zurErdeClick = true;
    }

    public void ClickOnKonvention()
    {
        KonventionsClick = true;
    }

}
