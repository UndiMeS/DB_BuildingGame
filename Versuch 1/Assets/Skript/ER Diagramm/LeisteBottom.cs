using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeisteBottom : MonoBehaviour
{
    public Sprite schwacheEntitaet;
    public Sprite selecSchwacheEntitaet;
    public Sprite entitaet;
    public Sprite selecEntitaet;
    public Toggle schwEntKnopf;
    public GameObject dropdownSE;

    public void Update()
    {
        if (ERErstellung.selectedGameObjekt!=null&&ERErstellung.selectedGameObjekt.CompareTag("Entitaet"))
        {
            if (ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach)
            {
                schwEntKnopf.isOn=true;
                dropdownSE.SetActive(true);
            }
            else
            {                
                schwEntKnopf.isOn = false;
                dropdownSE.SetActive(false);
            }
        }
    }

    public void SchwacheEntitaet(bool state)
    {
        if (ERErstellung.selectedGameObjekt == null)
        {
            return;
        }
        if (state)
        {
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().originalSprite = schwacheEntitaet;
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().selectedSprite = selecSchwacheEntitaet;
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = true;
        }
        else
        {
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().originalSprite = entitaet;
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().selectedSprite = selecEntitaet;
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = false;
        }
    }

    public void SchwacheEntitaetAuswahl(int option)
    {
        GameObject entity = null;
        int z = 0;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (z == option)
                {
                   Debug.Log(obj.name);
                    entity = obj;
                }
                z++;
            }
        }
    }
}
