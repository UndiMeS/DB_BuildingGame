using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedEntity
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
}
