using System.Collections.Generic;
using UnityEngine;

public class ProjektTabelle : MonoBehaviour
{
    public GameObject Tabelle;
    public GameObject stationsprojekteTabelle;
    public GameObject alleProjekteTabelle;
    public GameObject stationenTabelle;

    public GameObject prefabTabelle;
    public GameObject prefabStation;

    public GameObject alleScrollContent;
    public GameObject stationScrollContent;
    public GameObject forsstationScrollContent;

    public List<GameObject> zeilenListe = new List<GameObject>();

    public void stationsProjekteTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        stationsprojekteTabelle.SetActive(true);

        foreach (Projekt projekt in GebaeudeAnzeige.gebaeude.GetComponent<Forschung>().projekte)
        {
            GameObject zeile = Instantiate(prefabTabelle, stationScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, projekt.stationsnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, projekt.merkmal);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, projekt.stufe);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, projekt.kosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, projekt.forscheranzahl);
            Utilitys.TextInTMP(zeile.transform.GetChild(5).gameObject, projekt.verbesserungsfaktor);
        }
    }
    public void stationsProjekteTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        stationsprojekteTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void alleProjekteTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleProjekteTabelle.SetActive(true);
        foreach (Projekt projekt in Testing.forschungsprojekte)
        {
            GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, projekt.stationsnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, projekt.merkmal);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, projekt.stufe);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, projekt.kosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, projekt.forscheranzahl);
            Utilitys.TextInTMP(zeile.transform.GetChild(5).gameObject, projekt.verbesserungsfaktor);
        }
    }

    public void alleProjekteTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        alleProjekteTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void stationTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        stationenTabelle.SetActive(true);
       
        foreach (Forschung container in Testing.forschungsstationen)
        { 
            GameObject zeile = Instantiate(prefabStation, forsstationScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, container.stationsnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, container.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, container.spezialisierung);
        }
    }
    public void stationTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        stationenTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }
}

