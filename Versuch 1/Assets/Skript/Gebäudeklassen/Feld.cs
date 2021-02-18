using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feld : MonoBehaviour
{
    public static int nummerZaehler = 1;
    private int feldnummer;
    private int baukosten;
    public static int arbeiter = 3;
    private int ertrag;


    public void Start()
    {
        feldnummer = nummerZaehler;
        nummerZaehler++;
        baukosten = gameObject.GetComponent<ObjektBewegung>().preis;
        Testing.feldarbeiter -= arbeiter;
        ertrag = 10;
        Testing.umsatz += ertrag;
    }

    public void ausgabe(GameObject tabelle)
    {

        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, feldnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, arbeiter);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, ertrag);
    }
}
