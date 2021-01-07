using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class ObjektBewegung : MonoBehaviour
{
    public static bool selected;
    public int preis;

    private bool bauen;



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
            
            //Schaue, ob schon Gebäude ander Stelle und abfangen ob in Interface
            if (Testing.grid.CheckEmpty(transform.position,Testing.objektGebaut, (int) transform.rotation.eulerAngles.z) 
                && Utilitys.ImBildschirm())
            {

                selected = false;
                transform.position += new Vector3(0, 0, 0.8f);
                Testing.grid.SetWert(transform.position, Testing.objektGebaut);
                //2x1 und 2x2 Bauten abfangen und wert setzen
                if (Testing.objektGebaut>20 && Testing.objektGebaut % 10 % 3 == 1)
                {
                    GridWertSetzen1x2();
                }
                if (Testing.objektGebaut > 20 && Testing.objektGebaut % 10 % 3 == 2)
                {
                    GridWertSetzen2x2();
                }
                
                Testing.geld -= preis;
                GlowOnOff.status = 0;

                //if, da nur für haus1 Glow on of
                if (Testing.objektGebaut == 10) {
                    int anz = gameObject.transform.childCount;
                    for (int i = 0; i < anz; i++)
                    {
                        GameObject kind = gameObject.transform.GetChild(i).gameObject;
                        kind.GetComponent<GlowOnOff>().EnableHighlight(0);
                        Destroy(kind.GetComponent<GlowOnOff>());
                    }
                }
                Testing.objektGebaut = 0;
                Destroy(GetComponent<ObjektBewegung>());
            }
            else
            {
                FehlerAnzeige.fehlertext = "Objekt konnte nicht gesetzt werden!";
                Testing.objektGebaut = 0;
                Destroy(gameObject);
            }
        }
        //Drehen
        if (Input.GetMouseButtonDown(1))
        {
            if (Testing.objektGebaut < 20 || Testing.objektGebaut % 10 % 3 != 2)
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90f);
            }
            
        }
        //Position der Maus= Postion vom Haus
        if (selected == true)
        {
            Vector3 cursorPos = Utilitys.GetMouseWorldPosition();
            Vector3 position = Testing.grid.stayInGrid(cursorPos);
            transform.position = position;

            if(Testing.grid.CheckEmpty(transform.position, Testing.objektGebaut, (int)transform.rotation.eulerAngles.z))
            {
                GlowOnOff.status = 2;
            }
            else { GlowOnOff.status = 1; }
        }
        
            
            
            
        }

    private void GridWertSetzen2x2()
    {
        Testing.grid.SetWert(transform.position + new Vector3(10, 0, 0), Testing.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(0,-10, 0), Testing.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(10,-10, 0), Testing.objektGebaut);
    }

    private void GridWertSetzen1x2()
    {
        if (transform.rotation.eulerAngles.z == 0) { Testing.grid.SetWert(transform.position+new Vector3(10,0,0), Testing.objektGebaut);        }
        else if (transform.rotation.eulerAngles.z == 90) { Testing.grid.SetWert(transform.position + new Vector3(0, 10, 0), Testing.objektGebaut); }
        else if (transform.rotation.eulerAngles.z ==180) { Testing.grid.SetWert(transform.position + new Vector3(-10, 0, 0), Testing.objektGebaut); }
        else { Testing.grid.SetWert(transform.position + new Vector3(0, -10, 0), Testing.objektGebaut); }
    }
}

    

