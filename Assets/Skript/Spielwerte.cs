using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielwerte : MonoBehaviour
{

    public static void Werte()
    {
        Testing.geld = 600;//400;

        Wohncontainer.betten = 5;
        Wohncontainer.preis = 80;

        Feld.neuErtrag = 50;
        Feld.preis = 80;
        Feld.arbeiterzahl = 4; //am besten bei 4 belassen und anderes ändern

        Weide.preis = 100;
        Weide.arbeiterzahl = 3;
        Weide.neuErtrag = 50;  
        Weide.tierAnzahl = 4;

        Stallcontainer.preis = 90;
        Stallcontainer.gehege = 5;

        Forschung.preis = 200;

//Preise für menschen und Tiere...??

        Projekt.preis = 100;
        Projekt.preis_spielstart = Projekt.preis;
        Projekt.forscher = 3;
        Projekt.preis_nach_verbesserung = 50; //Projektkosten nach Verbesserung der Kosten
        Projekt.kosten_verbesserung = 200; //was kostet es, die Projektkosten zu verbessern

        Aufgaben.gewinn = 150; //Gewinn bei 1. Chance
        Aufgaben.gewinn2C = 30; //Gewinn bei 2. Chance

        SpielInfos.neuerUmsatz = 3; //alle X Tage neuer Umsatz !!!!!!!!!!!!! Achtung: Text in Leiste Top muss händisch geändert werden!!!! 
        SpielInfos.neueZusatzaufgabe = 1; //alle X Tage neue Zusatzaufgabe

    }
    
}
