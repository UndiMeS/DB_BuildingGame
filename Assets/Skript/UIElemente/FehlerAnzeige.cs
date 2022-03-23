using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*rote Fehleranzeige besitzt dieses Script
 * String fehlertext wird in anderen Sript verändert
 */
public class FehlerAnzeige : MonoBehaviour
{
    public GameObject fehlerObject;
    public static string fehlertext = "";
    public GameObject tutorialanzeige_Spiel;
    public GameObject tutorialanzeige_ER;
    public static string tutorialtext_Spiel = "";
    public static string tutorialtext_ER = "";
    public GameObject infoboxER;
    public GameObject infoboxSpiel;

    // Start is called before the first frame update
    void Start()
    {
        tutorialanzeige_Spiel.SetActive(true);
        tutorialanzeige_ER.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fehlertext.Equals(""))
        {
            tutorialanzeige_Spiel.SetActive(false);
            tutorialanzeige_ER.SetActive(false);
            
            if(fehlertext.Equals("trigger")){
                fehlertext = "";
                tutorialanzeige_ER.SetActive(true);
                tutorialanzeige_Spiel.SetActive(true);
            }else if(!fehlertext.Equals("Es sind zu viele Objekte.")&& 
               !fehlertext.Equals("Es dürfen keine zwei Beziehungen zwischen den gleichen Entitätsmengen existieren.")&&
               !fehlertext.Equals("Es dürfen keine zwei Relationships zwischen den gleichen Entitymengen existieren.") &&
               !fehlertext.Equals("Achte auf korrekte Rechtschreibung. Sphäre statt Spähre!") &&
               !fehlertext.Contains("Die Bezeichnungen"))
            {
                    Invoke("Zuruek",5);//anzeige des Fehlertextes fuer 2s, dann wieder auf "" zurückgesetz  
                
            }      
        }
        Utilitys.TextInTMP(fehlerObject, fehlertext);
        Utilitys.TextInTMP(tutorialanzeige_Spiel, tutorialtext_Spiel);
        Utilitys.TextInTMP(tutorialanzeige_ER, tutorialtext_ER);

        if(fehlertext.Equals("") && tutorialtext_ER.Equals("")){
            infoboxER.SetActive(false);
        }else{
            infoboxER.SetActive(true);
        }
        if(fehlertext.Equals("") && tutorialtext_Spiel.Equals("")){
            infoboxSpiel.SetActive(false);
        }else{
            infoboxSpiel.SetActive(true);
        }

    }

    private void Zuruek()
    {
        fehlertext = "";
        tutorialanzeige_ER.SetActive(true);
        tutorialanzeige_Spiel.SetActive(true);

    }

    public void ClearFehlertext()
    {
        fehlertext = "";

    }
}
