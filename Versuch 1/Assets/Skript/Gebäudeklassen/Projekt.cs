using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projekt 
{
    
    public string merkmal="";
    public int merkmalInt;
    public int stufe=1;
    public int kosten=100;
    public static int forscheranzahl=3;
    public float verbesserungsfaktor=0.1f;
    public int pos;

    public Projekt()
    {
        Testing.geld -= kosten;
        Testing.forscher -= forscheranzahl;   
    }

    public void SetMerkmal(string merkmalNeu)
    {
        merkmal = merkmalNeu;
    }

    public void setStufe(int stufeNeu)
    {
        stufe = stufeNeu;
        verbesserungsfaktor = stufe * (pos+0.1f);
    }
}
