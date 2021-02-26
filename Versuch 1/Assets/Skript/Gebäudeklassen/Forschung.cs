using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forschung : MonoBehaviour
{
    public static int nummerZaehler = 1;
    private int stationsnummer;
    private int baukosten;
    public static int arbeiter = 1;
    public string spezialisierung="";
    public int spezInt;

    public Projekt[] projekte;

    private Projekt selectedProj;

    public int anzahlProjekte;
    public int maxAnzahlProjekte;

    public int projektArbeiter;
    private TMPro.TMP_Dropdown dropdown;

    public void Start()
    {
        stationsnummer = nummerZaehler;
        nummerZaehler++;
        baukosten = gameObject.GetComponent<ObjektBewegung>().preis;
        Testing.forscher -= arbeiter;
        GebaeudeAnzeige.forschungsauswahl = true;
        projekte = new Projekt[0];
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


        if (projekte[0]!=null)
        {
            
            Utilitys.TextInTMP(tabelle.transform.GetChild(1).gameObject, projekte[anzahlProjekte-1].stufe);
            Utilitys.TextInTMP(tabelle.transform.GetChild(2).gameObject, projekte[anzahlProjekte-1].kosten);
            Utilitys.TextInTMP(tabelle.transform.GetChild(3).gameObject, projekte[anzahlProjekte-1].forscheranzahl);
            Utilitys.TextInTMP(tabelle.transform.GetChild(4).gameObject, projekte[anzahlProjekte - 1].verbesserungsfaktor);
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
            listeMerkmale = new List<string> { "", "Baukosten", "Arbeiteranzahl", "Ertrag", "Tiere" };
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
            }
        }
        if (projektzaehler==anzahlProjekte)
        {
            FehlerAnzeige.fehlertext = "Erzeuge erst ein neues Projekt!";
            dropdown.value = 1;
            setMerkmal(1);
        }
        selectedProj = projekte[projekte.Length - 1];
        if (spezInt == 1)
        {
            if (option == 1)
            {
                selectedProj.SetMerkmal("Baukosten");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = -1;
                Debug.Log("1");
                Wohncontainer.preis = selectedProj.neuerWert(Wohncontainer.preis, GebaeudeAnzeige.projektMerkmalStufen[0]);
                GebaeudeAnzeige.projektMerkmalStufen[0]++;
                
            }
            else if(option==2)
            {
                selectedProj.SetMerkmal("Bettenanzahl");
                selectedProj.merkmalInt = option - 1;
                selectedProj.pos = 1;
                Wohncontainer.bettenanzahl = selectedProj.neuerWert(Wohncontainer.bettenanzahl, GebaeudeAnzeige.projektMerkmalStufen[1]);
                GebaeudeAnzeige.projektMerkmalStufen[1]++;
            }
            else
            {
                FehlerAnzeige.fehlertext = "Fehler!";
            }
        }
        if (spezInt == 2)
        {

        }
        if (spezInt == 4)
        {

        }
        if (spezInt == 5)
        {

        }
    }

    public void addProjekt(Projekt pro)
    {
        projekte[anzahlProjekte] = pro;
    }
}
