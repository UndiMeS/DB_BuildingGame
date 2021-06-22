using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject pfeilSpiel;
    public GameObject pfeilER;
    private bool firstTime = true;
    private static bool missionClick = false;
    private static bool zusatzClick = false;
    private bool rotationTemp = true;
    public GameObject containerKiller;

    //Elemente für PopUp
    public GameObject buttonER;
    public GameObject buttonSpiel;
    public GameObject textER;
    public GameObject buttonMission;
    public GameObject container;
    public GameObject feld;
    public GameObject buttonZusatz;
    Button bZusatz;

    // Start is called before the first frame update
    void Start()
    {
        //OffTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        ShowTutorial();
    }
    private void OffTutorial()
    {
        bZusatz = buttonZusatz.GetComponent<Button>();
        bZusatz.interactable = true;
        containerKiller.SetActive(false);
        pfeilER.SetActive(false);
        pfeilSpiel.SetActive(false);
    }
    private void ShowTutorial()
    {
        if(Story.lvl[0] == false && Mission.missionsLevel[6] == false){
            bZusatz = buttonZusatz.GetComponent<Button>();
            bZusatz.interactable = false;
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, öffne zuerst den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erstelle ein ER-Diagramm anhand der ER-Beschreibung. Stimmen Anzahl und Beschriftung einer Komponente, wird diese in der Checkbox abgehackt. Tipp: Bestimmte Wörter sind in der Beschreibung durch antippen markierbar.";
            if(firstTime){
                popUpGameObject(buttonER);
                firstTime = false;
            }
            pfeilER.SetActive(true);
            pfeilSpiel.SetActive(true);
            missionClick = false;
        }else if(Story.lvl[0] == true && Mission.missionsLevel[6] == false){
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            containerKiller.SetActive(true);
            if(firstTime == false){
                popUpGameObject(buttonSpiel);
                firstTime = true;
            }
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Wechsel zurück in die Siedlung!"; 
            if(missionClick){
                if(rotationTemp){
                    pfeilSpiel.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    popUpGameObject(container);
                    rotationTemp = false;
                }
                containerKiller.SetActive(false);
                pfeilSpiel.transform.localPosition = new Vector3(-635,-215,0);
                FehlerAnzeige.tutorialtext_Spiel = "Errichte zur Erfüllung deiner Mission einen Wohncontainer!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
            }         
        }else if((Story.lvl[0] == true && Story.lvl[1] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            if(rotationTemp == false){
                    pfeilSpiel.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    rotationTemp = true;
            }
            pfeilSpiel.transform.localPosition = new Vector3(637,177,0);
            FehlerAnzeige.tutorialtext_Spiel = "Sehr gut! Um nun auch Astronauten einzufliegen, erweitere dein ER-Diagramm!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere das vorhandene Diagramm mit der neuen ER-Beschreibung!";
            pfeilER.transform.localPosition = new Vector3(166,20.5f,0);
            missionClick = false;
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";
            if(firstTime == true){
                popUpGameObject(buttonSpiel);
                firstTime = false;
            }
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            if(missionClick){
                FehlerAnzeige.tutorialtext_Spiel = "Neue Astronauten können über die Buttons im Wohncontainer eingeflogen werden. Auch den Button zum Anzeigen der Astronautenliste findest du dort.";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
                pfeilSpiel.SetActive(false);
            }
            //missionClick = false;
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Wechsel, wie nach jeder Mission in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erweitere nun erneut dein ER-Diagramm und führe den gleichen Kreislauf aus ER- u. Spielmodus fort und erweitere deine Siedlung!";
            pfeilER.SetActive(false);
            pfeilSpiel.transform.localPosition = new Vector3(637,177,0);
            pfeilSpiel.SetActive(true);
        }else if((Story.lvl[2] == true && Story.lvl[3] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            if(zusatzClick == false){
                missionClick = false;
                FehlerAnzeige.tutorialtext_Spiel = "Bei knappen Ressourcen kannst du auch eine Zusatzaufgabe lösen, um weiter zu bauen! Öffne eine Zusatzaufgabe!";
                FehlerAnzeige.tutorialtext_ER = "Super! Im Baumenü sind nun Feldsphären freigeschaltet. Auf geht's in die neue Mission!";
                bZusatz.interactable = true;
                pfeilSpiel.transform.localPosition = new Vector3(637,23,0);
                pfeilER.transform.localPosition = new Vector3(844,221,0);
                if(firstTime == false){
                    popUpGameObject(buttonZusatz);
                    firstTime = true;
                }
            }
            if(zusatzClick){
                FehlerAnzeige.tutorialtext_Spiel = "Das Tutorial ist beendet! Versuche nun die nächste Mission zu erfüllen! \n Tipp: Im Pausemenü findest du auch eine Spielhilfe!";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen und mit Feldspähren Erträge erwirtschaften!";
                pfeilSpiel.SetActive(false);
                pfeilER.SetActive(false);
            }   
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false){
            pfeilER.SetActive(false);
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Klasse! Erfülle nun die Mission!";
        }else{
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "";
        }
    }

    private void popUpGameObject(GameObject gameObject)
    {
        LeanTween.scale(gameObject,new Vector3(2 , 2),5).setEasePunch();
    }

    public void ClickOnMission()
    {
        missionClick = true;
    }
    public void ClickOnZusatz()
    {
        zusatzClick = true;
    }

}
