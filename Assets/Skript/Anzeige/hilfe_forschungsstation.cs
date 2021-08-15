using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hilfe_forschungsstation : MonoBehaviour
{
    public GameObject texte;
    public GameObject TransapentFuerForschungsstation;
    public GameObject HilfeForschungssattionTransapentRundeEcke;

    //Hilfeanzeige bei der Gebäudeanzeige der Forschungsstation
    public void Show()
    {
        texte.SetActive(true);
        TransapentFuerForschungsstation.SetActive(true);
        HilfeForschungssattionTransapentRundeEcke.SetActive(true);
        Invoke("Close", 8);
    }
        

    private void Close()
    {
        texte.SetActive(false);
        TransapentFuerForschungsstation.SetActive(false); 
        HilfeForschungssattionTransapentRundeEcke.SetActive(false);
    }
}
