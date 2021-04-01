using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierTabelle : MonoBehaviour
{
    public GameObject Tabelle;
    public GameObject wohnendeTabelle;
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public GameObject alleScrollContent;
    public GameObject bewohnerScrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void wohnendeTiereTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);
        int size = GebaeudeAnzeige.gebaeude.GetComponent<Stallcontainer>().tiere.Count;
        bewohnerScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;

        foreach (Tiere tier in GebaeudeAnzeige.gebaeude.GetComponent<Stallcontainer>().tiere)
        {
            bewohnerScrollContent.transform.position.Set(0, 0, 0);
            GameObject zeile = Instantiate(prefabTabelle, bewohnerScrollContent.transform);
            Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
            zeile.transform.localPosition = pos;
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, tier.stallnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, tier.tiername);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, tier.art);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, tier.transportkosten);

            i++;

        }
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
    }
    public void wohnendeTiereTabelleAus()
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

    public void alleTiereTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);
        int size = 0;
        foreach (Stallcontainer stall in Testing.stallcontainer)
        {
            size += stall.tiere.Count;
        }


        alleScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
        foreach (Stallcontainer stall in Testing.stallcontainer)
        {

            foreach (Tiere tier in stall.tiere)
            {
                alleScrollContent.transform.position.Set(0, 0, 0);
                GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
                Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
                zeile.transform.localPosition = pos;
                zeilenListe.Add(zeile);

                Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, tier.stallnummer);
                Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, tier.tiername);
                Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, tier.art);
                Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, tier.transportkosten);

                i++;
            }
        }
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

    }
    public void alleTiereTabelleAus()
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
}
