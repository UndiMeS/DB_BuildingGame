using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feld : MonoBehaviour
{
    public int feldnummer;
    public int baukosten;
    public int arbeiter;
    public int ertrag;

    public static int neuErtrag = 30; //unten auch
    public static int nummerZaehler = 1100;
    public static int preis = 70;
    public static int arbeiterzahl = 4;

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
            Testing.felder.Add(this);
            Testing.gebauedeListe.Add(gameObject);
        }
        

    }

    public void ausgabe(GameObject tabelle)
    {

        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, feldnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, arbeiter);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, ertrag);
    }

    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }

    internal static void resetStatics()
    {
        neuErtrag = 30; //unten auch
        nummerZaehler = 1100;
        preis = 70;
        arbeiterzahl = 4;
    }
}
