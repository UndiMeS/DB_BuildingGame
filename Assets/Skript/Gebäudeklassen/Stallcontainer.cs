using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stallcontainer : MonoBehaviour
{


    public int containernummer;
    public int gehegezahl;
    public int baukosten;
    public int freieGehege;

    public static int nummerZaehler = 1;
    public static int preis = 90;
    public static int gehege = 5;

    public int x;
    public int y;

    public List<Tiere> tiere = new List<Tiere>();

    public void Start()
    {
        if (containernummer == 0)
        {
            containernummer = nummerZaehler;
            nummerZaehler++;
            baukosten = preis;
            Testing.geld -= preis;
            gehegezahl = gehege;
            freieGehege = gehegezahl;
            Testing.stallcontainer.Add(this);
            Testing.gebauedeListe.Add(gameObject);
        }

    }

    public void ausgabe(GameObject tabelle)
    {

        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, containernummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, gehegezahl);
        Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, freieGehege);
    }
    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }
    public void setAll(int nr, int kosten, int gehege, int freiGeh, int xNeu, int yNeu)
    {
        containernummer = nr;
        nummerZaehler = nr;
        baukosten = kosten;
        gehegezahl = gehege;
        freieGehege = freiGeh;
        x = xNeu;
        y = yNeu;

    }

    internal static void resetStatics()
    {
        nummerZaehler = 1;
        preis = 90;
        gehege = 5;
    }
}
