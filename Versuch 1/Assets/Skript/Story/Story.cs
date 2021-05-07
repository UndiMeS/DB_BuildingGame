/* 
    ToDo:
    - Forschungsstation Spezialisierungsfenster verdecken
    - Forschungsstatuion bauen OHNE Spezialisierung zu wählen
        - wenn ich dann auf Station gehe werde ich aber immer gefragt, kann aber nichts wählen, wenn lvl 5 nciht erreicht ist
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    //Startlevel für ER-Editor
    public static int level=0;

    //Array zum Prüfen, ob LvL im ER erreicht ist
    public static bool[] lvl = new bool[] {false,false,false,false,false,false,false,false};

    //Zu verändernte Objekte für einzelne Level
    //Level 0 Objekte
    public GameObject transparentWohncontainer;

    //Level 1 Objecte
    public GameObject buttonForscher;
    Button bForscher;
    public GameObject buttonFeld;
    Button bFeld;
    public GameObject buttonWeide;
    Button bWeide;
    public GameObject buttonAlleAstronauten;
    Button bAlle;
    public GameObject buttonWohnendeAstronauten; 
    Button bWohnende;
    
    //Level 2 Objecte
    public GameObject transparentFeld;

    //Level 3 Objecte
    public GameObject transparentForschungsstation;

    //Level 4 Objecte
    public GameObject projektFeld;
    public GameObject projektFeld_bauen;
    public GameObject buttonAlleProjekte;
    Button bAlleProjekte;
    public GameObject buttonStationsprojekte;
    Button bStationsprojekte;
    public GameObject buttonHilfe;
    Button bHilfe;

    //Level 5 Objecte
    public GameObject buttonProjektVerbessern;
    Button bVerbessern;
    public GameObject buttonNeuesProjekt;
    Button bNeuesProjekt;

    //Level 6 Objecte
    public GameObject transparentStallcontainer;
    public GameObject buttonKuh;
    Button bKuh;
    public GameObject buttonSchwein;
    Button bSchwein;
    public GameObject buttonSchaaf;
    Button bSchaaf;
    public GameObject buttonAlleTiere;
    Button bAlleTiere;
    public GameObject buttonWohnendeTiere; 
    Button bWohnendeTiere;

    //Level 7 Objecte
    public GameObject transparentWeide;


    void Start()
    {
        //Freischaltbare Objekte auf aus/false setzten (Transparente auf true)

        //folgendes auskommentieren, um sofort auf alles zugriff zu haben.
        //allesOff(); 
    }   
    void Update()
    {
        //Prüfe auf erfüllte Level
        checkLevel();
    }

    public void allesOff()
    {
        //Level 0
        transparentWohncontainer.SetActive(true);

        //Level 1
        bForscher = buttonForscher.GetComponent<Button>();
        bForscher.interactable = false;
        bFeld = buttonFeld.GetComponent<Button>();
        bFeld.interactable = false;
        bWeide = buttonWeide.GetComponent<Button>();
        bWeide.interactable = false;
        bAlle = buttonAlleAstronauten.GetComponent<Button>();
        bAlle.interactable = false;
        bWohnende = buttonWohnendeAstronauten.GetComponent<Button>();
        bWohnende.interactable = false;

        //Level 2
        transparentFeld.SetActive(true);

        //Level 3
        transparentForschungsstation.SetActive(true);

        //Level 4
        projektFeld.SetActive(false);
        projektFeld_bauen.SetActive(false);
        bAlleProjekte = buttonAlleProjekte.GetComponent<Button>();
        bAlleProjekte.interactable = false;
        bStationsprojekte = buttonStationsprojekte.GetComponent<Button>();
        bStationsprojekte.interactable = false;
        bHilfe = buttonHilfe.GetComponent<Button>();
        bHilfe.interactable = false;

        //Level 5
        bVerbessern = buttonProjektVerbessern.GetComponent<Button>();
        bVerbessern.interactable = false;
        bNeuesProjekt = buttonNeuesProjekt.GetComponent<Button>();
        bNeuesProjekt.interactable = false;

        //Level 6
        transparentStallcontainer.SetActive(true);
        bKuh = buttonKuh.GetComponent<Button>();
        bKuh.interactable = false;
        bSchwein = buttonSchwein.GetComponent<Button>();
        bSchwein.interactable = false;
        bSchaaf = buttonSchaaf.GetComponent<Button>();
        bSchaaf.interactable = false;
        bAlleTiere = buttonAlleTiere.GetComponent<Button>();
        bAlleTiere.interactable = false;
        bWohnendeTiere = buttonWohnendeTiere.GetComponent<Button>();
        bWohnendeTiere.interactable = false;

        //Level 7
        transparentWeide.SetActive(true);

    }

    public void checkLevel()
    {
        if (lvl[0])
        {
            Debug.Log("Level 0 korrekt");
            transparentWohncontainer.SetActive(false);    
        }
        if(lvl[1])
        {
            Debug.Log("Level 1 korrekt");
            bForscher.interactable = true;
            bFeld.interactable = true;
            bWeide.interactable = true;
            bAlle.interactable = true;
            bWohnende.interactable = true;
        }
        if(lvl[2])
        {
            Debug.Log("Level 2 korrekt");
            transparentFeld.SetActive(false);
        }
        if(lvl[3])
        {
            Debug.Log("Level 3 korrekt");
            transparentForschungsstation.SetActive(false);
        }
        if(lvl[4])
        {
            Debug.Log("Level 4 korrekt");
            projektFeld.SetActive(true);
            projektFeld_bauen.SetActive(true);
            bAlleProjekte.interactable = true;
            bStationsprojekte.interactable = true;
            bHilfe.interactable = true;
        }
        if(lvl[5])
        {
            Debug.Log("Level 5 korrekt");
            bVerbessern.interactable = true;
            bNeuesProjekt.interactable = true;
        }
        if(lvl[6])
        {
            Debug.Log("Level 6 korrekt");
            transparentStallcontainer.SetActive(false);
            bKuh.interactable = true;
            bSchwein.interactable = true;
            bSchaaf.interactable = true;
            bAlleTiere.interactable = true;
            bWohnendeTiere.interactable = true;
        }
        if(lvl[7])
        {
            Debug.Log("Level 7 korrekt");
            transparentWeide.SetActive(false);

        }
    }

}