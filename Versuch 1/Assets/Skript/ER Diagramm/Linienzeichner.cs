using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linienzeichner : MonoBehaviour
{
    public GameObject objekt1;
    public GameObject objekt2;
    public Vector3 pos1;
    private Vector3 pos2;
    private RectTransform rect;
    public bool zeichnen=false;

    private LineRenderer lineRenderer;


    public int setposition=0;

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
            if (setposition==1)
            {
                pos1 = objekt1.transform.position + Vector3.right;
            }else if (setposition == 2)
            {
                pos1 = objekt1.transform.position - Vector3.right;
            }
            else
            {
                pos1 = objekt1.transform.position;
            }
            

            pos2 = objekt2.transform.position;
            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos2 );
           
        }
    }

   

    private void changeName()
    {
        if (objekt1 != null && objekt2 != null)
        {
            gameObject.name = objekt1.name + "-" + objekt2.name;
        }
    }

   

    public void setzeGameObjekte(GameObject last, GameObject select)
    {
        objekt1 = last;
        objekt2 = select;
    }
}
