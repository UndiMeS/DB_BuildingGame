﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projekt 
{
    public int stationsnummer;
    public string merkmal="";
    public int merkmalInt=-1;
    public int stufe=1;
    public static int preis_spielstart;
    public static int preis=100;
    public static int forscher=3;
    public int kosten;
    public int forscheranzahl;
    public float verbesserungsfaktor=0.1f;
    public int pos;
    public int verbesserterWert;
    public static int preis_nach_verbesserung = 50;
    public static int kosten_verbesserung = 200;

    public Projekt(int nr, int preis)
    {
        stationsnummer= nr;
        
        forscheranzahl = forscher;
        Testing.forscher -= forscher;
        kosten = preis;
        Testing.geld -= kosten;
        Testing.summeForschungen++;
        Testing.forschungsprojekte.Add(this);

    }
    //für Projekt was Forschungsstation verbessert
    public Projekt(int nr, string merk, int merkInt, int st, int kost, int forAnz,float faktor, int p)
    {
        stationsnummer = nr;
        merkmal = merk;
        merkmalInt = merkInt;
        stufe = st;
        preis = kost;
        pos = p;
        forscheranzahl = forAnz;
        kosten = preis;
        verbesserungsfaktor = faktor;
        Testing.forschungsprojekte.Add(this);
        if (merkmalInt!=11 && GebaeudeAnzeige.projektMerkmalStufen[merkmalInt] < stufe+1)
        {
            GebaeudeAnzeige.projektMerkmalStufen[merkmalInt] = stufe+1;
        }

        foreach (Forschung fors in Testing.forschungsstationen)
        {
            if (fors.stationsnummer == nr)
            {
                fors.addProjekt(this);
            }
        }
    }

    public void SetMerkmal(string merkmalNeu)
    {
        merkmal = merkmalNeu;
    }

   

    public int neuerWert(int alterWert, int stufeNeu)
    {
        int neuerWert = 0;
        if (alterWert <= 10 && pos-1==1)
        {
            stufe = stufeNeu;
            alterWert++;
            neuerWert = alterWert;
            verbesserungsfaktor=1.25f;
        }
        else if(alterWert <= 10)
        {
            stufe = stufeNeu;
            alterWert--;
            neuerWert = alterWert;
            verbesserungsfaktor = 0.9f;
        }
        else
        {
            stufe = stufeNeu;
            verbesserungsfaktor =(1+(pos-1) * 0.1f);
            neuerWert = Mathf.RoundToInt(alterWert * verbesserungsfaktor);
        }
        verbesserterWert = neuerWert;
        return neuerWert;
    }
}
