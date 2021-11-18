using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomLeisteHilfe : MonoBehaviour
{
    public GameObject Leiste;
    public GameObject HLeiste;
    public GameObject button;
    public GameObject zurueck;
    public GameObject texte;

    public GameObject optionsmenue;
    public GameObject tutorial;
    public GameObject zeitstopper;
    public GameObject hinweis;
    public GameObject infobox;

    public void Hilfe_anzeigen_ER()
    {
        if (!texte.activeSelf)
        {
            Einblenden();
        }
        else
        {
            Ausblenden();
        }
    }

    public void Einblenden()
    {
        Leiste.SetActive(false);
        HLeiste.SetActive(true);
        button.SetActive(true);
        zurueck.SetActive(true);
        texte.SetActive(true);
        optionsmenue.SetActive(false);
        optionsmenue.GetComponent<PauseMenu>().ObjectAnzeigenTimeStop(zeitstopper);
        hinweis.SetActive(true);
        infobox.SetActive(false);
        optionsmenue.GetComponent<PauseMenu>().WeiterspielenER();
        optionsmenue.GetComponent<PauseMenu>().HilfeER();
    }
    public void Ausblenden()
    {
        Leiste.SetActive(true);
        HLeiste.SetActive(false);
        button.SetActive(false);
        zurueck.SetActive(false);
        texte.SetActive(false);
        optionsmenue.GetComponent<PauseMenu>().ObjectAnzeigenTimeStop(zeitstopper);
        hinweis.SetActive(false);
        optionsmenue.GetComponent<PauseMenu>().ExitHilfeER();
        infobox.SetActive(true);
    }

    public void KonventionOnTop(ScrollRect konvention)
    {
        konvention.verticalNormalizedPosition = 1;
    }

    public void TurnOnOff(GameObject game)
    {
        game.SetActive(game.activeSelf);
    }
}
