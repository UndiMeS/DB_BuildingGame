﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wohncontainer : MonoBehaviour
{
    public static int nummerZaehler=1;
    private int containernummer;
    public int bettenanzahl;
    public static int preis;
    private int baukosten;
    public int freieBetten;

    
    public void Start()
    {
        containernummer = nummerZaehler;
        nummerZaehler++;
        baukosten = preis;
        bettenanzahl = 5;
        freieBetten = bettenanzahl;
        Testing.summeAnzMenschen += bettenanzahl;
    }

    public void ausgabe(GameObject tabelle) 
    {
        
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, containernummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, bettenanzahl);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, freieBetten);
    }

    
}
