using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GebaeudeAnzeige : MonoBehaviour
{
    public GameObject ueberschrift;
    public GameObject mText;

    // Start is called before the first frame update
    void Start()
    {
        ueberschrift.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > 280 && Toolbar.objektGebaut==0)
            {
                Vector3 cursorPos = Utilitys.GetMouseWorldPosition();
                cursorPos.z = 2f;
                int wert = Testing.grid.GetWert(cursorPos);
                
                switch ((int)wert / 10)
                {
                    case 0:
                        Debug.Log("nichts!");
                        Nichts();
                        break;
                    case 1:
                        Haus(wert);
                        Debug.Log("Haus");
                        break;
                }
            }
        }
    }

    private void Haus(int wert)
    {
        if (wert == 11)
        {
            Utilitys.TextInTMP (ueberschrift, "kleines Haus");
        }
        else if (wert == 12)
        {
            Utilitys.TextInTMP(ueberschrift, "mittleres Haus");
        }
        else
        {
            Utilitys.TextInTMP(ueberschrift, "großes Haus");
        }
        
    }

    private void Nichts()
    {
        Utilitys.TextInTMP(ueberschrift, "");
    }

    
}
