using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierTabelle : MonoBehaviour
{
    public GameObject Tabelle;
    public GameObject wohnendeTabelle;
    public GameObject alleTabelle;
    public GameObject stallTabelle;

    public GameObject prefabTabelle;
    public GameObject prefabStall;

    public GameObject alleScrollContent;
    public GameObject bewohnerScrollContent;
    public GameObject stallScrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void wohnendeTiereTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);

        foreach (Tiere tier in GebaeudeAnzeige.gebaeude.GetComponent<Stallcontainer>().tiere)
        {
            GameObject zeile = Instantiate(prefabTabelle, bewohnerScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, tier.stallnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, tier.tiername);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, tier.art);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, tier.transportkosten);
        }
    }
    public void wohnendeTiereTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        wohnendeTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void alleTiereTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);

        foreach (Tiere tier in Testing.tier)
        {
            GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, tier.stallnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, tier.tiername);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, tier.art);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, tier.transportkosten);
        }

    }
    public void alleTiereTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        alleTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void stallTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        stallTabelle.SetActive(true);

        foreach (Stallcontainer stall in Testing.stallcontainer)
        {
            GameObject zeile = Instantiate(prefabStall, stallScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, stall.containernummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, stall.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, stall.gehegezahl);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, stall.freieGehege);
        }
    }
    public void stallTiereTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        stallTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }


}
