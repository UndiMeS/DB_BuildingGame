using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aufgaben : MonoBehaviour
{
    public Sprite[] aufgabenListe = new Sprite[23];
    public string[] correct ;
    public string[] feedback;
    public int[] level ;

    private int welcheAufgabe = 0;

    public toogleEingabe toogle;
    public GameObject exitKnopf;
    public GameObject RichitgFalschAnzeige;
    public GameObject fenster;
    public GameObject checkButton;

    public GameObject transparent;
    public GameObject richtigHacken;
    public GameObject falschKreuz;

    public GameObject zusatzButton;
    public GameObject zusatzButton_transparent;


    public void Start()
    {
        transparent.SetActive(false);
        richtigHacken.SetActive(false);
        falschKreuz.SetActive(false);
        
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
    }


    public void check(){
        if (toogle.currentSelection.name.Equals(correct[welcheAufgabe]))
        {
            //Utilitys.TextInTMP(RichitgFalschAnzeige, "Richtig !");

            welcheAufgabe++;
            geldGeben();
            richtigHacken.SetActive(true);
            exitKnopf.SetActive(true);
            checkButton.SetActive(false);

            zusatzButton.SetActive(false);
            zusatzButton_transparent.SetActive(true);
    
            //Invoke("closeFenster", 2);
        }
        else
        {
            //string ausgabe = "Falsch! Richtig ist " + correct[welcheAufgabe];
            transparent.SetActive(true);
            string ausgabe = feedback[welcheAufgabe];
            Utilitys.TextInTMP(RichitgFalschAnzeige, ausgabe);
            //Invoke("clearAnzeige", 4);
            exitKnopf.SetActive(true);
            checkButton.SetActive(false);
            falschKreuz.SetActive(true);

            zusatzButton.SetActive(false);
            zusatzButton_transparent.SetActive(true);

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
        transparent.SetActive(false);
        richtigHacken.SetActive(false);
        falschKreuz.SetActive(false);
        
    }


    public void geldGeben(){
        
        Testing.geld += 100;
    }

}
