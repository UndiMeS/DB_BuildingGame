using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beziehung : MonoBehaviour
{
    public GameObject objekt1;
    public GameObject objekt2;
    private string kard1;
    private string kard2;

    private GameObject linie1;
    private GameObject linie2;

    public GameObject linie;
    private GameObject linienOrdner;
    
    // Start is called before the first frame update
    void Start()
    {
        linienOrdner = gameObject.transform.parent.gameObject.transform.GetChild(6).gameObject;
         objekt1=null;
         objekt2=null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void welcheEntity(int einsOderZwei, int option)
    {
        GameObject entity =null;
        int z=0;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (z == option)
                {
                    entity = obj;
                }
                z++;
            }            
        }
        Debug.Log(entity.name);
        if (einsOderZwei == 1)
        {
            erstellen(objekt1,entity);
        }
        else
        {
            erstellen(objekt2, entity);
        }
    }

    private void erstellen(GameObject obj, GameObject entity)
    {
        Debug.Log(obj != null);
        if (obj != null)
        {
            Destroy(linie1.GetComponent<Linienzeichner>());
            Destroy(linie1);
        }
        obj = entity;
        Debug.Log(obj.name);
        linie1 = zeichneLinie(obj);
    }

    private GameObject zeichneLinie(GameObject obj)
    {
        GameObject templinie = Instantiate(linie, transform);

        templinie.GetComponent<Linienzeichner>().setzeGameObjekte(obj, gameObject);
        templinie.GetComponent<Linienzeichner>().zeichnen = true;
        templinie.transform.SetParent(linienOrdner.transform);

        return templinie;
    }
}
