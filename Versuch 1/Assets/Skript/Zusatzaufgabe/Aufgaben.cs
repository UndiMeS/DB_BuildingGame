using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aufgaben : MonoBehaviour
{
    public Sprite[] aufgabenListe = new Sprite[23];
    public string[] correct ;
    public int[] level ;

    private int welcheAufgabe = 0;

    public toogleEingabe toogle;
    public GameObject exitKnopf;
    public GameObject RichitgFalschAnzeige;

    public void Start()
    {
        correct = new string[aufgabenListe.Length];
        correct[0] = "B";
        //correct={"B",....}
        level = new int[aufgabenListe.Length]; //?
    }


    public void check(){
        if (toogle.currentSelection.name.Equals(correct[welcheAufgabe]))
        {
            Utilitys.TextInTMP(RichitgFalschAnzeige, "Richtig !");

            welcheAufgabe++;
            geldGeben();
            exitKnopf.SetActive(true);
        }
        else
        {
            Utilitys.TextInTMP(RichitgFalschAnzeige, "Falsch !");
            Invoke("clearAnzeige", 8);
        }
    }

    public void clearAnzeige()
    {
        Utilitys.TextInTMP(RichitgFalschAnzeige, " ");
    }

    public void openAufgabe()
    {
        toogle.init();
        toogle.toggleOff();
        gameObject.GetComponent<Image>().sprite = aufgabenListe[welcheAufgabe];
        exitKnopf.SetActive(false);
        clearAnzeige();
        
    }


    public void geldGeben(){
        
        Testing.geld += 100;
    }

}
