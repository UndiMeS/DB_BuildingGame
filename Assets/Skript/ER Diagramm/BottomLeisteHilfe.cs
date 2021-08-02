using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomLeisteHilfe : MonoBehaviour
{
    public GameObject Leiste;
    public GameObject HLeiste;
    public GameObject button;
    public GameObject zurueck;
    public GameObject texte;


    public void Einblenden()
    {
        Leiste.SetActive(false);
        HLeiste.SetActive(true);
        button.SetActive(true);
        zurueck.SetActive(true);
        texte.SetActive(true);
    }
    public void Ausblenden()
    {
        Leiste.SetActive(true);
        HLeiste.SetActive(false);
        button.SetActive(false);
        zurueck.SetActive(false);
        texte.SetActive(false);
    }

    public void KonventionOnTop(ScrollRect konvention)
    {
        konvention.verticalNormalizedPosition = 1;
    }
}
