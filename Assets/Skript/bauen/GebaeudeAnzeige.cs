using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Anzeige der Informationen eines Gebauedes, noch nicht vollstaendig
public class GebaeudeAnzeige : MonoBehaviour
{
    public List<GameObject> anzeigen;

    public GameObject wohncontainerTabelle;
    public GameObject feldTabelle;
    public GameObject stallTabelle;
    public GameObject forschungsTabelle;
    public GameObject weidenTabelle;
    public GameObject projektTabelle;

    public GameObject spezialisierungsauswahl;
    public static GameObject staticSpezialisierungsauswahl;


    public static GameObject gebaeude;

    private int wert = 0;

    private int menschkosten = 20;
    private int tierkosten = 10;

    //public static int forschungsauswahl = 0; //0 keine forschungsauswahl aktuell, 1..n = Stationsnummer

    public TMP_Dropdown Forschungsmerkmal;

    public GameObject spezialisierungsIcon;
    public Sprite wohn;
    public Sprite feld;
    public Sprite weide;
    public Sprite stall;

    public static int[] projektMerkmalStufen = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    public static int[] maxStufen;

    public static bool childOn = false;
    public static bool allesAus = false;

    public GameObject merkmalGO;
    public GameObject KostenVerbessernGO;
    public GameObject buttonRechts;

    public GameObject sound_kuh;
    public GameObject sound_schwein;
    public GameObject sound_schaaf;
    public AudioSource[] sound_Forschen;
    public AudioSource[] sound_Feld;
    public AudioSource[] sound_Weide;
    public AudioSource sound_ProjektVerbesserung;
    public AudioSource sound_neuesProjekt;
    // Start is called before the first frame update
    void Start()
    {
        Nichts();
        maxStufen = new int[] { 10, 10, 10, 3, 10, 10, 3, 10, 3, 10, 10 }; // max+1 angeben
        staticSpezialisierungsauswahl = spezialisierungsauswahl;

    }

    void OnSceneLoaded()
    {
        Start();
        gebaeude = null;
        wert = 0;
        projektMerkmalStufen = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        childOn = false;
        allesAus = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !PauseMenu.SpielIstPausiert)
        {
            GebaeudeInfoBauen.wertFest = 0;
            if (Testing.objektGebaut == 0 && outBox(Input.mousePosition))
            {
                Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
                cursorPos.z = 2f;
                wert = Testing.grid.GetWert(cursorPos);
                gebaeude = Testing.grid.GetGebaeude(cursorPos);
            }
        }
        if (!ObjektBewegung.selected && Testing.gebautesObjekt != null)
        {
            GebaeudeInfoBauen.wertFest = 0;
            wert = Testing.objektGebaut;
            gebaeude = Testing.grid.GetGebaeude(Testing.gebautesObjekt.transform.position);
            Testing.gebautesObjekt = null;
            Testing.objektGebaut = 0;
        }
        if (ObjektBewegung.selected || GebaeudeInfoBauen.wertFest != 0 || allesAus)
        {
            wert = 0;
        }


        int i = 1;
        foreach (GameObject anzeige in anzeigen)
        {
            if (i != wert)
            {

                anzeige.SetActive(false);
            }
            else
            {
                anzeige.SetActive(true);
                ObjektBewegung.infoAnzeige = anzeige;
            }
            i++;
        }
        childOn = true;

        switch (wert)
        {
            case 0:
                Nichts();
                break;
            case 1:
                Haus(gebaeude);
                break;
            case 2:
                Feld(gebaeude);
                break;
            case 3:
                Forschung(gebaeude);
                break;
            case 4:
                Weide(gebaeude);
                break;
            case 5:
                Stall(gebaeude);
                break;
        }
        if (Testing.laden)
        {
            // forschungsauswahl = 0;
        }



    }

    private bool outBox(Vector3 mousePosition)
    {
        if (childOn)
        {
            return !(RectTransformUtility.RectangleContainsScreenPoint(ObjektBewegung.infoAnzeige.GetComponent<RectTransform>(), mousePosition, Camera.main) ||
     RectTransformUtility.RectangleContainsScreenPoint(buttonRechts.GetComponent<RectTransform>(), mousePosition, Camera.main));
        }
        else { return true; }
    }

    private void Haus(GameObject gebaeude)
    {
        gebaeude.GetComponent<Wohncontainer>().ausgabe(wohncontainerTabelle);
    }
    private void Feld(GameObject gebaeude)
    {
        gebaeude.GetComponent<Feld>().ausgabe(feldTabelle);
    }
    private void Forschung(GameObject gebaeude)
    {
        if (!gebaeude.GetComponent<Forschung>().spezialisierung.Equals(""))
        {
            gebaeude.GetComponent<Forschung>().ausgabeStation(forschungsTabelle);
            if (gebaeude.GetComponent<Forschung>().spezialisierung.Equals("Wohncontainer"))
            {
                spezialisierungsIcon.GetComponent<Image>().sprite = wohn;
            }
            else if (gebaeude.GetComponent<Forschung>().spezialisierung.Equals("Feldsphäre"))
            {
                spezialisierungsIcon.GetComponent<Image>().sprite = feld;
            }
            else if (gebaeude.GetComponent<Forschung>().spezialisierung.Equals("Weidesphäre"))
            {
                spezialisierungsIcon.GetComponent<Image>().sprite = weide;
            }
            else if (gebaeude.GetComponent<Forschung>().spezialisierung.Equals("Stallcontainer"))
            {
                spezialisierungsIcon.GetComponent<Image>().sprite = stall;
            }

            gebaeude.GetComponent<Forschung>().ausgabeProjekt(projektTabelle, merkmalGO, KostenVerbessernGO);
        }
        else
        {
            spezialisierungsauswahl.SetActive(true);
            anzeigen[2].SetActive(false);
        }
    }

    private void Stall(GameObject gebaeude)
    {
        gebaeude.GetComponent<Stallcontainer>().ausgabe(stallTabelle);
    }


    private void Weide(GameObject gebaeude)
    {
        gebaeude.GetComponent<Weide>().ausgabe(weidenTabelle);
    }


    private void Nichts()
    {
        childOn = false;
    }

    public void Forscher()
    {
        if (Testing.geld < menschkosten)
        {
            FehlerAnzeige.fehlertext = "Zu wenig Geld.";
            return;
        }
        if (gebaeude.GetComponent<Wohncontainer>().freieBetten != 0)
        {
            AudioSource forscherSound = sound_Forschen[UnityEngine.Random.Range(0, sound_Forschen.Length)].GetComponent<AudioSource>();
            forscherSound.Play();
            
            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.forscher++;
            Testing.geld -= menschkosten;
            Testing.summeMenschen++;
            Mensch temp = new Mensch("Forschung", gebaeude.GetComponent<Wohncontainer>().containernummer);
            gebaeude.GetComponent<Wohncontainer>().bewohner.Add(temp);
        }
    }
    public void Feldarbeiter()
    {
        if (Testing.geld < menschkosten)
        {
            FehlerAnzeige.fehlertext = "Zu wenig Geld.";
            return;
        }
        if (gebaeude.GetComponent<Wohncontainer>().freieBetten != 0)
        {
            AudioSource feldSound = sound_Feld[UnityEngine.Random.Range(0, sound_Feld.Length)].GetComponent<AudioSource>();
            feldSound.Play();

            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.feldarbeiter++;
            Testing.geld -= menschkosten;
            Testing.summeMenschen++;
            Mensch temp = new Mensch("Feld", gebaeude.GetComponent<Wohncontainer>().containernummer);
            gebaeude.GetComponent<Wohncontainer>().bewohner.Add(temp);
        }
    }
    public void Tierpfleger()
    {
        if (Testing.geld < menschkosten)
        {
            FehlerAnzeige.fehlertext = "Zu wenig Geld.";
            return;
        }
        if (gebaeude.GetComponent<Wohncontainer>().freieBetten != 0)
        {
            AudioSource weideSound = sound_Weide[UnityEngine.Random.Range(0, sound_Weide.Length)].GetComponent<AudioSource>();
            weideSound.Play();
            
            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.tierpfleger++;
            Testing.geld -= menschkosten;
            Testing.summeMenschen++;
            Mensch temp = new Mensch("Weide", gebaeude.GetComponent<Wohncontainer>().containernummer);
            gebaeude.GetComponent<Wohncontainer>().bewohner.Add(temp);
        }
    }
    public void Tiere(int welchesTier)
    {
        AudioSource kuh = sound_kuh.GetComponent<AudioSource>();
        AudioSource schaaf = sound_schaaf.GetComponent<AudioSource>();
        AudioSource schwein = sound_schwein.GetComponent<AudioSource>();
        if (Testing.geld < tierkosten)
        {
            FehlerAnzeige.fehlertext = "Zu wenig Geld.";
            return;
        }
        if (gebaeude.GetComponent<Stallcontainer>().freieGehege != 0)
        {
            gebaeude.GetComponent<Stallcontainer>().freieGehege--;
            Testing.tiere++;
            Testing.geld -= tierkosten;
            Testing.summeTiere++;
            string art = "";
            if (welchesTier == 0)
            {
                art = "Kuh";
                kuh.Play(0);

            }
            else if (welchesTier == 1)
            {
                art = "Schwein";
                schwein.Play(0);
            }
            else
            {
                art = "Schaf";
                schaaf.Play(0);
            }
            Tiere temp = new Tiere(art, gebaeude.GetComponent<Stallcontainer>().containernummer);
            gebaeude.GetComponent<Stallcontainer>().tiere.Add(temp);
        }
    }

    public void Spezialisierung(string spezialisierung)
    {
        gebaeude.GetComponent<Forschung>().spezialisierung = spezialisierung;
        spezialisierungsauswahl.SetActive(false);

        if (spezialisierung.Equals("Wohncontainer"))
        {
            gebaeude.GetComponent<Forschung>().spezialisierung = "Wohncontainer";
            spezialisierungsIcon.GetComponent<Image>().sprite = wohn;

        }
        else if (spezialisierung.Equals("Feldsphäre"))
        {
            gebaeude.GetComponent<Forschung>().spezialisierung = "Feldsphäre";
            spezialisierungsIcon.GetComponent<Image>().sprite = feld;
        }
        else if (spezialisierung.Equals("Weidesphäre"))
        {
            gebaeude.GetComponent<Forschung>().spezialisierung = "Weidesphäre";
            spezialisierungsIcon.GetComponent<Image>().sprite = weide;
        }
        else if (spezialisierung.Equals("Stallcontainer"))
        {
            gebaeude.GetComponent<Forschung>().spezialisierung = "Stallcontainer";
            spezialisierungsIcon.GetComponent<Image>().sprite = stall;
        }
        gebaeude.GetComponent<Forschung>().verbesserung(Forschungsmerkmal, merkmalGO);
    }
    public void erstelleProjekt()
    {
        if (gebaeude.GetComponent<Forschung>().maxAnzahlProjekte > gebaeude.GetComponent<Forschung>().anzahlProjekte && Testing.forscher >= Projekt.forscher && Testing.geld >= gebaeude.GetComponent<Forschung>().projektkosten)
        {
            gebaeude.GetComponent<Forschung>().createProjekt();
            AudioSource projektSound = sound_neuesProjekt.GetComponent<AudioSource>();
            projektSound.Play();
        }
        else
        {
            if (Testing.geld < gebaeude.GetComponent<Forschung>().projektkosten)
            {
                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld.";
            }
            else if (Testing.forscher < Projekt.forscher)
            {
                FehlerAnzeige.fehlertext = "Du hast zu wenige Forscher.";
            }
            else
            {
                FehlerAnzeige.fehlertext = "Du kannst hier keine neuen Projekte mehr erzeugen.";
            }


        }


    }

    public void projektMerkmal(int option)
    {
        gebaeude.GetComponent<Forschung>().setMerkmal(option);
    }

    public static void spezialMenueAnzeigen()
    {
        FehlerAnzeige.fehlertext = "Wähle eine Spezialisierung der Forschungsstation fest.";
        staticSpezialisierungsauswahl.SetActive(true);
    }

    public void stationverbessern()
    {
        if (gebaeude.GetComponent<Forschung>().projektkosten == Projekt.preis_spielstart)
        {
            
            if (Testing.geld < Projekt.kosten_verbesserung)
            {
                FehlerAnzeige.fehlertext = "Zu wenig Geld.";
                return;
            }else{
                Testing.geld -= Projekt.kosten_verbesserung;
                float vf = (float) Projekt.preis_nach_verbesserung/Projekt.preis_spielstart;
                new Projekt(gebaeude.GetComponent<Forschung>().stationsnummer, "Projektkosten", 11, 1, Projekt.kosten_verbesserung, 0, vf, 0);
                gebaeude.GetComponent<Forschung>().projektkosten = Projekt.preis_nach_verbesserung;
                KostenVerbessernGO.SetActive(false);
                AudioSource verbesserungSound = sound_ProjektVerbesserung.GetComponent<AudioSource>();
                verbesserungSound.Play();
            }
        }
        
    }
}
