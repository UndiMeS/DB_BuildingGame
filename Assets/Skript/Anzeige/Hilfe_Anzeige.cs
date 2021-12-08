using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilfe_Anzeige : MonoBehaviour
{
    public GameObject hilfeFenster;
    public GameObject PauseMenuUI;
    public GameObject hilfeZurueckButton;
    public GameObject hilfeGebaeudeinfo;
    public GameObject hilfeButtondestroyer;
    public GameObject hilfeTexte;
    public GameObject baumenuTransparent;
    public GameObject mission;
    public GameObject tutorial;
    public GameObject info;
    public GameObject hilfeBackground;


    //Hilfe Anzeigen in PauseMen� der Landschaft
    public void Hilfe()
    {
        if (!hilfeFenster.activeSelf)
        {
            PauseMenuUI.SetActive(false);
            PauseMenu.SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
            hilfeFenster.SetActive(true);
            hilfeZurueckButton.SetActive(true);
            //hilfeGebaeudeinfo.SetActive(true);
            hilfeButtondestroyer.SetActive(true);
            hilfeTexte.SetActive(true);
            baumenuTransparent.SetActive(false);
            LeanTween.moveLocalY(mission, 650, 0.3f);
            tutorial.SetActive(false);
            info.SetActive(false);
            hilfeBackground.SetActive(true);
        }
        else
        {
            PauseMenu.SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;
            hilfeFenster.SetActive(false);
            hilfeZurueckButton.SetActive(false);
            //hilfeGebaeudeinfo.SetActive(false);
            hilfeButtondestroyer.SetActive(false);
            hilfeTexte.SetActive(false);
            baumenuTransparent.SetActive(true);
            tutorial.SetActive(true);
            info.SetActive(true);
            hilfeBackground.SetActive(false);
        }
    }
}
