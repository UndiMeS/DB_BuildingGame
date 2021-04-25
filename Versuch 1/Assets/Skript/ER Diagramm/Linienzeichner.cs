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
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startWidth = 0.05f;
        
        lineRenderer.sortingOrder = 0;
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
                   
            
            pos1pos2Bestimmen();

            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos2 );
            //berechneLinie(); //localposition
        }
    }

    private void pos1pos2Bestimmen()
    {
        Vector3[] v1 = new Vector3[4];
        Vector3[] v2 = new Vector3[4];
        objekt1.GetComponent<RectTransform>().GetWorldCorners(v1);
        objekt2.GetComponent<RectTransform>().GetWorldCorners(v2);

        pos1 = objekt1.transform.position;
        pos2 = objekt2.transform.position;
        float difX = Math.Abs( pos1.x - pos2.x);
        float difY = Math.Abs(pos1.y - pos2.y);
        if (difX > difY)
        {
            if (pos1.x > pos2.x)
            {
                pos1 =(v1[0]+v1[1])/2;
                pos2 = (v2[2] + v2[3]) / 2;
            }
            else
            {
                pos1 = (v1[2] + v1[3]) / 2;
                pos2 = (v2[0] + v2[1]) / 2;
            }
        }
        else
        {
            if (pos1.y > pos2.y)
            {
                pos1 = (v1[0] + v1[3]) / 2;
                pos2 = (v2[1] + v2[2]) / 2;
            }
            else
            {
                pos1 = (v1[1] + v1[2]) / 2;
                pos2 = (v2[0] + v2[3]) / 2;
            }
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
