using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projekt 
{
    public int stationsnummer;
    public string merkmal="";
    public int merkmalInt=-1;
    public int stufe=1;
    public static int preis=100;
    public static int forscher=3;
    public int kosten;
    public int forscheranzahl;
    public float verbesserungsfaktor=0.1f;
    public int pos;

    public Projekt(int nr)
    {
        stationsnummer= nr;
        forscheranzahl = forscher;
        Testing.forscher -= forscher;
        kosten = preis;
        Testing.geld -= kosten;
        Testing.summeForschungen++;
        Testing.forschungsprojekte.Add(this);

    }

    public Projekt(int nr, string merk, int merkInt, int st, int kost, int forAnz,float faktor, int p)
    {
        stationsnummer = nr;
        merkmal = merk;
        merkmalInt = merkInt;
        stufe = st;
        preis = kost;
        forscher = forAnz;
        pos = p;
        forscheranzahl = forscher;
        kosten = preis;
        verbesserungsfaktor = faktor;
        Testing.forschungsprojekte.Add(this);
        if (GebaeudeAnzeige.projektMerkmalStufen[merkmalInt] < stufe+1)
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
            verbesserungsfaktor=1.1f;
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
        return neuerWert;
    }
}
