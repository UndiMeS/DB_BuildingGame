using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linienzeichner : MonoBehaviour
{
    public GameObject objekt1;
    public GameObject objekt2;
    private Vector3 pos1;
    private Vector3 pos2;
    private RectTransform rect;
    private int breite=5;
    public bool zeichnen=false;

    // Start is called before the first frame update
    void Start()
    {
       rect = gameObject.GetComponent<RectTransform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (zeichnen && objekt1!=null)
        {

            pos1 = objekt1.transform.position;
            pos2 = objekt2.transform.position;

            berechneLinie();
        }
    }

    private void berechneLinie()
    {
        Debug.Log("?");
        rect.sizeDelta = new Vector2((pos2 - pos1).magnitude, breite);
        gameObject.transform.position = pos1;

        double winkel = Math.Atan((pos2.y - pos1.y) / (pos2.x - pos2.y));
        gameObject.transform.rotation = Quaternion.AngleAxis((float)winkel, Vector3.forward);
        
    }

    public void setzeGameObjekte(GameObject last, GameObject select)
    {
        objekt1 = last;
        objekt2 = select;


    }
}
