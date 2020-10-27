using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GebaeudeAnzeige : MonoBehaviour
{
    public GameObject ueberschrift;
   

    // Start is called before the first frame update
    void Start()
    {
        Utilitys.TextInTMP(ueberschrift, "");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Utilitys.ImBildschirm() && Toolbar.objektGebaut==0)
            {
                Vector3 cursorPos = Utilitys.GetMouseWorldPosition();
                cursorPos.z = 2f;
                int wert = Testing.grid.GetWert(cursorPos);
                
                switch (wert / 10)
                {
                    case 0:
                        Nichts();
                        break;
                    case 1:
                        Haus(wert);
                        break;
                    case 2:
                        Weide(wert);
                        break;
                    case 3:
                        Feld(wert);
                        break;
                }
            }
        }
    }

    private void Haus(int wert)
    {
        if (wert == 10)
        {
            Utilitys.TextInTMP (ueberschrift, "kleines Haus");
            Debug.Log("kleines Haus");
        }
        else if (wert == 11)
        {
            Utilitys.TextInTMP(ueberschrift, "mittleres Haus");
        }
        else
        {
            Utilitys.TextInTMP(ueberschrift, "großes Haus");
        }
        
    }
    private void Weide(int wert)
    {
        if (wert == 20)
        {
            Utilitys.TextInTMP(ueberschrift, "kleine Weide");
        }
        else if (wert == 21)
        {
            Utilitys.TextInTMP(ueberschrift, "mittlere Weide");
        }
        else
        {
            Utilitys.TextInTMP(ueberschrift, "große Weide");
        }

    }
    private void Feld(int wert)
    {
        if (wert == 30)
        {
            Utilitys.TextInTMP(ueberschrift, "kleines Feld");
        }
        else if (wert == 31)
        {
            Utilitys.TextInTMP(ueberschrift, "mittleres Feld");
        }
        else
        {
            Utilitys.TextInTMP(ueberschrift, "großes Feld");
        }

    }

    private void Nichts()
    {
        Utilitys.TextInTMP(ueberschrift, "");
    }

    
}
