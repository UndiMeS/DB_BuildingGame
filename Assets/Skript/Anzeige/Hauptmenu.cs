using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hauptmenu : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void StartSpiel()
    {
       SwitchToBaumenue();
    }

    public void SpielBeenden()
    {
        Debug.Log("Beendet!");
        Application.Quit();
    }

    

    public void SwitchToBaumenue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;
        GebaeudeAnzeige.allesAus = false;
    }

    public void Laden()
    {
        Testing.laden = true;
        SwitchToBaumenue();
    }
}
