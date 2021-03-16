﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weide : MonoBehaviour
{
    public int weidennummer;
    public int baukosten;
    public int arbeiter ;
    public int ertrag;
    public int tiere;

    public static int nummerZaehler = 1;
    public static int preis = 80;
    public static int arbeiterzahl =3;
    public static int neuErtrag = 10;
    public static int tierAnzahl = 3;

    public int x;
    public int y;


    public void Start()
    {
        weidennummer = nummerZaehler;
        nummerZaehler++;
        baukosten = preis;
        Testing.geld -= preis;
        arbeiter = arbeiterzahl;
        Testing.tierpfleger -= arbeiter;
        ertrag = neuErtrag;
        Testing.umsatz += ertrag;
        tiere = tierAnzahl;
        Testing.tiere -= tiere;

        Testing.weiden.Add(this);
        Testing.gebauedeListe.Add(gameObject);
    }

    public void ausgabe(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, weidennummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, arbeiter);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, ertrag);
        Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, tiere);
    }

    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }

    public void setAll(int nr, int kosten, int arb, int ert, int tier, int xNeu, int yNeu)
    {
        weidennummer = nr;
        nummerZaehler = nr;
        baukosten = kosten;
        arbeiter = arb;
        ertrag = ert;
        tiere = tier;
        x = xNeu;
        y = yNeu;

        Testing.umsatz -= ertrag;
        Testing.tierpfleger += arbeiter;
        Testing.tiere += tiere;

    }
}
