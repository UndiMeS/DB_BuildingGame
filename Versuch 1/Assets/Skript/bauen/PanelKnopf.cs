using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class PanelKnopf : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int gebaeudeNummer;//0 nichts; 1 haus, 2 forschung, 3 Feld, 4 Weide 5 stall
    public GameObject gebaeude;

    public KnopfGruppe knopfGruppe;
    public RawImage hintergrund;

    public static GameObject gebautetsGebaeude;
    public GameObject spezialisierungsauswahl;
    public GameObject gebaeudeOrdner;

    // Start is called before the first frame update
    void Start()
    {
        hintergrund = GetComponent<RawImage>();
        knopfGruppe.Subscribe(this);
    }
    //Methode beim erzeugen eines Gebaeudes
    public void KnopfGedrueckt()
    {
        Testing.objektGebaut = gebaeudeNummer;
        gebautetsGebaeude = Instantiate(gebaeude);
        gebautetsGebaeude.transform.SetParent(gebaeudeOrdner.transform);
        Debug.Log("Hier");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        knopfGruppe.OnTabSelected(this);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        knopfGruppe.OnTabEnter(this);
        if (gebaeudeNummer != 0 && Testing.objektGebaut == 0)
        {
            KameraKontroller.aktiviert = false;
            testenObBedingungenErfuellt();
        }
        else
        {
            if (gebaeudeNummer == 0 && gebautetsGebaeude != null)
            {
                Testing.objektGebaut = 0;
                Destroy(gebautetsGebaeude.GetComponent<ObjektBewegung>());
                Destroy(gebautetsGebaeude);
                gebautetsGebaeude = null;
                KameraKontroller.aktiviert = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        knopfGruppe.OnTabExit(this);
    }

    public void testenObBedingungenErfuellt()
    {
        

        if (gebaeudeNummer == 2)
        {
            if (Feld.arbeiterzahl > Testing.feldarbeiter)
            {
                GebaeudeInfoBauen.wertFest = 2;

                FehlerAnzeige.fehlertext = "Erstelle zuerst Feldarbeiter!";
                return;
            }
        }
        if(gebaeudeNummer == 4)
        {
            GebaeudeInfoBauen.wertFest = 4;
            if (Weide.arbeiterzahl > Testing.tierpfleger&&Weide.tierAnzahl> Testing.summeTiere)
            {
                
                FehlerAnzeige.fehlertext = "Erstelle zuerst Tierpfleger und Tiere!";
                return;
            }else if (Weide.arbeiterzahl > Testing.tierpfleger)
            {
                FehlerAnzeige.fehlertext = "Erstelle zuerst Tierpfleger!";
                return;
            }
            else if (Weide.tierAnzahl > Testing.tiere)
            {
                FehlerAnzeige.fehlertext = "Erstelle zuerst Tiere!";
                return;
            }
        }
        if (gebaeudeNummer == 3)
        {
            if (0== Testing.forscher)
            {
                GebaeudeInfoBauen.wertFest = 3;
                FehlerAnzeige.fehlertext = "Erstelle zuerst Forscher!";
                return;
            }

        }

        KnopfGedrueckt();
    }
}
