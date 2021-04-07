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
    public GameObject fenster;
    public GameObject checkButton;

    public void Start()
    {
        correct = new string[aufgabenListe.Length];
        correct[0] = "C";
        correct[1] = "D";
        correct[2] = "C";
        correct[3] = "A";
        correct[4] = "B";
        correct[5] = "A";
        correct[6] = "C";
        correct[7] = "D";
        correct[8] = "D";
        correct[9] = "C";
        correct[10] = "B";
        correct[11] = "D";
        correct[12] = "C";
        correct[13] = "D";
        correct[14] = "B";
        correct[15] = "C";
        correct[16] = "A";
        correct[17] = "B";
        correct[18] = "C";
        correct[19] = "B";
        correct[20] = "D";
        correct[21] = "A";
        correct[22] = "D";
        correct[23] = "C";
        correct[24] = "D";
        correct[25] = "D";
        
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
            checkButton.SetActive(false);
    
            //Invoke("closeFenster", 2);
        }
        else
        {
            string ausgabe = "Falsch! Richtig ist " + correct[welcheAufgabe];
            Utilitys.TextInTMP(RichitgFalschAnzeige, ausgabe);
            Invoke("clearAnzeige", 4);
            exitKnopf.SetActive(true);
            checkButton.SetActive(false);

            welcheAufgabe++;
            //Invoke("closeFenster", 8);
        }
    }

    public void clearAnzeige()
    {
        Utilitys.TextInTMP(RichitgFalschAnzeige, " ");
    }

    public void closeFenster()
    {
        fenster.SetActive(false);
    }


    public void openAufgabe()
    {
        toogle.init();
        toogle.toggleOff();
        gameObject.GetComponent<Image>().sprite = aufgabenListe[welcheAufgabe];
        exitKnopf.SetActive(false);
        clearAnzeige();
        checkButton.SetActive(true);
        
    }


    public void geldGeben(){
        
        Testing.geld += 100;
    }

}
