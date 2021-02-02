using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Anzeige der Informationen eines Gebauedes, noch nicht vollstaendig
public class GebaeudeAnzeige : MonoBehaviour
{
    public GameObject ueberschrift;
    public GameObject feld;
    public GameObject anAusKnoepfe;
    public GameObject panelHaus;
   

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
            if ( Testing.objektGebaut==0)
            {

                Vector3 cursorPos = Utilitys.GetMouseWorldPosition(Input.mousePosition);
                cursorPos.z = 2f;
                int wert = Testing.grid.GetWert(cursorPos);
                
                switch (wert)
                {
                    case 0:
                        Nichts();
                        break;
                    case 1:
                        Haus(wert);
                        break;
                    case 2:
                        Forschung(wert);
                        break;
                    case 3:
                        Feld(wert);
                        break;
                    case 4:
                        Weide(wert);
                        break;
                    case 5:
                        Stall(wert);
                        break;
                }
            }
        }
    }

    private void Stall(int wert)
    {
        throw new NotImplementedException();
    }

    private void Forschung(int wert)
    {
        throw new NotImplementedException();
    }

    private void Haus(int wert)
    {
        
        
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
