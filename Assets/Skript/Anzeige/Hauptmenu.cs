using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
     * Hauptskript für das Startmenü
     */
public class Hauptmenu : MonoBehaviour
{
    //Legt die Auflösung des Spiels fest, wichtig für ER Oberfläche, da diese von Paramtertern aus 1920x1080 Bildschirm abhängig
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    //Startknopf nach Introvideo über neues Spiel
    public void StartSpiel()
    {
        SwitchToBaumenue();
    }

    //beenden Knopf unten links
    public void SpielBeenden()
    {
        Debug.Log("Beendet!");
        Application.Quit();
    }


    //lädt Spiel
    public void SwitchToBaumenue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;
        GebaeudeAnzeige.allesAus = false;
    }

    //Spiel laden - Knopf 
    public void Laden()
    {
        Testing.laden = true; //dort werden Werte gelöscht und laden-Funktionen aufgerufen
        SwitchToBaumenue();
    }
}
