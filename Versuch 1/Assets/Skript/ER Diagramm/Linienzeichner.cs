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
    private int breite=3;
    public bool zeichnen=false;

    private LineRenderer lineRenderer;
    private float counter;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
       rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(zeichnen &&( objekt1 == null || objekt2 == null))
        {
            Destroy(gameObject);
            Destroy(gameObject.GetComponent<Linienzeichner>());
        }
        changeName();
        if (zeichnen && objekt1!=null&&objekt2!=null)
        {
            pos1 = objekt1.transform.localPosition;
            pos2 = objekt2.transform.localPosition;
            berechneLinie();
        }
    }

    private void changeName()
    {
        if (objekt1 != null && objekt2 != null)
        {
            gameObject.name = objekt1.name + "-" + objekt2.name;
        }
    }

    private void berechneLinie()
    {
        gameObject.transform.position = objekt1.transform.position;
        rect.sizeDelta = new Vector2((pos2 - pos1).magnitude, breite);
     
        double winkel = Vector3.Angle(objekt2.transform.position - objekt1.transform.position, Vector3.right);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, (float)winkel);
        if (pos2.y < pos1.y)
        {
           gameObject.transform.rotation = Quaternion.Euler(0, 0,-(float) winkel);
        }

    }

    public void setzeGameObjekte(GameObject last, GameObject select)
    {
        objekt1 = last;
        objekt2 = select;
    }
}
