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


    public GameObject gebaeude;

    private int wert = 0;

    private int menschkosten = 10;

    // Start is called before the first frame update
    void Start()
    {
        Nichts();
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
                    }i++;
                }

            
                
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
                Forschung(wert);
                break;
            case 4:
                Weide(wert);
                break;
            case 5:
                Stall(wert);
                break;
        }
    }

    private bool outBox(Vector3 mousePosition)
    {
        Vector3[] v = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(v);
        return mousePosition.x < v[2].x && mousePosition.y > v[2].y;
    }

    private void Haus(GameObject gebaeude)
    {
        gebaeude.GetComponent<Wohncontainer>().ausgabe(wohncontainerTabelle);
    }
    private void Feld(GameObject gebaeude)
    {
        gebaeude.GetComponent<Feld>().ausgabe(feldTabelle);
    }
    private void Forschung(int wert)
    {

    }

    private void Stall(int wert)
    {
    }

    

    
    private void Weide(int wert)
    {
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
}
