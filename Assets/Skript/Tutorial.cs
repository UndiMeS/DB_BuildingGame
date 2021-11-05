using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    
    public bool tutorialOff = false; //Bool, um Tutorial in der Entwicklung auszuschalten

    //Tutorial Hilfselemente;
    private bool firstTime = true;
    private static bool missionClick = false;
    private static bool missionTemp = false;
    private static bool zusatzClick = false;
    private static bool beschreibungClick = false;
    private static bool zurErdeClick = false;
    private static bool KonventionsClick = false;
    public bool ClickOnBeschreibungstext = false;
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
    public GameObject konventionsFenster;
    public GameObject buttonHilfeInGame;
    public RTS_Cam.RTS_Camera RTS_Camera;

    //Elemente die Markiert werden sollen
    public GameObject HighlightMarsToERD;
    public GameObject HighlightERDBeschreibung;
    public GameObject HighlightERDLeisteUnten;
    public GameObject HighlightERDToMars;
    public GameObject HighlightMarsMission;
    public GameObject HighlightWohncontainer;
    public GameObject HighlightBeziehung;
    public GameObject HighlightERKlick;

    public GameObject HighlightFeldastros;
    public GameObject HighlightTabelleAstros;
    public GameObject HighlightAnzFeldastros;

    //Pfeile
    public GameObject pfeilSpiel;
    public GameObject pfeilER;
    public GameObject pfeilLeisteUnten;
    public GameObject klickPfeil;
    public GameObject pfeilErtrag;
    public GameObject pfeilBeziehung;


    // Start is called before the first frame update
    void Start()
    {
        if (tutorialOff)
        {
            OffTutorial();
        }
        bZusatz = buttonZusatz.GetComponent<Button>();
        bMission = buttonMission.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialOff == false){
            ShowTutorial(); 
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            FehlerAnzeige.fehlertext = "Zum Löschen der Gebäudeauswahl, klicke links unten auf den Mülleimer!";
        }
    }
    private void OffTutorial()
    {
        bMission.interactable = true;
        containerKiller.SetActive(false);        
        wohncontainerHilfe.SetActive(false);
        WohncontainerTutorialPfeil.anzeigen = false;
        konventionsFenster.SetActive(false);
    }
    private void ShowTutorial()
    {
        //Vorbereitung der Komponenten
        containerKiller.SetActive(false);
        wohncontainerHilfe.SetActive(false);
        konventionsFenster.SetActive(false);

        //Zeitpunkt: Neues Spiel gestartet und Wechsel in ER-Editor
        if(Story.lvl[0] == false && Mission.missionsLevel[6] == false){
            
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;//zu ERD gehen          
            bZusatz.interactable = false;
            bMission.interactable = false;
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, folge dem roten Pfeil und öffne zuerst den ER-Editor!";

            //wenn noch ncith geöffnet, dann öffnet es sich
            konventionsFenster.SetActive(!KonventionsClick);

            //ERD
            
            if (!beschreibungClick ){  //in ERD angekommen
                FehlerAnzeige.tutorialtext_ER = "Öffne die Beschreibung rechts.";
                HighlightERDLeisteUnten.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
            
            if(beschreibungClick)
            { 
                if (!ClickOnBeschreibungstext)
                {
                    FehlerAnzeige.tutorialtext_ER = "Klicke in das Beschreibungsfeld, um Wörter zu markieren! Du kannst bis zu 10 Wörter anklicken.";
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDLeisteUnten.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = false;
                }
                else if (beschreibungER.activeSelf)
                {
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt.";
                    HighlightERDLeisteUnten.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = true;
                }
                else
                {
                    HighlightERDLeisteUnten.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = true;
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt.";
                }
            }
            missionClick = false; //vorbereitung für nächstes Level

            
        }
        //Zeitpunkt: ER-Level 0 (Wohncontainer) fertig und öffnen des Missionsfensters
        else if (Story.lvl[0] == true && Mission.missionsLevel[6] == false){
            //ausschalten aus den vorherrigen Level
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUnten.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = true;

            bZusatz.interactable = false;
            bMission.interactable = true;
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Tipp: Halte das Diagramm durch Verschiebung per Drag'n'Drop übersichtlich!\n Wechsel zurück in die Siedlung!"; 
            
            //Prüfe, ob Missionsbutten gedrückt wurde
            if(missionClick){
                containerKiller.SetActive(false);
                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn =false;
                HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = true;

                FehlerAnzeige.tutorialtext_Spiel = "Errichte nun einen Wohncontainer! Zum Bauen hast du ein Startguthaben von "+Testing.geld+". Du kannst dieses oben sehen.";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
            }
            else
            {
                containerKiller.SetActive(true);
            }         
        
        //Zeitpunkt: Mission 0 (Wohncontainer) fertig und Wechsel in ER-Editor
        }else if((Story.lvl[0] == true && Story.lvl[1] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn =false;
            HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = !beschreibungER.activeSelf; //an aus

            FehlerAnzeige.tutorialtext_Spiel = "Sehr gut! Um nun auch Astronauten einzufliegen, erweitere dein ER-Diagramm!";
                        
            Beziehung bez;
            if(ERErstellung.selectedGameObjekt.TryGetComponent(out bez))
            {
                FehlerAnzeige.tutorialtext_ER = "In Beziehung stehende Entitymengen könnne in der rechten unteren Ecke eingestellt werden.";
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
            else
            {
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
                FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung! \n Hinweis: Wird eine Entitymenge als 'schwach' gekennzeichnet, wird automatisch auch eine schwache Relation erzeugt! ";
            }

            missionClick = false;
            bZusatz.interactable = false;
        
        //Zeitpunkt: ER-Level 1 fertig (Astronauten) und wechsel zur Mission (Astronauten)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";

            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;

            //Prüfe, ob Missionsbutten gedrückt wurde
            if (missionClick){

                FehlerAnzeige.tutorialtext_Spiel = "Klicke auf den eben erbauten Wohncontainer. Neue Astronauten können über die Buttons mit entsprechenden Symbol eingeflogen werden. Den Namen erhälst du über 'Alle Astronauten'!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
                
                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;

                WohncontainerTutorialPfeil.anzeigen = true;
                if (wohncontainerGebaeudeanzeige.activeSelf)
                {
                    HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = true;
                    WohncontainerTutorialPfeil.anzeigen = false;
                    if (Testing.feldarbeiter >= 1)
                    {
                        HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = true;
                    }
                    if (Testing.feldarbeiter >= 5)
                    {
                        HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
                    }
                }
                else
                {
                    HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
                }
            }
            else
            {
                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
           

            bZusatz.interactable = false;
        
        //Zeitpunkt: Mission 1 (Astronauten einfliegen) fertig und Wechsel in ER-Editor (Feldsphäre)
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            WohncontainerTutorialPfeil.anzeigen = false;
            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Die Anzahl der zur Verfügung stehenden Astronauten kannst du in der Infoleiste ganz rechts sehen. Wechsel, wie nach jeder Mission in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere nun erneut dein ER-Diagramm, führe den gleichen Kreislauf aus ER- u. Spielmodus fort und erweitere deine Siedlung! \n Hinweis: Beim Anlegen einer Relationship musst du die entsprechenden Entitymengen noch auswählen und die gewünschte Kardinalität setzen.";
            if (beschreibungER.activeSelf)
            {
                pfeilER.SetActive(false);
                //pfeilER.transform.localPosition = new Vector3(166,20.5f,0);
            }
            else
            {
                pfeilER.SetActive(true);

            }
            pfeilER.transform.localPosition = new Vector3(590, 130, 0);
            pfeilSpiel.transform.localPosition = new Vector3(637,208,0);
            pfeilSpiel.SetActive(true);
            bZusatz.interactable = false;
            missionClick = false;
            Beziehung bez;
            if (ERErstellung.selectedGameObjekt.TryGetComponent(out bez) && ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
            {
                pfeilBeziehung.SetActive(true);
                FehlerAnzeige.tutorialtext_ER = "In Beziehung stehende Entitymengen könnne in der rechten unteren Ecke eingestellt werden.";
            }
            else
            {
                pfeilBeziehung.SetActive(false);
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";

            }

            //Zeitpunkt: ER-Level 2 fertig (Feldsphäre) und Wechsel zum Spiel für Zusatzaufgabe
        }
        else if((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            bZusatz.interactable = true;
            pfeilBeziehung.SetActive(false);
            if (zusatzClick == false && missionClick == false && missionTemp == false){
                FehlerAnzeige.tutorialtext_Spiel = "Bei knappen Ressourcen kannst du auch eine Zusatzaufgabe lösen, um weiter zu bauen! Öffne eine Zusatzaufgabe!";
                FehlerAnzeige.tutorialtext_ER = "Super! Im Baumenü sind nun Feldsphären freigeschaltet. Auch Feldastronauten leben bereits in der Siedlung. Auf geht's in die neue Mission!";
                pfeilSpiel.transform.localPosition = new Vector3(637,57,0);
                pfeilER.transform.localPosition = new Vector3(590,208,0);
                
            }
            //Prüfe ob Zusatzfenster geklickt wurde
            if(zusatzClick){
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen und mit Feldspähren Erträge erwirtschaften! \nTipp: Du benötigst 4 Feldsphären!";
                pfeilSpiel.SetActive(false);
                pfeilER.SetActive(false);
                missionTemp = true;
                //Prüfe, ob Missionsfenster geklickt wurde
                if(missionClick){
                    FehlerAnzeige.tutorialtext_Spiel = "Für Feldsphären benötigst du die eben eingeflogenen Feldastronauten. Hinweis: Rechts neben der Guthabenanzeige in der Infoleiste am oberen Bildschirmrand siehst du den Ertrag, der dir alle "+SpielInfos.neuerUmsatz+" Sol (Marstage) ausgezahlt wird.";
                    pfeilErtrag.SetActive(true);
                }else{
                    FehlerAnzeige.tutorialtext_Spiel = "Versuche nun die nächste Mission zu erfüllen! \n Tipp: Rechts und im Pausemenü findest du auch eine Spielhilfe!";
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
        
        }else if((Story.lvl[5] == true && Story.lvl[6] == false) && (Mission.missionsLevel[8] == true && Mission.missionsLevel[2] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Tipp: \n Lass dir die Tabelle aller Wohncontainer anzeigen, um Container mit noch freien Betten anhand der Containernummer in der Siedlung zu finden.";
            FehlerAnzeige.tutorialtext_ER = "";   
        
        }else if (Story.lvl[7] == true && Mission.missionsLevel[3] == true && Mission.missionsLevel[4] == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Starte nun mit dem Bau von Weidesphären!";

        }else if (Story.lvl[7] == true && Mission.missionsLevel[4] == true && Mission.missionsLevel[5] == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Deine Siedlung ist nun grundsätzlich aufgebaut, muss jedoch noch umfangreich erweitert werden. Tipp: Vielleicht kannst du durch intelligentes Forschen deine letzte Mission einfacher erfüllen!";
            FehlerAnzeige.tutorialtext_ER = "Du hast es geschafft. Dein ER-Diagramm ist für diese Siedlung komplett! Auf zu deinen letzten Missionen!";
        
        //Screenshots erstellen
        }else if (Story.lvl[7] == true && Mission.missionsLevel[5] == true && Mission.missionsLevel[9] == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Für eine vollumfängliche Dokumentation des Siedlungsbaus, erstelle sowohl für die Siedlung, als auch für das ER-Diagramm einen Screenshot (im jeweiligen Menü).";
            FehlerAnzeige.tutorialtext_ER = "Klasse! Für eine vollumfängliche Dokumentation des Siedlungsbaus, erstelle sowohl für die Siedlung, als auch für das ER-Diagramm einen Screenshot.";
            pfeilSpiel.SetActive(true);
            pfeilSpiel.transform.localPosition = new Vector3(637,279,0);

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
        //Falls kein Tutorialhinweis geplant ist, so gib bei erfülltem ER-Level einen Standarttext aus
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Erfülle nun die Mission!";
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == true){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "Wechsel zurück in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "";

        //Sonst: setzte alle Texte zurück
        }else{
            //FehlerAnzeige.tutorialtext_Spiel = "";
            //FehlerAnzeige.tutorialtext_ER = "";
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
        RTS_Camera.enabled = true;
        KonventionsClick = true;
    }


}
