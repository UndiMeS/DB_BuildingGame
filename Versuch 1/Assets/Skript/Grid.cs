using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Grid
{
    private int weite;
    private int hoehe;
    private int[,] gridArray;
    private float zellengroesse;
    private TextMesh[,] debugTextArray;



    public Grid(int weite, int hoehe, float zellengroesse)
    {
        this.weite = weite;
        this.hoehe = hoehe;
        this.zellengroesse = zellengroesse;

        gridArray = new int[weite, hoehe];
        debugTextArray = new TextMesh[weite,hoehe];

        //Erzeugt Grid in der Welt mit Gizmolinien
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = Utilitys.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x,y )+new Vector3(zellengroesse,zellengroesse)*0.5f, 20, Color.white,TextAnchor.MiddleCenter); //20 Textgröße
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1),Color.white,100);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y),Color.white,100);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, hoehe), GetWorldPosition(weite, hoehe), Color.white, 100);
        Debug.DrawLine(GetWorldPosition(weite, 0), GetWorldPosition(weite, hoehe), Color.white, 100);

        }
    
    //gridposition zu Weltposition
    private Vector3 GetWorldPosition(int x, int y)
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
    public void SetWert(int x, int y, int wert)
    {
        if(x >= 0 && y >= 0 && x < weite && y < hoehe) {    //später vielleicht Werte für Gebäude??
            gridArray[x, y] = wert;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
            debugTextArray[x, y] = Utilitys.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(zellengroesse, zellengroesse) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);

        }
    }

    public void SetWert(Vector3 weltPosition, int wert)
    {
        int x, y;
        GetXY(weltPosition, out x, out y);
        SetWert(x, y, wert);
        
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

    public int GetWert(Vector3 weltPosition)
    {
        int x, y;
        GetXY(weltPosition, out x, out y);
        return gridArray[x, y];
    }
        
}
