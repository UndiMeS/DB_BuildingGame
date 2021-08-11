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
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startWidth = 0.1f;
        
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
            if (setposition != 0)
            {
                Vector3[] ecken = new Vector3[4];
                objekt1.GetComponent<RectTransform>().GetWorldCorners(ecken);
                Vector3[] mittelpunkte = new Vector3[] { (ecken[0] + ecken[1]) / 2, (ecken[1] + ecken[2]) / 2, (ecken[2] + ecken[3]) / 2, (ecken[3] + ecken[0]) / 2 };
                //falls Entität mit sich selbst in Beziehung
                if (setposition == 1)
                {
                    pos1 = mittelpunkte[0];
                }
                else if (setposition == 2)
                {
                    pos1 = mittelpunkte[2];
                }
            }
            else
            {
                //pos1 = objekt1.transform.position;
                pos1 = getPosition(objekt1);
            }


            //pos2 = objekt2.transform.position;
            pos2 = getPosition(objekt2);
            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos2 );
           
        }
    }

   private Vector3 getPosition(GameObject @object)
    {
        Vector3[] v = new Vector3[4];
        @object.GetComponent<RectTransform>().GetWorldCorners(v);
        float x = v[0].x + (@object.transform.position.x - v[0].x) / (2 * @object.GetComponent<RectTransform>().pivot.x);
        float y = v[0].y + (@object.transform.position.y - v[0].y) / (2 * @object.GetComponent<RectTransform>().pivot.y);

        return new Vector2(x, y);
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
