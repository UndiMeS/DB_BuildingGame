﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entitaet : MonoBehaviour
{
    public string entitaetsName;
    public bool schwach;
    public string instanceID;
    
    public  GameObject vaterEntitaet;
    public GameObject schwacheBeziehung;
    public List<GameObject> attribute;
    public List<GameObject> primaerschluessel;
    public List<GameObject> beziehungen;
    
    public float x;
    public float y;

    public void Start()
    {
        instanceID = gameObject.GetInstanceID().ToString();
    }
    public void Update()
    {
        entitaetsName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }
    public void attributloeschen(GameObject selectedGameObjekt)
    {
        attribute.Remove(selectedGameObjekt);
        primaerschluessel.Remove(selectedGameObjekt);
    }
}
