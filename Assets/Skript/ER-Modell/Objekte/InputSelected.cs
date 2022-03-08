using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSelected : MonoBehaviour
{
    public bool selected;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete) && selected == false)
        {
            FehlerAnzeige.fehlertext = "Zum Löschen einzelner Komponenten, klicke links unten auf den Mülleimer!";
        }
    }

    public void SetTrue()
    {
        selected = true;
    }
    public void SetFalse()
    {
        selected = false;
    }
}
