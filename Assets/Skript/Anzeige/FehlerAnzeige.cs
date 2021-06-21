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
    public GameObject tutorialanzeige;
    public static string tutorialtext="";

    // Start is called before the first frame update
    void Start()
    {
        tutorialanzeige.SetActive(true);
        
        //Zum Testen
        Utilitys.TextInTMP(tutorialanzeige, "Fliege neue Astronauten ein, indem du auf die entsprechenden Buttons im Wohncontainer klickst. Die Namen kannst du dir auch über einen Button anzeigen lassen");
    }

    // Update is called once per frame
    void Update()
    {
        if (!fehlertext.Equals(""))
        {
            tutorialanzeige.SetActive(false);
            Invoke("Zuruek", 3);//anzeige des Fehlertextes fuer 2s, dann wieder auf "" zurückgesetzt
        }        
        Utilitys.TextInTMP(fehlerObject, fehlertext);
        //Utilitys.TextInTMP(tutorialanzeige, tutorialtext);
        
    }

    private void Zuruek()
    {
        fehlertext = ""; 
        tutorialanzeige.SetActive(true);

    }

    public void ClearFehlertext()
    {
        fehlertext = "";

    }
 }
