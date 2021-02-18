using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

//Bewgung der Gebaeude
public class ObjektBewegung : MonoBehaviour
{
    public static bool selected;
    public int preis;
    private bool bauen;

    public static GameObject erstellfenster;
    public static GameObject infoAnzeige;

    // Start is called before the first frame update
    void Start()
    {
        selected = true;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Schaue, ob schon Gebäude ander Stelle und abfangen ob in Bildschirmflaeche
            if (Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z)&& outBox(Input.mousePosition))
            {
                selected = false;
                transform.position += new Vector3(0, 0, 0.8f);
                Testing.grid.SetWert(transform.position, Testing.objektGebaut,gameObject);

                //2x1 und 2x2 Bauten abfangen und wert setzen
                /*if (Testing.objektGebaut>20 && Testing.objektGebaut % 10 % 3 == 1)//10,11,12 haus; 20,21,22 weide; 30,31,32 feld; ...1 klein;...2 mittel;...3 groß
                {
                    GridWertSetzen1x2();
                }
                if (Testing.objektGebaut > 20 && Testing.objektGebaut % 10 % 3 == 2)
                {
                    GridWertSetzen2x2();
                }*/

                Testing.geld -= preis;
                addAnzeigeComponent();
                Testing.objektGebaut = 0;
                PanelKnopf.gebautetsGebaeude = null;
                KameraKontroller.aktiviert = true;
                
                Destroy(GetComponent<ObjektBewegung>());
               
            }
            else
            {
                FehlerAnzeige.fehlertext = "Objekt konnte nicht gesetzt werden!";
                int x, y;
                Testing.grid.GetXY(transform.position, out x, out y);
                Testing.objektGebaut = 0;
                KameraKontroller.aktiviert = true;
                PanelKnopf.gebautetsGebaeude = null;
                Destroy(gameObject);
                Destroy(GetComponent<ObjektBewegung>());
            }
        }
        /*//Drehen
        if (Input.GetMouseButtonDown(1))
        {
            if (Testing.objektGebaut < 20 || Testing.objektGebaut % 10 % 3 != 2)
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90f);
            }
            
        }*/

        //Position der Maus= Postion vom Haus
        if (selected == true)
        {
            Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
            Vector3 position = Testing.grid.stayInGrid(cursorPos);
            transform.position = position;
        }




    }

    private void addAnzeigeComponent()
    {
        if(Testing.objektGebaut == 1)
        {
            gameObject.AddComponent<Wohncontainer>();
        }else if(Testing.objektGebaut == 2)
        {
            gameObject.AddComponent<Feld>();
        }
    }

    private bool outBox(Vector3 mousePosition)
    {
        Vector3[] v = new Vector3[4];
        erstellfenster.GetComponent<RectTransform>().GetWorldCorners(v);
        bool temp = mousePosition.x < v[3].x;
        infoAnzeige.GetComponent<RectTransform>().GetWorldCorners(v);
        return !(temp || (mousePosition.x > v[1].x && mousePosition.y < v[1].y));
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



