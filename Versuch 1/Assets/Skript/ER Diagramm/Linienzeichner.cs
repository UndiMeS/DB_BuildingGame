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
        if(zeichnen &&( objekt1 == null || objekt2 == null))
        {
            Debug.Log("hier!");
            Destroy(gameObject);
            Destroy(gameObject.GetComponent<Linienzeichner>());
        }
        changeName();
        if (zeichnen && objekt1!=null&&objekt2!=null)
        {
            pos1 = objekt1.transform.position;
            pos2 = objekt2.transform.position;

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
        rect.sizeDelta = new Vector2((pos2 - pos1).magnitude, breite);
        gameObject.transform.position = pos1;

        double winkel = Vector3.Angle(pos2-pos1,Vector3.right);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, (float)winkel);
        if (pos2.y < pos1.y)
        {
            gameObject.transform.rotation = Quaternion.Euler(-180f, 0, (float) winkel);
        }


    }

    public void setzeGameObjekte(GameObject last, GameObject select)
    {
        objekt1 = last;
        objekt2 = select;
    }
}
