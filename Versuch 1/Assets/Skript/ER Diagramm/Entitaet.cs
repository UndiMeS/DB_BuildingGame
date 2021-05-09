using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entitaet : MonoBehaviour
{
    public string entitaetsName;
    public bool schwach;
    public string istanceID;
    
    public  GameObject vaterEntitaet;
    public GameObject schwacheBeziehung;
    public List<GameObject> attribute;
    public List<GameObject> primaerschluessel;
     public List<GameObject> beziehungen;
    public void Start()
    {
        istanceID = gameObject.GetInstanceID().ToString();
    }
    public void Update()
    {
        entitaetsName = gameObject.name;
    }
    public void attributloeschen(GameObject selectedGameObjekt)
    {
        attribute.Remove(selectedGameObjekt);
        primaerschluessel.Remove(selectedGameObjekt);
    }
}
