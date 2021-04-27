using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropDownMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown menu;
    public int einsOderZwei;
    public TMPro.TMP_Dropdown kard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menu.options.Clear();
        if (kard != null)
        {
            kard.RefreshShownValue();
        }

        foreach(GameObject obj in ERErstellung.modellObjekte)
        {if (obj != null)
            {
                if (obj.CompareTag("Entitaet"))
                {
                    if (!(obj.GetComponent<Entitaet>().schwach&&obj.Equals(ERErstellung.selectedGameObjekt)))
                    {
                        menu.options.Add(new TMPro.TMP_Dropdown.OptionData(obj.name));
                    }
                }
            }
            
        }
        menu.RefreshShownValue();
    }

    public void eingabeDropDown(int option)
    {
        if (!ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().welcheEntity(einsOderZwei, option);
        }
        else
        {
            FehlerAnzeige.fehlertext = "Kann nicht mehr verändert werden.";
        }
    }

    public void kardinalitaetSetzen(int option)
    {
        if (!ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kardinalitaet(einsOderZwei, option);
        }
        else
        {
            FehlerAnzeige.fehlertext = "Kann nicht mehr verändert werden.";
        }
    }
}
