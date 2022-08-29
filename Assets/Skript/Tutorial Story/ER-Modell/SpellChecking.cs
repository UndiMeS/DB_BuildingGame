using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetSpell.SpellChecker;
using static NetSpell.SpellChecker.Spelling;

public class SpellChecking : MonoBehaviour
{
    public static Spelling SpellChecker;
    public static List<string> ueberpruefteWoerterKorrekt= new List<string>();
    public static List<string> ueberpruefteWoerterFalsch = new List<string>();

    public static List<string> WORDS = new List<string>() { "", "neues Attribut", "neue Entitätsmenge", "neue Beziehung", "Kosten", "Baukosten", "Preis", "Baupreis", "Containernummer", "Cnr", "Cnr.", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "Cnr", "Bettenzahl", "Bettenanzahl", "Betten", "Kapazität", "freie Betten", "freieBetten", "Freie Betten", "FreieBetten", "BettenFrei", "Bettenfrei", "Anreisegebühr", "Anreisegebühren", "Anreisekosten", "Kosten", "Gebühren", "Aufgabe", "Aufgaben", "Name", "Namen", "Geburtsdatum", "Geburtstag", "Arbeiterzahl", "Feldarbeiter", "Arbeiteranzahl", "Ertrag", "Feldnummer", "FNR", "Fnr", "Fnr.", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Weidenarbeiter", "Weidearbeiter", "Anzahl Arbeiter", "Weidennummer", "Weidenummer", "Wnr", "Wnr.", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.", "Weidenr.", "Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere", "Transportkosten", "Transportpreis", "Art", "Tierart", "Stallnummer", "SNR", "Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Gehegezahl", "Gehegeanzahl", "Gehege", "freie Gehege", "freieGehege", "Gehege frei", "Stationsnummer", "Stationsnr.", "Spezialisierung", "Astronautenzahl", "Astronautenanzahl", "Forschungsarbeiter", "Forschungsastronauten", "Verbesserungsfaktor", "Faktor", "Verbesserung", "Stufe", "Forschungsstufe", "Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal", "arbeitet", "verantwortet", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für", "istverantwortlich", "istVerantwortlich", "ist verantwortlich", "wohnt in", "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "wohnen", "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht", "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "leben", "lebt", "helfen", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf", "forschen", "verbessert", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "MethodenVerbessern", "verbessertMethodenVon", "verbessertMethoden", "organisiert","Wohncontainer","Astronaut","Astronauten","Feldsphäre", "Feldsphären", "Forschungsstation", "Forschungsstationen", "Forschungsprojekt", "Forschungsprojekte", "Forschungsstation", "Stallcontainer","Nutztier","Nutztiere","Weidesphäre", "Weidesphären" };



    public void Awake()
    {
        if (ERAufgabe.zeitZumLoesen == 0)
        {
            SpellChecker = new Spelling();
            rechtschreibPruefer("Test");
        }
    }

    public bool rechtschreibPruefer(string word)
    {
       
        if (ueberpruefteWoerterKorrekt.Contains(word))
        {
            return true;
        }
        else if (ueberpruefteWoerterFalsch.Contains(word))
        {
            return false;
        }
        else
        {
            
            //SpellChecker.Text = word;
            bool temp = true;
            
                if (WORDS.Contains(word))
                {
                    temp&= true;
                }
                else
                {
                    temp &= false;
                }          

            

            if (temp)
            {
                ueberpruefteWoerterKorrekt.Add(word);
            }
            else
            {
                ueberpruefteWoerterFalsch.Add(word);
            }
            return temp;
        }
    }


}
