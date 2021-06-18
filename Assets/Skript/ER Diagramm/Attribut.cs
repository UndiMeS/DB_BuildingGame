using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribut : MonoBehaviour
{
    public string attributName;
    public int instanceID;
    public bool primaerschluessel;
    public int vaterID;
    public float x;
    public float y;

    public GameObject vater;

    public void Start()
    {
        instanceID = gameObject.GetInstanceID();
    }

    private void Update()
    {
        attributName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        vaterID = vater.GetInstanceID();
    }

    internal void setWerte(LoadedAttribut attribut)
    {
        attributName = attribut.attributName;
        gameObject.name = attribut.attributName;
        instanceID = attribut.instanceID;
        primaerschluessel = attribut.primaerschluessel;
        vaterID = attribut.vaterID;
        x = attribut.x;
        y = attribut.y;
    }
}
