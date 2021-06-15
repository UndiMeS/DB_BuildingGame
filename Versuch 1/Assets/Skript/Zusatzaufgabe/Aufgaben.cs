using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aufgaben : MonoBehaviour
{
    public Sprite[] aufgabenListe = new Sprite[25];
    public Sprite[] loesungsListe = new Sprite[25];
    public string[] correct ;
    public string[] secondchance;
    public int[] level ;

    public static int welcheAufgabe = 0;

    public toogleEingabe toogle;
    public GameObject exitKnopf;
    public GameObject RichitgFalschAnzeige;
    public GameObject RichitgFalschAnzeigeSecondChance;
    public GameObject fenster;
    public GameObject checkButton;

    public GameObject richtigHacken;
    //public GameObject falschKreuz;

    public GameObject zusatzButton;
    public GameObject zusatzButton_transparent;

    public GameObject hinweisFenster;
    public GameObject hinweisButton;
    public GameObject lösungsButton;
    public GameObject exitKnopfHinweis;
    public GameObject zweiteChance;
    public GameObject toggleKiller;
    public GameObject toggleKiller2;
    public GameObject secondChanceScreen;
    public GameObject exitKnopfSecondChance;
    public GameObject geldanzeige;

    public static int gewinn = 150;
    public static int gewinn2C = 40;

    private int temp = 0;
    private int cheat_temp = 0;

    public GameObject sound_true;
    public GameObject sound_false;

    public void Start()
    {
        //Richtige Antworten

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
        
  
        level = new int[aufgabenListe.Length]; //?

        //Hinweis Texte für die zweite Chance

        secondchance = new string[aufgabenListe.Length];
        secondchance[0] = "In wie viele Klassen gehst du persönlich an deiner Schule?";
        secondchance[1] = "Unterrichtet an deiner Schule nur eine Lehrkraft Informatik? Und hat diese auch andere Fächer, die sie unterrichtet?";
        secondchance[2] = "Kleine Kinos haben ggf. nur ein Saal, aber größere? Und kann denn derselbe (nicht der gleiche) Raum an verschiedenen Orten gleichzeitig exitieren?";
        secondchance[3] = "Wie viele Menschen in eurem Umfeld sind denn mit mehr als einer Person verheiratet?";
        secondchance[4] = "Schlüsselwörter wie „nur“ oder „genau eine“ geben den Hinweis auf die Kardinalität 1.";
        secondchance[5] = "Denke an den Hinweis der vorherigen Aufgabe!";
        secondchance[6] = "Nehmen wir an man darf in einer Straße parken. Frage dich, wie viele Autos könnten in einer Straße Parken? Und in wie vielen Straßen kann dasselbe Auto gleichzeitig parken?";
        secondchance[7] = "Zeigt ein Kino mit mehreren Sälen nur einen Film?";
        secondchance[8] = "Hast du Freundinnen und Freunde, die das gleiche Hobby ausüben wie du?";
        secondchance[9] = "Maxime hat bspw. in seiner Garage einen Caprio und einen Kleinbus. Am Wochenende verleiht er diese häufig an seine Freunde.";
        secondchance[10] = "Eine vierköpfige Familie hat eine Adresse. Gibt es eigentlich auch Menschen ohne Handy?";
        secondchance[11] = "Es gibt Filme, die haben den gleichen Namen. Es gibt Hauptdarsteller, die drehen an zwei Filmen gleichzeitig mit.";
        secondchance[12] = "Es ist zwar selten, jedoch kommt es vor, dass zwei Bücher mit gleichen Namen zu selben zeit veröffentlicht werden. ";
        secondchance[13] = "Laut Wikipedia ist die die Internationale Standartbuchnummer (ISBN) “eine Nummer zur eindeutigen Kennzeichnung von Büchern [...]“.";
        secondchance[14] = "Hast du schon einmal davon gehört, dass in einer Klasse zwei Schüler oder Schülerinnen den gleichen Namen haben?";
        secondchance[15] = "Achte auf die Primärschlüssel der Entitymenge und die Kardinalität.";
        secondchance[16] = "Teilen zwei Patienten sich dieselben Zähne? Und können Zähne überhaupt ohne Menschen/Patienten „existieren“?";
        secondchance[17] = "Was geschieht mit dem Klassenzimmer, wenn das Schulgebäude abgerissen wird?";
        secondchance[18] = "Was geschieht, wenn du die Zeitschrift in den Müll wirfst?";
        secondchance[19] = "Was geschieht mit dem Monitor, wenn du den Computer herunterfährst oder dir einen neuen zulegst?";
        secondchance[20] = "Welcher Bereich auf der Rechnung beschreibt die gekauften Artikel? Dort stehen die Attribute!";
        secondchance[21] = "Es gibt auch eine Entitymenge „Rechnung“. Achte auf ALLE Attribute der Entitymenge „Kunde“.";
        secondchance[22] = "Hast du schon einmal Artikel in einem Sportgeschäft gekauft und eine Rechnung/Quittung erhalten? Wie viele waren das? Waren die Artikel auch nach deinem Kauf noch im Laden auf Lager?";
        secondchance[23] = "Tipp: Ein Kunde kauft an einem gewissen Tag in dem Geschäft ein und bezahlt einen bestimmten Preis. Und wir benötigen noch einen Primärschlüssel!";
        secondchance[24] = "An einem Tag werden in dem Sporthaus 300 Rechnungen ausgestellt. Welche Attributwerte könnten doppelt vorkommen?";
        secondchance[25] = "Das ist die letzte Aufgabe! Alle Antwortmöglichkeiten wurden in vorherigen Aufgaben thematisiert! Versuche es nochmal!";
    
    
        
    
    }
    /*
    *Prüfen der Eingabe und drücken auf Button
    */
    public void check(){
        AudioSource soundTrue = sound_true.GetComponent<AudioSource>();
        AudioSource soundFalse = sound_false.GetComponent<AudioSource>();


        //keine Eingabe
        if(toogle.toggleGroupInstance.AnyTogglesOn() == false)
        {
           toogle.toggleRed();
           Invoke("toggleFarbe",1);
        }else{
            //Richtige Eingabe
            if (toogle.currentSelection.name.Equals(correct[welcheAufgabe]))
            {
                soundTrue.Play();
                toogle.toggleColor(Color.green, toogle.currentSelection);
                Invoke("toggleFarbe",3);
                toggleKiller2.SetActive(true);
                //falschKreuz.SetActive(false);
                hinweisButton.SetActive(false);
                temp++;
                cheat_temp = 0; //cheat_temp verhindet, dass man das Zusatzmenü komplett verlässt und dann wieder bei 1. Chance startet
                geldGeben(temp);
                welcheAufgabe++;
                richtigHacken.SetActive(true);
                exitKnopfHinweis.SetActive(false);
                checkButton.SetActive(false);

                zusatzButton.SetActive(false);
                zusatzButton_transparent.SetActive(true);
            }
            //falsche Eingabe
            else
            {   
                soundFalse.Play();
                temp++;//temp zählt die Chancen (temp == 2 dann keine Chance mehr!)
               //falschKreuz.SetActive(true);
                toogle.toggleColor(Color.red, toogle.currentSelection);
                Invoke("toggleFarbe",2);
                //zweite chance bereits gehabt
                if(temp == 2){
                    cheat_temp = 0;
                    checkButton.SetActive(false);
                    toggleKiller.SetActive(true);
                    hinweisButton.SetActive(false);
                    lösungsButton.SetActive(true);
                    checkButton.SetActive(false);
                    zusatzButton.SetActive(false);
                    zusatzButton_transparent.SetActive(true);
                    welcheAufgabe++;

                //zweite Chance noch möglich
                }else{
                    cheat_temp = 1;
                    checkButton.SetActive(true);
                    zweiteChance.SetActive(true);
                    toggleKiller.SetActive(true);
                    hinweisButton.SetActive(true);
                    Invoke("SecondChanceAnzeigen", 2);
                }
            }
        }
    }

    /*
    *Ausgabe des Hinweises und der Lösung
    */
    public void hinweis()
    {
        string ausgabe;
        //Ausgabe der Lösung
        if (temp == 2){
            hinweisFenster.GetComponent<Image>().sprite = loesungsListe[welcheAufgabe-1];
            hinweisFenster.SetActive(true);
            fenster.SetActive(false);
            lösungsButton.SetActive(false);
            exitKnopfHinweis.SetActive(true);

        //Ausgabe des Hinweises
        }else{
            secondChanceScreen.SetActive(true);
            ausgabe = secondchance[welcheAufgabe];
            Utilitys.TextInTMP(RichitgFalschAnzeigeSecondChance, ausgabe);
            exitKnopfSecondChance.SetActive(true);
            exitKnopf.SetActive(false);
            toggleKiller.SetActive(true);
        }
    }
    /*
    *Exit Button des Lösungsfensters
    */
    public void exitHinweis()
    {
        hinweisFenster.SetActive(false);
        lösungsButton.SetActive(true);
        fenster.SetActive(true);
        exitKnopfHinweis.SetActive(false);
        if(temp == 2){
            checkButton.SetActive(false);
        }else{
            checkButton.SetActive(true);
        }
        clearAnzeige();
    }
   /*
    *Exit Button des Hinweisfensters
    */
    public void exitsecondChanceScreen()
    {
        secondChanceScreen.SetActive(false);
        exitKnopfSecondChance.SetActive(false);
        clearAnzeige();
        exitKnopf.SetActive(true);
        toggleKiller.SetActive(false);

    }
    /*
    *Textausgabe zurücksetzten
    */
    public void clearAnzeige()
    {
        Utilitys.TextInTMP(RichitgFalschAnzeige, " ");
    }
    /*
    *Bei Klick auf Zusatzaufgabenbutton rechts neue Aufgabe laden
    */
    public void openAufgabe()
    {
        
        //Prüfen, ob noch eine zweite Chance aus vorheriger Aufgabe da ist
        if(cheat_temp == 1){
            temp = 1;
            hinweisButton.SetActive(true);
            //falschKreuz.SetActive(true);
        }else{
            temp = 0;
            hinweisButton.SetActive(false);
            //falschKreuz.SetActive(false);
        }
        //Laden aller nötigen Komponenten
        
        zweiteChance.SetActive(false);
        geldanzeige.SetActive(false);
        toggleKiller.SetActive(false);
        toggleKiller2.SetActive(false);
        toogle.init();
        toogle.toggleOff();
        gameObject.GetComponent<Image>().sprite = aufgabenListe[welcheAufgabe];
        exitKnopfHinweis.SetActive(false);
        clearAnzeige();
        checkButton.SetActive(true);
        richtigHacken.SetActive(false);
        secondChanceScreen.SetActive(false);
        exitKnopfSecondChance.SetActive(false);
        toogle.toggleWhite();
        
        
    }

   /*
    *Betrag auszahlen
    */
    public void geldGeben(int versuch){
        string ausgabe;
        geldanzeige.SetActive(true);
        if(versuch == 1){
            //1. Versuch richtig
            Testing.geld += gewinn;
            ausgabe = "+ " + gewinn.ToString();
        }else{
            //2. Versuch richtig
            Testing.geld += gewinn2C;
            ausgabe = "+ " + gewinn2C.ToString();
        }
        Utilitys.TextInTMP(geldanzeige, ausgabe);
    }
    /*
    *Hinweisfenster anzeigen
    */
    public void SecondChanceAnzeigen()
    {
        zweiteChance.SetActive(false);
        toggleKiller.SetActive(false);
    }
    /*
    *Methode, um den Lösungsbutton anzuzeigen
    */
    public void LösungsButton()
    {
        lösungsButton.SetActive(false);
    }
    /*
    *Methode für Invoke Farbwechsel
    */
    public void toggleFarbe()
    {
        toogle.toggleWhite();
    }
}
