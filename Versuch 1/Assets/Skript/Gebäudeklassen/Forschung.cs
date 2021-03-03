using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forschung : MonoBehaviour
{
    public int x;
    public int y;
    
    private int stationsnummer;
    private int baukosten;
    
    public string spezialisierung="";
    private int spezInt;

    public static int nummerZaehler = 1;
    public static int arbeiter = 1;

    private Projekt[] projekte;
    private Projekt selectedProj;

    public int anzahlProjekte;
    public int maxAnzahlProjekte;

    private int projektArbeiter;
    private TMPro.TMP_Dropdown dropdown;

    public void Start()
    {
        stationsnummer = nummerZaehler;
        nummerZaehler++;
        baukosten = gameObject.GetComponent<ObjektBewegung>().preis;
        Testing.forscher -= arbeiter;
        GebaeudeAnzeige.forschungsauswahl = true;
        projekte = new Projekt[0];
        Testing.forschungsstationen.Add(this);
    }

    public void ausgabeStation(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(0).gameObject, stationsnummer);
        Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, baukosten);
        Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, spezialisierung);
    }

    public void ausgabeProjekt(GameObject tabelle)
    {
        Utilitys.TextInTMP(tabelle.transform.GetChild(5).gameObject, anzahlProjekte);
        Utilitys.TextInTMP(tabelle.transform.GetChild(6).gameObject, maxAnzahlProjekte);


        if (projekte[projekte.Length-1]!=null)
        {
            
            Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, projekte[projekte.Length-1].stufe);
            Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, projekte[projekte.Length - 1].kosten);
            Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, projekte[projekte.Length - 1].forscheranzahl);
            Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, projekte[projekte.Length - 1].verbesserungsfaktor);
        }
        
        

    }

    public void verbesserung(TMPro.TMP_Dropdown ddm)
    {
        dropdown = ddm;
        List<string> listeMerkmale = new List<string>();

        if (spezInt == 1)
        {
            listeMerkmale = new List<string> { "", "Baukosten", "Bettenanzahl" };
            maxAnzahlProjekte = 2;
        }
        if (spezInt == 2)
        {
            listeMerkmale = new List<string> { "", "Baukosten", "Arbeiteranzahl", "Ertrag" };
            maxAnzahlProjekte = 3;
        }
        if (spezInt == 4)
        {
            listeMerkmale = new List<string> { "", "Baukosten", "Arbeiteranzahl", "Ertrag", "Tieranzahl" };
            maxAnzahlProjekte = 4;
        }
        if (spezInt == 5)
        {
            listeMerkmale = new List<string> { "", "Baukosten", "Gehegezahl" };
            maxAnzahlProjekte = 2;
        }
        ddm.ClearOptions();
        ddm.AddOptions(listeMerkmale);
        projekte = new Projekt[maxAnzahlProjekte];
    }

    public void setMerkmal(int option)
    {
        if (option == 0)
        {
            return;
        }
        int projektzaehler=0;
        int tempInt = 0;
        int frei = 0;
        for(int i = 0; i<projekte.Length; i++)
        {            
            if (projekte[i]!= null &&projekte[i].merkmalInt == option-1)
            {
                Projekt temp = projekte[i];
                projekte[i] = projekte[projekte.Length - 1];
                projekte[projekte.Length - 1] = temp;
                return;
            }if(projekte[i]!= null)
            {
                projektzaehler++;
                tempInt = i;
            }
            if (projekte[i] == null)
            {
                frei = i;
            }
        }
        if (projektzaehler>=anzahlProjekte)
        {
            FehlerAnzeige.fehlertext = "Erzeuge erst ein neues Projekt!";
            dropdown.value = tempInt;
            setMerkmal(tempInt);

        }
        selectedProj = new Projekt();
        projekte[frei]= selectedProj ;
        selectedProj.stationsnummer = stationsnummer;

        if (spezInt == 1)
        {
            if (option == 1)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = -1;
                Wohncontainer.preis = selectedProj.neuerWert(Wohncontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[0]);
                GebaeudeAnzeige.projektMerkmalStufen[0]++;
                
            }
            else if(option==2)
            {
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
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
            if (option == 1)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = -1;
                Feld.preis = selectedProj.neuerWert(Feld.preis, GebaeudeAnzeige.projektMerkmalStufen[2]);
                GebaeudeAnzeige.projektMerkmalStufen[2]++;
            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
                Feld.arbeiterzahl = selectedProj.neuerWert(Feld.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[3]);
                GebaeudeAnzeige.projektMerkmalStufen[3]++;
            }
            else if (option == 3)
            {
                selectedProj.SetMerkmal("Ertrag");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
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
            if (option == 1)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = -1;
                Weide.preis = selectedProj.neuerWert(Weide.preis, GebaeudeAnzeige.projektMerkmalStufen[5]);
                GebaeudeAnzeige.projektMerkmalStufen[5]++;
            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
                Weide.arbeiterzahl = selectedProj.neuerWert(Weide.arbeiterzahl, GebaeudeAnzeige.projektMerkmalStufen[6]);
                GebaeudeAnzeige.projektMerkmalStufen[6]++;
            }
            else if (option == 3)
            {
                selectedProj.SetMerkmal("Ertrag");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
                Weide.neuErtrag = selectedProj.neuerWert(Weide.neuErtrag, GebaeudeAnzeige.projektMerkmalStufen[7]);
                GebaeudeAnzeige.projektMerkmalStufen[7]++;
            }
            else if (option == 4)
            {
                selectedProj.SetMerkmal("Tieranzahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
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
            if (option == 1)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = -1;
                Stallcontainer.preis = selectedProj.neuerWert(Stallcontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[9]);
                GebaeudeAnzeige.projektMerkmalStufen[9]++;

            }
            else if (option == 2)
            {
                selectedProj.SetMerkmal("Gehegezahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
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
        projekte[anzahlProjekte] = pro;
    }
    public void SetXY(int neuX, int neuY)
    {
        x = neuX;
        y = neuY;
    }
    public void getXY(out int outx,out int outy)
    {
        outx = x;
        outy = y;
    }
}
