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
    public static string fehlertext="";
    public GameObject tutorialanzeige_Spiel;
    public GameObject tutorialanzeige_ER;
    public static string tutorialtext_Spiel="";
    public static string tutorialtext_ER="";

    public static bool change = false;
    private static bool zwischendurch = false;
    public bool temp;

    // Start is called before the first frame update
    void Start()
    {
        tutorialanzeige_Spiel.SetActive(true);
        tutorialanzeige_ER.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fehlertext.Equals("")&&change)
        {            
            tutorialanzeige_Spiel.SetActive(false);
            tutorialanzeige_ER.SetActive(false);
            Invoke("Zuruek", 3);//anzeige des Fehlertextes fuer 2s, dann wieder auf "" zurückgesetzt
        }
        else if(!fehlertext.Equals(""))
         
        {
            tutorialanzeige_ER.SetActive(true);
            tutorialanzeige_Spiel.SetActive(true);
        }        
        Utilitys.TextInTMP(fehlerObject, fehlertext);
        Utilitys.TextInTMP(tutorialanzeige_Spiel, tutorialtext_Spiel);
        Utilitys.TextInTMP(tutorialanzeige_ER, tutorialtext_ER);
        temp = zwischendurch;
    }

    private void Zuruek()
    {
        if (!zwischendurch)
        {
            fehlertext = "";
        }
        else
        {
            zwischendurch = false;
            Invoke("Zuruek", 3);
        }
    }

    public void ClearFehlertext()
    {
        fehlertext = "";

    }
    public static void changeFehlertext(string text)
    {
        if (fehlertext != text)
        {          
            fehlertext = text;
            change = true;
            zwischendurch = false;
        }
        else
        {           
            zwischendurch = true;
        }      
   
    }
 }
