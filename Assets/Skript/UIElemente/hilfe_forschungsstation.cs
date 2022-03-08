using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class hilfe_forschungsstation : MonoBehaviour
{
    public bool aktiv = false;
    private int timePro = 3;

    public GameObject texte;
    public GameObject TransapentFuerForschungsstation;
    public GameObject HilfeForschungssattionTransapentRundeEcke;

    public List<GameObject> beschreibungen;
    public GameObject MerkmalHighlight;
    public GameObject ProjekteHighlight;
    public TMPro.TMP_Dropdown Forschungsmerkmal;

    public GameObject mausDropdown;
    public GameObject mausProjekt;
    public GameObject mausVerbessern;

    //Hilfeanzeige bei der Gebäudeanzeige der Forschungsstation
    public void Show()
    {
        if (!aktiv)
        {
            aktiv = true;
            texte.SetActive(true);
            TransapentFuerForschungsstation.SetActive(true);
            HilfeForschungssattionTransapentRundeEcke.SetActive(true);
            Ablauf();
            Invoke("Close", timePro*5);
        }
    }
        

    private void Close()
    {
        aktiv = false;
        beschreibungen[4].SetActive(false);
        mausVerbessern.SetActive(false);
        Cursor.visible = true;


        texte.SetActive(false);
        TransapentFuerForschungsstation.SetActive(false); 
        HilfeForschungssattionTransapentRundeEcke.SetActive(false);
    }

    public void Ablauf()
    {
        ersterSchritt();
        Invoke("zweiterSchritt", timePro); 
        Invoke("dritterSchritt", timePro*2);
        Invoke("vierterSchritt", timePro*3);
        Invoke("fuenfterSchritt", timePro*4);
    }

    public void ersterSchritt()
    {
        beschreibungen[0].SetActive(true);
        ProjekteHighlight.GetComponent<HighlightButton>().highlinghtingOn = true;
    }

    public void zweiterSchritt()
    {
        beschreibungen[0].SetActive(false);
        ProjekteHighlight.GetComponent<HighlightButton>().highlinghtingOn = false;
        mausDropdown.SetActive(true);
        beschreibungen[1].SetActive(true);
        Forschungsmerkmal.Show();

        
        Cursor.visible = false;
    }

    public void dritterSchritt() {
        Cursor.visible = true;
        mausDropdown.SetActive(false);
        beschreibungen[1].SetActive(false);
        Forschungsmerkmal.Hide();

        beschreibungen[2].SetActive(true);
        
        MerkmalHighlight.GetComponent<HighlightButton>().highlinghtingOn = true;
    }

    public void vierterSchritt()
    {
        beschreibungen[2].SetActive(false);
        MerkmalHighlight.GetComponent<HighlightButton>().highlinghtingOn = false;

        beschreibungen[3].SetActive(true);
        mausProjekt.SetActive(true);
        Cursor.visible = false;
    }

    public void fuenfterSchritt()
    {
        beschreibungen[3].SetActive(false);
        mausProjekt.SetActive(false);


        beschreibungen[4].SetActive(true);
        mausVerbessern.SetActive(true);
    }
}
