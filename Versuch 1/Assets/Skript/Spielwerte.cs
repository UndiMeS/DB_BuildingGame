using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielwerte : MonoBehaviour
{

    public static void Werte()
    {
        Testing.geld = 4000;

        Wohncontainer.betten = 5;
        Wohncontainer.preis = 50;

        Feld.neuErtrag = 50;
        Feld.preis = 70;
        Feld.arbeiterzahl = 4; //am besten bei 4 belassen und anderes ändern

        Weide.preis = 100;
        Weide.arbeiterzahl = 3;
        Weide.neuErtrag = 50;  
        Weide.tierAnzahl = 4;

        Stallcontainer.preis = 90;
        Stallcontainer.gehege = 5;

        Forschung.preis = 100;

//Preise für menschen und Tiere...??

        Projekt.preis = 100;
        Projekt.forscher = 3;

        Aufgaben.gewinn = 150; //Gewinn bei 1. Chance
        Aufgaben.gewinn2C = 40; //Gewinn bei 2. Chance

        SpielInfos.neuerUmsatz = 4; //alle X Tage neuer Umsatz !!!!!!!!!!!!! Achtung: Text in Leiste Top muss händisch geändert werden!!!! 
        SpielInfos.neueZusatzaufgabe = 1; //alle X Tage neue Zusatzaufgabe

    }
    
}
