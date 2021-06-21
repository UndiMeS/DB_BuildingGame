using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static bool[] step = new bool[12];

    public GameObject pfeil;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ShowTutorialSpiel();
        //ShowTutorialER();
    }

    private void ShowTutorialSpiel()
    {
        if(ERAufgabe.missionCheck == true && Mission.missionsLevel[0] == false){
            FehlerAnzeige.tutorialtext_Spiel = "Um den Siedlungsbau zu beginnen, öffne den ER-Editor!";
        }else if(ERAufgabe.missionCheck == false && Mission.missionsLevel[0] == false){
            FehlerAnzeige.tutorialtext_Spiel = "Schau dir nun deine Mission an!";
        }else if(ERAufgabe.missionCheck == true && Mission.missionsLevel[0] == true){
            FehlerAnzeige.tutorialtext_Spiel = "test";
        }
    }
    private void ShowTutorialER()
    {
        if(ERAufgabe.level_ER[0] == false && ERAufgabe.level_ER[1] == false){
            FehlerAnzeige.tutorialtext_ER = "Erstelle ein ER-Diagramm anhand der ER-Beschreibung. Wenn Anzahl und Beschriftung einer Komponente stimmen, wird diese in der Checkbox abgehackt.";
        }else if(ERAufgabe.level_ER[0] == true && ERAufgabe.level_ER[1] == false){
            FehlerAnzeige.tutorialtext_ER = "Sehr gut! Wechsel zurück in die Siedlung!";
        }else if(ERAufgabe.level_ER[1] == true && ERAufgabe.level_ER[2] == false){
            FehlerAnzeige.tutorialtext_ER = "testER";
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
}
