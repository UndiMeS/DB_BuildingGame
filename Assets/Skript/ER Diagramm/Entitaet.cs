using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entitaet : MonoBehaviour
{
    public string entitaetsName;
    public bool schwach;
    public int instanceID;

    public int vaterEntitaetID;
    public int schwacheBeziehungID;
    public List<int> attributeID;
    public List<int> primaerschluesselID;
    public List<int> beziehungenID;

    public float x;
    public float y;

    public GameObject vaterEntitaet;
    public GameObject schwacheBeziehung;
    public List<GameObject> attribute;
    public List<GameObject> primaerschluessel;
    public List<GameObject> beziehungen;

    public void Start()
    {
        instanceID = gameObject.GetInstanceID();
    }
    public void Update()
    {
        entitaetsName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        attributeID.Clear();
        foreach (GameObject attribut in attribute)
        {
            attributeID.Add(attribut.GetInstanceID());
        }
        primaerschluesselID.Clear();
        foreach (GameObject primaer in primaerschluessel)
        {
            primaerschluesselID.Add(primaer.GetInstanceID());
        }
        beziehungenID.Clear();
        foreach (GameObject bez in beziehungen)
        {
            beziehungenID.Add(bez.GetInstanceID());
        }if (vaterEntitaet != null)
        {
            vaterEntitaetID = vaterEntitaet.GetInstanceID();
            schwacheBeziehungID = schwacheBeziehung.GetInstanceID();
        }else if (schwach)
        {
            schwach = false;
        }
        
    }

    public void setWerte(LoadedEntity ent)
    {
        entitaetsName = ent.entitaetsName;
        gameObject.name = entitaetsName;
        schwach = ent.schwach;
        instanceID = ent.instanceID;
        vaterEntitaetID = ent.vaterEntitaetID;
        schwacheBeziehungID = ent.schwacheBeziehungID;
        attributeID = ent.attributeID;
        primaerschluesselID = ent.primaerschluesselID;
        beziehungenID = ent.beziehungenID;
        x = ent.x;
        y = ent.y;
    }

    public void attributloeschen(GameObject selectedGameObjekt)
    {
        attribute.Remove(selectedGameObjekt);
        primaerschluessel.Remove(selectedGameObjekt);
    }
}
