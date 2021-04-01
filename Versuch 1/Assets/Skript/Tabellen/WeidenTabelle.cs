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
        Time.timeScale = 0;
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);

        int size = Testing.weiden.Count;
        scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabTabelle.GetComponent<RectTransform>().sizeDelta.x, prefabTabelle.GetComponent<RectTransform>().sizeDelta.y * size);
        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

        int i = 0;
        foreach (Weide weide in Testing.weiden)
        {

            scrollContent.transform.position.Set(0, 0, 0);
            GameObject zeile = Instantiate(prefabTabelle, scrollContent.transform);
            Vector3 pos = i * new Vector3(0, -zeile.GetComponent<RectTransform>().sizeDelta.y + 4, 0);
            zeile.transform.localPosition = pos;
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, weide.weidennummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, weide.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, weide.arbeiter); 
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, weide.tiere);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, weide.ertrag);

            i++;

        }

        prefabTabelle.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

    }
    public void alleWeidenTabelleAus()
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
