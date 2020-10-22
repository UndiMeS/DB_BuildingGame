using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeldAnzeige : MonoBehaviour
{
   
    public Text geldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        geldText.text = "Geld: " + Testing.geld+"€";
    }
}
