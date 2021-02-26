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


    public GameObject gebaeude;

    private int wert = 0;

    private int menschkosten = 10;
    private int tierkosten = 10;

    public static bool forschungsauswahl = false;

    public TMP_Dropdown Forschungsmerkmal;

    public GameObject spezialisierungsIcon;
    public Sprite wohn;
    public Sprite feld;
    public Sprite weide;
    public Sprite stall;

    public static int[] projektMerkmalStufen;

    public GameObject ProjektBlockPanel;

    // Start is called before the first frame update
    void Start()
    {
        Nichts();
        projektMerkmalStufen = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 };
        staticSpezialisierungsauswahl = spezialisierungsauswahl;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ( Testing.objektGebaut==0 && outBox(Input.mousePosition))
            {
                Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
                cursorPos.z = 2f;
                wert = Testing.grid.GetWert(cursorPos);
                gebaeude = Testing.grid.GetGebaeude(cursorPos);


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
        }
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
        if (forschungsauswahl)
        {
            foreach (GameObject anzeige in anzeigen)
            {
                    anzeige.SetActive(false);
            }
        }
    }

    private bool outBox(Vector3 mousePosition)
    {
        Vector3[] v = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(v);
        if (gameObject.activeSelf) { return mousePosition.x < v[2].x && mousePosition.y > v[2].y; }
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
        if (!forschungsauswahl)
        {
            gebaeude.GetComponent<Forschung>().ausgabeStation(forschungsTabelle);
            gebaeude.GetComponent<Forschung>().ausgabeProjekt(projektTabelle);
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
    }

    public void Forscher()
    {
        if(gebaeude.GetComponent<Wohncontainer>().freieBetten!= 0)
        {
            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.forscher++;
            Testing.geld -= menschkosten;
        }        
    }
    public void Feldarbeiter()
    {
        if (gebaeude.GetComponent<Wohncontainer>().freieBetten != 0)
        {
            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.feldarbeiter++;
            Testing.geld -= menschkosten;
        }
    }
    public void Tierpfleger()
    {
        if (gebaeude.GetComponent<Wohncontainer>().freieBetten != 0)
        {
            gebaeude.GetComponent<Wohncontainer>().freieBetten--;
            Testing.tierpfleger++;
            Testing.geld -= menschkosten;
        }
    }
     public void Tiere()
    {
        if (gebaeude.GetComponent<Stallcontainer>().freieGehege != 0)
        {
            gebaeude.GetComponent<Stallcontainer>().freieGehege--;
            Testing.tiere++;
            Testing.geld -= tierkosten;
        }
    }

    public void Spezialisierung(string spezialisierung)
    {
        foreach (GameObject ge in Testing.gebauedeListe)
        {
            gebaeude = ge;
        }
        wert = 3;
        gebaeude.GetComponent<Forschung>().spezialisierung = spezialisierung;
        spezialisierungsauswahl.SetActive(false);
        forschungsauswahl = false;

        if (spezialisierung.Equals("Wohncontainer"))
        {
            gebaeude.GetComponent<Forschung>().spezInt = 1;
            spezialisierungsIcon.GetComponent<Image>().sprite = wohn;

        }else if (spezialisierung.Equals("Feldsphäre"))
        {
            gebaeude.GetComponent<Forschung>().spezInt = 2;
            spezialisierungsIcon.GetComponent<Image>().sprite = feld;
        }
        else if (spezialisierung.Equals("Weidesphäre"))
        {
            gebaeude.GetComponent<Forschung>().spezInt = 4;
            spezialisierungsIcon.GetComponent<Image>().sprite = weide;
        }
        else if (spezialisierung.Equals("Stallcontainer"))
        {
            gebaeude.GetComponent<Forschung>().spezInt = 5;
            spezialisierungsIcon.GetComponent<Image>().sprite = stall;
        }
        gebaeude.GetComponent<Forschung>().verbesserung(Forschungsmerkmal);
        ProjektBlockPanel.SetActive(true);
    }
    public void erstelleProjekt()
    {
        Projekt projekt = new Projekt();
        if (gebaeude.GetComponent<Forschung>().maxAnzahlProjekte >= gebaeude.GetComponent<Forschung>().anzahlProjekte&& Testing.forscher + projekt.forscheranzahl >= projekt.forscheranzahl)
        {
            gebaeude.GetComponent<Forschung>().addProjekt(projekt);
            gebaeude.GetComponent<Forschung>().anzahlProjekte++;
            ProjektBlockPanel.SetActive(false);
        }
        else
        {   if(Testing.forscher + projekt.forscheranzahl < projekt.forscheranzahl)
            {
                FehlerAnzeige.fehlertext = "Du hast zu wenige Forscher";
            }
            else
            {
                FehlerAnzeige.fehlertext = "Du kannst hier keine neuen Projekte mehr erzeugen.";
            }
            Testing.forscher += projekt.forscheranzahl;
            
            if (gebaeude.GetComponent<Forschung>().anzahlProjekte == 0)
            {
                ProjektBlockPanel.SetActive(true);
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

}
