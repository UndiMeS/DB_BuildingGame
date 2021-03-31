using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WohncontainerTabelle : MonoBehaviour
{
    public bool wohnendeAstro=false;
    public bool alleAstro = false;

    public GameObject Tabelle;
    public GameObject wohnendeTabelle;
    public GameObject ueberschriftzeile;
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public GameObject scrollContent;
    public List<GameObject> zeilenListe= new List<GameObject>();
    
    public void wohnendeAstroTabelleAn()
    {
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;        

        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);
        wohnendeAstro = true;
        int i = 0;
        foreach(Mensch mensch in GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner)
        {
            GameObject zeile = Instantiate(prefabTabelle,wohnendeTabelle.transform);
            Vector3 pos =  ueberschriftzeile.transform.localPosition;
            pos +=(i+1)* new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y+4, 0);            
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
    public void wohnendeAstroTabelleAus()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        wohnendeTabelle.SetActive(false);
        wohnendeAstro = false;

        foreach(GameObject zeile in zeilenListe)
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
        alleAstro = true;
        int size = 0;
        foreach(Wohncontainer wohn in Testing.wohncontainer)
        {
            size += wohn.bewohner.Count;
        }


        scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(ueberschriftzeile.GetComponent<RectTransform>().sizeDelta.x, ueberschriftzeile.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
        
        int i = 0;
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {

            foreach (Mensch mensch in wohn.bewohner)
            {
                scrollContent.transform.position.Set(0, 0, 0);
                GameObject zeile = Instantiate(prefabTabelle, scrollContent.transform);
                Vector3 pos =i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y+4 , 0);
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
        alleAstro = false;

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }
}
