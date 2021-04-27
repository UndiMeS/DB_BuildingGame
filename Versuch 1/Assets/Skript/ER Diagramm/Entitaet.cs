using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entitaet : MonoBehaviour
{
    public bool schwach;
    public GameObject vaterEntitaet;
    public GameObject schwacheBeziehung;

    public List<GameObject> attribute;
    public List<GameObject> primaerschluessel;

    public List<GameObject> beziehungen;

    public void attributloeschen(GameObject selectedGameObjekt)
    {
        attribute.Remove(selectedGameObjekt);
        primaerschluessel.Remove(selectedGameObjekt);
    }
}
