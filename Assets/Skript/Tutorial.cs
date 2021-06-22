using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject pfeilSpiel;
    public GameObject pfeilER;
    private bool firstTime = true;
    private static bool missionClick = false;
    private bool rotationTemp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowTutorial();
    }

    private void ShowTutorial()
    {
        if(Story.lvl[0] == false && Mission.missionsLevel[6] == false){
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, öffne zuerst den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Erstelle ein ER-Diagramm anhand der ER-Beschreibung. Wenn Anzahl und Beschriftung einer Komponente stimmen, wird diese in der Checkbox abgehackt. Tipp: Bestimmte Wörter sind in der Beschreibung markierbar.";
            pfeilER.SetActive(true);
            pfeilSpiel.SetActive(true);
            missionClick = false;
        }else if(Story.lvl[0] == true && Mission.missionsLevel[6] == false){
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Wechsel zurück in die Siedlung!"; 
            if(missionClick){
                if(rotationTemp){
                    pfeilSpiel.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    rotationTemp = false;
                }
                pfeilSpiel.transform.localPosition = new Vector3(-635,-215,0);
                FehlerAnzeige.tutorialtext_Spiel = "Errichte zur Erfüllung deiner Mission einen Wohncontainer und gib den 1. Astronauten an!";
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
            missionClick = false;
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[6] == true && Mission.missionsLevel[0] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir deine neue Mission an!";
            FehlerAnzeige.tutorialtext_ER = "Fabelhaft! Wechsel nun erneut in die Siedlung und erfülle deine nächste Mission!";
            pfeilER.transform.localPosition = new Vector3(844,221,0);
            pfeilSpiel.transform.localPosition = new Vector3(637,100,0);
            if(missionClick){
                FehlerAnzeige.tutorialtext_Spiel = "Neue Astronauten können über die Buttons im Wohncontainer eingeflogen werden. Auch den Button zum Anzeigen der Astronautenliste findest du dort.";
                FehlerAnzeige.tutorialtext_ER = "Du musst erst die Mission erfüllen. Wechsel zurück in die Siedlung!";
                pfeilSpiel.SetActive(false);
            }
        }else if((Story.lvl[1] == true && Story.lvl[2] == false) && (Mission.missionsLevel[0] == true && Mission.missionsLevel[1] == false)){
            FehlerAnzeige.tutorialtext_Spiel = "Die ersten Siedlungsbewohner sind gelandet. Wechsel, wie nach jeder Mission in den ER-Editor!";
            FehlerAnzeige.tutorialtext_ER = "Das Tutorial ist abgeschlossen!\n Führe den gleichen Kreislauf aus ER- u. Spielmodus fort und erweitere deine Siedlung!";
            pfeilER.SetActive(true);
        }else if (Story.lvl[7] == false && ERAufgabe.missionCheck == false){
            FehlerAnzeige.tutorialtext_Spiel = "";
            FehlerAnzeige.tutorialtext_ER = "Klasse! Erfülle nun die Mission!";
        }
    }

    private void popUpGameObject(GameObject gameObject)
    {
        if (firstTime)
        {
            LeanTween.scale(gameObject,new Vector3(2 , 2),5).setEasePunch();
        }
        firstTime = false;
    }

    public void ClickOnMission()
    {
        missionClick = true;
    }

}
