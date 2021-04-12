using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool SpielIstPausiert= false;
    public static bool ERon = false;

    public GameObject PauseMenuUI;
    public GameObject kameraKontroller;
    public GameObject canvas;
    public GameObject hilfeFenster;
    public GameObject hilfeZurückButton;
    public GameObject hilfeGebaeudeinfo;
    public GameObject hilfeButtondestroyer;
    public GameObject hilfeTexte;


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
        hilfeFenster.SetActive(false);
        hilfeZurückButton.SetActive(false);
        hilfeGebaeudeinfo.SetActive(false);
        hilfeButtondestroyer.SetActive(false);
        hilfeTexte.SetActive(false);
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
    public void Hilfe()
    {
        PauseMenuUI.SetActive(false);
        SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;
        hilfeFenster.SetActive(true);
        hilfeZurückButton.SetActive(true);
        hilfeGebaeudeinfo.SetActive(true);
        hilfeButtondestroyer.SetActive(true);
        hilfeTexte.SetActive(true);

    }

    public void ObjectAnzeigen (GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;
            
        }
        else
        {
            objekt.SetActive(true);
            SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
        }
    }

    public void SwitchToER()
    {
        ERon = true;
        //SpielIstPausiert = true;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(1);
    }

    public void SwitchToBaumenue()
    {
        ERon = false;
        //SpielIstPausiert = false;
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


