using System.Collections.Generic;
using UnityEngine;

public class WohncontainerTabelle : MonoBehaviour
{ 

    public GameObject Tabelle;
    public GameObject wohnendeTabelle;
    public GameObject alleTabelle;
    public GameObject wohncontainerTabelle;

    public GameObject prefabTabelle;
    public GameObject wohnprefab;

    public GameObject alleScrollContent;
    public GameObject bewohnerScrollContent;
    public GameObject wohnScrollContent;
    public List<GameObject> zeilenListe = new List<GameObject>();

    public GameObject mission;
    public GameObject gebaeudeAnzeige;
    public RTS_Cam.RTS_Camera RTS_Camera;

    public void Start()
    {
        if(PlatformManager.touch == true)
            {
                RTS_Camera.useTouchInput = false;
                RTS_Camera.useScrollwheelZooming = false;
            }
            else
            {
                RTS_Camera.usePanning = false;
                RTS_Camera.useScrollwheelZooming = false;
            }
    }

    public void TabellenAn()
    {
        if (mission.transform.localPosition.y<150) {
            mission.transform.localPosition= new Vector3(16, 330,0); }
        gebaeudeAnzeige.SetActive(false);
    }

    public void wohnendeAstroTabelleAn()
    {        
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        wohnendeTabelle.SetActive(true);

        foreach (Mensch mensch in GebaeudeAnzeige.gebaeude.GetComponent<Wohncontainer>().bewohner)
        {
            GameObject zeile = Instantiate(prefabTabelle, bewohnerScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, mensch.containerNummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, mensch.name);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, mensch.geburtstag);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, mensch.aufgabe);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, mensch.anreisegebuehr);
        }
    }
    public void wohnendeAstroTabelleAus()
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

    public void alleAstroTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        alleTabelle.SetActive(true);

        foreach (Mensch mensch in Testing.menschen)
        {
            GameObject zeile = Instantiate(prefabTabelle, alleScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, mensch.containerNummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, mensch.name);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, mensch.geburtstag);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, mensch.aufgabe);
            Utilitys.TextInTMP(zeile.transform.GetChild(4).gameObject, mensch.anreisegebuehr);
        }
    }
    public void alleAstroTabelleAus()
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

    public void exit()
    {


        if(PlatformManager.touch == true)
            {
                RTS_Camera.useTouchInput = true;
                RTS_Camera.useScrollwheelZooming = true;
            }
            else
            {
                RTS_Camera.usePanning = true;
                RTS_Camera.useScrollwheelZooming = true;
            }


        alleAstroTabelleAus();
        wohnendeAstroTabelleAus();
        wohnTabelleAus();
        gameObject.GetComponent<FelderTabelle>().alleFelderTabelleAus();
        gameObject.GetComponent<ProjektTabelle>().alleProjekteTabelleAus();
        gameObject.GetComponent<ProjektTabelle>().stationsProjekteTabelleAus();
        gameObject.GetComponent<ProjektTabelle>().stationTabelleAus();
        gameObject.GetComponent<TierTabelle>().alleTiereTabelleAus();
        gameObject.GetComponent<TierTabelle>().wohnendeTiereTabelleAus();
        gameObject.GetComponent<WeidenTabelle>().alleWeidenTabelleAus();
        gameObject.GetComponent<TierTabelle>().stallTiereTabelleAus();
        gebaeudeAnzeige.SetActive(true);
    }

    public void wohnTabelleAn()
    {
        PauseMenu.SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;

        Tabelle.SetActive(true);
        wohncontainerTabelle.SetActive(true);
       
        foreach (Wohncontainer container in Testing.wohncontainer)
        {
            GameObject zeile = Instantiate(wohnprefab, wohnScrollContent.transform);
            zeilenListe.Add(zeile);

            Utilitys.TextInTMP(zeile.transform.GetChild(0).gameObject, container.containernummer);
            Utilitys.TextInTMP(zeile.transform.GetChild(1).gameObject, container.baukosten);
            Utilitys.TextInTMP(zeile.transform.GetChild(2).gameObject, container.bettenanzahl);
            Utilitys.TextInTMP(zeile.transform.GetChild(3).gameObject, container.freieBetten);
        }
    }
    public void wohnTabelleAus()
    {
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        Tabelle.SetActive(false);
        wohncontainerTabelle.SetActive(false);

        foreach (GameObject zeile in zeilenListe)
        {
            Destroy(zeile);
        }
    }
}
