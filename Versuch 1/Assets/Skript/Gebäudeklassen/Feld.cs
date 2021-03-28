using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feld : MonoBehaviour
{   
    public int feldnummer;
    public int baukosten;
    public int arbeiter;
    public int ertrag;

    public static int neuErtrag = 20;
    public static int nummerZaehler = 1;
    public static int preis = 90;
    public static int arbeiterzahl = 3;

    public int x;
    public int y;
    public void Start()
    {
        if (feldnummer == 0)
        {
            feldnummer = nummerZaehler;
            nummerZaehler++;
            baukosten = preis;
            Testing.geld -= preis;
            arbeiter = arbeiterzahl;
            Testing.feldarbeiter -= arbeiter;
            ertrag = neuErtrag;
            Testing.umsatz += ertrag;
        }
        Testing.felder.Add(this);
        Testing.gebauedeListe.Add(gameObject);
    }

    public void ausgabe(GameObject tabelle)
    {

        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, feldnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, arbeiter);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, ertrag);
    }

    public void SetXY(int neuX,int neuY)
    {
        x = neuX;
        y = neuY;
    }

    public void setAll(int nr, int kosten, int arb, int ert, int xNeu, int yNeu)
    {
        feldnummer = nr;
        nummerZaehler = nr;
        baukosten = kosten;
        arbeiter = arb;
        ertrag = ert;
        x = xNeu;
        y = yNeu;

    }
}
