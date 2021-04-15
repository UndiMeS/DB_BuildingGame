using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aufgaben : MonoBehaviour
{
    public Sprite[] aufgabenListe = new Sprite[23];
    public string[] correct ;
    public string[] feedback;

    public string[] secondchance;
    public int[] level ;

    private int welcheAufgabe = 0;

    public toogleEingabe toogle;
    public GameObject exitKnopf;
    public GameObject RichitgFalschAnzeige;
    public GameObject fenster;
    public GameObject checkButton;

    public GameObject richtigHacken;
    public GameObject falschKreuz;

    public GameObject zusatzButton;
    public GameObject zusatzButton_transparent;

    public GameObject hinweisFenster;
    public GameObject hinweisButton;
    public GameObject lösungsButton;
    public GameObject exitKnopfHinweis;
    public GameObject zweiteChance;
    public GameObject toggleKiller;

    private int temp = 0;
    private int cheat_temp = 0;

    public void Start()
    {
        //hinweisFenster.SetActive(false); 

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

        feedback = new string[aufgabenListe.Length];
        feedback[0] = "Nicht ganz! Richtig wäre n : 1. Zum Beispiel kann Jona nicht gleichzeitig in Klasse 9 und 10 sein. Jedoch könnten 25 Schüler gemeinsam in Klasse 9 gehen.";
        feedback[1] = "Das ist falsch. An einer Schule gibt es ja mehrere Informatiklehrer. Gleichzeitig kann jeder Lehrer mindestens zwei Fächer unterrichten. Richtig wäre n : m.";
        feedback[2] = "Nicht ganz! Ein Kino hat meistens mehrere Kinosäle. Derselbe Saal kann jedoch nicht in verschiedenen Kinos auftauchen. Also n : 1.";
        feedback[3] = "Ein Mensch kann nicht mit mehr als einem anderen Menschen verheiratet sein. Richtig ist daher 1 : 1.";
        feedback[4] = "Das war falsch. Die Kardinalität der Relation zwischen A und B ist 1 : n.";
        feedback[5] = "Nein. Die Kardinalität der Relation zwischen A und B ist 1 : 1.";
        feedback[6] = "Kann dasselbe Auto in mehreren Straßen gleichzeitig parken? Nein. Jedoch hat eine Straße Platz für mehrere Autos. Richtig wäre daher n : 1.";
        feedback[7] = "Richtig wäre n : m. Zum Beispiel lief Harry Potter gleichzeitig in mehreren Kinos. Und jedes Kino hat gleichzeitig verschiedene Filme im Programm.";
        feedback[8] = "Richtig wäre n : m. Man kann ja auch mehrere Hobbys besitzen und diese auch mit anderen zusammen ausüben.";
        feedback[9] = "Nicht ganz! Jedes Auto hat immer genau einen Halter, wobei dieser auch mehrere Autos besitzen kann. Und mehrere Nutzer können das Auto fahren und ein Nutzer hat auch die Möglichkeit mehrere Autos zu fahren.";
        feedback[10] = "Nicht ganz! Jeder Mensch besitzt eine eindeutige Personalausweisnummer. Diese ist der Primärschlüssel. Auch Handynummern sind meistens eindeutig einem Menschen zugeordnet. Jedoch muss dann auch jeder Mensch eine Nummer besitzen!";
        feedback[11] = "Leider nein. Die Schlüsselattribute sind Name und Erscheinungsdatum. Die anderen Varianten sind nicht eindeutig.";
        feedback[12] = "Ein Autor kann gleichzeitig auch mehrere Bücher veröffentlichen oder verschiedene Autoren den gleichen Namen nutzen. Richtig sind alle drei Attribute zusammen.";
        feedback[13] = "Die ISBN ist der Primärschlüssel. Zwar können auch Autor, Name und Erscheinungsdatum ein Buch eindeutig zuordnen, jedoch suchen wir immer eine minimale Menge von Attributen.";
        feedback[14] = "Leider nein. An einer Schule können auch zum Beispiel zwei Annas mit Geschlecht weiblich in Klasse 10 vorkommen. Die E-Mail ist jedoch eindeutig.";
        feedback[15] = "Fast! Die Adresse des Kunden ist laut Text nicht hinterlegt (A falsch) und ein Kunde kann mehr als ein Artikel kaufen (B falsch). Jeder Kunde kann über die Kundennummer eindeutig zugeordnet werden. Name ist daher kein Schlüsselattribut (D falsch). Richtig wäre daher C.";
        feedback[16] = "Fast! Ohne Patienten können Zähne nicht existieren. Die Entitymenge Patient ist daher schwach (B falsch). Ein Zahn kann nicht mehreren Patienten zugeordnet werden (C falsch). Zwischen Patient und Zahn ist die Kardinalität 1 : n, und damit wäre A richtig. ";
        feedback[17] = "Falsch! Ein Klassenzimmer kann leider nicht in der Luft schweben. Es benötigt ein Schulgebäude, um existieren zu können uns ist daher schwach.";
        feedback[18] = "Das ist nicht korrekt! Artikel werden in Zeitschriften abgedruckt. Ohne diese können wir Artikel nicht lesen. Artikel ist daher eine schwache Entitymenge.";
        feedback[19] = "Leider nein. Zwar wird auf dem Monitor ohne Computer nichts angezeigt, jedoch ist ein Monitor ein eigener Gegenstand. Keine Entitymenge muss als schwach gekennzeichnet werden.";
        feedback[20] = "Das ist nicht ganz richtig! Die Attribute von „Artikel“ stehen im Tabellenkopf. Korrekt wäre D.";
        feedback[21] = "Leider nein. Richtig wäre Adresse, Name und Kundennummer. Letztere ist der Primärschlüssel. Rechnungsdatum ist ein Attribut der Entitymenge „Rechnung“.";
        feedback[22] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte jedoch auch die gleichen Artikel kaufen. Richtig wäre daher n : m.";
        feedback[23] = "Nicht ganz. Jede Rechnung wird einer Kundennummer zugeordnet, hat eine eindeutige Rechnungsnummer, ein Datum und einen Betrag.";
        feedback[24] = "Leider falsch! Die Attribute Rechnungsbetrag, Rechnungsdatum, Artikelnummer und Kundennummer können mehrfach vorkommen. Die Rechnungsnummer lässt jede Rechnung eindeutig ermitteln.";
        feedback[25] = "Das war leider falsch! Die falsche Aussage ist A, da mehrere Rechnungen am selben Datum ausgestellt werden können. Das Rechnungsdatum ist somit nicht eindeutig und damit kein Primärschlüssel.";

        secondchance = new string[aufgabenListe.Length];
        secondchance[0] = "In wie viele Klassen gehst du persönlich an deiner Schule?";
        secondchance[1] = "Unterrichtet an deiner Schule nur eine Lehrkraft Informatik? Und hat diese auch andere Fächer, die sie unterrichtet?";
        secondchance[2] = "Kleine Kinos haben ggf. nur ein Saal und größere? Und kann den derselbe (nicht der gleiche) Raum an verschiedenen Orte gleichzeitig exitieren?";
        //ab hier weiter die Rückmeldungen ändern.
        secondchance[3] = "Ein Mensch kann nicht mit mehr als einem anderen Menschen verheiratet sein. Richtig ist daher 1 : 1.";
        secondchance[4] = "Das war falsch. Die Kardinalität der Relation zwischen A und B ist 1 : n.";
        secondchance[5] = "Nein. Die Kardinalität der Relation zwischen A und B ist 1 : 1.";
        secondchance[6] = "Kann dasselbe Auto in mehreren Straßen gleichzeitig parken? Nein. Jedoch hat eine Straße Platz für mehrere Autos. Richtig wäre daher n : 1.";
        secondchance[7] = "Richtig wäre n : m. Zum Beispiel lief Harry Potter gleichzeitig in mehreren Kinos. Und jedes Kino hat gleichzeitig verschiedene Filme im Programm.";
        secondchance[8] = "Richtig wäre n : m. Man kann ja auch mehrere Hobbys besitzen und diese auch mit anderen zusammen ausüben.";
        secondchance[9] = "Nicht ganz! Jedes Auto hat immer genau einen Halter, wobei dieser auch mehrere Autos besitzen kann. Und mehrere Nutzer können das Auto fahren und ein Nutzer hat auch die Möglichkeit mehrere Autos zu fahren.";
        secondchance[10] = "Nicht ganz! Jeder Mensch besitzt eine eindeutige Personalausweisnummer. Diese ist der Primärschlüssel. Auch Handynummern sind meistens eindeutig einem Menschen zugeordnet. Jedoch muss dann auch jeder Mensch eine Nummer besitzen!";
        secondchance[11] = "Leider nein. Die Schlüsselattribute sind Name und Erscheinungsdatum. Die anderen Varianten sind nicht eindeutig.";
        secondchance[12] = "Ein Autor kann gleichzeitig auch mehrere Bücher veröffentlichen oder verschiedene Autoren den gleichen Namen nutzen. Richtig sind alle drei Attribute zusammen.";
        secondchance[13] = "Die ISBN ist der Primärschlüssel. Zwar können auch Autor, Name und Erscheinungsdatum ein Buch eindeutig zuordnen, jedoch suchen wir immer eine minimale Menge von Attributen.";
        secondchance[14] = "Leider nein. An einer Schule können auch zum Beispiel zwei Annas mit Geschlecht weiblich in Klasse 10 vorkommen. Die E-Mail ist jedoch eindeutig.";
        secondchance[15] = "Fast! Die Adresse des Kunden ist laut Text nicht hinterlegt (A falsch) und ein Kunde kann mehr als ein Artikel kaufen (B falsch). Jeder Kunde kann über die Kundennummer eindeutig zugeordnet werden. Name ist daher kein Schlüsselattribut (D falsch). Richtig wäre daher C.";
        secondchance[16] = "Fast! Ohne Patienten können Zähne nicht existieren. Die Entitymenge Patient ist daher schwach (B falsch). Ein Zahn kann nicht mehreren Patienten zugeordnet werden (C falsch). Zwischen Patient und Zahn ist die Kardinalität 1 : n, und damit wäre A richtig. ";
        secondchance[17] = "Falsch! Ein Klassenzimmer kann leider nicht in der Luft schweben. Es benötigt ein Schulgebäude, um existieren zu können uns ist daher schwach.";
        secondchance[18] = "Das ist nicht korrekt! Artikel werden in Zeitschriften abgedruckt. Ohne diese können wir Artikel nicht lesen. Artikel ist daher eine schwache Entitymenge.";
        secondchance[19] = "Leider nein. Zwar wird auf dem Monitor ohne Computer nichts angezeigt, jedoch ist ein Monitor ein eigener Gegenstand. Keine Entitymenge muss als schwach gekennzeichnet werden.";
        secondchance[20] = "Das ist nicht ganz richtig! Die Attribute von „Artikel“ stehen im Tabellenkopf. Korrekt wäre D.";
        secondchance[21] = "Leider nein. Richtig wäre Adresse, Name und Kundennummer. Letztere ist der Primärschlüssel. Rechnungsdatum ist ein Attribut der Entitymenge „Rechnung“.";
        secondchance[22] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte jedoch auch die gleichen Artikel kaufen. Richtig wäre daher n : m.";
        secondchance[23] = "Nicht ganz. Jede Rechnung wird einer Kundennummer zugeordnet, hat eine eindeutige Rechnungsnummer, ein Datum und einen Betrag.";
        secondchance[24] = "Leider falsch! Die Attribute Rechnungsbetrag, Rechnungsdatum, Artikelnummer und Kundennummer können mehrfach vorkommen. Die Rechnungsnummer lässt jede Rechnung eindeutig ermitteln.";
        secondchance[25] = "Das war leider falsch! Die falsche Aussage ist A, da mehrere Rechnungen am selben Datum ausgestellt werden können. Das Rechnungsdatum ist somit nicht eindeutig und damit kein Primärschlüssel.";
    }


    public void check(){
        if (toogle.currentSelection.name.Equals(correct[welcheAufgabe]))
        {
            falschKreuz.SetActive(false);
            hinweisButton.SetActive(false);
            temp++;
            cheat_temp = 0;
            geldGeben(temp);
            welcheAufgabe++;
            richtigHacken.SetActive(true);
            exitKnopfHinweis.SetActive(false);
            checkButton.SetActive(false);

            zusatzButton.SetActive(false);
            zusatzButton_transparent.SetActive(true);
        }
        else
        {   
            temp++;
            if(temp == 2){
                cheat_temp = 0;
                checkButton.SetActive(false);
                toggleKiller.SetActive(true);
                hinweisButton.SetActive(false);
                lösungsButton.SetActive(true);
            }else{
                cheat_temp = 1;
                checkButton.SetActive(true);
                zweiteChance.SetActive(true);
                toggleKiller.SetActive(true);
                hinweisButton.SetActive(true);
                Invoke("SecondChanceAnzeigen", 1);
            }
            if(temp == 2)
            {
                checkButton.SetActive(false);
                zusatzButton.SetActive(false);
                zusatzButton_transparent.SetActive(true);
                welcheAufgabe++;
            }
            
            falschKreuz.SetActive(true);

        }
        
    }

    public void hinweis()
    {
        hinweisFenster.SetActive(true);
        fenster.SetActive(false);
        checkButton.SetActive(false);
        string ausgabe;
        if (temp == 2){
            ausgabe = feedback[welcheAufgabe - 1];//da im else Zweig in check schon auf nächste Aufgabe gezeigt wird
        }else{
            ausgabe = secondchance[welcheAufgabe];
        }
        
        Utilitys.TextInTMP(RichitgFalschAnzeige, ausgabe);
        exitKnopfHinweis.SetActive(true);
    }

    public void exitHinweis()
    {
        hinweisFenster.SetActive(false);
        fenster.SetActive(true);
        exitKnopfHinweis.SetActive(false);
        if(temp == 2){
            checkButton.SetActive(false);
        }else{
            checkButton.SetActive(true);
        }
        clearAnzeige();
    }

    public void clearAnzeige()
    {
        Utilitys.TextInTMP(RichitgFalschAnzeige, " ");
    }


    public void openAufgabe()
    {
        if(cheat_temp == 1){
            temp = 1;
            hinweisButton.SetActive(true);
            falschKreuz.SetActive(true);
        }else{
            temp = 0;
            hinweisButton.SetActive(false);
            falschKreuz.SetActive(false);
        }
        toggleKiller.SetActive(false);
        toogle.init();
        toogle.toggleOff();
        gameObject.GetComponent<Image>().sprite = aufgabenListe[welcheAufgabe];
        exitKnopfHinweis.SetActive(false);
        clearAnzeige();
        checkButton.SetActive(true);
        richtigHacken.SetActive(false);
        
        
    }


    public void geldGeben(int versuch){
        if(versuch == 1){
            //1. Versuch richtig
            Testing.geld += 100;
        }else{
            //2. Versuch richtig
            Testing.geld += 50;
        }
    }
    public void SecondChanceAnzeigen()
    {
        zweiteChance.SetActive(false);
        toggleKiller.SetActive(false);
    }

    public void LösungsButton()
    {
        lösungsButton.SetActive(false);
    }

    /*
    *Cheatbut: Wenn man die erste toggle Wahl macht, dann mittels Zusatzbutton rechts die Anzeige verlässt und wieder öffnet, erhält man erneut die erste Chance!
    */
    public void Cheatbug()
    {
        
    }
}
