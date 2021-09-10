using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pausemenü in der Landschaft und im EREditor
public class PauseMenu : MonoBehaviour
{

    public static bool SpielIstPausiert= false; //Spiel ist nicht pausiert im ER Editor, pausiert z.B.: im Pausemenü

    public static bool ERon = false; //gibt an ob in ER Editor, wichtig für die Zeit

    //Objekte die an oder ausgeschalten werden
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
    public GameObject leisteRechts;
    public GameObject infoBox;
    public GameObject leisteBottom;
    public GameObject tutorial;
    public GameObject leisteTop;
    public GameObject hilfeInGameER;

    //für Screenshot
    public KameraKontroller KameraScript;
    private GameObject selectedGameObjektZwischenspeicher;

    public GameObject RTS_Camera;
    public RTS_Cam.RTS_Camera RTS_CameraScript;

    public Vector3 ScreenShotPosition;
    public bool ScreenShot;
    //public RTS_Camera CameraScript;

    void Start()
    {
        RTS_CameraScript = RTS_Camera.GetComponent<RTS_Cam.RTS_Camera>();
    }

    //zurück-Knopf im Pausemenü/Optionsmenü der Landschaft
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
        RTS_CameraScript.enabled = true;
        GebaeudeAnzeige.allesAus = false;
        baumenuTransparent.SetActive(true);
    }

    //zurück-Knopf im Pausemenü/Optionsmenü des ER-Editors
    public void WeiterspielenER()
    {
        PauseMenuUI.SetActive(false);
        KameraKontroller.aktiviert = true;
        RTS_CameraScript.enabled = true;
        GebaeudeAnzeige.allesAus = false;
        SpielIstPausiert = false;
        Time.timeScale = 1;

    }

    // ruft Optionsmenü in Landschaft aus (rechts Knopf)
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        SpielIstPausiert = true;
        KameraKontroller.aktiviert = false;
        RTS_CameraScript.enabled = false;
        GebaeudeInfoBauen.wertFest = 0;
        GebaeudeAnzeige.allesAus = true;
        
    }

    //geht zurück ins Hauptmenü
    public void LadeMenu()
    {
        Testing.resetAll(); //alle Werte werden auf 0 gesetzt
        SceneManager.LoadScene(0);
    }
    
    //Hilfe Anzeigen in Optionsmenü des ER-Editors
    public void HilfeER()
    {
        hilfeFenster.SetActive(true);
        hilfeZurückButton.SetActive(true);        
        hilfeButtondestroyer.SetActive(true);
        hilfeTexte.SetActive(true);
        Aufgabenfenster.SetActive(false);
        Checkliste.SetActive(false);
        KameraKontroller.aktiviert = false;
        RTS_CameraScript.enabled = false;
    }

    //Schließen der Hilfe Anzeigen des ER-Editors
    public void ExitHilfeER()
    {
        hilfeFenster.SetActive(false);
        hilfeZurückButton.SetActive(false);        
        hilfeButtondestroyer.SetActive(false);
        hilfeTexte.SetActive(false);
        Aufgabenfenster.SetActive(true);
        Checkliste.SetActive(true);
        KameraKontroller.aktiviert = true;
        RTS_CameraScript.enabled = true;
    }

    // GameObject objekt wird angezeigt oder ausgeblendet
    // dabei wird die Zeit angehalten, keine Gebäudeanzeige (Landschaft unten links), keine Kamerabewegung
    public void ObjectAnzeigenTimeStop (GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            SpielIstPausiert = false;
            KameraKontroller.aktiviert = true;
            RTS_CameraScript.enabled = true;            
            GebaeudeAnzeige.allesAus = false;
            Time.timeScale = 1;
        }
        else
        {
            objekt.SetActive(true);
            SpielIstPausiert = true;
            KameraKontroller.aktiviert = false;
            RTS_CameraScript.enabled = false;
            GebaeudeInfoBauen.wertFest = 0;
            GebaeudeAnzeige.allesAus = true;
            Time.timeScale = 0;
        }

    }

    // GameObject objekt wird angezeigt oder ausgeblendet
    // ohne obigen Einschränkungen
    public void ObjectAnzeigenNotStop(GameObject objekt)
    {
        if (objekt.activeSelf)
        {
            objekt.SetActive(false);
            KameraKontroller.aktiviert = true;
            RTS_CameraScript.enabled = true;
            GebaeudeAnzeige.allesAus = false;
        }
        else
        {
            objekt.SetActive(true);
            KameraKontroller.aktiviert = false;
            RTS_CameraScript.enabled = false;
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
        RTS_Camera.transform.rotation = Quaternion.Euler(0,0,0);
        RTS_CameraScript.targetFollow = null;
    }

    public void SwitchToBaumenue()
    {
        ERon = false;
        SpielIstPausiert = false;
        kameraKontroller.GetComponent<KameraKontroller>().changeHintergrund(0);
        mission.transform.localPosition = new Vector3(16, 650, 0);
        RTS_Camera.transform.rotation = Quaternion.Euler(-45,0,0);
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

    public void screenshotMachen()
    {
        //KameraScript.ScreenshotZoom();
        //canvas.SetActive(false);

        
        RTS_CameraScript.useScrollwheelZooming = false;

        Invoke("screenshotErstellen", 0.7f);
        Invoke("allesAn", 0.1f);        
        
    }

    public void screenshotErstellen()
    {
        canvas.SetActive(false);

        
        
        

        //yield return new WaitForSeconds(0.2f);
        ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Zertifikatsbilder/Spiel.png",2); //Größe mit Faktor 2 multipliziert, damit wir es im Zertifikat verkleinern können

        
        Debug.Log("Screenshot gemacht");
        
        //Wichtiger Bool, damit letzte Mission erfüllt werden kann
        if(ScreenShot == false)
        {
            RTS_Camera.transform.position = ScreenShotPosition;
            Mission.screenshotSpiel = true;
            ScreenShot =true;
        }
        
        Invoke("allesAn", 0.1f);
        RTS_CameraScript.useScrollwheelZooming = true;
        
        
    }



    private void allesAn()
    {
        canvas.SetActive(true);
        FehlerAnzeige.fehlertext = "Screenshot erstellt!";
        ScreenShot = false;
        Weiterspielen();
    }
    public void screenshotMachenER()
    {

        WeiterspielenER();
        //KameraScript.ScreenshotZoom();
        RTS_CameraScript.useScrollwheelZooming = false;
        Invoke("ERscreenshotErstellen", 0.7f);
         
        Invoke("neuesAllesAn", 1.0f);
    }

    public void ERscreenshotErstellen()
    {
        
        infoBox.SetActive(false);
        leisteRechts.SetActive(false);
        Aufgabenfenster.SetActive(false);
        Checkliste.SetActive(false);
        tutorial.SetActive(false);
        leisteBottom.SetActive(false);
        leisteTop.SetActive(false);
        hilfeInGameER.SetActive(false);


        selectedGameObjektZwischenspeicher = ERErstellung.selectedGameObjekt;
        ERErstellung.selectedGameObjekt = null;

        if(ScreenShot == false)
        {
            RTS_Camera.transform.position = ScreenShotPosition;
            ScreenShot = true;
        }

        ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Zertifikatsbilder/ERD.png",2); //Größe mit Faktor 2 multipliziert, damit wir es im Zertifikat verkleinern können
        Debug.Log("Screenshot gemacht");
        //FehlerAnzeige.fehlertext = "Screenshot wurde gemacht. Er befindet sich in deinen Speicherdaten.";
        
        //Wichtiger Bool, damit letzte Mission erfüllt werden kann
        Mission.screenshotER = true;
        RTS_CameraScript.useScrollwheelZooming = true;
        
    }
    public void neuesAllesAn()
    { 
        //RTS_Camera.transform.position = ScreenShotPosition;
        FehlerAnzeige.fehlertext = "Screenshot erstellt!";
        leisteRechts.SetActive(true);
        infoBox.SetActive(true);
        leisteRechts.SetActive(true);
        Aufgabenfenster.SetActive(true);
        Checkliste.SetActive(true);
        tutorial.SetActive(true);
        leisteBottom.SetActive(true);
        leisteTop.SetActive(true);
        hilfeInGameER.SetActive(true);

        ScreenShot = false;

        ERErstellung.selectedGameObjekt = selectedGameObjektZwischenspeicher;
    }
}


