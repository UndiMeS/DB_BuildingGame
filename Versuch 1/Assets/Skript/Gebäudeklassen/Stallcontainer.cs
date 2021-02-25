using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stallcontainer : MonoBehaviour
{
    public static int nummerZaehler = 1;
    private int containernummer;
    public int gehegezahl;
    private int baukosten;
    public int freieGehege;


    public void Start()
    {
        containernummer = nummerZaehler;
        nummerZaehler++;
        baukosten = gameObject.GetComponent<ObjektBewegung>().preis;
        gehegezahl = 5;
        freieGehege = gehegezahl;
        Testing.summeTiere += gehegezahl;
    }

    public void ausgabe(GameObject tabelle)
    {

        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, containernummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, gehegezahl);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, freieGehege);
    }
}
