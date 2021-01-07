using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeldAnzeige : MonoBehaviour
{
   
    public GameObject geldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(geldText, "Geld: " + Testing.geld + "€");
    }
}
