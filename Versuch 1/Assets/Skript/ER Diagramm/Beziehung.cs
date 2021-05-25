using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beziehung : MonoBehaviour
{
    public string beziehungsName;
    public int instanceID;

    public int objekt1ID;
    public int objekt2ID;

    public string kard1 = "1";
    public string kard2 = "1";

    public bool schwach = false;

    public float x;
    public float y;

    public GameObject objekt1 = null;
    public GameObject objekt2 = null;

    private GameObject kardText1;
    private GameObject kardText2;

    public GameObject linie1;
    public GameObject linie2;

    public GameObject linie;
    public GameObject linienOrdner;

    public Sprite schwachSelected;
    public Sprite schwachOriginal;
    public Sprite Selected;
    public Sprite Original;

    private bool firsttime = true;
    // Start is called before the first frame update
    void Start()
    {
        kardText1 = gameObject.transform.GetChild(2).gameObject;
        kardText2 = gameObject.transform.GetChild(3).gameObject;

        if (firsttime)
        {
            firsttime = false;
            kard1 = "1";
            kard2 = "1";
        }

        instanceID = gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        beziehungsName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        objekt1ID = objekt1.GetInstanceID();
        objekt2ID = objekt2.GetInstanceID();

        Utilitys.TextInTMP(kardText1, kard1);
        if (kard2.Equals("n"))
        {
            Utilitys.TextInTMP(kardText2, "m");
        }
        else
        {
            Utilitys.TextInTMP(kardText2, kard2);
        }

        if (objekt1 != null)
        {
            positionOfKardinalitaet(kardText1, objekt1, objekt1.Equals(objekt2));
            kardText1.SetActive(true);
        }
        else
        {
            kardText1.SetActive(false);
        }

        if (objekt2 != null)
        {
            positionOfKardinalitaet(kardText2, objekt2, objekt1.Equals(objekt2));
            kardText2.SetActive(true);
        }
        else
        {
            kardText2.SetActive(false);
        }

        if (objekt1.Equals(objekt2))
        {
            linie1.GetComponent<Linienzeichner>().setposition = 1;
            linie2.GetComponent<Linienzeichner>().setposition = 2;
        }
        else
        {
            linie1.GetComponent<Linienzeichner>().setposition = 0;
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

    internal void setWerte(LoadedBeziehung bez)
    {
        firsttime = false;
        beziehungsName = bez.beziehungsName;
        gameObject.name = bez.beziehungsName;
        instanceID = bez.instanceID;
        objekt1ID = bez.objekt1ID;
        objekt2ID = bez.objekt2ID;
        kard1 = bez.kard1;
        kard2 = bez.kard2;
        schwach = bez.schwach;
        x = bez.x;
        y = bez.y;
    }

    public void setLinienordner(GameObject lO)
    {
        linienOrdner = lO;

        if (objekt1 != null)
        {
            zeichneLinie(objekt1);
        }
        if (objekt2 != null)
        {
            zeichneLinie(objekt2);
        }
    }

    public void erstelleBeziehung()
    {
        welcheEntity(1, 0, false);
        welcheEntity(2, 0, false);
    }

    private void positionOfKardinalitaet(GameObject kardtext, GameObject objekt, bool offset)   //GRÖßE VON EROBJEKT /2
    {
        Vector3 pos2 = objekt.transform.position;
        Vector3 pos1 = gameObject.transform.position;

        double winkel = Vector3.Angle(pos2 - pos1, Vector3.right);

        kardtext.transform.position = pos1 + Vector3.Normalize(pos2 - pos1);

        if (45 < winkel && winkel < 135 || 225 < winkel && 305 > winkel)
        {
            kardtext.transform.localPosition += new Vector3(10, 0, 0);
            if (offset && kardtext.Equals(kardText1))
            {
                kardtext.transform.localPosition += new Vector3(50, 0, 0);
            }
        }
        else
        {
            kardtext.transform.localPosition += new Vector3(0, 10, 0);
            if (offset && kardtext.Equals(kardText1))
            {
                kardtext.transform.localPosition += new Vector3(0, 50, 0);
            }
        }


    }

    public void welcheEntity(int einsOderZwei, int option, bool schwachKommen)
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
                if (schwachKommen && obj.Equals(objekt1)) { }
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
            objekt2.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie2 = zeichneLinie(objekt2);
        }
    }



    private GameObject zeichneLinie(GameObject obj)
    {
        if (linienOrdner != null)
        {
            GameObject templinie = Instantiate(linie, transform);

            templinie.GetComponent<Linienzeichner>().setzeGameObjekte(obj, gameObject);
            templinie.GetComponent<Linienzeichner>().zeichnen = true;
            templinie.transform.SetParent(linienOrdner.transform);

            return templinie;
        }
        return null;
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
                kard2 = "n";
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
