using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static Boolean SpielIstPausiert= false;

    public GameObject PauseMenuUI;
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
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        SpielIstPausiert = true;
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
}
