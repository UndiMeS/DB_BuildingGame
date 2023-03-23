using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//Bewgung der Gebaeude
public class ObjektBewegung : MonoBehaviour
{
    public static bool selected;
    private bool bauen;

    public static GameObject erstellfenster;
    public static GameObject infoAnzeige;

    public GebäudeAnimation AnimationScript;
    public GameObject GrünesGebäude;
    public GameObject FinalGebäude;
    public float ZPosition;
    public float XPosition;
    public float YPosition;
    public Material GrünesGebäudeRenderer;
    public Color RedHouseColor;
    public Color GreenHouseColor;

    public GameObject ButtonLeisteRechts;
    public bool nocheinbau;

    public RTS_Cam.RTS_Camera RTSscript;

    //public bool BuildBool = true;
    

    // Start is called before the first frame update
    void Start()
    {
        ButtonLeisteRechts = GameObject.Find("ButtonLeisteRechts");
        GebaeudeInfoBauen.wertFest = 0;
        selected = true;
        Testing.gebautesObjekt = gameObject;

        RTSscript = GameObject.FindWithTag("MainCamera").GetComponent<RTS_Cam.RTS_Camera>();
        //GrünesGebäudeRenderer = GrünesGebäude.GetComponent<Renderer>();
        //LandingAnimation = this.gameObject.GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RTSscript.enabled = false;
        }

        Debug.Log("wir sind hier " + Testing.objektGebaut);
        if (Input.GetMouseButtonUp(0) )
        {

            RTSscript.enabled = true;

            //nocheinbau = true;

           
            //Schaue, ob schon Gebäude an der Stelle und abfangen ob in Bildschirmflaeche
            if (Testing.NeuesGebaeude == false && initKlasseTestePreis()&& Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z)&& outBox(Input.mousePosition))
            {
                if (Testing.objektGebaut == 1)
                {
                     gameObject.AddComponent<Wohncontainer>();
                }
                else if (Testing.objektGebaut == 2)
                {
                    gameObject.AddComponent<Feld>();
                }
                else if (Testing.objektGebaut == 3)
                {
                    gameObject.AddComponent<Forschung>();
                }
                else if (Testing.objektGebaut == 4)
                {
                   gameObject.AddComponent<Weide>();
                }
                else if (Testing.objektGebaut == 5)
                {
                   gameObject.AddComponent<Stallcontainer>();
                }
                


                selected = false;
                PanelKnopf.NochEinBau = true;

                Debug.Log("baue das Haus");
                GrünesGebäude.SetActive(false);
                FinalGebäude.SetActive(true);
                
                
                Testing.grid.SetWert(transform.position, Testing.objektGebaut,gameObject);
                transform.position += new Vector3(XPosition, YPosition, ZPosition);
                AnimationScript.GebäudeBauen = true;


                //2x1 und 2x2 Bauten abfangen und wert setzen
                /*if (Testing.objektGebaut>20 && Testing.objektGebaut % 10 % 3 == 1)//10,11,12 haus; 20,21,22 weide; 30,31,32 feld; ...1 klein;...2 mittel;...3 groß
                {
                    GridWertSetzen1x2();
                }
                if (Testing.objektGebaut > 20 && Testing.objektGebaut % 10 % 3 == 2)
                {
                    GridWertSetzen2x2();
                }*/


                if (Testing.objektGebaut == 3)
                {
                    GebaeudeAnzeige.staticSpezialisierungsauswahl.SetActive(true);
                }
                
                PanelKnopf.gebautetsGebaeude = null;
                KameraKontroller.aktiviert = true;




                Debug.Log("Panel" + Testing.objektGebaut);

                Destroy(GetComponent<ObjektBewegung>());

                
               
            }
            else
            {
                if (FehlerAnzeige.fehlertext.Equals("") && !outBox(Input.mousePosition))
                {
                    //GrünesGebäudeRenderer.material.SetColor("_Color", Color.red); 
                    FehlerAnzeige.fehlertext = "Wähle zum Bauen eine freie Fläche!";
                }else if (FehlerAnzeige.fehlertext.Equals("") && !Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z))
                    {
                        FehlerAnzeige.fehlertext = "An dieser Stelle befindet sich schon ein Gebäude!";
                        //GrünesGebäudeRenderer.material.SetColor("_Color", Color.red); 
                    }

                selected = false;                
                int x, y;
                Testing.grid.GetXY(transform.position, out x, out y);
                //Testing.objektGebaut = 0;
                KameraKontroller.aktiviert = true;
                PanelKnopf.gebautetsGebaeude = null;
                Testing.gebautesObjekt = null;
                Debug.Log("Hier!");
                Destroy(gameObject);
                Destroy(GetComponent<ObjektBewegung>());
            }

            if(Testing.neuesgebaeude == true)
            {
                Testing.objektGebaut = 0;
                Testing.GebaeudeTemp = null;

                selected = false;                
                int x, y;
                Testing.grid.GetXY(transform.position, out x, out y);
                //Testing.objektGebaut = 0;
                KameraKontroller.aktiviert = true;
                PanelKnopf.gebautetsGebaeude = null;
                Testing.gebautesObjekt = null;
                Debug.Log("Hier!");
                Destroy(gameObject);
                Destroy(GetComponent<ObjektBewegung>());
            }
        }
        Debug.Log("Hier!" + PauseMenu.SpielIstPausiert + " " + initKlasseTestePreis());
        if (PauseMenu.SpielIstPausiert||!initKlasseTestePreis())
        {
            selected = false;
            int x, y;
            Testing.grid.GetXY(transform.position, out x, out y);
            Testing.grid.SetWert(transform.position, 0, null);
            Testing.objektGebaut = 0;
            KameraKontroller.aktiviert = true;
            PanelKnopf.gebautetsGebaeude = null;
            Testing.gebautesObjekt = null;
            Debug.Log("Hier!"+ PauseMenu.SpielIstPausiert+" "+ initKlasseTestePreis());
            Destroy(gameObject);
            Destroy(GetComponent<ObjektBewegung>());
        }
        
        //Position der Maus= Postion vom Haus
        if (selected == true)
        {     

            

            Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
            Vector3 position = Testing.grid.stayInGrid(cursorPos);
            position.z = 0;
            
            transform.position = position;

            if(!Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z)||!outBox(Input.mousePosition))
            {
                GrünesGebäudeRenderer.SetColor("_BaseColor", RedHouseColor);
                
                 
            }
            else
            {
                GrünesGebäudeRenderer.SetColor("_BaseColor", GreenHouseColor);
                
            }
        }




    }

    private bool BuildBool()
    {
            
        if (Testing.objektGebaut == 1)
        {
            if (Testing.geld < Wohncontainer.preis)
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 2)
        {
            if (Testing.geld < Feld.preis)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 3)
        {
            if (Testing.geld < Forschung.preis)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 4)
        {
            if (Testing.geld < Weide.preis)
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 5)
        {
            if (Testing.geld < Stallcontainer.preis)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    
    }

    private bool initKlasseTestePreis()
    {
        Debug.Log(Testing.objektGebaut);
        if (Testing.objektGebaut == 1)
        {
            if (Testing.geld < Wohncontainer.preis)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 1;
                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                Testing.objektGebaut = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 2)
        {
            if (Testing.geld < Feld.preis)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 2;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                Testing.objektGebaut = 0;
                return false;
            }
            else if (Feld.arbeiterzahl > Testing.feldarbeiter)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 2;

                FehlerAnzeige.fehlertext = "Siedle zuerst Feldastronauten in einem Wohncontainer mit noch freien Betten an! ";
                Testing.objektGebaut = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 3)
        {
            if (Testing.geld < Forschung.preis)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 3;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                Testing.objektGebaut = 0;
                return false;
            }
            else if (0 == Testing.forscher)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 3;

                FehlerAnzeige.fehlertext = "Siedle zuerst Forschungsastronauten in einem Wohncontainer mit noch freien Betten an!";
                Testing.objektGebaut = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (Testing.objektGebaut == 4)
        {
            if (Testing.geld < Weide.preis)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 4;
                Debug.Log("3");
                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                Testing.objektGebaut = 0;
                return false;
            }
            else if (Weide.arbeiterzahl > Testing.tierpfleger && Weide.tierAnzahl > Testing.summeTiere)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 4;
                Debug.Log("3");
                FehlerAnzeige.fehlertext = "Siedle zuerst Weideastronauten und Tiere an!";
                Testing.objektGebaut = 0;
                return false;
            }
            else if (Weide.arbeiterzahl > Testing.tierpfleger)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 4;
                Debug.Log("3");
                FehlerAnzeige.fehlertext = "Siedle zuerst Weideastronauten an!";
                Testing.objektGebaut = 0;
                return false;
            }
            else if (Weide.tierAnzahl > Testing.summeTiere)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest = 4;
                Debug.Log("3");
                FehlerAnzeige.fehlertext = "Siedle zuerst Tiere an!";
                Testing.objektGebaut = 0;
                return false;
            }
            else
            {
                Debug.Log("3");
                return true;
            }
        }
        else if (Testing.objektGebaut == 5)
        {
            if (Testing.geld < Stallcontainer.preis)
            {
                Testing.GebaeudeTemp = null;
                GebaeudeInfoBauen.wertFest =5;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                Testing.objektGebaut = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    private void deleteGebaeudeKlasse()
    {
        if (Testing.objektGebaut == 1)
        {
            Wohncontainer.nummerZaehler--;
        }else if (Testing.objektGebaut == 2)
        {
            Feld.nummerZaehler--;
        }
        else if (Testing.objektGebaut == 3)
        {
            //GebaeudeAnzeige.forschungsauswahl = 0;
            Testing.forscher++;
            Forschung.nummerZaehler--;
        }
        else if (Testing.objektGebaut == 4)
        {
            Weide.nummerZaehler--;
        }
        else if (Testing.objektGebaut == 5)
        {
            Stallcontainer.nummerZaehler--;
        }
    }

    private bool outBox(Vector3 mousePosition)
    {
        bool temp = RectTransformUtility.RectangleContainsScreenPoint(ButtonLeisteRechts.GetComponent<RectTransform>(), mousePosition,null);
        if (!GebaeudeAnzeige.childOn) { return !temp; }
        return !temp&&!RectTransformUtility.RectangleContainsScreenPoint(infoAnzeige.GetComponent<RectTransform>(), mousePosition, null); 
    }

    /*private void GridWertSetzen2x2()
    {
        Testing.grid.SetWert(transform.position + new Vector3(10, 0, 0), Testing.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(0, -10, 0), Testing.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(10, -10, 0), Testing.objektGebaut);
    }

    private void GridWertSetzen1x2()
    {
        if (transform.rotation.eulerAngles.z == 0) { Testing.grid.SetWert(transform.position + new Vector3(10, 0, 0), Testing.objektGebaut); }
        else if (transform.rotation.eulerAngles.z == 90) { Testing.grid.SetWert(transform.position + new Vector3(0, 10, 0), Testing.objektGebaut); }
        else if (transform.rotation.eulerAngles.z == 180) { Testing.grid.SetWert(transform.position + new Vector3(-10, 0, 0), Testing.objektGebaut); }
        else { Testing.grid.SetWert(transform.position + new Vector3(0, -10, 0), Testing.objektGebaut); }
    }*/
}



