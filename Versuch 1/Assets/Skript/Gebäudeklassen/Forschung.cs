using System.Collections.Generic;
using UnityEngine;

public class Forschung : MonoBehaviour
{
    public int stationsnummer;
    private int baukosten;
    public string spezialisierung;
    private int spezInt;
    public int anzahlProjekte = 0;
    public int maxAnzahlProjekte = 3;

    public static int nummerZaehler = 1;
    public static int chef = 1;
    public static int preis = 100;

    public int x;
    public int y;

    private TMPro.TMP_Dropdown dropdown;

    private List<Projekt> projekte;
    private Projekt selectedProj;

    private string aktuellesMerkmal = "";
    private int merkmal;
    private int option=0; 
    private GameObject merkmalsanzeige;

    public void Start()
    {
        stationsnummer = nummerZaehler;
        nummerZaehler++;
        baukosten = preis;
        Testing.geld -= preis;
        Testing.forscher -= chef;
        GebaeudeAnzeige.forschungsauswahl = true;
        projekte = new List<Projekt>();

        Testing.forschungsstationen.Add(this);
        Testing.gebauedeListe.Add(gameObject);
    }

    
    public void ausgabeStation(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, stationsnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, spezialisierung);
    }

    public void ausgabeProjekt(GameObject tabelle, GameObject merkmalsNameGO)
    {
        merkmalsanzeige = merkmalsNameGO;
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
        Utilitys.TextInTMP(merkmalsNameGO, "Projekt für <i>" + aktuellesMerkmal + "</i> anlegen.");


    }

    public void verbesserung(TMPro.TMP_Dropdown ddm, GameObject aktuellesmerkmal)
    {
        merkmalsanzeige = aktuellesmerkmal;
        dropdown = ddm;
        List<string> listeMerkmale = new List<string>();
        if (spezialisierung.Equals("Wohncontainer"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Bettenanzahl" };
            maxAnzahlProjekte = 5;
            spezInt = 1;
        }
        if (spezialisierung.Equals("Feldsphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag" };
            maxAnzahlProjekte = 7;
            spezInt = 2;
        }
        if (spezialisierung.Equals("Weidesphäre"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Arbeiterzahl", "Ertrag", "Tieranzahl" };
            maxAnzahlProjekte = 8;
            spezInt = 4;
        }
        if (spezialisierung.Equals("Stallcontainer"))
        {
            listeMerkmale = new List<string> { "Baukosten", "Gehegezahl" };
            maxAnzahlProjekte = 5;
            spezInt = 5;
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
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Baukosten</i> anlegen");
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 1;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Bettenanzahl</i> anlegen");
                aktuellesMerkmal = "Bettenanzahl";
            }
        }
        if (spezInt == 2)
        {
            if (opt == 0)
            {
                merkmal = 2;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Baukosten</i> anlegen");
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 3;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Arbeiterzahl</i> anlegen");
                aktuellesMerkmal = "Arbeiterzahl";
            }
            else if (opt == 2)
            {
                merkmal = 4;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Ertrag</i> anlegen");
                aktuellesMerkmal = "Ertrag";
            }
        }
        if (spezInt == 4)
        {
            if (opt == 0)
            {
                merkmal = 5;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Baukosten</i> anlegen");
                aktuellesMerkmal = "Baukosten";
            }
            else if (opt == 1)
            {
                merkmal = 6;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Arbeiterzahl</i> anlegen");
                aktuellesMerkmal = "Arbeiterzahl";
            }
            else if (opt == 2)
            {
                merkmal = 7;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Ertrag</i> anlegen");
                aktuellesMerkmal = "Ertrag";
            }
            else if (opt == 3)
            {
                merkmal = 8;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Tieranzahl</i> anlegen");
                aktuellesMerkmal = "Tieranzahl";
            }
        }
        if (spezInt == 5)
        {
            if (opt == 0)
            {
                merkmal = 9;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Baukosten</i> anlegen");
                aktuellesMerkmal = "Baukosten";

            }
            else if (opt == 1)
            {
                merkmal = 10;
                Utilitys.TextInTMP(merkmalsanzeige, "Projekt für <i>Gehegezahl</i> anlegen");
                aktuellesMerkmal = "Gehegezahl";
            }
        }
        selectedProj = null;
        foreach (Projekt pro in projekte)
        {
            if (pro.merkmalInt == opt && pro.stufe == GebaeudeAnzeige.projektMerkmalStufen[merkmal]-1)
            {
                selectedProj = pro;
            }
        }
   }

    public void createProjekt()
    {
        if (anzahlProjekte == maxAnzahlProjekte )
        {
            FehlerAnzeige.fehlertext = "An dieser Station können keine neuen Projekte gestartet werden.";
            return;
        }if(GebaeudeAnzeige.maxStufen[merkmal]  == GebaeudeAnzeige.projektMerkmalStufen[merkmal])
        {
            FehlerAnzeige.fehlertext = "Maximale Stufe des Merkmals erreicht.";
            return;
        }
        anzahlProjekte++;
        selectedProj = new Projekt(stationsnummer);
        projekte.Add(selectedProj);

        if (spezInt == 1)
        {
            if (option == 0)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Wohncontainer.preis = selectedProj.neuerWert(Wohncontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[0]);
                GebaeudeAnzeige.projektMerkmalStufen[0]++;
                merkmal = 0;
            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = option;
                selectedProj.pos =2;
                Wohncontainer.betten = selectedProj.neuerWert(Wohncontainer.betten, GebaeudeAnzeige.projektMerkmalStufen[1]);
                GebaeudeAnzeige.projektMerkmalStufen[1]++;
                merkmal = 1;
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
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Feld.preis = selectedProj.neuerWert(Feld.preis, GebaeudeAnzeige.projektMerkmalStufen[2]);
                GebaeudeAnzeige.projektMerkmalStufen[2]++;
                merkmal = 2;
            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Arbeiterzahl");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Feld.arbeiterzahl = selectedProj.neuerWert(Feld.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[3]);
                GebaeudeAnzeige.projektMerkmalStufen[3]++;
                merkmal = 3;
            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Ertrag");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 2;
                Feld.neuErtrag = selectedProj.neuerWert(Feld.neuErtrag, GebaeudeAnzeige.projektMerkmalStufen[4]);
                GebaeudeAnzeige.projektMerkmalStufen[4]++;
                merkmal = 4;
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
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Weide.preis = selectedProj.neuerWert(Weide.preis, GebaeudeAnzeige.projektMerkmalStufen[5]);
                GebaeudeAnzeige.projektMerkmalStufen[5]++;
                merkmal = 5;
            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Arbeiterzahl");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 2;
                Weide.arbeiterzahl = selectedProj.neuerWert(Weide.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[6]);
                GebaeudeAnzeige.projektMerkmalStufen[6]++;
                merkmal = 6;
            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Ertrag");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 2;
                Weide.neuErtrag = selectedProj.neuerWert(Weide.neuErtrag, GebaeudeAnzeige.projektMerkmalStufen[7]);
                GebaeudeAnzeige.projektMerkmalStufen[7]++;
                merkmal = 7;
            }
            else if (option == 3)
            {
                selectedProj.SetMerkmal("Tieranzahl");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Weide.tierAnzahl = selectedProj.neuerWert(Weide.tierAnzahl, GebaeudeAnzeige.projektMerkmalStufen[8]);
                GebaeudeAnzeige.projektMerkmalStufen[8]++;
                merkmal = 8;
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
                selectedProj.merkmalInt = option;
                selectedProj.pos = 0;
                Stallcontainer.preis = selectedProj.neuerWert(Stallcontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[9]);
                GebaeudeAnzeige.projektMerkmalStufen[9]++;
                merkmal = 9;

            }
            else if (option == 1)
            {
                selectedProj.SetMerkmal("Gehegezahl");
                selectedProj.merkmalInt = option;
                selectedProj.pos = 2;
                Stallcontainer.gehege = selectedProj.neuerWert(Stallcontainer.gehege, GebaeudeAnzeige.projektMerkmalStufen[10]);
                GebaeudeAnzeige.projektMerkmalStufen[10]++;
                merkmal = 10;
            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
        projekte.Add(selectedProj);
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

    public void setAll(int nr, string spez, int anzProj, int maxAnz, int xNeu, int yNeu, TMPro.TMP_Dropdown ddm, GameObject merkmalGO)
    {
        stationsnummer = nr;
        nummerZaehler = nr;
        spezialisierung = spez;

        anzahlProjekte = anzProj;
        maxAnzahlProjekte = maxAnz;
        x = xNeu;
        y = yNeu;

        Testing.forscher += chef;
        GebaeudeAnzeige.forschungsauswahl = false;
        projekte = new List<Projekt>();
        verbesserung(ddm, merkmalGO);
    }
}
