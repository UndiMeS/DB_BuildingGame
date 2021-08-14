using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hilfe_forschungsstation : MonoBehaviour
{
    public GameObject texte;
    public GameObject TransapentFuerForschungsstation;

    //Hilfeanzeige bei der Geb�udeanzeige der Forschungsstation
    public void Show()
    {
        texte.SetActive(true);
        TransapentFuerForschungsstation.SetActive(true);
        Invoke("Close", 8);
    }
        

    private void Close()
    {
        texte.SetActive(false);
        TransapentFuerForschungsstation.SetActive(false);
    }
}
