using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wohncontainer : MonoBehaviour
{   
    public int containernummer;    
    public int baukosten;
    public int bettenanzahl;
    public int freieBetten;

    public static int nummerZaehler = 1;
    public static int betten = 5;
    public static int preis = 75;

    public int x;
    public int y;

    public void Start()
    {
        containernummer = nummerZaehler;
        nummerZaehler++;
        baukosten = preis;
        bettenanzahl = betten;
        freieBetten = bettenanzahl;
        Testing.summeMenschen += bettenanzahl;
        Testing.wohncontainer.Add(this);
    }

    public void ausgabe(GameObject tabelle) 
    {
        
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, containernummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, bettenanzahl);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, freieBetten);
    }

    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }

    public void setAll(int contNr, int kosten, int betAnz, int betfrei, int xNeu, int yNeu)
    {
        containernummer = contNr;
        nummerZaehler = contNr;
        baukosten = kosten;
        bettenanzahl = betAnz;
        freieBetten = betfrei;
        x = xNeu;
        y = yNeu;
    }
}
