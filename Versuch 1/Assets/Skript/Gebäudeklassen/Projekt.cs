using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projekt 
{
    public int stationsnummer;
    public string merkmal="";
    public int merkmalInt=-1;
    public int stufe=1;
    public int kosten=100;
    public int forscheranzahl=3;
    public float verbesserungsfaktor=0.1f;
    public int pos;

    public Projekt()
    {
        Testing.geld -= kosten;
        Testing.summeForschungen++;
        Testing.forschungsprojekte.Add(this);
    }

    public void SetMerkmal(string merkmalNeu)
    {
        merkmal = merkmalNeu;
    }

   

    public int neuerWert(int alterWert, int stufeNeu)
    {
        int neuerWert = 0;
        if (alterWert <= 10)
        {
            stufe = stufeNeu;
            alterWert++;
            neuerWert = alterWert;
        }
        else
        {
            stufe = stufeNeu;
            verbesserungsfaktor =(1+pos * 0.1f);
            neuerWert = Mathf.RoundToInt(alterWert * verbesserungsfaktor);
        }
        return neuerWert;
    }
}
