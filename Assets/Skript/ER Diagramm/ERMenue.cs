using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ERMenue : MonoBehaviour
{
    public GameObject aufgabe;

    public GameObject optionsmenue;

    public void aufgabeAnzeigen()
    {
        if (aufgabe.activeSelf)
        {
            aufgabe.SetActive(false);
            aufgabe.transform.GetChild(0).gameObject.SetActive(false);
            aufgabe.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            aufgabe.SetActive(true);
            aufgabe.transform.GetChild(0).gameObject.SetActive(true);
            aufgabe.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
   public void LadeMenu()
    {
        ERErstellung.modellObjekte.RemoveRange(0, ERErstellung.modellObjekte.Count);
        SceneManager.LoadScene(0);
    }

}
