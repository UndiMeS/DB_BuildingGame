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
            }else if(!fehlertext.Equals("Es sind zu viele Objekte.")){    
                Invoke("Zuruek", 3);//anzeige des Fehlertextes fuer 2s, dann wieder auf "" zurückgesetz  
            }      
        }
        Utilitys.TextInTMP(fehlerObject, fehlertext);
        Utilitys.TextInTMP(tutorialanzeige_Spiel, tutorialtext_Spiel);
        Utilitys.TextInTMP(tutorialanzeige_ER, tutorialtext_ER);

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
