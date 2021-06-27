﻿using System;
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
    public GameObject Aufgabenfenster;
    public GameObject Checkliste;
    public GameObject baumenuTransparent;

    public GameObject mission;


    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Spiel pausiert "+ SpielIstPausiert);
        
    }

    public void Weiterspielen()
    {
        PauseMenuUI.SetActive(false);
        hilfeFenster.SetActive(false);
        hilfeZurückButton.SetActive(false);
        if (hilfeGebaeudeinfo != null)
        {
            hilfeGebaeudeinfo.SetActive(false);
        }
        hilfeButtondestroyer.SetActive(false);
        hilfeTexte.SetActive(false);
        SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;
        GebaeudeAnzeige.allesAus = false;
        baumenuTransparent.SetActive(true);
    }

    public void WeiterspielenER()
    {
        PauseMenuUI.SetActive(false);
        KameraKontroller.aktiviert = true;
        GebaeudeAnzeige.allesAus = false;
        hilfeButtondestroyer.SetActive(false);
        hilfeTexte.SetActive(false);
        hilfeZurückButton.SetActive(false);
        hilfeFenster.SetActive(false);
        SpielIstPausiert = false;
        Time.timeScale = 1;

    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;
        GebaeudeInfoBauen.wertFest = 0;
        GebaeudeAnzeige.allesAus = true;
        
    }
    public void LadeMenu()
    {
        Testing.resetAll();
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
        baumenuTransparent.SetActive(false);

    }
    public void HilfeER()
    {
        PauseMenuUI.SetActive(false);
        

        hilfeFenster.SetActive(true);
        hilfeZurückButton.SetActive(true);        
        hilfeButtondestroyer.SetActive(true);
        ObjectAnzeigenTimeStop(hilfeTexte);
        Aufgabenfenster.SetActive(false);
        Checkliste.SetActive(false);
    }

    public void ObjectAnzeigenTimeStop (GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;            
            GebaeudeAnzeige.allesAus = false;
            Time.timeScale = 1;
        }
        else
        {
            objekt.SetActive(true);
            SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
            GebaeudeInfoBauen.wertFest = 0;
            GebaeudeAnzeige.allesAus = true;
            Time.timeScale = 0;
        }

    }

    public void ObjectAnzeigenNotStop(GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;
            GebaeudeAnzeige.allesAus = false;
        }
        else
        {
            objekt.SetActive(true);
            SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
            GebaeudeInfoBauen.wertFest = 0;
            GebaeudeAnzeige.allesAus = true;
        }

    }

    public void SwitchToER()
    {
        ERon = true;
        SpielIstPausiert = false;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(1);
        GebaeudeInfoBauen.wertFest = 0;
        
    }

    public void SwitchToBaumenue()
    {
        ERon = false;
        SpielIstPausiert = false;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(0);
        mission.transform.localPosition = new Vector3(16, 650, 0);
    }

    public void animationMission()
    {
        LeanTween.cancel(mission);
        if (mission.transform.localPosition.y < 400)
        {
            LeanTween.moveLocalY(mission, 650, 0.3f);
        }
        else{
            LeanTween.moveLocalY(mission, 380, 0.3f);
        }
        
    }
    public void animationMissionHalb()
    {
        LeanTween.cancel(mission);
        if (mission.transform.localPosition.y == 380)
        {
            LeanTween.moveLocalY(mission, 650, 0.3f);
        }
        else 
        {
            LeanTween.moveLocalY(mission, 380, 0.3f);
        }      
    }

    public void screenshotMachen(string wo)
    {
        canvas.SetActive(false);
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/SaveState/"+wo+"Screenshot.png");
        Debug.Log("Screenshot gemacht");
        Invoke("allesAn", 0.1f);
    }

    private void allesAn()
    {
        canvas.SetActive(true);
        FehlerAnzeige.fehlertext = "Screenshot wurde gemacht. Er befindet sich in deinen Speicherdaten.";
        Weiterspielen();
    }
    public void screenshotMachenER()
    {
        Weiterspielen();
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/SaveState/ERDScreenshot.png");
        Debug.Log("Screenshot gemacht");
        FehlerAnzeige.fehlertext = "Screenshot wurde gemacht. Er befindet sich in deinen Speicherdaten.";
    }

}


