using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
// Auskommentierte Zeilen geben die Nummer in dem Feld an
public class Gitter
{
    private int weite;
    private int hoehe;
    private int[,] gridArray;
    private float zellengroesse;
    private TextMesh[,] debugTextArray;

    private GameObject[,] gebaeudeArray;

    public Gitter(int weite, int hoehe, float zellengroesse)
    {
        this.weite = weite;
        this.hoehe = hoehe;
        this.zellengroesse = zellengroesse;

        gridArray = new int[weite, hoehe];
        debugTextArray = new TextMesh[weite, hoehe];
        gebaeudeArray = new GameObject[weite, hoehe];

        //Erzeugt Grid in der Welt mit Gizmolinien
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = Utilitys.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(zellengroesse, zellengroesse) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter); //20 Textgröße
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, hoehe), GetWorldPosition(weite, hoehe), Color.white, 100);
        Debug.DrawLine(GetWorldPosition(weite, 0), GetWorldPosition(weite, hoehe), Color.white, 100);
    }

    //gridposition zu Weltposition
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * zellengroesse;
    }

    //worldposition in x,y
    public void GetXY(Vector3 weltPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(weltPosition.x / zellengroesse);
        y = Mathf.FloorToInt(weltPosition.y / zellengroesse);

    }

    //Setzt wert an die Stelle
    public void SetWert(int x, int y, int wert, GameObject gebaeude)
    {
        if (x >= 0 && y >= 0 && x < weite && y < hoehe)
        {    
            gridArray[x, y] = wert;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
            erzeugeGebaede(x, y, wert, gebaeude);

            if (wert == 1)
            {
                gebaeude.GetComponent<Wohncontainer>().SetXY(x, y);
            }else if (wert == 2)
            {
                gebaeude.GetComponent<Feld>().SetXY(x, y);
            }
            else if (wert == 3)
            {
                gebaeude.GetComponent<Forschung>().SetXY(x, y);
            }
            else if (wert == 4)
            {
                gebaeude.GetComponent<Weide>().SetXY(x, y);
            }
            else if (wert == 5)
            {
                gebaeude.GetComponent<Stallcontainer>().SetXY(x, y);
            }
        }
    }

    private void erzeugeGebaede(int x, int y, int wert, GameObject gebaeude)
    {
        if (gebaeude == null)
        {
            return;
        }
        else 
        {
            gebaeudeArray[x, y] = gebaeude;
        }
        
    }

    public void SetWert(Vector3 weltPosition, int wert, GameObject gebaeude)
    {
        int x, y;
        GetXY(weltPosition, out x, out y);
        SetWert(x, y, wert, gebaeude);

    }

    //Schaue, ob Wert=0, bzw nichts an dieser Stelle gebaut
    public bool CheckEmpty(Vector3 weltposition)
    {
        int x, y;
        GetXY(weltposition, out x, out y);
        if (gridArray[x, y] == 0)
        {
            return true;
        }

        return false;
    }

    public bool CheckEmpty(Vector3 weltposition, int objektnummer, int drehung)
    {

        bool ausgabe = CheckEmpty(weltposition);
        /*if(objektnummer > 20 &&  objektnummer% 10 % 3 == 1)
        {
            if (drehung == 0) { ausgabe = ausgabe && CheckEmpty(weltposition + new Vector3(10, 0, 0)); }
            else if (drehung == 90) { ausgabe = ausgabe && CheckEmpty(weltposition + new Vector3(0, 10, 0)); }
            else if (drehung == 180) { ausgabe = ausgabe && CheckEmpty(weltposition + new Vector3(-10, 0, 0)); }
            else { ausgabe = ausgabe && CheckEmpty(weltposition + new Vector3(0, -10, 0)); }
        }
        if (objektnummer > 20 && objektnummer % 10 % 3 == 2)
        {
            ausgabe = ausgabe & CheckEmpty(weltposition + new Vector3(10, 0, 0));
            ausgabe = ausgabe & CheckEmpty(weltposition + new Vector3(0, -10, 0));
            ausgabe = ausgabe & CheckEmpty(weltposition + new Vector3(10, -10, 0));
        }*/
        return ausgabe;
    }

    public int GetWert(Vector3 weltPosition)
    {
        int x, y;
        GetXY(weltPosition, out x, out y);
        return gridArray[x, y];
    }

    public GameObject GetGebaeude(Vector3 weltPosition)
    {
        int x, y;
        GetXY(weltPosition, out x, out y);
        return gebaeudeArray[x, y];
    }
    public GameObject GetGebaeude(int x, int y)
    { 
        return gebaeudeArray[x, y];
    }

    //Weltposition in Grid 
    public Vector3 stayInGrid(Vector3 cursorPos)
    {
        Vector3 position = new Vector3(-1, -1, -1);
        float x = cursorPos.x;
        x = ((int)(x / Testing.zellengroesse)) * Testing.zellengroesse + Testing.zellengroesse / 2;
        position.x = x;

        float y = cursorPos.y;
        y = ((int)(y / Testing.zellengroesse)) * Testing.zellengroesse + Testing.zellengroesse / 2;
        position.y = y;


        position.z = -0.8f;
        if (position.x > Testing.weite * Testing.zellengroesse) { position.x = Testing.weite * Testing.zellengroesse - Testing.zellengroesse / 2; }
        if (position.x < 0) { position.x = Testing.zellengroesse / 2; }
        if (position.y > Testing.hoehe * Testing.zellengroesse) { position.y = Testing.hoehe * Testing.zellengroesse - Testing.zellengroesse / 2; }
        if (position.y < 0) { position.y = Testing.zellengroesse / 2; }
        return position;
    }

}
