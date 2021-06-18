using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hilfe_forschungsstation : MonoBehaviour
{
    public GameObject texte;

    public void Show()
    {
        texte.SetActive(true);
        Invoke("Close", 5);
    }
        

    private void Close()
    {
        texte.SetActive(false);
    }
}
