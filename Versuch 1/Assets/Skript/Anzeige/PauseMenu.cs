﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool SpielIstPausiert= false;

    public GameObject PauseMenuUI;
    public GameObject kameraKontroller;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SpielIstPausiert)
            {
                Weiterspielen();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Weiterspielen()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;
    }

    public void WeiterspielenER()
    {
        PauseMenuUI.SetActive(false);
        KameraKontroller.aktiviert = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;
    }
    public void LadeMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void BeendeSpiel()
    {
        Debug.Log("Beendet!");
        Application.Quit();
    }

    public void ObjectAnzeigen (GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            Time.timeScale = 1;
            SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;
            
        }
        else
        {
            objekt.SetActive(true);
            Time.timeScale = 0;
            SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
        }
    }

    public void SwitchToER()
    {
 
        Time.timeScale = 0;
        SpielIstPausiert = true;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(1);
    }

    public void SwitchToBaumenue()
    {
        Time.timeScale = 1;
        SpielIstPausiert = false;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(0);
    }

    public void AllesAusblenden()
    {
        PauseMenuUI.SetActive(false);
        FehlerAnzeige.fehlertext = "Du hast kurz Zeit einen Screenshot zu machen";
        Invoke("Info", 5);
        
    }

    private void Info()
    {
        canvas.SetActive(false);
        Invoke("AllesAn", 5);
    }

    private void AllesAn()
    {
        canvas.SetActive(true);
    }
}


