using System.Collections.Generic;
using UnityEngine;

public class ProjektTabelle : MonoBehaviour
{
    public bool stationsprojekte = false;
    public bool alleProjekte = false;

    public GameObject Tabelle;
    public GameObject stationsprojekteTabelle;
    public GameObject alleProjekteTabelle;

    public GameObject prefabTabelle;

    public GameObject alleScrollContent;
    public GameObject stationScrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void stationsProjekteTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        stationsprojekteTabelle.SetActive(true);
        stationsprojekte = true;

        int size = GebaeudeAnzeige.gebaeude.GetComponent<Forschung>().projekte.Count;
        
        stationScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
                    foreach (Projekt projekt in GebaeudeAnzeige.gebaeude.GetComponent<Forschung>().projekte)
            {
                stationScrollContent.transform.position.Set(0, 0, 0);
                GameObject zeile = Instantiate(prefabTabelle, stationScrollContent.transform);
                Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
                zeile.transform.localPosition = pos;
                zeilenListe.Add(zeile);

                Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, projekt.stationsnummer);
                Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, projekt.merkmal);
                Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, projekt.stufe);
                Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, projekt.kosten);
                Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, projekt.forscheranzahl);
                Utilitys.TextInTMP(zeile.transform.GetChild(5).gameObject, projekt.verbesserungsfaktor);

                i++;
            
        }

        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

    }
    public void stationsProjekteTabelleAus()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        stationsprojekteTabelle.SetActive(false);
        stationsprojekte = false;

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }

    public void alleProjekteTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleProjekteTabelle.SetActive(true);
        alleProjekte = true;
        int size = 0;
        foreach (Forschung station in Testing.forschungsstationen)
        {
            size += station.projekte.Count;
        }


        alleScrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
        foreach (Forschung station in Testing.forschungsstationen)
        {

            foreach (Projekt projekt in station.projekte)
            {
                alleScrollContent.transform.position.Set(0, 0, 0);
                GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
                Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
                zeile.transform.localPosition = pos;
                zeilenListe.Add(zeile);

                Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, projekt.stationsnummer);
                Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, projekt.merkmal);
                Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, projekt.stufe);
                Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, projekt.kosten);
                Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, projekt.forscheranzahl);
                Utilitys.TextInTMP(zeile.transform.GetChild(5).gameObject, projekt.verbesserungsfaktor);

                i++;
            }
        }

        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

    }
    public void alleProjekteTabelleAus()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        alleProjekteTabelle.SetActive(false);
        alleProjekte = false;

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }
}

