using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beziehung : MonoBehaviour
{
    public GameObject objekt1 = null;
    public GameObject objekt2 = null;

    public string kard1 = "1";
    private GameObject kardText1;
    public string kard2 = "1";
    private GameObject kardText2;

    private GameObject linie1;
    private GameObject linie2;

    public GameObject linie;
    public GameObject linienOrdner;

    public Sprite schwachSelected;
    public Sprite schwachOriginal;
    public Sprite Selected;
    public Sprite Original;

    public bool schwach = false;

    private bool firsttime = true;
    // Start is called before the first frame update
    void Start()
    {
        linienOrdner = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;
        kardText1 = gameObject.transform.GetChild(2).gameObject;
        kardText2 = gameObject.transform.GetChild(3).gameObject;

        if (firsttime)
        {
            firsttime = false;
            kard1 = "1";
            kard2 = "1";
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        Utilitys.TextInTMP(kardText1, kard1);
        Utilitys.TextInTMP(kardText2, kard2);
        if (objekt1 != null)
        {
            positionOfKardinalitaet(kardText1, objekt1);
            kardText1.SetActive(true);
        }
        else
        {
            kardText1.SetActive(false);
        }

        if (objekt2 != null)
        {
            positionOfKardinalitaet(kardText2, objekt2);
            kardText2.SetActive(true);
        }
        else
        {
            kardText2.SetActive(false);
        }



        if (schwach)
        {
            gameObject.GetComponent<ERObjekt>().selectedSprite = schwachSelected;
            gameObject.GetComponent<ERObjekt>().originalSprite = schwachOriginal;
        }
        else
        {
            gameObject.GetComponent<ERObjekt>().selectedSprite = Selected;
            gameObject.GetComponent<ERObjekt>().originalSprite = Original;
        }
    }

    public void erstelleBeziehung()
    {
        welcheEntity(1, 0);
        welcheEntity(2, 0);
    }

    private void positionOfKardinalitaet(GameObject kardtext, GameObject objekt)   //GRÖßE VON EROBJEKT /2
    {
        Vector3 pos2 = objekt.transform.position;
        Vector3 pos1 = gameObject.transform.position;

        double winkel = Vector3.Angle(pos2 - pos1, Vector3.right);

        kardtext.transform.position = pos1 + Vector3.Normalize(pos2 - pos1);

        if (45 < winkel && winkel < 135 || 225 < winkel && 305 > winkel)
        {
            kardtext.transform.localPosition += new Vector3(10, 0, 0);
        }
        else
        {
            kardtext.transform.localPosition += new Vector3(0, 10, 0);
        }
    }

    public void welcheEntity(int einsOderZwei, int option)
    {
        Start();
        if (option == -1)
        {
            return;
        }
        if (schwach && einsOderZwei == 1)
        {
            FehlerAnzeige.fehlertext = "Änderung der Entitäten nicht möglich!";
            return;
        }
        GameObject entity = null;
        int z = -1;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (schwach && obj.Equals(objekt1)) { }
                else
                {
                    z++;
                }
                if (z == option)
                {
                    entity = obj;
                    break;
                }
                
            }
        }
        if (schwach && einsOderZwei == 2)
        {
            if (objekt1.Equals(entity))
            {
                FehlerAnzeige.fehlertext = "Es kann keine schwache Entität zu sich selber erstellt werden";
                return;
            }
            else if (objekt2 != null)
            {
                Destroy(linie2.GetComponent<Linienzeichner>());
                Destroy(linie2);
                objekt1.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt2 = entity;
            objekt1.GetComponent<Entitaet>().vaterEntitaet = entity;
            objekt1.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie2 = zeichneLinie(objekt2);
        }
        else if (!entity.Equals(objekt1) && einsOderZwei == 1)
        {            
            if (objekt1 != null)
            {
                Destroy(linie1.GetComponent<Linienzeichner>());
                Destroy(linie1);
                objekt1.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt1 = entity;
            objekt1.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie1 = zeichneLinie(objekt1);
        }
        else if (!entity.Equals(objekt2) && einsOderZwei == 2)
        {
            if (objekt2 != null)
            {
                Destroy(linie2.GetComponent<Linienzeichner>());
                Destroy(linie2);
                objekt2.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt2 = entity;
            objekt2.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            linie2 = zeichneLinie(objekt2);
        }
    }



    private GameObject zeichneLinie(GameObject obj)
    {
        GameObject templinie = Instantiate(linie, transform);

        templinie.GetComponent<Linienzeichner>().setzeGameObjekte(obj, gameObject);
        templinie.GetComponent<Linienzeichner>().zeichnen = true;
        templinie.transform.SetParent(linienOrdner.transform);

        return templinie;
    }

    public void kardinalitaet(int einoderzwei, int option)
    {
        if (einoderzwei == 2)
        {
            if (objekt2 == null)
            {
                return;
            }
            if (option == 0)
            {
                kard2 = "1";
            }
            else
            {
                kard2 = "m";
            }
            kardText2.SetActive(true);

        }
        else
        {
            if (objekt1 == null)
            {
                FehlerAnzeige.fehlertext = "Lege zuerst die Entität fest!";
                return;
            }
            if (option == 0)
            {
                kard1 = "1";
            }
            else
            {
                kard1 = "n";
            }
            kardText1.SetActive(true);

        }
    }
}
