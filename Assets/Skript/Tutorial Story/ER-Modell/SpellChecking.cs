using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellChecking : MonoBehaviour
{
    public static List<string> WORDS = new List<string>() { "Kosten", "Baukosten", "Preis", "Baupreis", "Containernummer", "Cnr", "Cnr.", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "Cnr", "Bettenzahl", "Bettenanzahl", "Betten", "Kapazität", "freie Betten", "freieBetten", "Freie Betten", "FreieBetten", "BettenFrei", "Bettenfrei", "Anreisegebühr", "Anreisegebühren", "Anreisekosten", "Kosten", "Gebühren", "Aufgabe", "Aufgaben", "Name", "Namen", "Geburtsdatum", "Geburtstag", "Arbeiterzahl", "Feldarbeiter", "Arbeiteranzahl", "Ertrag", "Feldnummer", "FNR", "Fnr", "Fnr.", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Weidenarbeiter", "Weidearbeiter", "Anzahl Arbeiter", "Weidennummer", "Weidenummer", "Wnr", "Wnr.", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.", "Weidenr.", "Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere", "Transportkosten", "Transportpreis", "Art", "Tierart", "Stallnummer", "SNR", "Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Gehegezahl", "Gehegeanzahl", "Gehege", "freie Gehege", "freieGehege", "Gehege frei", "Stationsnummer", "Stationsnr.", "Spezialisierung", "Astronautenzahl", "Astronautenanzahl", "Forschungsarbeiter", "Forschungsastronauten", "Verbesserungsfaktor", "Faktor", "Verbesserung", "Stufe", "Forschungsstufe", "Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal", "arbeitet", "verantwortet", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für", "istverantwortlich", "istVerantwortlich", "ist verantwortlich", "wohnt in", "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "wohnen", "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht", "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "leben", "lebt", "helfen", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf", "forschen", "verbessert", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "MethodenVerbessern", "verbessertMethodenVon", "verbessertMethoden", "organisiert" };

    

    public static string rechtschreibPruefer(string word)
    {
        if (WORDS.Contains(word))
        {
            return "";
        }
        string letters = "abcdefghijklmnoprstuw";
        List<string[]> splits = new List<string[]>();
        for (int i = 0; i < word.Length + 1; i++)
        {
            splits.Add(new string[2] { word.Substring(0, i), word.Substring(i) });
        }
        
        //lässt einen Buchstaben weg
        for (int i = 0; i < splits.Count; i++)
        {
            if (splits[i][1].Length > 0 && WORDS.Contains(splits[i][0] + splits[i][1].Substring(1)))
            {
                    return splits[i][0] + splits[i][1].Substring(1);
                
            }
        }
        //tauscht 2 Buchstaben
        for (int i = 0; i < splits.Count; i++)
        {
           
            if (splits[i][1].Length > 1&&WORDS.Contains(splits[i][0] + splits[i][1][1] + splits[i][1][0] + splits[i][1].Substring(2)))
                {
                    return splits[i][0] + splits[i][1][1] + splits[i][1][0] + splits[i][1].Substring(2);
                
            }
        }
        
        //fügt Buchstaben an jeder Stelle hinzu
       for (int i = 0; i < splits.Count; i++)
        {
            foreach (char c in letters)
            {
                if (WORDS.Contains(splits[i][0] + c + splits[i][1]))
                {
                    return splits[i][0] + c + splits[i][1];

                }
               
            }
        }
        return "";
    }
}
