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
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public void wohnendeAstroTabelleAn()
    {
        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);
        wohnendeAstro = true;

        for(int i =0; i< GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner.Count;i++)
        {
            GameObject zeile = Instantiate(prefabTabelle, wohnendeTabelle.transform);
            zeile.transform.position = wohnendeTabelle.transform.GetChild(0).position;
            Debug.Log(zeile.GetComponent<RectTransform>().sizeDelta);
            zeile.transform.position.Set(wohnendeTabelle.transform.GetChild(0).position.x, wohnendeTabelle.transform.GetChild(0).position.y+(i+1) * zeile.GetComponent<RectTransform>().sizeDelta.y,0);
            Debug.Log(zeile.transform.position);
        }
    }
    public void wohnendeAstroTabelleAus()
    {
        Tabelle.SetActive(false);
        wohnendeTabelle.SetActive(false);
        wohnendeAstro = false;
    }

    public void Update()
    {
        if (wohnendeAstro)
        {
            //anzeigenWohnendeAstro();
        }
    }

    private void anzeigenWohnendeAstro()
    {
        int i = 2;
        foreach (Mensch mensch in GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner)
        {
            Utilitys.TextInTMP(wohnendeTabelle.transform.GetChild(i).transform.GetChild(0).gameObject, mensch.containerNummer);
            Utilitys.TextInTMP(wohnendeTabelle.transform.GetChild(i).transform.GetChild(1).gameObject, mensch.name);
            Utilitys.TextInTMP(wohnendeTabelle.transform.GetChild(i).transform.GetChild(2).gameObject, mensch.geburtstag);
            Utilitys.TextInTMP(wohnendeTabelle.transform.GetChild(i).transform.GetChild(3).gameObject, mensch.aufgabe);
            Utilitys.TextInTMP(wohnendeTabelle.transform.GetChild(i).transform.GetChild(4).gameObject, mensch.anreisegebuehr);
            i++;
        }
    }
}
