using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Aufgaben : MonoBehaviour
{
    public string[] correct ;
    public string[] secondchance;

    public static int welcheAufgabe = 0;
    private int anzahlAufgabe = 25;


    public toogleEingabe toogle;
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
    private string[] inhalt_aufgabenstellung;
    public GameObject image;
    public List<Sprite> inhalt_image;
    public TMPro.TextMeshProUGUI text;
    private string[] inhalt_text;
    public TMPro.TextMeshProUGUI anwortA;
    private string[] inhalt_anwortA;
    public TMPro.TextMeshProUGUI anwortB;
    private string[] inhalt_anwortB;
    public TMPro.TextMeshProUGUI anwortC;
    private string[] inhalt_anwortC;
    public TMPro.TextMeshProUGUI anwortD;
    private string[] inhalt_anwortD;
    private string[] inhalt_loesung;

    public GameObject ueberdeckung;
    private void init()
    {
        int anzahlSchwach = 4;
        if (OhneSchwacheEntity.schwachAus)
        {
            correct = new string[anzahlAufgabe];
            secondchance = new string[anzahlAufgabe];
            inhalt_anwortA = new string[anzahlAufgabe];
            inhalt_anwortB = new string[anzahlAufgabe];
            inhalt_anwortC = new string[anzahlAufgabe];
            inhalt_anwortD = new string[anzahlAufgabe];
            inhalt_aufgabenstellung = new string[anzahlAufgabe];
            inhalt_text = new string[anzahlAufgabe];
            inhalt_loesung = new string[anzahlAufgabe];
        }
        else {
            anzahlAufgabe += anzahlSchwach;
            correct = new string[anzahlAufgabe];
            secondchance = new string[anzahlAufgabe];
            inhalt_anwortA = new string[anzahlAufgabe];
            inhalt_anwortB = new string[anzahlAufgabe];
            inhalt_anwortC = new string[anzahlAufgabe];
            inhalt_anwortD = new string[anzahlAufgabe];
            inhalt_aufgabenstellung = new string[anzahlAufgabe];
            inhalt_text = new string[anzahlAufgabe]; 
            inhalt_loesung = new string[anzahlAufgabe];
        }

        if (Sprache.sprache == "ge")
        {
            int i = 0;
            //Frage 1
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “gehtIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "In wie viele Klassen gehst du persönlich an deiner Schule?";
            inhalt_loesung[i] = "Nicht ganz! Richtig wäre n : 1. Zum Beispiel kann Jona nicht gleichzeitig in Klasse 9 und 10 sein. Jedoch können 25 Schüler gemeinsam in Klasse 9 gehen";
            i++;

            //Frage 2
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “unterrichtetVon”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Unterrichtet an deiner Schule nur eine Lehrkraft Informatik? Und hat diese auch andere Fächer, die sie unterrichtet?";
            inhalt_loesung[i] = "Das ist falsch. An einer Schule gibt es mehrere Informatiklehrer. Gleichzeitig kann jeder Lehrer mindestens zwei Fächer unterrichten. Richtig wäre n : m.";
            i++;

            //Frage 3
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “istIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "Kleine Kinos haben ggf. nur ein Saal, aber größere? Und kann denn derselbe (nicht der gleiche) Raum an verschiedenen Orten gleichzeitig existieren?";
            inhalt_loesung[i] = "Das ist falsch. In einen Kino gibt es mehrere Kinosäle. Gleichzeitig kann ein Kinosaal nur in einen Gebäude/ Kino sein. Richtig wäre n : 1.";
            i++;

            //Frage 4
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “verheiratetMit”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "A";
            secondchance[i] = "Wie viele Menschen in eurem Umfeld sind denn mit mehr als einer Person verheiratet?";
            inhalt_loesung[i] = "Ein Mensch kann nicht mit mehr als einem anderen Menschen verheiratet sein. Richtig ist daher 1 : 1.";
            i++;

            //Frage 5
            inhalt_aufgabenstellung[i] = "Welche Kardinalität steht für folgende Beschreibung?";
            inhalt_text[i] = "Jeder Entität der Entitätsmenge A können mehrere Objekte der Entitätsmenge B zugeordnet werden. Umgekehrt kann jedoch jeder Entität aus B nur eine Entität aus A zugeordnet werden.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "B";
            secondchance[i] = "Schlüsselwörter wie „nur“ oder „genau eine“ geben den Hinweis auf die Kardinalität 1.";
            inhalt_loesung[i] = "Das war falsch. Die Kardinalität der Beziehung zwischen A und B ist 1 : n. Der erste Satz beschreibt die Kardinalität 1 und der zweite n. ";
            i++;

            //Frage 6
            inhalt_aufgabenstellung[i] = "Welche Kardinalität steht für folgende Beschreibung?";
            inhalt_text[i] = "Jeder Entität der Entitätsmenge A wird genau eine Entität der Entitätsmenge B zugeordnet. Gleiches gilt für die Zuordnung der Entitäten von B auf A.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "A";
            secondchance[i] = "Denke an den Hinweis der vorherigen Aufgabe!";
            inhalt_loesung[i] = "Nein. Die Kardinalität der Beziehung zwischen A und B ist 1 : 1.";
            i++;

            //Frage 7
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “parktIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "Nehmen wir an man darf in einer Straße parken. Frage dich, wie viele Autos könnten in einer Straße Parken? Und in wie vielen Straßen kann dasselbe Auto gleichzeitig parken?";
            inhalt_loesung[i] = "Kann dasselbe Auto in mehreren Straßen gleichzeitig parken? Nein. Jedoch hat eine Straße Platz für mehrere Autos. Richtig wäre daher n : 1.";
            i++;

            //Frage 8
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “gezeigtIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Zeigt ein Kino mit mehreren Sälen nur einen Film?";
            inhalt_loesung[i] = "Richtig wäre n : m. Zum Beispiel lief Harry Potter gleichzeitig in mehreren Kinos. Und jedes Kino hat gleichzeitig verschiedene Filme im Programm.";
            i++;

            //Frage 9
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung “ausüben”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Hast du Freundinnen und Freunde, die das gleiche Hobby ausüben wie du?";
            inhalt_loesung[i] = "Richtig wäre n : m. Man kann auch mehrere Hobbys besitzen (z.B.: Anna spielt Fußball und Gitarre) und diese auch mit anderen zusammen ausüben (z.B.: Anna und Max spielen beide Gitarre).";
            i++;

            //Frage 10
            inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm. Benenne das passende Paar an Kardinalitäten für die Beziehung “besitzt” und “nutzt” (in dieser Reihenfolge)!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "n : 1 und n : 1";
            inhalt_anwortB[i] = "n : m und n : m";
            inhalt_anwortC[i] = "1 : n und n : m";
            inhalt_anwortD[i] = "1 : 1 und 1 : n";
            correct[i] = "C";
            secondchance[i] = "Maxime hat bspw. in seiner Garage einen Caprio und einen Kleinbus. Am Wochenende verleiht er diese häufig an seine Freunde.";
            inhalt_loesung[i] = "Nicht ganz! Jedes Auto hat immer genau einen Halter, wobei dieser auch mehrere Autos besitzen kann. Und mehrere Nutzer können das Autofahren und ein Nutzer hat auch die Möglichkeit mehrere Autos zu fahren.";
            i++;

            //Frage 11
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Mensch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Handynummer";
            inhalt_anwortB[i] = "Personalausweisnummer";
            inhalt_anwortC[i] = "Adresse";
            inhalt_anwortD[i] = "Name und Geburtstag";
            correct[i] = "B";
            secondchance[i] = "Eine vierköpfige Familie hat eine Adresse. Gibt es eigentlich auch Menschen ohne Handy?";
            inhalt_loesung[i] = "Nicht ganz! Jeder Mensch besitzt einen eindeutige Personalausweisnummer. Dieser ist der Primärschlüssel. Auch Handynummer sind eindeutig. Jedoch besitzt nicht jeder Mensch ein eigenes Handy.";
            i++;

            //Frage 12
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Film.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Hauptperson und Name";
            inhalt_anwortB[i] = "Name";
            inhalt_anwortC[i] = "Erscheinungsdatum und Hauptperson";
            inhalt_anwortD[i] = "Name und Erscheinungsdatum";
            correct[i] = "D";
            secondchance[i] = "Es gibt Filme, die haben den gleichen Namen. Es gibt Hauptdarsteller, die drehen an zwei Filmen gleichzeitig mit.";
            inhalt_loesung[i] = "Leider nein. Die Schlüsselattribute sind Name und Erscheinungsdatum. Die anderen Varianten sind nicht eindeutig.";
            i++;

            //Frage 13
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Buch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Name und Erscheinungsdatum";
            inhalt_anwortB[i] = "Erscheinungsdatum und Autor";
            inhalt_anwortC[i] = "Autor und Name und Erscheinungsdatum";
            inhalt_anwortD[i] = "Name";
            correct[i] = "C";
            secondchance[i] = "Es ist zwar selten, jedoch kommt es vor, dass zwei Bücher mit gleichen Namen zu selben Zeit veröffentlicht werden. ";
            inhalt_loesung[i] = "Ein Autor kann gleichzeitig auch mehrere Bücher veröffentlichen oder verschiedene Autoren den gleichen Namen nutzen. Richtig sind alle drei Attribute zusammen.";
            i++;

            //Frage 14
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Buch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Name und Erscheinungsdatum";
            inhalt_anwortB[i] = "Name und ISBN";
            inhalt_anwortC[i] = "Autor und Name und Erscheinungsdatum";
            inhalt_anwortD[i] = "ISBN";
            correct[i] = "D";
            secondchance[i] = "Laut Wikipedia ist die die Internationale Standartbuchnummer (ISBN) “eine Nummer zur eindeutigen Kennzeichnung von Büchern [...]“.";
            inhalt_loesung[i] = "Die ISBN ist der Primärschlüssel. Zwar können auch Autor, Name und Erscheinungsdatum ein Buch eindeutig zuordnen, jedoch suchen wir immer eine <b> minimale Menge<b> von Attributen.";
            i++;

            //Frage 15
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Schüler.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Geschlecht und E-Mail";
            inhalt_anwortB[i] = "E-Mail";
            inhalt_anwortC[i] = "Name und Klasse";
            inhalt_anwortD[i] = "Name und E-Mail";
            correct[i] = "B";
            secondchance[i] = "Hast du schon einmal davon gehört, dass in einer Klasse zwei Schüler oder Schülerinnen den gleichen Namen haben?";
            inhalt_loesung[i] = "Leider nein. An einer Schule können auch zum Beispiel zwei Annas in der 10. Klasse gehen. Die E-Mail ist jedoch eindeutig.";
            i++;

            //Frage 16
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Artikel“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Artikelnummer, Preis";
            inhalt_anwortB[i] = "Beschreibung, Farbe, Größe";
            inhalt_anwortC[i] = "Artikelnummer, Rechnungsnummer";
            inhalt_anwortD[i] = "Artikelnummer, Beschreibung, Farbe, Größe, Preis";
            correct[i] = "D";
            secondchance[i] = "Welcher Bereich auf der Rechnung beschreibt die gekauften Artikel? Dort stehen die Attribute!";
            inhalt_loesung[i] = "Der Tabellenkopf liefert die Attribute, Artikelnummer, Beschreibung, Farbe, Größe und Preis.";
            i++;

            //Frage 17
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Kunde“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Adresse, Name, Kundennummer";
            inhalt_anwortB[i] = "Name, Adresse";
            inhalt_anwortC[i] = "Rechnungsdatum, Kundennummer";
            inhalt_anwortD[i] = "Adresse, Kundennummer";
            correct[i] = "A";
            secondchance[i] = "Es gibt auch eine Entitätsmenge „Rechnung“. Achte auf ALLE Attribute der Entitätsmenge „Kunde“.";
            inhalt_loesung[i] = "Die Attribute können wir aus dem Briefkopf ablesen. Adresse, Name und Kundennummer sind die Attribute von Kunde.";
            i++;

            //Frage 18
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. In einem ER-Diagramm zu diesem Sporthandel existiert eine Beziehung “enthält” zwischen Rechnung und Artikel. Benenne die Kardinalität dieser Beziehung!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Hast du schon einmal Artikel in einem Sportgeschäft gekauft und eine Rechnung/Quittung erhalten? Wie viele waren das? Waren die Artikel auch nach deinem Kauf noch im Laden auf Lager?";
            inhalt_loesung[i] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte auch die gleichen Artikel bestellen. Richtig wäre daher n : m.";
            i++;

            //Frage 19
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitätsmenge „Rechnung“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortB[i] = "Kundennummer, Artikelnummer, Rechnungsnummer";
            inhalt_anwortC[i] = "Kundennummer, Rechnungsnummer, Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortD[i] = "Rechnungsnummer, Name, Adresse, Rechnungsbetrag, Rechnungsdatum";
            correct[i] = "C";
            secondchance[i] = "Tipp: Ein Kunde kauft an einem gewissen Tag in dem Geschäft ein und bezahlt einen bestimmten Preis. Und wir benötigen noch einen Primärschlüssel!";
            inhalt_loesung[i] = "Es sind alles Werte, die diese Rechnung auszeichnen. Das wären die Kundennummer, die Rechnungsnummer, der Rechnungsbetrag und das Rechnungsdatum. ";
            i++;

            //Frage 20
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute lassen die <b>Rechnung</b> eindeutig ermitteln?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortB[i] = "Kundennummer, Artikelnummer, Rechnungsdatum";
            inhalt_anwortC[i] = "Kundennummer, Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortD[i] = "Rechnungsnummer";
            correct[i] = "D";
            secondchance[i] = "An einem Tag werden in dem Sporthaus 300 Rechnungen ausgestellt. Welche Attributwerte könnten doppelt vorkommen?";
            inhalt_loesung[i] = "Richtig wäre die Rechnungsnummer. Jede Rechnung hat eine eindeutige Nummer.";
            i++;

            //Frage 21
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Aussage ist falsch?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsnummer ist Primärschlüssel der Entitätsmenge Rechnung.";
            inhalt_anwortB[i] = "Ein Kunde kann zwei Rechnungen mit gleichen Rechnungsbetrag erhalten.";
            inhalt_anwortC[i] = "Jede Rechnung wird genau einem Kunden zugeordnet.";
            inhalt_anwortD[i] = "Beschreibung und Größe sind Schlüsselattribute der Entitätsmenge Artikel.";
            correct[i] = "D";
            secondchance[i] = "Das ist die letzte Aufgabe! Alle Antwortmöglichkeiten wurden in vorherigen Aufgaben thematisiert! Versuche es nochmal!";
            inhalt_loesung[i] = "Diese Aussage ist richtig. Die Aussage D ist falsch. Beschreibung und Größe können zwar bei jeden Artikel eindeutig sein, jedoch ist die Kombination nicht minimal. Der Primärschlüssel ist die Artikelnummer.";
            i++;

            //Frage 22
            inhalt_aufgabenstellung[i] = "Wie viele Entitätsmengen enthält das ER-Modell mindestens?";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "keine";
            inhalt_anwortB[i] = "eine";
            inhalt_anwortC[i] = "zwei";
            inhalt_anwortD[i] = "drei";
            correct[i] = "C";
            secondchance[i] = "Um welche Subjektive geht es in den Text hauptsächlich.";
            inhalt_loesung[i] = "Das Diagramm enthält zwei Entitätsmengen Kunde und Artikel. Lager ist keine Entitätsmenge.";
            i++;

            //Frage 23
            inhalt_aufgabenstellung[i] = "Benenne die Attribute besitzt die Entitätsmenge „Kunde“?";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "Name und Kundenummer";
            inhalt_anwortB[i] = "Kundennummer";
            inhalt_anwortC[i] = "Kundenummer, Name, Adresse";
            inhalt_anwortD[i] = "keine";
            correct[i] = "A";
            secondchance[i] = "Steht in dem Text irgendwas von einer Adresse?";
            inhalt_loesung[i] = "Falsch. Im Text wird die Adresse des Kunden nicht erwähnt. Die Attribute sind Name und Kundennummer.";
            i++;

            //Frage 24
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitätsmenge Artikel.";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "Name";
            inhalt_anwortB[i] = "ID";
            inhalt_anwortC[i] = "Name und Preis";
            inhalt_anwortD[i] = "ID, Name, Preis";
            correct[i] = "B";
            secondchance[i] = "Es kann 2 Kugelschreiber geben, die gleich heißen und den gleichen Namen haben.";
            inhalt_loesung[i] = "Falsch die ID ist die minimale Menge an Schlüsselattributen.";
            i++;

            //Frage 25
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Beziehung zwischen „Kunde“ und „Artikel“!";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Wie viele Artikel kann man kaufen und kann nicht ein Artikel von mehreren gekauft werden?";
            inhalt_loesung[i] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte auch die gleichen Artikel bestellen. Richtig wäre daher n : m.";
            i++;

            if (!OhneSchwacheEntity.schwachAus)
            {
                //Frage 26
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "Schulgebäude";
                inhalt_anwortB[i] = "Klassenzimmer";
                inhalt_anwortC[i] = "keine";
                inhalt_anwortD[i] = "Schulgebäude und Klassenzimmer";
                correct[i] = "B";
                secondchance[i] = "Was geschieht mit dem Klassenzimmer, wenn das Schulgebäude abgerissen wird?";
                inhalt_loesung[i] = "Falsch. Ein Klassenzimmer kann leider nicht in der Luft schweben. Es benötigt ein Schulgebäude, um existieren zu können und ist daher schwach.";
                i++;

                //Frage 27
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "keine";
                inhalt_anwortB[i] = "Zeitschrift";
                inhalt_anwortC[i] = "Artikel";
                inhalt_anwortD[i] = "Zeitschrift und Artikel";
                correct[i] = "C";
                secondchance[i] = "Was geschieht, wenn du die Zeitschrift in den Müll wirfst?";
                inhalt_loesung[i] = "Das ist nicht korrekt! Artikel werden in Zeitschriften abgedruckt. Ohne diese können wir Artikel nicht lesen, daher ist Artikel eine schwache Entitätsmenge.";
                i++;

                //Frage 28
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitätsmenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "Computer";
                inhalt_anwortB[i] = "Monitor";
                inhalt_anwortC[i] = "Computer und Monitor";
                inhalt_anwortD[i] = "keine";
                correct[i] = "D";
                secondchance[i] = "Was geschieht mit dem Monitor, wenn du den Computer herunterfährst oder dir einen neuen zulegst?";
                inhalt_loesung[i] = "Leider nein. Zwar wird auf dem Monitor ohne Computer nichts angezeigt, jedoch ist ein Monitor ein eigener Gegenstand. Keine Entitätsmenge muss als schwach gekennzeichnet werden.";
                i++;

                //Frage 29
                inhalt_aufgabenstellung[i] = "Bestimme die Vaterentitätsmenge und die schwache Entitätsmenge (in dieser Reihenfolge) aus diesem Text.";
                inhalt_text[i] = "Für eine Zahnarztpraxis soll ein ER-Diagramm erstellt werden. Ein Patient der Praxis hat einen Namen und eine eindeutige Patientennummer. Ein Patient besitzt Zähne. Ohne Patient würden diese nicht existieren. Jeder Zahn wird einem Quadranten zugeordnet und hat eine eindeutige Nummer. Auch hat jeder Zahn einen Zustand. Jeder Zahnarzt hat einen Namen und eine eindeutige Zulassungsnummer. Ein Zahnarzt behandelt Zähne. Manchmal müssen jedoch auch mehrere Zahnärzte einen Zahn behandeln.";
                inhalt_anwortA[i] = "keine";
                inhalt_anwortB[i] = "Patient und Zahn";
                inhalt_anwortC[i] = "Zahn und Patient";
                inhalt_anwortD[i] = "Zahnarzt und Zahn";
                correct[i] = "B";
                secondchance[i] = "Was kann nicht ohne den anderen existieren?";
                inhalt_loesung[i] = "Fast! Ohne Patienten können Zähne nicht existieren. Die Entitätsmenge Zahn ist daher schwach.";

            }
        }
        else if (Sprache.sprache == "en")
        {
            int i = 0;
            //Frage 1
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “gehtIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "In wie viele Klassen gehst du persönlich an deiner Schule?";
            inhalt_loesung[i] = "Nicht ganz! Richtig wäre n : 1. Zum Beispiel kann Jona nicht gleichzeitig in Klasse 9 und 10 sein. Jedoch können 25 Schüler gemeinsam in Klasse 9 gehen";
            i++;

            //Frage 2
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “unterrichtetVon”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Unterrichtet an deiner Schule nur eine Lehrkraft Informatik? Und hat diese auch andere Fächer, die sie unterrichtet?";
            inhalt_loesung[i] = "Das ist falsch. An einer Schule gibt es mehrere Informatiklehrer. Gleichzeitig kann jeder Lehrer mindestens zwei Fächer unterrichten. Richtig wäre n : m.";
            i++;

            //Frage 3
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “istIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "Kleine Kinos haben ggf. nur ein Saal, aber größere? Und kann denn derselbe (nicht der gleiche) Raum an verschiedenen Orten gleichzeitig existieren?";
            inhalt_loesung[i] = "Das ist falsch. In einen Kino gibt es mehrere Kinosäle. Gleichzeitig kann ein Kinosaal nur in einen Gebäude/ Kino sein. Richtig wäre n : 1.";
            i++;

            //Frage 4
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “verheiratetMit”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "A";
            secondchance[i] = "Wie viele Menschen in eurem Umfeld sind denn mit mehr als einer Person verheiratet?";
            inhalt_loesung[i] = "Ein Mensch kann nicht mit mehr als einem anderen Menschen verheiratet sein. Richtig ist daher 1 : 1.";
            i++;

            //Frage 5
            inhalt_aufgabenstellung[i] = "Welche Kardinalität steht für folgende Beschreibung?";
            inhalt_text[i] = "Jeder Entity der Entitymenge A können mehrere Objekte der Entitymenge B zugeordnet werden. Umgekehrt kann jedoch jeder Entity aus B nur eine Entity aus A zugeordnet werden.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "B";
            secondchance[i] = "Schlüsselwörter wie „nur“ oder „genau eine“ geben den Hinweis auf die Kardinalität 1.";
            inhalt_loesung[i] = "Das war falsch. Die Kardinalität der Relationship zwischen A und B ist 1 : n. Der erste Satz beschreibt die Kardinalität 1 und der zweite n. ";
            i++;

            //Frage 6
            inhalt_aufgabenstellung[i] = "Welche Kardinalität steht für folgende Beschreibung?";
            inhalt_text[i] = "Jeder Entity der Entitymenge A wird genau eine Entity der Entitymenge B zugeordnet. Gleiches gilt für die Zuordnung der Entitys von B auf A.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "A";
            secondchance[i] = "Denke an den Hinweis der vorherigen Aufgabe!";
            inhalt_loesung[i] = "Nein. Die Kardinalität der Relationship zwischen A und B ist 1 : 1.";
            i++;

            //Frage 7
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “parktIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "C";
            secondchance[i] = "Nehmen wir an man darf in einer Straße parken. Frage dich, wie viele Autos könnten in einer Straße Parken? Und in wie vielen Straßen kann dasselbe Auto gleichzeitig parken?";
            inhalt_loesung[i] = "Kann dasselbe Auto in mehreren Straßen gleichzeitig parken? Nein. Jedoch hat eine Straße Platz für mehrere Autos. Richtig wäre daher n : 1.";
            i++;

            //Frage 8
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “gezeigtIn”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Zeigt ein Kino mit mehreren Sälen nur einen Film?";
            inhalt_loesung[i] = "Richtig wäre n : m. Zum Beispiel lief Harry Potter gleichzeitig in mehreren Kinos. Und jedes Kino hat gleichzeitig verschiedene Filme im Programm.";
            i++;

            //Frage 9
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship “ausüben”!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Hast du Freundinnen und Freunde, die das gleiche Hobby ausüben wie du?";
            inhalt_loesung[i] = "Richtig wäre n : m. Man kann auch mehrere Hobbys besitzen (z.B.: Anna spielt Fußball und Gitarre) und diese auch mit anderen zusammen ausüben (z.B.: Anna und Max spielen beide Gitarre).";
            i++;

            //Frage 10
            inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm. Benenne das passende Paar an Kardinalitäten für die Relationship “besitzt” und “nutzt” (in dieser Reihenfolge)!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "n : 1 und n : 1";
            inhalt_anwortB[i] = "n : m und n : m";
            inhalt_anwortC[i] = "1 : n und n : m";
            inhalt_anwortD[i] = "1 : 1 und 1 : n";
            correct[i] = "C";
            secondchance[i] = "Maxime hat bspw. in seiner Garage einen Caprio und einen Kleinbus. Am Wochenende verleiht er diese häufig an seine Freunde.";
            inhalt_loesung[i] = "Nicht ganz! Jedes Auto hat immer genau einen Halter, wobei dieser auch mehrere Autos besitzen kann. Und mehrere Nutzer können das Autofahren und ein Nutzer hat auch die Möglichkeit mehrere Autos zu fahren.";
            i++;

            //Frage 11
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Mensch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Handynummer";
            inhalt_anwortB[i] = "Personalausweisnummer";
            inhalt_anwortC[i] = "Adresse";
            inhalt_anwortD[i] = "Name und Geburtstag";
            correct[i] = "B";
            secondchance[i] = "Eine vierköpfige Familie hat eine Adresse. Gibt es eigentlich auch Menschen ohne Handy?";
            inhalt_loesung[i] = "Nicht ganz! Jeder Mensch besitzt einen eindeutige Personalausweisnummer. Dieser ist der Primärschlüssel. Auch Handynummer sind eindeutig. Jedoch besitzt nicht jeder Mensch ein eigenes Handy.";
            i++;

            //Frage 12
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Film.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Hauptperson und Name";
            inhalt_anwortB[i] = "Name";
            inhalt_anwortC[i] = "Erscheinungsdatum und Hauptperson";
            inhalt_anwortD[i] = "Name und Erscheinungsdatum";
            correct[i] = "D";
            secondchance[i] = "Es gibt Filme, die haben den gleichen Namen. Es gibt Hauptdarsteller, die drehen an zwei Filmen gleichzeitig mit.";
            inhalt_loesung[i] = "Leider nein. Die Schlüsselattribute sind Name und Erscheinungsdatum. Die anderen Varianten sind nicht eindeutig.";
            i++;

            //Frage 13
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Buch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Name und Erscheinungsdatum";
            inhalt_anwortB[i] = "Erscheinungsdatum und Autor";
            inhalt_anwortC[i] = "Autor und Name und Erscheinungsdatum";
            inhalt_anwortD[i] = "Name";
            correct[i] = "C";
            secondchance[i] = "Es ist zwar selten, jedoch kommt es vor, dass zwei Bücher mit gleichen Namen zu selben Zeit veröffentlicht werden. ";
            inhalt_loesung[i] = "Ein Autor kann gleichzeitig auch mehrere Bücher veröffentlichen oder verschiedene Autoren den gleichen Namen nutzen. Richtig sind alle drei Attribute zusammen.";
            i++;

            //Frage 14
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Buch.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Name und Erscheinungsdatum";
            inhalt_anwortB[i] = "Name und ISBN";
            inhalt_anwortC[i] = "Autor und Name und Erscheinungsdatum";
            inhalt_anwortD[i] = "ISBN";
            correct[i] = "D";
            secondchance[i] = "Laut Wikipedia ist die die Internationale Standartbuchnummer (ISBN) “eine Nummer zur eindeutigen Kennzeichnung von Büchern [...]“.";
            inhalt_loesung[i] = "Die ISBN ist der Primärschlüssel. Zwar können auch Autor, Name und Erscheinungsdatum ein Buch eindeutig zuordnen, jedoch suchen wir immer eine <b> minimale Menge<b> von Attributen.";
            i++;

            //Frage 15
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Schüler.";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Geschlecht und E-Mail";
            inhalt_anwortB[i] = "E-Mail";
            inhalt_anwortC[i] = "Name und Klasse";
            inhalt_anwortD[i] = "Name und E-Mail";
            correct[i] = "B";
            secondchance[i] = "Hast du schon einmal davon gehört, dass in einer Klasse zwei Schüler oder Schülerinnen den gleichen Namen haben?";
            inhalt_loesung[i] = "Leider nein. An einer Schule können auch zum Beispiel zwei Annas in der 10. Klasse gehen. Die E-Mail ist jedoch eindeutig.";
            i++;

            //Frage 16
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitymenge „Artikel“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Artikelnummer, Preis";
            inhalt_anwortB[i] = "Beschreibung, Farbe, Größe";
            inhalt_anwortC[i] = "Artikelnummer, Rechnungsnummer";
            inhalt_anwortD[i] = "Artikelnummer, Beschreibung, Farbe, Größe, Preis";
            correct[i] = "D";
            secondchance[i] = "Welcher Bereich auf der Rechnung beschreibt die gekauften Artikel? Dort stehen die Attribute!";
            inhalt_loesung[i] = "Der Tabellenkopf liefert die Attribute, Artikelnummer, Beschreibung, Farbe, Größe und Preis.";
            i++;

            //Frage 17
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitymenge „Kunde“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Adresse, Name, Kundennummer";
            inhalt_anwortB[i] = "Name, Adresse";
            inhalt_anwortC[i] = "Rechnungsdatum, Kundennummer";
            inhalt_anwortD[i] = "Adresse, Kundennummer";
            correct[i] = "A";
            secondchance[i] = "Es gibt auch eine Entitymenge „Rechnung“. Achte auf ALLE Attribute der Entitymenge „Kunde“.";
            inhalt_loesung[i] = "Die Attribute können wir aus dem Briefkopf ablesen. Adresse, Name und Kundennummer sind die Attribute von Kunde.";
            i++;

            //Frage 18
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. In einem ER-Diagramm zu diesem Sporthandel existiert eine Relationship “enthält” zwischen Rechnung und Artikel. Benenne die Kardinalität dieser Relationship!";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Hast du schon einmal Artikel in einem Sportgeschäft gekauft und eine Rechnung/Quittung erhalten? Wie viele waren das? Waren die Artikel auch nach deinem Kauf noch im Laden auf Lager?";
            inhalt_loesung[i] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte auch die gleichen Artikel bestellen. Richtig wäre daher n : m.";
            i++;

            //Frage 19
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute besitzt die Entitymenge „Rechnung“?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortB[i] = "Kundennummer, Artikelnummer, Rechnungsnummer";
            inhalt_anwortC[i] = "Kundennummer, Rechnungsnummer, Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortD[i] = "Rechnungsnummer, Name, Adresse, Rechnungsbetrag, Rechnungsdatum";
            correct[i] = "C";
            secondchance[i] = "Tipp: Ein Kunde kauft an einem gewissen Tag in dem Geschäft ein und bezahlt einen bestimmten Preis. Und wir benötigen noch einen Primärschlüssel!";
            inhalt_loesung[i] = "Es sind alles Werte, die diese Rechnung auszeichnen. Das wären die Kundennummer, die Rechnungsnummer, der Rechnungsbetrag und das Rechnungsdatum. ";
            i++;

            //Frage 20
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Attribute lassen die <b>Rechnung</b> eindeutig ermitteln?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortB[i] = "Kundennummer, Artikelnummer, Rechnungsdatum";
            inhalt_anwortC[i] = "Kundennummer, Rechnungsbetrag, Rechnungsdatum";
            inhalt_anwortD[i] = "Rechnungsnummer";
            correct[i] = "D";
            secondchance[i] = "An einem Tag werden in dem Sporthaus 300 Rechnungen ausgestellt. Welche Attributwerte könnten doppelt vorkommen?";
            inhalt_loesung[i] = "Richtig wäre die Rechnungsnummer. Jede Rechnung hat eine eindeutige Nummer.";
            i++;

            //Frage 21
            inhalt_aufgabenstellung[i] = "Gegeben ist folgende Rechnung eines Sporthandels. Welche Aussage ist falsch?";
            inhalt_text[i] = "";
            inhalt_anwortA[i] = "Rechnungsnummer ist Primärschlüssel der Entitymenge Rechnung.";
            inhalt_anwortB[i] = "Ein Kunde kann zwei Rechnungen mit gleichen Rechnungsbetrag erhalten.";
            inhalt_anwortC[i] = "Jede Rechnung wird genau einem Kunden zugeordnet.";
            inhalt_anwortD[i] = "Beschreibung und Größe sind Schlüsselattribute der Entitymenge Artikel.";
            correct[i] = "D";
            secondchance[i] = "Das ist die letzte Aufgabe! Alle Antwortmöglichkeiten wurden in vorherigen Aufgaben thematisiert! Versuche es nochmal!";
            inhalt_loesung[i] = "Diese Aussage ist richtig. Die Aussage D ist falsch. Beschreibung und Größe können zwar bei jeden Artikel eindeutig sein, jedoch ist die Kombination nicht minimal. Der Primärschlüssel ist die Artikelnummer.";
            i++;

            //Frage 22
            inhalt_aufgabenstellung[i] = "Wie viele Entitymengen enthält das ER-Modell mindestens?";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "keine";
            inhalt_anwortB[i] = "eine";
            inhalt_anwortC[i] = "zwei";
            inhalt_anwortD[i] = "drei";
            correct[i] = "C";
            secondchance[i] = "Um welche Subjektive geht es in den Text hauptsächlich.";
            inhalt_loesung[i] = "Das Diagramm enthält zwei Entitymengen Kunde und Artikel. Lager ist keine Entitymenge.";
            i++;

            //Frage 23
            inhalt_aufgabenstellung[i] = "Benenne die Attribute besitzt die Entitymenge „Kunde“?";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "Name und Kundenummer";
            inhalt_anwortB[i] = "Kundennummer";
            inhalt_anwortC[i] = "Kundenummer, Name, Adresse";
            inhalt_anwortD[i] = "keine";
            correct[i] = "A";
            secondchance[i] = "Steht in dem Text irgendwas von einer Adresse?";
            inhalt_loesung[i] = "Falsch. Im Text wird die Adresse des Kunden nicht erwähnt. Die Attribute sind Name und Kundennummer.";
            i++;

            //Frage 24
            inhalt_aufgabenstellung[i] = "Bestimme den Primärschlüssel, bzw. die Schlüsselattribute für die Entitymenge Artikel.";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "Name";
            inhalt_anwortB[i] = "ID";
            inhalt_anwortC[i] = "Name und Preis";
            inhalt_anwortD[i] = "ID, Name, Preis";
            correct[i] = "B";
            secondchance[i] = "Es kann 2 Kugelschreiber geben, die gleich heißen und den gleichen Namen haben.";
            inhalt_loesung[i] = "Falsch die ID ist die minimale Menge an Schlüsselattributen.";
            i++;

            //Frage 25
            inhalt_aufgabenstellung[i] = "Benenne die Kardinalität der Relationship zwischen „Kunde“ und „Artikel“!";
            inhalt_text[i] = "Jeder Kunde kann in einem Onlineshop mehrere Artikel kaufen. Der Kunde besitzt eine Kundennummer und sein Name ist hinterlegt. Jeder Artikel besitzt eine eindeutige ID, sodass er im Lager gefunden werden kann und natürlich auch einen Namen, damit der Kunde weiß, was er kauft, sowie einen Preis.";
            inhalt_anwortA[i] = "1 : 1";
            inhalt_anwortB[i] = "1 : n";
            inhalt_anwortC[i] = "n : 1";
            inhalt_anwortD[i] = "n : m";
            correct[i] = "D";
            secondchance[i] = "Wie viele Artikel kann man kaufen und kann nicht ein Artikel von mehreren gekauft werden?";
            inhalt_loesung[i] = "Stell dir vor du kaufst in dem Shop ein. Du kannst gleichzeitig mehrere Artikel kaufen und dafür eine Rechnung erhalten. Ein anderer Käufer könnte auch die gleichen Artikel bestellen. Richtig wäre daher n : m.";
            i++;

            if (!OhneSchwacheEntity.schwachAus)
            {
                //Frage 26
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitymenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "Schulgebäude";
                inhalt_anwortB[i] = "Klassenzimmer";
                inhalt_anwortC[i] = "keine";
                inhalt_anwortD[i] = "Schulgebäude und Klassenzimmer";
                correct[i] = "B";
                secondchance[i] = "Was geschieht mit dem Klassenzimmer, wenn das Schulgebäude abgerissen wird?";
                inhalt_loesung[i] = "Falsch. Ein Klassenzimmer kann leider nicht in der Luft schweben. Es benötigt ein Schulgebäude, um existieren zu können und ist daher schwach.";
                i++;

                //Frage 27
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitymenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "keine";
                inhalt_anwortB[i] = "Zeitschrift";
                inhalt_anwortC[i] = "Artikel";
                inhalt_anwortD[i] = "Zeitschrift und Artikel";
                correct[i] = "C";
                secondchance[i] = "Was geschieht, wenn du die Zeitschrift in den Müll wirfst?";
                inhalt_loesung[i] = "Das ist nicht korrekt! Artikel werden in Zeitschriften abgedruckt. Ohne diese können wir Artikel nicht lesen, daher ist Artikel eine schwache Entitymenge.";
                i++;

                //Frage 28
                inhalt_aufgabenstellung[i] = "Gegeben ist folgendes ER-Diagramm! Welche Entitymenge muss als schwach gekennzeichnet werden?";
                inhalt_text[i] = "";
                inhalt_anwortA[i] = "Computer";
                inhalt_anwortB[i] = "Monitor";
                inhalt_anwortC[i] = "Computer und Monitor";
                inhalt_anwortD[i] = "keine";
                correct[i] = "D";
                secondchance[i] = "Was geschieht mit dem Monitor, wenn du den Computer herunterfährst oder dir einen neuen zulegst?";
                inhalt_loesung[i] = "Leider nein. Zwar wird auf dem Monitor ohne Computer nichts angezeigt, jedoch ist ein Monitor ein eigener Gegenstand. Keine Entitymenge muss als schwach gekennzeichnet werden.";
                i++;

                //Frage 29
                inhalt_aufgabenstellung[i] = "Bestimme die Vaterentitätsmenge und die schwache Entitymenge (in dieser Reihenfolge) aus diesem Text.";
                inhalt_text[i] = "Für eine Zahnarztpraxis soll ein ER-Diagramm erstellt werden. Ein Patient der Praxis hat einen Namen und eine eindeutige Patientennummer. Ein Patient besitzt Zähne. Ohne Patient würden diese nicht existieren. Jeder Zahn wird einem Quadranten zugeordnet und hat eine eindeutige Nummer. Auch hat jeder Zahn einen Zustand. Jeder Zahnarzt hat einen Namen und eine eindeutige Zulassungsnummer. Ein Zahnarzt behandelt Zähne. Manchmal müssen jedoch auch mehrere Zahnärzte einen Zahn behandeln.";
                inhalt_anwortA[i] = "keine";
                inhalt_anwortB[i] = "Patient und Zahn";
                inhalt_anwortC[i] = "Zahn und Patient";
                inhalt_anwortD[i] = "Zahnarzt und Zahn";
                correct[i] = "B";
                secondchance[i] = "Was kann nicht ohne den anderen existieren?";
                inhalt_loesung[i] = "Fast! Ohne Patienten können Zähne nicht existieren. Die Entitymenge Zahn ist daher schwach.";

            }
        }

    }

    public void Awake()
    {
        init();
    }
    public void Update()
    {
        if(welcheAufgabe <anzahlAufgabe){
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
            ueberdeckung.SetActive(true);
            hinweisFenster.GetComponent<TMPro.TextMeshProUGUI>().SetText(inhalt_loesung[welcheAufgabe-1]);
            hinweisFenster.SetActive(true);
            lösungsButton.SetActive(false);
            toggleKiller.SetActive(false) ;
        //Ausgabe des Hinweises
        }else{
            secondChanceScreen.SetActive(true);
            ausgabe = secondchance[welcheAufgabe];
            Utilitys.TextInTMP(RichitgFalschAnzeigeSecondChance, ausgabe);
            exitKnopfSecondChance.SetActive(true);
            toggleKiller.SetActive(true);
        }
    }
    /*
    *Exit Button des Lösungsfensters
    */
    public void exitHinweis()
    {
        hinweisFenster.SetActive(false);
        ueberdeckung.SetActive(false);
        lösungsButton.SetActive(false);
        fenster.SetActive(false);
        
    }
   /*
    *Exit Button des Hinweisfensters
    */
    public void exitsecondChanceScreen()
    {
        secondChanceScreen.SetActive(false);
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
        if (welcheAufgabe < anzahlAufgabe)
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
