﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ERMenue : MonoBehaviour
{
    public GameObject aufgabe;

    public GameObject optionsmenue;

    public void aufgabeAnzeigen()
    {
        Debug.Log("?");
        if (aufgabe.activeSelf)
        {
            aufgabe.SetActive(false);
        }
        else
        {
            aufgabe.SetActive(true);
        }
    }
   public void LadeMenu()
    {
        ERErstellung.modellObjekte.RemoveRange(0, ERErstellung.modellObjekte.Count);
        SceneManager.LoadScene(0);
    }

}
