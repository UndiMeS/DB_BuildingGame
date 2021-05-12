using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribut : MonoBehaviour
{
    public string attributName;
    public string instanceID;
    public bool primaerschluessel;
    public GameObject vater;
    public float x;
    public float y;

    public void Start()
    {
        instanceID = gameObject.GetInstanceID().ToString();
    }

    private void Update()
    {
        attributName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }
}
