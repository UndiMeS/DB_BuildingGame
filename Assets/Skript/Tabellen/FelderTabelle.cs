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
     
        int size = Testing.felder.Count;
        scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
        foreach (Feld feld in Testing.felder)
        {

            scrollContent.transform.position.Set(0, 0, 0);
            GameObject zeile = Instantiate(prefabTabelle, scrollContent.transform);
            Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
            zeile.transform.localPosition = pos;
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, feld.feldnummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, feld.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, feld.arbeiter);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, feld.ertrag);

            i++;

        }

        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

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
