using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeidenTabelle : MonoBehaviour
{
    public GameObject Tabelle;
    public GameObject alleTabelle;

    public GameObject prefabTabelle;

    public GameObject scrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public void alleWeidenTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);

        foreach (Weide weide in Testing.weiden)
        {
            GameObject zeile = Instantiate(prefabTabelle, scrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, weide.weidennummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, weide.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, weide.arbeiter); 
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, weide.tiere);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, weide.ertrag);
        }
    }
    public void alleWeidenTabelleAus()
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
