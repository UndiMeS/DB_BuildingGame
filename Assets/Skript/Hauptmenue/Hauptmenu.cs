using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
/*
     * Hauptskript für das Startmenü
     */
public class Hauptmenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider lautstaerke;
    public Toggle fensterModus;
    public Slider spracheSlider;
    public Toggle schwacheEntity;


    //Legt die Auflösung des Spiels fest, wichtig für ER Oberfläche, da diese von Paramtertern aus 1920x1080 Bildschirm abhängig
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        SetFullscreen(PlayerPrefs.GetInt("Vollbild"));
        lautstaerke.value = PlayerPrefs.GetFloat("Volume");
        SetVolume(PlayerPrefs.GetFloat("Volume"));
        SetSprache(PlayerPrefs.GetString("Sprache"));
        SetSchwach(PlayerPrefs.GetInt("Schwach"));
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetSprache(float sprache)
    {
        if (sprache == 0)
        {
            Sprache.sprache = "ge";
            PlayerPrefs.SetString("Sprache", "ge");
        }else if (sprache == 1)
        {
            Sprache.sprache = "en";
            PlayerPrefs.SetString("Sprache", "en");
        }
    }
    public void SetSprache(string sprache)
    {
        if (sprache == "ge")
        {
            Sprache.sprache = "ge";
            PlayerPrefs.SetString("Sprache", "ge");
            spracheSlider.value = 0;
        }
        else if (sprache == "en")
        {
            Sprache.sprache = "en";
            spracheSlider.value = 1;
            PlayerPrefs.SetString("Sprache", "en");
        }
    }

    public void SetFullscreen(bool vollbild)
    {
        Screen.fullScreen = !vollbild;
        if (vollbild)
        {
            PlayerPrefs.SetInt("Vollbild", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Vollbild", 0);
        }
        
    }
    public void SetFullscreen(int vollbild)
    {
        if (vollbild==1)
        {
            fensterModus.isOn = true;
            SetFullscreen(true);
        }
        else
        {
            fensterModus.isOn = false;
            SetFullscreen(false);
        }

    }

    public void SetSchwach(bool schwach)
    {
        OhneSchwacheEntity.schwachAus = !schwach;
        if (schwach)
        {
            PlayerPrefs.SetInt("Schwach", 1);
        }
        else
        {            
            PlayerPrefs.SetInt("Schwach", 0);
        }
    }
    public void SetSchwach(int schwach)
    {
        if (schwach==0)
        {
            OhneSchwacheEntity.schwachAus = false;
            schwacheEntity.isOn = false;
        }
        else
        {
            OhneSchwacheEntity.schwachAus = true;
            schwacheEntity.isOn = true;
        }
    }
}
