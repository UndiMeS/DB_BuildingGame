using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weide : MonoBehaviour
{
    public static int nummerZaehler = 1;
    private int weidennummer;
    private int baukosten;
    public static int arbeiter = 3;
    private int ertrag;
    public static int tiere = 3;


    public void Start()
    {
        weidennummer = nummerZaehler;
        nummerZaehler++;
        baukosten = gameObject.GetComponent<ObjektBewegung>().preis;
        Testing.tierpfleger -= arbeiter;
        ertrag = 10;
        Testing.umsatz += ertrag;
        Testing.tiere -= tiere;
    }

    public void ausgabe(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, weidennummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, arbeiter);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, ertrag);
        Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, tiere);
    }
}
