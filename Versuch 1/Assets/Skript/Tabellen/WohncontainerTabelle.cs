using System.Collections.Generic;
using UnityEngine;

public class WohncontainerTabelle : MonoBehaviour
{ 

    public GameObject Tabelle;
    public GameObject wohnendeTabelle;
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public GameObject alleScrollContent;
    public GameObject bewohnerScrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void wohnendeAstroTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);
        int size = GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner.Count;
        bewohnerScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;

        foreach (Mensch mensch in GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner)
        {
            bewohnerScrollContent.transform.position.Set(0, 0, 0);
            GameObject zeile = Instantiate(prefabTabelle, bewohnerScrollContent.transform);
            Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
            zeile.transform.localPosition = pos;
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, mensch.containerNummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, mensch.name);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, mensch.geburtstag);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, mensch.aufgabe);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, mensch.anreisegebuehr);

            i++;

        }
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
    }
    public void wohnendeAstroTabelleAus()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        wohnendeTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void alleAstroTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);
        int size = 0;
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {
            size += wohn.bewohner.Count;
        }


        alleScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {

            foreach (Mensch mensch in wohn.bewohner)
            {
                alleScrollContent.transform.position.Set(0, 0, 0);
                GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
                Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
                zeile.transform.localPosition = pos;
                zeilenListe.Add(zeile);

                Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, mensch.containerNummer);
                Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, mensch.name);
                Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, mensch.geburtstag);
                Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, mensch.aufgabe);
                Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, mensch.anreisegebuehr);

                i++;
            }
        }
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

    }
    public void alleAstroTabelleAus()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        alleTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void exit()
    {
        alleAstroTabelleAus();
        wohnendeAstroTabelleAus();
        gameObject.GetComponent<FelderTabelle>().alleFelderTabelleAus();
        gameObject.GetComponent<ProjektTabelle>().alleProjekteTabelleAus();
        gameObject.GetComponent<ProjektTabelle>().stationsProjekteTabelleAus();
        gameObject.GetComponent<TierTabelle>().alleTiereTabelleAus();
        gameObject.GetComponent<TierTabelle>().wohnendeTiereTabelleAus();
        gameObject.GetComponent<WeidenTabelle>().alleWeidenTabelleAus();
    }
}
