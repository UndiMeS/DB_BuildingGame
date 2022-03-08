using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelderTabelle : MonoBehaviour
{
    public GameObject Tabelle;
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public GameObject scrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void alleFelderTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);
     
        foreach (Feld feld in Testing.felder)
        {
            GameObject zeile = Instantiate(prefabTabelle, scrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, feld.feldnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, feld.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, feld.arbeiter);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, feld.ertrag);
        }
    }
    public void alleFelderTabelleAus()
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
}
