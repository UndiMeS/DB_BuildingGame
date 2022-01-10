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

    //public bool BuildBool = true;
    

    // Start is called before the first frame update
    void Start()
    {
        GebaeudeInfoBauen.wertFest = 0;
        selected = true;
        Testing.gebautesObjekt = gameObject;
        //GrünesGebäudeRenderer = GrünesGebäude.GetComponent<Renderer>();
        //LandingAnimation = this.gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) )
        {
            //Schaue, ob schon Gebäude an der Stelle und abfangen ob in Bildschirmflaeche
            if (initKlasseTestePreis()&& Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z)&& outBox(Input.mousePosition))
            {
                selected = false;
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
                Testing.objektGebaut = 0;
                KameraKontroller.aktiviert = true;
                PanelKnopf.gebautetsGebaeude = null;
                Testing.gebautesObjekt = null;
                Destroy(gameObject);
                Destroy(GetComponent<ObjektBewegung>());
            }
        }
        if (PauseMenu.SpielIstPausiert)
        {
            int x, y;
            Testing.grid.GetXY(transform.position, out x, out y);
            Testing.grid.SetWert(transform.position, 0, null);
            Testing.objektGebaut = 0;
            KameraKontroller.aktiviert = true;
            PanelKnopf.gebautetsGebaeude = null;
            Testing.gebautesObjekt = null;
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
                Debug.Log("besetzt");
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
        if (Testing.objektGebaut == 1)
        {
            if (Testing.geld < Wohncontainer.preis)
            {
                GebaeudeInfoBauen.wertFest = 1;
                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                return false;
            }
            else
            {
                gameObject.AddComponent<Wohncontainer>();
                return true;
            }
        }
        else if (Testing.objektGebaut == 2)
        {
            if (Testing.geld < Feld.preis)
            {
                GebaeudeInfoBauen.wertFest = 2;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                return false;
            }
            else
            {
                gameObject.AddComponent<Feld>();
                return true;
            }
        }
        else if (Testing.objektGebaut == 3)
        {
            if (Testing.geld < Forschung.preis)
            {
                GebaeudeInfoBauen.wertFest = 3;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                return false;
            }
            else
            {
                gameObject.AddComponent<Forschung>();
                return true;
            }
        }
        else if (Testing.objektGebaut == 4)
        {
            if (Testing.geld < Weide.preis)
            {
                GebaeudeInfoBauen.wertFest = 4;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                return false;
            }
            else
            {
                gameObject.AddComponent<Weide>();
                return true;
            }
        }
        else if (Testing.objektGebaut == 5)
        {
            if (Testing.geld < Stallcontainer.preis)
            {
                GebaeudeInfoBauen.wertFest =5;

                FehlerAnzeige.fehlertext = "Du hast zu wenig Geld. Mache eine Zusatzaufgabe!";
                return false;
            }
            else
            {
                gameObject.AddComponent<Stallcontainer>();
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
        bool temp = RectTransformUtility.RectangleContainsScreenPoint(erstellfenster.GetComponent<RectTransform>(), mousePosition,null);
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



