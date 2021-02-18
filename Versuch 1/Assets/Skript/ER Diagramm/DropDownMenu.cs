using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown menu;
    public int einsOderZwei;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menu.options.Clear();


        foreach(GameObject obj in ERErstellung.modellObjekte)
        {if (obj != null)
            {
                if (obj.CompareTag("Entitaet"))
                {
                    menu.options.Add(new TMPro.TMP_Dropdown.OptionData(obj.name));
                }
            }
            
        }
    }

    public void eingabeDropDown(int option)
    {
        ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().welcheEntity(einsOderZwei, option);
    }

    public void kardinalitaetSetzen(int option)
    {
        ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kardinalitaet(einsOderZwei, option);
    }
}
