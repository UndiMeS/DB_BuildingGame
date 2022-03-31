using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{

    public bool tutorialOff = false; //Bool, um Tutorial in der Entwicklung auszuschalten

    //Tutorial Hilfselemente;
    private bool firstTime = true;
    public static bool missionClick = false;
    private static bool missionTemp = false;
    private static bool zusatzClick = false;
    private static bool beschreibungClick = false;
    private static bool zurErdeClick = false;
    private static bool KonventionsClick = false;
    public bool ClickOnBeschreibungstext = false;
    public GameObject containerKiller;

    //Elemente aus Spiel
    public GameObject buttonER;
    public GameObject buttonSpiel;
    public GameObject textER;
    public GameObject buttonMission;
    Button bMission;
    public Image MissionButtonImage;

    public GameObject container;
    public GameObject feld;
    public GameObject buttonZusatz;
    public Image ZusatzBackground;
    public Image ZusatzIcon;
    Button bZusatz;
    public GameObject beschreibungER;
    public GameObject wohncontainerGebaeudeanzeige;
    public GameObject wohncontainerGebaeudeanzeigeTransparent;
    public GameObject konventionsFenster;
    public GameObject buttonHilfeInGame;
    public RTS_Cam.RTS_Camera RTS_Camera;
    public GameObject buttonHilfeERD;

    //Elemente die Markiert werden sollen
    public GameObject HighlightMarsToERD;
    public GameObject HighlightERDBeschreibung;
    public GameObject HighlightERDLeisteUntenEntity;
    public GameObject HighlightERDLeisteUntenAttribut;
    public GameObject HighlightERDLeisteUntenBeziehung;
    public GameObject HighlightERDToMars;
    public GameObject HighlightMarsMission;
    public GameObject HighlightWohncontainer;
    public GameObject HighlightBeziehung;
    public GameObject HighlightERKlick;

    public GameObject HighlightFeldastros;
    public GameObject HighlightTabelleAstros;
    public GameObject HighlightAnzFeldastros;

    public GameObject HighlightZusatz;
    public GameObject HighlightErtrag;

    public GameObject HighlightMarsOption;
    public GameObject HighlightERDOption;

    public SaveLoad saveLoad;
    public Zertifikat zertifikat;


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
        if (tutorialOff == false)
        {
            ShowTutorial();
        }
        else
        {
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightErtrag.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = false;

        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            FehlerAnzeige.fehlertext = "Zum Löschen der Gebäudeauswahl, klicke links unten auf den Mülleimer!";
        }
    }
    private void OffTutorial()
    {
        bZusatz = buttonZusatz.GetComponent<Button>();
        bMission = buttonMission.GetComponent<Button>();
        bMission.interactable = true;
        bZusatz.interactable = true;
        containerKiller.SetActive(false);
        WohncontainerTutorialPfeil.anzeigen = false;
        konventionsFenster.SetActive(false);
    }
    private void ShowTutorial()
    {

        //Vorbereitung der Komponenten
        containerKiller.SetActive(false);
        //konventionsFenster.SetActive(false);


        //Screenshot
        if (ZertifikatErstellen.abkuerzer || (Story.lvl[7] == true && Mission.missionsLevel[5] == true && Mission.missionsLevel[9] == false))
        {
            zertifikat.ChangeToScreenshot();
            bMission.enabled = true;


            FehlerAnzeige.tutorialtext_Spiel = "Erstelle sowohl für die Siedlung, als auch für das ER-Diagramm einen Screenshot. Achte darauf, dass deine ganze Siedlung sichtbar ist.";
            FehlerAnzeige.tutorialtext_ER = "Achte darauf, dass deine ganzes ER-Modell sichtbar ist.";


            HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = true;

            
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;            
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightErtrag.GetComponent<HighlightButton>().highlinghtingOn = false;

            if (Mission.screenshotER && !Mission.screenshotSpiel)
            {
                HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            }else if (!Mission.screenshotER && Mission.screenshotSpiel)
            {
                HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
            else if (!Mission.screenshotER && !Mission.screenshotSpiel)
            {
                HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            }
            else if (Mission.screenshotER && Mission.screenshotSpiel)
            {
                HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;
                HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            }


        }//zur Erde zurückkehren
        else if ((Story.lvl[7] == true && Mission.missionsLevel[9] == true) || Mission.screenshotMission)
        {
            HighlightMarsOption.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDOption.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;

            if (zurErdeClick == false)
            {
                FehlerAnzeige.tutorialtext_Spiel = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
                FehlerAnzeige.tutorialtext_ER = "Hervorragend! Deine Marsmission ist erfolgreich beendet. Du kannst nun noch weiter deine Siedlung erweitern oder zur Erde zurückkehren, um dein Missionszertifikat zu erhalten!";
            }
            else
            {
                FehlerAnzeige.tutorialtext_Spiel = "Herzlichen Glückwunsch zu deinem Missionszertifikat! Das Spiel wird nun automatisch beendet!";
            }
            //Falls kein Tutorialhinweis geplant ist, so gib bei erfülltem ER-Level einen Standarttext aus
        }
        //Zeitpunkt: Neues Spiel gestartet und Wechsel in ER-Editor
        else if (Story.lvl[0] == false && Mission.missionsLevel[6] == false)
        {

            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;//zu ERD gehen
            bZusatz.enabled = false;
            bMission.enabled = false;

            Color temp = ZusatzBackground.color;
            temp.a = 0.5f;
            ZusatzBackground.color=temp;

            temp = ZusatzIcon.color;
            temp.a = 0.5f;
            ZusatzIcon.color = temp;
            
            temp = MissionButtonImage.color;
            temp.a = 0.5f;
            MissionButtonImage.color = temp;

            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, folge den Markierungen und öffne zuerst den ER-Editor!";

            //wenn noch ncith geöffnet, dann öffnet es sich
            if (!KonventionsClick)
            {
                konventionsFenster.SetActive(!KonventionsClick);
            }

            //ERD

            if (!beschreibungClick)
            {  //in ERD angekommen
                FehlerAnzeige.tutorialtext_ER = "Öffne die Beschreibung rechts.";
                HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = true;
            }

            if (beschreibungClick)
            {
                if (!ClickOnBeschreibungstext)
                {
                    FehlerAnzeige.tutorialtext_ER = "Klicke in das Beschreibungsfeld, um Wörter zu markieren! Du kannst bis zu 10 Wörter anklicken.";
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = false;
                }
                else if (beschreibungER.activeSelf)
                {
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt.";
                    HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = true;
                }
                else
                {
                    HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
                    HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = true;
                    HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;
                    beschreibungER.transform.GetChild(0).GetChild(0).GetComponent<ScrollRect>().enabled = true;
                    FehlerAnzeige.tutorialtext_ER = "Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehakt.";
                }
            }
            missionClick = false; //vorbereitung für nächstes Level


        }
        //Zeitpunkt: ER-Level 0 (Wohncontainer) fertig und öffnen des Missionsfensters
        else if (Story.lvl[0] == true && Mission.missionsLevel[6] == false)
        {
            //ausschalten aus den vorherrigen Level
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenEntity.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenAttribut.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDLeisteUntenBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERKlick.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = true;

            bZusatz.enabled = false;
            bMission.enabled = true;

            Color temp = ZusatzBackground.color;
            temp.a = 0.5f;
            ZusatzBackground.color = temp;

            temp = ZusatzIcon.color;
            temp.a = 0.5f;
            ZusatzIcon.color = temp;

            temp = MissionButtonImage.color;
            temp.a = 1f;
            MissionButtonImage.color = temp;


            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Tipp: Halte das Diagramm durch Verschiebung per Drag'n'Drop übersichtlich!\n Wechsel zurück in die Siedlung!";

            //Prüfe, ob Missionsbutten gedrückt wurde
            if (missionClick)
            {
                Story.ErstesHaus = true;
                containerKiller.SetActive(false);
                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;
                HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = true;

                FehlerAnzeige.tutorialtext_Spiel = "Errichte nun einen Wohncontainer! Zum Bauen hast du ein Startguthaben von " + Testing.geld + ". Du kannst dieses oben sehen.";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
            }
            else
            {
                Story.ErstesHaus = false;
                containerKiller.SetActive(true);
            }

            //Zeitpunkt: Mission 0 (Wohncontainer) fertig und Wechsel in ER-Editor
        }
        else if ((Story.lvl[0] == true && Story.lvl[1] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false))
        {

            Story.ErstesHaus = false;

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightWohncontainer.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = !beschreibungER.activeSelf; //an aus

            FehlerAnzeige.tutorialtext_Spiel = "Sehr gut! Um nun auch Astronauten einzufliegen, erweitere dein ER-Diagramm!";

            Beziehung bez;
            if (ERErstellung.selectedGameObjekt.TryGetComponent(out bez) && !ERAufgabe.beziehungKardRichtig)
            {
                if (Sprache.sprache == "en")
                {
                    FehlerAnzeige.tutorialtext_ER = "In Realtion stehende Entitymengen könnne in der rechten unteren Ecke eingestellt werden.";
                }
                else
                {
                    FehlerAnzeige.tutorialtext_ER = "In Beziehung stehende Entitätsmengen könnne in der rechten unteren Ecke eingestellt werden.";
                }
               
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
            else
            {
                if (OhneSchwacheEntity.schwachAus)
                {
                    FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung!";
                }
                else
                {
                    if (Sprache.sprache == "en")
                    {
                        FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung! \n Hinweis: Wird eine Entitymenge als 'schwach' gekennzeichnet, wird automatisch auch eine schwache Relationship erzeugt! ";
                    }
                    else
                    {
                        FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung! \n Hinweis: Wird eine Entitätsmenge als 'schwach' gekennzeichnet, wird automatisch auch eine schwache Beziehung erzeugt! ";
                    }
                    
                }
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            }

            missionClick = false;
            bMission.enabled = true;

            bZusatz.enabled = false;
            Color temp = ZusatzBackground.color;
            temp.a = 0.5f;
            ZusatzBackground.color = temp;

            temp = ZusatzIcon.color;
            temp.a = 0.5f;
            ZusatzIcon.color = temp;

            temp = MissionButtonImage.color;
            temp.a = 1f;
            MissionButtonImage.color = temp;
            GebaeudeAnzeige.allesAus = true;

            //Zeitpunkt: ER-Level 1 fertig (Astronauten) und wechsel zur Mission (Astronauten)
        }
        else if ((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false))
        {
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";

            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;

            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = true;

            GebaeudeAnzeige.allesAus = false;

            //Prüfe, ob Missionsbutten gedrückt wurde
            if (missionClick)
            {
                FehlerAnzeige.tutorialtext_Spiel = "Klicke auf den eben erbauten Wohncontainer. Neue Astronauten können über die Buttons mit entsprechenden Symbol eingeflogen werden. Den Namen erhälst du über 'Alle Astronauten'!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";

                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;
                if (wohncontainerGebaeudeanzeige.activeSelf)
                {
                    HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = true;

                    WohncontainerTutorialPfeil.anzeigen = false;
                    if (Testing.feldarbeiter >= 1)
                    {
                        HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = true;
                    }
                    else
                    {
                        HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = false;
                    }
                    if (Testing.feldarbeiter >= 5)
                    {
                        HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
                    }
                    else
                    {
                        HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = true;
                    }
                }
                else
                {
                    WohncontainerTutorialPfeil.anzeigen = true;
                }
            }
            else
            {
                HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = true;
            }


            bZusatz.enabled = false;
            bMission.enabled = true;

            Color temp = ZusatzBackground.color;
            temp.a = 0.5f;
            ZusatzBackground.color = temp;

            temp = ZusatzIcon.color;
            temp.a = 0.5f;
            ZusatzIcon.color = temp;

            temp = MissionButtonImage.color;
            temp.a = 1;
            MissionButtonImage.color = temp;

            //Zeitpunkt: Mission 1 (Astronauten einfliegen) fertig und Wechsel in ER-Editor (Feldsphäre)
        }
        else if ((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false))
        {

            HighlightAnzFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightFeldastros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightTabelleAstros.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDToMars.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsMission.GetComponent<HighlightButton>().highlinghtingOn = false;
            WohncontainerTutorialPfeil.anzeigen = false;

            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Wechsel, wie nach jeder Mission in den ER-Editor!";
            if (Sprache.sprache == "en")
            {
                FehlerAnzeige.tutorialtext_ER = "Beim Anlegen einer Beziehung musst du die entsprechenden Entitymengen noch auswählen und die gewünschte Kardinalität setzen.";
            }
            else
            {
                FehlerAnzeige.tutorialtext_ER = "Beim Anlegen einer Beziehung musst du die entsprechenden Entitätsmengen noch auswählen und die gewünschte Kardinalität setzen.";
            }

            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = true;
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = !beschreibungER.activeSelf; //an aus

            bZusatz.enabled = true;
            bMission.enabled = true;

            Color temp = ZusatzBackground.color;
            temp.a = 1;
            ZusatzBackground.color = temp;

            temp = ZusatzIcon.color;
            temp.a = 1;
            ZusatzIcon.color = temp;

            temp = MissionButtonImage.color;
            temp.a = 1;
            MissionButtonImage.color = temp;

            missionClick = false;

            Beziehung bez;
            if (ERErstellung.selectedGameObjekt.TryGetComponent(out bez) && !ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt) && !ERAufgabe.beziehungKardRichtig)
            {
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = true;
            }
            else
            {
                HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            }



            //Zeitpunkt: ER-Level 2 fertig (Feldsphäre) und Wechsel zum Spiel für Zusatzaufgabe
        }
        else if ((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false))
        {
            bZusatz.interactable = true;



            bZusatz.enabled = true;
            bMission.enabled = true;

            Color temp = ZusatzBackground.color;
            temp.a = 1;
            ZusatzBackground.color = temp;

            temp = ZusatzIcon.color;
            temp.a = 1;
            ZusatzIcon.color = temp;

            temp = MissionButtonImage.color;
            temp.a = 1;
            MissionButtonImage.color = temp;

            HighlightBeziehung.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightMarsToERD.GetComponent<HighlightButton>().highlinghtingOn = false;
            HighlightERDBeschreibung.GetComponent<HighlightButton>().highlinghtingOn = false;

            if (firstTime == true)
            {
                popUpGameObject(buttonHilfeERD);
                firstTime = false;
            }

            if (zusatzClick == false && missionClick == false && missionTemp == false)
            {
                FehlerAnzeige.tutorialtext_Spiel = "Bei knappen Ressourcen kannst du auch eine Zusatzaufgabe lösen, um weiter zu bauen! Öffne eine Zusatzaufgabe!";
                FehlerAnzeige.tutorialtext_ER = "Super! Im Baumenü sind nun Feldsphären freigeschaltet. Auf geht's in die neue Mission!";
                HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = true;
            }


            //Prüfe ob Zusatzfenster geklickt wurde
            if (zusatzClick)
            {
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen und mit Feldspähren Erträge erwirtschaften! \nTipp: Du benötigst 4 Feldsphären!";
                if (Testing.geld < 50)
                {
                    HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = true;
                }
                else
                {
                    HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = false;
                }
                missionTemp = true;
                //Prüfe, ob Missionsfenster geklickt wurde
                if (missionClick)
                {
                    FehlerAnzeige.tutorialtext_Spiel = "Für Feldsphären benötigst du die eben eingeflogenen Feldastronauten. Hinweis: Am oberen Bildschirmrand siehst du den Ertrag, der dir alle " + SpielInfos.neuerUmsatz + " Sol (Marstage) ausgezahlt wird.";
                    HighlightErtrag.GetComponent<HighlightButton>().highlinghtingOn = true;
                }
                else
                {
                    FehlerAnzeige.tutorialtext_Spiel = "Versuche nun die nächste Mission zu erfüllen! \n Tipp: Rechts und im Pausemenü findest du auch eine Spielhilfe!";
                    if (firstTime == true)
                    {
                        popUpGameObject(buttonHilfeInGame);
                        firstTime = false;
                    }
                }
            }


        }
        else if ((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[1] == true && Mission.missionsLevel[7] == false))
        {
            HighlightZusatz.GetComponent<HighlightButton>().highlinghtingOn = false;
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Erweitere erneut dein ER-Diagramm!";
            FehlerAnzeige.tutorialtext_ER = "";
            HighlightErtrag.GetComponent<HighlightButton>().highlinghtingOn = false;

            //Zeitpunkt: Hinweis zum Bau von Forschungsstationen       
        }
        else if ((Story.lvl[3] == true && Story.lvl[4] == false) && (Mission.missionsLevel[1] == true && Mission.missionsLevel[7] == false))
        {
            if (missionTemp)
            {
                missionClick = false;
                missionTemp = false;
            }
            FehlerAnzeige.tutorialtext_Spiel = "Klasse! Erfülle nun die Mission!";
            FehlerAnzeige.tutorialtext_ER = "Du kannst nun Forschungsstationen errichten! Check deine neue Mission!";
            if (missionClick)
            {
                FehlerAnzeige.tutorialtext_Spiel = "Beachte, dass für jede Forschungsstation genau ein Forschungsastronaut (Symbol Reagenzglas) verantwortlich ist!";
                zusatzClick = false;
            }

        }
        else if ((Story.lvl[4] == true && Story.lvl[5] == false) && (Mission.missionsLevel[7] == true && Mission.missionsLevel[8] == false))
        {
            FehlerAnzeige.tutorialtext_Spiel = " Spezialisiere die Forschungsstation auf Wohncontainer! In der Forschungsstationsanzeige findest du anschließend ein Fragezeichen. Klicke dieses, um Hilfe bei der Erstellung von Projekten zu erhalten.";
            FehlerAnzeige.tutorialtext_ER = "Los geht's mit den ersten Forschungen! Check deine Mission!";

        }
        else if ((Story.lvl[5] == true && Story.lvl[6] == false) && (Mission.missionsLevel[8] == true && Mission.missionsLevel[2] == false))
        {
            FehlerAnzeige.tutorialtext_Spiel = "Tipp: \n Lass dir die Tabelle aller Wohncontainer anzeigen, um Container mit noch freien Betten anhand der Containernummer in der Siedlung zu finden.";
            FehlerAnzeige.tutorialtext_ER = "";

        }
        else if (Story.lvl[7] == true && Mission.missionsLevel[3] == true && Mission.missionsLevel[4] == false)
        {

            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Starte nun mit dem Bau von Weidesphären!";

        }
        else if (Story.lvl[7] == true && Mission.missionsLevel[4] == true && Mission.missionsLevel[5] == false)
        {

            FehlerAnzeige.tutorialtext_Spiel = "Deine Siedlung ist nun grundsätzlich aufgebaut, muss jedoch noch umfangreich erweitert werden. Tipp: Vielleicht kannst du durch intelligentes Forschen deine letzte Mission einfacher erfüllen!";
            FehlerAnzeige.tutorialtext_ER = "Du hast es geschafft. Dein ER-Diagramm ist für diese Siedlung komplett! Auf zu deinen letzten Missionen!";

        }
        
        else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false)
        {
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Erfülle nun die Mission!";
        }
        else if (Story.lvl[7] == false && ERAufgabe.missionCheck == true)
        {
            FehlerAnzeige.tutorialtext_Spiel = "Wechsel zurück in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "";

            //Sonst: setzte alle Texte zurück
        }
        else
        {
            //FehlerAnzeige.tutorialtext_Spiel = "";
            //FehlerAnzeige.tutorialtext_ER = "";
        }
    }

    //Methode, die GameObject aufblopen lässt
    private void popUpGameObject(GameObject gameObject)
    {
        LeanTween.scale(gameObject, new Vector3(2, 2), 5).setEasePunch();
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
        if (!ZertifikatErstellen.abkuerzer)
        {
            saveLoad.speichern();
        }
    }

    public void ClickOnKonvention()
    {
        RTS_Camera.enabled = true;
        KonventionsClick = true;
    }


}
