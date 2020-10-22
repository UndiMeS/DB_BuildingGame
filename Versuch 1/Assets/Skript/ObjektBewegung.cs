using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class ObjektBewegung : MonoBehaviour
{
    public static bool selected;
    public Text fehlermeldung;
  


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
           
            //Schaue ob Maus im Panel
            if (Input.mousePosition.y < 280)
            {
            Text fehler= Instantiate(fehlermeldung, transform.position, transform.rotation);
            fehler.text = "Objekt konnte nicht gesetzt werden!";
            //yield return new WaitForSeconds(4);
            UnityEngine.Debug.Log("Objekt konnte nicht gesetzt werden!");
            //fehlermeldung.GetComponent<Text>().text = "";
            Destroy(gameObject);
            }
            
            else{
                //Schaue, ob schon Gebäude ander Stelle
                if (Testing.grid.CheckEmpty(transform.position))
                {
                    selected = false;
                    transform.position += new Vector3(0, 0, 0.42f);
                    Testing.grid.SetWert(transform.position, Toolbar.objektGebaut);
                    Destroy(GetComponent<ObjektBewegung>());

                }
                else
                {
                    Destroy(gameObject);
                }



            }
        }
        //Drehen
        if (Input.GetMouseButtonDown(1))
        {
            transform.rotation *= Quaternion.Euler(0, 0, 90f);
        }
        //Position der Maus= Postion vom Haus
        if (selected == true)
        {
            Vector3 cursorPos = Utilitys.GetMouseWorldPosition();
            cursorPos.z = 2f;
            Vector3 position =stayInGrid(cursorPos);
            transform.position = position;

            
        }
    }

    //Weltposition in Grid 
    private Vector3 stayInGrid(Vector3 cursorPos)
    {
        Vector3 position= new Vector3(-1,-1,-1);
        float x = cursorPos.x;
        x = ((int)(x / Testing.zellengroesse))*Testing.zellengroesse + Testing.zellengroesse / 2;
        position.x = x;

        float y = cursorPos.y;
        y = ((int)(y / Testing.zellengroesse)) * Testing.zellengroesse + Testing.zellengroesse / 2;
        position.y = y;

        position.z = 0.88f;
        if (position.x > Testing.weite * Testing.zellengroesse) { position.x = Testing.weite*Testing.zellengroesse - Testing.zellengroesse / 2; }
        if (position.x < 0) { position.x = Testing.zellengroesse / 2; }
        if (position.y > Testing.hoehe * Testing.zellengroesse) { position.y = Testing.hoehe*Testing.zellengroesse - Testing.zellengroesse / 2; }
        if (position.y < 0) { position.y = Testing.zellengroesse / 2; }
        return position;
    }


  
   
}
