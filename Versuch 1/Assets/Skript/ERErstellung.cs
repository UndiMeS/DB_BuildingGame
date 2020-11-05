using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERErstellung : MonoBehaviour
{
    private new string name;
    private GameObject objekt;
    private bool erschaffen=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (erschaffen) { Utilitys.TextInTMP(objekt.transform.GetChild(0).gameObject, name); }
        
    }

    public void eingabeText(string eingabe)
    {
        name = eingabe;
        Debug.Log(name);
    }

    public void erstelleObjekt(GameObject prefab)
    {
        objekt=Instantiate(prefab, transform);
        objekt.transform.Translate(Screen.width / 2, Screen.height / 2, 0);
        erschaffen = true;
    }

}
