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
        if (Input.GetMouseButtonDown(0))
        {
            
            //Schaue, ob schon Gebäude ander Stelle und abfangen ob in Interface
            if (Testing.grid.CheckEmpty(transform.position,Toolbar.objektGebaut, (int) transform.rotation.eulerAngles.z) 
                && Input.mousePosition.y>280*Screen.height/900 && Input.mousePosition.x<1000*Screen.width/1600)
            {

                selected = false;
                transform.position += new Vector3(0, 0, 0.8f);
                Testing.grid.SetWert(transform.position, Toolbar.objektGebaut);
                //2x1 und 2x2 Bauten abfangen und wert setzen
                if (Toolbar.objektGebaut>20 && Toolbar.objektGebaut % 10 % 3 == 1)
                {
                    GridWertSetzen1x2();
                }
                if (Toolbar.objektGebaut > 20 && Toolbar.objektGebaut % 10 % 3 == 2)
                {
                    GridWertSetzen2x2();
                }
                Toolbar.objektGebaut = 0;
                Testing.geld -= preis;
                
                Destroy(GetComponent<ObjektBewegung>());
            }
            else
            {
                FehlerAnzeige.fehlertext = "Objekt konnte nicht gesetzt werden!";
                Toolbar.objektGebaut = 0;
                Destroy(gameObject);
            }
        }
        //Drehen
        if (Input.GetMouseButtonDown(1))
        {
            if (Toolbar.objektGebaut < 20 || Toolbar.objektGebaut % 10 % 3 != 2)
            {
                transform.rotation *= Quaternion.Euler(0, 0, 90f);
            }
            
        }
        //Position der Maus= Postion vom Haus
        if (selected == true)
        {
            Vector3 vector3 = Utilitys.GetMouseWorldPosition();
            Vector3 cursorPos = vector3;
            Vector3 position = Testing.grid.stayInGrid(cursorPos);
            transform.position = position;
        }
        
            
            
            
        }

    private void GridWertSetzen2x2()
    {
        Testing.grid.SetWert(transform.position + new Vector3(10, 0, 0), Toolbar.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(0,-10, 0), Toolbar.objektGebaut);
        Testing.grid.SetWert(transform.position + new Vector3(10,-10, 0), Toolbar.objektGebaut);
    }

    private void GridWertSetzen1x2()
    {
        if (transform.rotation.eulerAngles.z == 0) { Testing.grid.SetWert(transform.position+new Vector3(10,0,0), Toolbar.objektGebaut);        }
        else if (transform.rotation.eulerAngles.z == 90) { Testing.grid.SetWert(transform.position + new Vector3(0, 10, 0), Toolbar.objektGebaut); }
        else if (transform.rotation.eulerAngles.z ==180) { Testing.grid.SetWert(transform.position + new Vector3(-10, 0, 0), Toolbar.objektGebaut); }
        else { Testing.grid.SetWert(transform.position + new Vector3(0, -10, 0), Toolbar.objektGebaut); }
    }
}

    

