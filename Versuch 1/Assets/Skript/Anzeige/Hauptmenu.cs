using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hauptmenu : MonoBehaviour
{
    public void StartSpiel()
    {
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SpielBeenden()
    {
        Debug.Log("Beendet!");
        Application.Quit();
    }

    

    public void SwitchToBaumenue()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.hintergrund = 0;
    }

    public void Laden()
    {
        Testing.laden = true;
        SwitchToBaumenue();
    }
}
