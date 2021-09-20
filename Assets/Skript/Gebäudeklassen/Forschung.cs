using System;
using System.Collections.Generic;
using UnityEngine;

public class Forschung : MonoBehaviour
{
    public int stationsnummer = 0;
    public int baukosten;
    public string spezialisierung = "";
    private int spezInt;
    public int anzahlProjekte = 0;
    public int maxAnzahlProjekte = 3;
    public int projektkosten = 100;

    public static int nummerZaehler = 1; //unten auch
    public static int chef = 1;
    public static int preis = 100;

    public int x;
    public int y;

    private TMPro.TMP_Dropdown dropdown;

    public List<Projekt> projekte = new List<Projekt>();
    private Projekt selectedProj;

    private string aktuellesMerkmal = "";
    private int merkmal;
    private int option = 0;
    private GameObject merkmalsanzeige;

    public void Start()
    {
        if (stationsnummer == 0)
        {
            stationsnummer = nummerZaehler;
            nummerZaehler++;
            baukosten = preis;
            Testing.geld -= preis;
            Testing.forscher -= chef;
            //GebaeudeAnzeige.forschungsauswahl = stationsnummer;
            projekte = new List<Projekt>();

            Testing.forschungsstationen.Add(this);
            Testing.gebauedeListe.Add(gameObject);

            bool temp = true;
            foreach (Mensch mensch in Testing.menschen)
                {
                    if (mensch.aufgabe == "Forschung" && mensch.stationsNummer == 0&&mensch.projektForschungsstationsNummer==0)
                    {
                        mensch.stationsNummer = stationsnummer;
                        temp = false;
                        break;
                    }
            }
            
            if (temp)
            {
                Debug.Log("Fehler");
            }

        }
        if (nummerZaehler < stationsnummer)
        {
            nummerZaehler = stationsnummer + 1;
            preis = baukosten;
        }
    }


    public void ausgabeStation(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, stationsnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, spezialisierung);
    }

    public void ausgabeProjekt(GameObject tabelle, GameObject merkmalGO, GameObject verbsserungGO)
    {
        merkmalsanzeige = merkmalGO;
        Utilitys.TextInTMP(tabelle.transform.GetChild(5).gameObject, anzahlProjekte);
        Utilitys.TextInTMP(tabelle.transform.GetChild(6).gameObject, maxAnzahlProjekte);


        if (selectedProj != null)
        {
            Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, selectedProj.stufe);
            Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, selectedProj.kosten);
            Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, selectedProj.forscheranzahl);
            Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, selectedProj.verbesserungsfaktor);
        }
        else
        {
            Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, "");
            Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, "");
            Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, "");
            Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, "");
        }
        refreshDropdown();
        Utilitys.TextInTMP(merkmalGO.transform.GetChild(0).gameObject, "Projekt <i>" + aktuellesMerkmal + "</i> anlegen. (" + (GebaeudeAnzeige.projektMerkmalStufen[merkmal] - 1) + "/" + GebaeudeAnzeige.maxStufen[merkmal] + ")");
        Utilitys.TextInTMP(merkmalGO.transform.GetChild(1).gameObject, projektkosten);
        if (projektkosten == 50)
        {
            verbsserungGO.SetActive(false);
        }
        else
        {
            verbsserungGO.SetActive(true);
        }
    }



    public void verbesserung(TMPro.TMP_Dropdown ddm, GameObject aktuellesmerkmal)
    {
        merkmalsanzeige = aktuellesmerkmal;
        dropdown = ddm;
        List<string> listeMerkmale = new List<string>();
        if (spezialisierung.Equals("Wohncontainer")) //hier
        {
            listeMerkmale = new List<string> { "Baukosten", "Bettenanzahl" };
            maxAnzahlProjekte = 5;
            spezInt = 1;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (spezialisierung.Equals("Feldsphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag" };
            maxAnzahlProjekte = 7;
            spezInt = 2;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        if (spezialisierung.Equals("Weidesphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag", "Tieranzahl" };
            maxAnzahlProjekte = 8;
            spezInt = 4;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (spezialisierung.Equals("Stallcontainer"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Gehegezahl" };
            maxAnzahlProjekte = 5;
            spezInt = 5;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        ddm.ClearOptions();
        ddm.AddOptions(listeMerkmale);
        ddm.SetValueWithoutNotify(0);
        setMerkmal(0);
    }

    private void refreshDropdown()
    {
        List<string> listeMerkmale = new List<string>();
        if (spezialisierung.Equals("Wohncontainer"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Bettenanzahl" };
        }
        if (spezialisierung.Equals("Feldsphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag" };
        }
        if (spezialisierung.Equals("Weidesphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag", "Tieranzahl" };
        }
        if (spezialisierung.Equals("Stallcontainer"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Gehegezahl" };
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(listeMerkmale);
        dropdown.value = option;
    }

    public void setMerkmal(int opt)
    {
        option = opt;
        if (spezInt == 1)
        {
            if (opt == 0)
            {
                merkmal = 0;
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 1;
                aktuellesMerkmal = "Bettenanzahl";
            }
        }
        if (spezInt == 2)
        {
            if (opt == 0)
            {
                merkmal = 2;
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 3;
                aktuellesMerkmal = "Arbeiterzahl";
            }
            else if (opt == 2)
            {
                merkmal = 4;
                aktuellesMerkmal = "Ertrag";
            }
        }
        if (spezInt == 4)
        {
            if (opt == 0)
            {
                merkmal = 5;
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 6;
                aktuellesMerkmal = "Arbeiterzahl";
            }
            else if (opt == 2)
            {
                merkmal = 7;
                aktuellesMerkmal = "Ertrag";
            }
            else if (opt == 3)
            {
                merkmal = 8;
                aktuellesMerkmal = "Tieranzahl";
            }
        }
        if (spezInt == 5)
        {
            if (opt == 0)
            {
                merkmal = 9;
                aktuellesMerkmal = "Baukosten";

            }
            else if (opt == 1)
            {
                merkmal = 10;
                aktuellesMerkmal = "Gehegezahl";
            }
        }
        selectedProj = null;

        foreach (Projekt pro in projekte)
        {
            if (pro.merkmalInt == merkmal && pro.stufe == GebaeudeAnzeige.projektMerkmalStufen[merkmal] - 1)
            {
                selectedProj = pro;
            }
        }
    }
    //beim laden wird selectedProjekt gesetzt
    internal void setProjekt()
    {

        if (projekte.Count != 0)
        {
            refreshDropdown();
            if (projekte[0].merkmal == dropdown.options[0].text)
            {
                selectedProj = projekte[0];
            }
        }
    }

    public void createProjekt()
    {
        if (anzahlProjekte == maxAnzahlProjekte)
        {
            FehlerAnzeige.fehlertext = "An dieser Station können keine neuen Projekte gestartet werden.";
            return;
        }
        if (GebaeudeAnzeige.maxStufen[merkmal] == (GebaeudeAnzeige.projektMerkmalStufen[merkmal] - 1)) //-1 da sonst z.B. 9/10 als Ende endsteht
        {
            FehlerAnzeige.fehlertext = "Maximale Stufe des Merkmals erreicht.";
            return;
        }
        anzahlProjekte++;
        selectedProj = new Projekt(stationsnummer, projektkosten);
        projekte.Add(selectedProj);

        if (spezInt == 1)
        {
            if (option == 0)
            {
                merkmal = 0;
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Wohncontainer.preis = selectedProj.neuerWert(Wohncontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[0]);
                GebaeudeAnzeige.projektMerkmalStufen[0]++;

            }
            else if (option == 1)
            {
                merkmal = 1;
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 2;
                Wohncontainer.betten = selectedProj.neuerWert(Wohncontainer.betten, GebaeudeAnzeige.projektMerkmalStufen[1]);
                GebaeudeAnzeige.projektMerkmalStufen[1]++;
            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
        if (spezInt == 2)
        {
            if (option == 0)
            {
                selectedProj.SetMerkmal("Baukosten");
                merkmal = 2;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Feld.preis = selectedProj.neuerWert(Feld.preis, GebaeudeAnzeige.projektMerkmalStufen[2]);
                GebaeudeAnzeige.projektMerkmalStufen[2]++;

            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Arbeiterzahl");
                merkmal = 3;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Feld.arbeiterzahl = selectedProj.neuerWert(Feld.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[3]);
                GebaeudeAnzeige.projektMerkmalStufen[3]++;

            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Ertrag");
                merkmal = 4;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 2;
                Feld.neuErtrag = selectedProj.neuerWert(Feld.neuErtrag, GebaeudeAnzeige.projektMerkmalStufen[4]);
                GebaeudeAnzeige.projektMerkmalStufen[4]++;

            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
        if (spezInt == 4)
        {
            if (option == 0)
            {
                selectedProj.SetMerkmal("Baukosten");
                merkmal = 5;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Weide.preis = selectedProj.neuerWert(Weide.preis, GebaeudeAnzeige.projektMerkmalStufen[5]);
                GebaeudeAnzeige.projektMerkmalStufen[5]++;

            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Arbeiterzahl");
                merkmal = 6;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Weide.arbeiterzahl = selectedProj.neuerWert(Weide.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[6]);
                GebaeudeAnzeige.projektMerkmalStufen[6]++;

            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Ertrag");
                merkmal = 7;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 2;
                Weide.neuErtrag = selectedProj.neuerWert(Weide.neuErtrag, GebaeudeAnzeige.projektMerkmalStufen[7]);
                GebaeudeAnzeige.projektMerkmalStufen[7]++;

            }
            else if (option == 3)
            {
                selectedProj.SetMerkmal("Tieranzahl");
                merkmal = 8;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Weide.tierAnzahl = selectedProj.neuerWert(Weide.tierAnzahl, GebaeudeAnzeige.projektMerkmalStufen[8]);
                GebaeudeAnzeige.projektMerkmalStufen[8]++;

            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
        if (spezInt == 5)
        {
            if (option == 0)
            {
                selectedProj.SetMerkmal("Baukosten");

                merkmal = 9;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 0;
                Stallcontainer.preis = selectedProj.neuerWert(Stallcontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[9]);
                GebaeudeAnzeige.projektMerkmalStufen[9]++;


            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Gehegezahl");

                merkmal = 10;
                selectedProj.merkmalInt = merkmal;
                selectedProj.pos = 2;
                Stallcontainer.gehege = selectedProj.neuerWert(Stallcontainer.gehege, GebaeudeAnzeige.projektMerkmalStufen[10]);
                GebaeudeAnzeige.projektMerkmalStufen[10]++;

            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
    }


    public void addProjekt(Projekt pro)
    {
        projekte.Add(pro);
    }
    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }
    public void getXY(out int outx, out int outy)
    {
        outx = x;
        outy = y;
    }

    internal static void resetStatics()
    {
        nummerZaehler = 1; //unten auch
        chef = 1;
        preis = 100;
    }
}
