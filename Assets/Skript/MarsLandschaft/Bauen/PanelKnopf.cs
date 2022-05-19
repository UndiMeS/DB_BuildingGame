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
    public static bool NochEinBau;
    public GameObject gebaeudeTemp;
    public bool ShowOver;
    //public Animator LandingAnimation;

    // Start is called before the first frame update
    void Start()
    {
        hintergrund = GetComponent<RawImage>();


        
        
        
        if (gebaeudeNummer != 0)
        {
            
            knopfGruppe.Subscribe(this);
        }
    }
    //Methode beim erzeugen eines Gebaeudes
    public void KnopfGedrueckt()
    {

        Testing.objektGebaut = gebaeudeNummer;
        gebautetsGebaeude = Instantiate(gebaeude);
        
        Debug.Log("wir sind hier PanelKnopf first " + Testing.objektGebaut);

        // Multiple Builds
        // if(Testing.neuesgebaeude == true)
        // {
        //     Testing.objektGebaut = this.gebaeudeNummer;
        //     Testing.GebaeudeTemp = this.gebaeude;

        //     Testing.neuesgebaeude = false;

        // }
        
        // Multiple Builds
        // if(NochEinBau == false)
        // {
        //     Testing.objektGebaut = this.gebaeudeNummer;
        //     Testing.GebaeudeTemp = this.gebaeude;
            
        // }

            Testing.objektGebaut = this.gebaeudeNummer;
            //Testing.GebaeudeTemp = this.gebaeude;


        Debug.Log("wir sind hier PanelKnopf second " + Testing.objektGebaut);
        

        // Multiple Builds
        // if(Testing.GebaeudeTemp != null)
        // {
        //     gebautetsGebaeude = Instantiate(Testing.GebaeudeTemp);
        //     gebautetsGebaeude.transform.SetParent(gebaeudeOrdner.transform);
        // }


        
    }

    // Update is called once per frame
    void Update()
    {
        

        // if(Testing.GebaeudeTemp != null)
        // {
        //     //NochEinBau = this.gebaeudeTemp.GetComponent<ObjektBewegung>().nocheinbau;
            
        //     Debug.Log("NochEinBau directly = "+ NochEinBau);
        // }
        

        //  Mutliply Builds
        // if(NochEinBau == true)
        // {
        //     Debug.Log("NochEinBau = true");
        //     KnopfGedrueckt();
        //     //testenObBedingungenErfuellt();
        // }
        

           //Multiple Builds
        // if(Testing.objektGebaut != gebaeudeNummer)
        // {
        //     NochEinBau = false;
        // }


        // if(Testing.neuesgebaeude == true)
        // {
        //     Testing.objektGebaut = this.gebaeudeNummer;
        //     Testing.GebaeudeTemp = this.gebaeude;

        //     Testing.neuesgebaeude = false;

        // }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Testing.neuesgebaeude = true;
        
        knopfGruppe.OnTabEnter(this);
        if (gebaeudeNummer == 0)
        {
            hintergrund.color = Color.red;
            // Multiple Builds
            //Testing.GebaeudeTemp = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        
        knopfGruppe.OnTabSelected(this);

        

        // Multiple Builds --> && NochEinBau == false
        if (gebaeudeNummer != 0 && Testing.objektGebaut == 0 )
        {
            Debug.Log("test");
            Testing.objektGebaut = gebaeudeNummer;
            // Multiple Builds
            //Testing.GebaeudeTemp = this.gebaeude;
            KameraKontroller.aktiviert = false;
            testenObBedingungenErfuellt();
        }
        else
        {
            if (gebaeudeNummer == 0 && gebautetsGebaeude != null)
            {
                // Multiple Builds
                //Testing.GebaeudeTemp = null;
                Testing.objektGebaut = 0;
                ObjektBewegung.selected = false;
                Destroy(gebautetsGebaeude.GetComponent<ObjektBewegung>());
                Destroy(gebautetsGebaeude);
                gebautetsGebaeude = null;
                KameraKontroller.aktiviert = true;
            }
        }
        
        if (gebaeudeNummer != 0)
        {
            hintergrund.color = knopfGruppe.tabIdle;
            
        }
        else
        {
            hintergrund.color = Color.black;
        }

    // Multiple Builds
    // if(Testing.neuesgebaeude == true)
    //     {
    //         Testing.objektGebaut = this.gebaeudeNummer;
    //         // Multiple Builds
    //         //Testing.GebaeudeTemp = this.gebaeude;

    //         Testing.neuesgebaeude = false;
    //         testenObBedingungenErfuellt();

    //     }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Multiple Builds
        //Testing.neuesgebaeude = false;
        
        if (gebaeudeNummer != 0)
        {
            knopfGruppe.OnTabExit();
            
        }
        else
        {
            hintergrund.color = Color.black;
        }
        
    }
   

    public void testenObBedingungenErfuellt()
    {
        

        if (gebaeudeNummer == 2)
        {
            if (Feld.arbeiterzahl > Testing.feldarbeiter)
            {
                GebaeudeInfoBauen.wertFest = 2;
                KameraKontroller.aktiviert = true;
                FehlerAnzeige.fehlertext = "Siedle zuerst Feldastronauten in einem Wohncontainer mit noch freien Betten an! ";
                return;
            }
        }
        if(gebaeudeNummer == 4)
        {
            GebaeudeInfoBauen.wertFest = 4;
            if (Weide.arbeiterzahl > Testing.tierpfleger&&Weide.tierAnzahl> Testing.summeTiere)
            {
                KameraKontroller.aktiviert = true;
                FehlerAnzeige.fehlertext = "Siedle zuerst Weideastronauten und Tiere an!";
                return;
            }else if (Weide.arbeiterzahl > Testing.tierpfleger)
            {
                KameraKontroller.aktiviert = true;
                FehlerAnzeige.fehlertext = "Siedle zuerst Weideastronauten an!";
                return;
            }
            else if (Weide.tierAnzahl > Testing.tiere)
            {
                KameraKontroller.aktiviert = true;
                FehlerAnzeige.fehlertext = "Siedle zuerst Tiere an!";
                return;
            }
        }
        if (gebaeudeNummer == 3)
        {
            if (0== Testing.forscher)
            {
                Debug.Log("Gebäude Nummer: " + gebaeudeNummer);
                KameraKontroller.aktiviert = true;
                GebaeudeInfoBauen.wertFest = 3;
                FehlerAnzeige.fehlertext = "Siedle zuerst Forschungsastronauten in einem Wohncontainer mit noch freien Betten an!";
                return;
            }

        }

        KnopfGedrueckt();
    }

    // void OnMouseOver()
    // {
    //     Testing.NeuesGebaeude = true;
    //     ShowOver = true;
    // }

    // void OnMouseExit()
    // {
    //     ShowOver = false;
    //     Testing.NeuesGebaeude = false;
    // }
}
