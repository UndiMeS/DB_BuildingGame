using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Aufgaben : MonoBehaviour
{
    public List<Sprite> aufgabenListe = new List<Sprite>();
    public List<Sprite> loesungsListe = new List<Sprite>();
    public List<Sprite> SchwachaufgabenListe = new List<Sprite>();
    public List<Sprite> SchwachloesungsListe = new List<Sprite>();
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
    //public GameObject zusatzButton_transparent;

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

    public GameObject aufgabenstellung;
    private List<string> inhalt_aufgabenstellung = new List<string> {
        "Benenne die Kardinalität der Beziehung “gehtIn”!",
        "Benenne die Kardinalität der Beziehung “unterrichtetVon”!",
        "Benenne die Kardinalität der Beziehung “istIn”!",
        "Benenne die Kardinalität der Beziehung “verheiratetMit”!",
        "Welche Kardinalität steht für folgende Beschreibung?",
        "Welche Kardinalität steht für folgende Beschreibung?",
        "Benenne die Kardinalität der Beziehung “parktIn”!",
        "Benenne die Kardinalität der Beziehung “gezeigtIn”!",
        "Benenne die Kardinalität der Beziehung “ausüben”!",
        "Gegeben ist folgendes ER-Diagramm. Benenne das passende Paar an Kardinalitäten für die Relationen “besitzt” und “nutzt” (in dieser Reihenfolge)!",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Mensch.",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Film.",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Buch.",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Buch.",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Schüler.",
        "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Artikel“?",
        "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Kunde“?",
        "Gegeben ist folgende Rechnung eines Sporthandels. In einem ER-Diagramm zu diesem Sporthandel existiert eine Relation “enthält” zwischen Rechnung und Artikel.\nBenenne die Kardinalität dieser Relationship!",
        "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Rechnung“?",
        "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute lassen die <b>Rechnung</b> eindeutig ermitteln?",
        "Gegeben ist folgende Rechnung eines Sporthandels. Welche Aussage ist falsch?",
        //Artikel Kunde
        "Wie viele Entitätsmengen enthält das ER-Model mindestens?",
        "Benenne die  Attribute besitzt die Entitätsmenge „Kunde“?",
        "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Artikel.",
        "Benenne die Kardinalität der Beziehung zwischen „Kunde“ und „Artikel“!",
        //schwache
        "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?",
        "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?",
        "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?",
        "Bestimme die Vaterentitätsmenge und die schwache Entitätsmenge (in dieser Reihenfolge) aus diesem Text."
    };
    public GameObject image;
    public List<Sprite> inhalt_image;
    public TMPro.TextMeshProUGUI text;
    private List<string> inhalt_text = new List<string> {
        "","","","",
        "Jeder Entität der Entitätsmenge A können mehrere Objekte der Entitätsmenge B zugeordnet werden. Umgekehrt kann jedoch jeder Entität aus B nur eine Entität aus A zugeordnet werden.",
        "Jeder Entität der Entitätsmenge A wird genau eine Entität der Entitätsmenge B zugeordnet. Gleiches gilt für die Zuordnung der Entitäten von B  auf A.",
        "","","","","","",
        "",
        "","","","","","","",
        //Artikel Kunde
        "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.",
        "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.",
        "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.",
        "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.",
        //schwach
        "","","","","Für eine Zahnarztpraxis soll ein ER-Diagramm erstellt werden. Ein Patient der Praxis hat einen Namen und eine eindeutige Patientennummer. Ein Patient besitzt Zähne. Ohne Patient würden diese nicht existieren. Jeder Zahn wird einem Quadranten zugeordnet und hat eine eindeutige Nummer. Auch hat jeder Zahn einen Zustand. Jeder Zahnarzt hat einen Namen und eine eindeutige Zulassungsnummer. Ein Zahnarzt behandelt Zähne. Manchmal müssen jedoch auch mehrere Zahnärzte einen Zahn behandeln."

    };
    public TMPro.TextMeshProUGUI anwortA;
    private List<string> inhalt_anwortA = new List<string> {
        "1 : 1","1 : 1","1 : 1","1 : 1","1 : 1","1 : 1","1 : 1","1 : 1","1 : 1",
        "n : 1 und n : 1",
        "Handynummer","Hauptperson und Name","Name und Erscheinungsdatum","Name und Erscheinungsdatum","Geschlecht und E-Mail",
        "Artikelnummer, Preis","Adresse, Name, Kundennummer","1 : 1","Rechnungsbetrag, Rechnungsdatum",
        "Rechnungsbetrag, Rechnungsdatum","Rechnungsnummer ist Primärschlüssel	der Entitymenge Rechnung.",
        //Artikel Kunde
        "keine","Name und Kundenummer","Name", "1 : 1",
        //schwach
        "Schulgebäude","keine","Computer","keine"
    };
    public TMPro.TextMeshProUGUI anwortB;
    private List<string> inhalt_anwortB = new List<string> {
        "1 : n","1 : n","1 : n","1 : n","1 : n","1 : n","1 : n","1 : n","1 : n",
        "n : m und n : m",
        "Personalausweisnummer","Name","Erscheinungsdatum und Autor","Name und ISBN","E-Mail",
        "Beschreibung, Farbe, Größe","Name, Adresse","1 : n", "Kundennummer, Artikelnummer, Rechnungsnummer",
        "Kundennummer, Artikelnummer, Rechnungsdatum","Ein Kunde kann zwei Rechnungen mit gleichen Rechnungsbetrag erhalten.",
        //Artikel Kunde
        "eine","Kundennummer","ID", "1 ; n",
        //schwach
        "Klassenzimmer","Zeitschrift","Monitor","Patient und Zahn"
    };
    public TMPro.TextMeshProUGUI anwortC;
    private List<string> inhalt_anwortC = new List<string> {
        "n : 1","n : 1","n : 1","n : 1","n : 1","n : 1","n : 1","n : 1","n : 1",
        "1 : n und n : m",
        "Adresse", "Erscheinungsdatum und Hauptperson", "Autor und Name und Erscheinungsdatum", "Autor und Name und Erscheinungsdatum","Name und Klasse",
        "Artikelnummer, Rechnungsnummer","Rechnungsdatum, Kundennummer", "n : 1", "Kundennummer, Rechnungsnummer, Rechnungsbetrag, Rechnungsdatum",
        "Kundennummer, Rechnungsbetrag, Rechnungsdatum","Jede Rechnung wird genau einem Kunden zugeordnet.",
        //Artikel Kunde
        "zwei","Kundenummer, Name, Adresse","Name und Preis","n : 1",
        //schwach
        "keine","Artikel","Computer und Monitor","Zahn und Patient"
            };
    public TMPro.TextMeshProUGUI anwortD;
    private List<string> inhalt_anwortD = new List<string> {
        "n : m","n : m","n : m","n : m","n : m","n : m","n : m","n : m","n : m",
        "1 : 1 und 1 : n",
        "Name und Geburtstag", "Name und Erscheinungsdatum","Name","ISBN","Name und E-Mail" ,
        "Artikelnummer, Beschreibung, Farbe, Größe, Preis","Adresse, Kundennummer", "n : m","Rechnungsnummer, Name, Adresse, Rechnungsbetrag, Rechnungsdatum",
        "Rechnungsnummer", "Beschreibung und Größe sind Schlüsselattribute der Entitätsmenge Artikel.",
        //Artikel Kunde
        "drei","keine","ID, Name, Preis","n : m",
        //schwach
        "Schulgebäude und Klassenzimmer","Zeitschrift und Artikel","keine","Zahnarzt und Zahn"
    };


    public void Start()
    {
        if (OhneSchwacheEntity.schwachAus)
        {
            int anzahlSchwach = 4;
            inhalt_anwortA = inhalt_anwortA.GetRange(0, inhalt_anwortA.Count - anzahlSchwach);
            inhalt_anwortB = inhalt_anwortB.GetRange(0, inhalt_anwortB.Count - anzahlSchwach);
            inhalt_anwortD = inhalt_anwortD.GetRange(0, inhalt_anwortD.Count - anzahlSchwach);
            inhalt_anwortC = inhalt_anwortC.GetRange(0, inhalt_anwortC.Count - anzahlSchwach);
            inhalt_aufgabenstellung = inhalt_aufgabenstellung.GetRange(0, inhalt_aufgabenstellung.Count - anzahlSchwach);
            inhalt_image = inhalt_image.GetRange(0, inhalt_image.Count - anzahlSchwach);
            inhalt_text = inhalt_text.GetRange(0, inhalt_text.Count - anzahlSchwach);
        }

        //Richtige Antworten
        correct = new string[aufgabenListe.Count];
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
        correct[15] = "D";
        correct[16] = "A";
        correct[17] = "D";
        correct[18] = "C";
        correct[19] = "D";
        correct[20] = "D";
        correct[21] = "C";
        correct[22] = "A";
        correct[23] = "B";
        correct[24] = "D";


        level = new int[aufgabenListe.Count]; //?

        //Hinweis Texte für die zweite Chance

        secondchance = new string[aufgabenListe.Count];
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
        secondchance[15] = "Welcher Bereich auf der Rechnung beschreibt die gekauften Artikel? Dort stehen die Attribute!";
        secondchance[16] = "Es gibt auch eine Entitätsmenge „Rechnung“. Achte auf ALLE Attribute der Entitätsmenge „Kunde“.";
        secondchance[17] = "Hast du schon einmal Artikel in einem Sportgeschäft gekauft und eine Rechnung/Quittung erhalten? Wie viele waren das? Waren die Artikel auch nach deinem Kauf noch im Laden auf Lager?";
        secondchance[18] = "Tipp: Ein Kunde kauft an einem gewissen Tag in dem Geschäft ein und bezahlt einen bestimmten Preis. Und wir benötigen noch einen Primärschlüssel!";
        secondchance[19] = "An einem Tag werden in dem Sporthaus 300 Rechnungen ausgestellt. Welche Attributwerte könnten doppelt vorkommen?";
        secondchance[20] = "Das ist die letzte Aufgabe! Alle Antwortmöglichkeiten wurden in vorherigen Aufgaben thematisiert! Versuche es nochmal!";
        secondchance[21] = "Um welche Subjektive geht es in den Text hauptsächlich.";
        secondchance[22] = "Steht in dem Text irgendwas von einer Adresse?";
        secondchance[23] = "Es kann 2 Kugelschreiber geben, die gleich heißen und den gleichen Namen haben.";
        secondchance[24] = "Wieviele Artikel kann man kaufen und kann nicht ein Artikel von mehreren gekauft werden?";

        if (!OhneSchwacheEntity.schwachAus)
        {
            secondchance[25] = "Was geschieht mit dem Klassenzimmer, wenn das Schulgebäude abgerissen wird?";
            secondchance[26] = "Was geschieht, wenn du die Zeitschrift in den Müll wirfst?";
            secondchance[27] = "Was geschieht mit dem Monitor, wenn du den Computer herunterfährst oder dir einen neuen zulegst?";
            secondchance[28] = "Was kann nicht ohne den anderen exisiteren?";
            correct[25] = "B";
            correct[26] = "C";
            correct[27] = "D";
            correct[28] = "B";
        }
    }
    public void Update()
    {
        if(welcheAufgabe <aufgabenListe.Count){
            zusatzButton.GetComponent<Button>().enabled = true;
        }
        else
        {
            zusatzButton.GetComponent<Button>().enabled = false;
            zusatzButton.SetActive(false);
        }       
    }
    /*
    *Prüfen der Eingabe und drücken auf Button
    */
    public void check(){
        AudioSource soundTrue = sound_true.GetComponent<AudioSource>();
        AudioSource soundFalse = sound_false.GetComponent<AudioSource>();

        toogle.toggleWhite();
        //keine Eingabe
        if (toogle.toggleGroupInstance.AnyTogglesOn() == false)
        {
           toogle.toggleRed();
            toogle.toggleWhite();
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

                zusatzButton.SetActive(true);
            }
            //falsche Eingabe
            else
            {   
                soundFalse.Play();
                temp++;//temp zählt die Chancen (temp == 2 dann keine Chance mehr!)
               //falschKreuz.SetActive(true);
                toogle.toggleColor(Color.red, toogle.currentSelection);
                Invoke("toggleFarbe",1);
                //zweite chance bereits gehabt
                if(temp == 2){
                    cheat_temp = 0;
                    checkButton.SetActive(false);
                    toggleKiller.SetActive(true);
                    hinweisButton.SetActive(false);
                    lösungsButton.SetActive(true);
                    checkButton.SetActive(false);
                    zusatzButton.SetActive(true);
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
            toggleKiller.SetActive(false) ;
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
        if (cheat_temp == 1){
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
        if (welcheAufgabe < aufgabenListe.Count)
        {
            //gameObject.GetComponent<Image>().sprite = aufgabenListe[welcheAufgabe];
            aufgabenstellung.GetComponent<TextMeshProUGUI>().SetText(inhalt_aufgabenstellung[welcheAufgabe]);
            image.SetActive(inhalt_image[welcheAufgabe] != null);
            image.GetComponent<Image>().sprite = inhalt_image[welcheAufgabe];
            image.GetComponent<Image>().SetNativeSize();
            text.SetText(inhalt_text[welcheAufgabe]);
            anwortA.SetText(inhalt_anwortA[welcheAufgabe]);
            anwortB.SetText(inhalt_anwortB[welcheAufgabe]);
            anwortC.SetText(inhalt_anwortC[welcheAufgabe]);
            anwortD.SetText(inhalt_anwortD[welcheAufgabe]);

        }
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
        if(cheat_temp == 0&& temp==2)
        {
            toogle.toggleOff();
            if (correct[welcheAufgabe - 1] == "A")
            {
               var toggles = toogle.toggleGroupInstance.GetComponentsInChildren<Toggle>();
                toggles[0].isOn = true;
                toogle.toggleColor(Color.green, toggles[0]);
            }
            else if (correct[welcheAufgabe - 1] == "B")
            {
                var toggles = toogle.toggleGroupInstance.GetComponentsInChildren<Toggle>();
                toggles[1].isOn = true;
                toogle.toggleColor(Color.green, toggles[1]);
            }
            else if (correct[welcheAufgabe - 1] == "C")
            {
                var toggles = toogle.toggleGroupInstance.GetComponentsInChildren<Toggle>();
                toggles[2].isOn = true;
                toogle.toggleColor(Color.green, toggles[2]);
            }
            else if (correct[welcheAufgabe - 1] == "D")
            {
                var toggles = toogle.toggleGroupInstance.GetComponentsInChildren<Toggle>();
                toggles[3].isOn = true;
                toogle.toggleColor(Color.green, toggles[3]);
            }
        }
    }
}
