using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
  
    List<string> WORDS = new List<string>() { "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Containernummer", "Cnr", "Cnr.", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id", "Cnr", "freie Betten", "freieBetten", "Betten frei", "Freie Betten", "FreieBetten", "BettenFrei", "Bettenfrei", "Anreisegebühr", "Anreisegebühren", "Anreisekosten", "Kosten", "Gebühren", "Reisekosten", "Preis", "Aufgabe", "Beruf", "Job", "Art", "Name", "Namen", "Geburtsdatum", "Geburtstag", "Datum", "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Feldarbeiter", "Anzahl Arbeiter", "Arbeiteranzahl", "Ertrag", "Gewinn", "Gehalt", "Feldnummer", "FNR", "Fnr", "Fnr.", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Nummer", "ID", "id", "Id", "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Weidenarbeiter", "Weidearbeiter", "Anzahl", "Anzahl Arbeiter", "Arbeiteranzahl", "Ertrag", "Gewinn", "Gehalt", "Weidennummer", "Weidenummer", "Wnr", "Wnr.", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.", "Weidenr.", "Nummer", "ID", "id", "Id", "Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere", "Name", "Namen", "Anreisegebühr", "Kosten", "Gebühren", "Reisekosten", "Preis", "Transportkosten", "Transportpreis", "Art", "Gattung", "Tierart", "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Containerkosten", "Containernummer", "Cnr", "Cnr.", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id", "Stallnummer", "SNR", "Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Containernr.", "Gehegezahl", "Gehegeanzahl", "Gehege", "Kapazität", "freie Gehege", "freieGehege", "Gehege frei", "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Stationskosten", "Stationsnummer", "SNR", "Snr", "Snr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Stationsnr.", "Nummer", "ID", "id", "Id", "Spezialisierung", "Gebiet", "Typ", "Bereich", "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Projektkosten", "Forschungskosten", "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Forschungsarbeiter", "Forschungsastronauten", "Anzahl", "Anzahl Arbeiter", "Arbeiteranzahl", "Verbesserungsfaktor", "Gewinn", "Faktor", "Verbesserung", "Stufe", "Forschungsstufe", "Level", "LvL", "Forschungslevel", "Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal", "arbeitet", "verantwortet", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für", "istverantwortlich", "istVerantwortlich", "ist verantwortlich", "wohnt in", "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt", "wohnen", "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht", "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften", "leben", "lebt", "wohnen", "wohntIn", "wohnt in", "wohnt", "wohnenIn", "wohnenIn", "beherbergt", "schläftIn", "PlatzFür", "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf", "leben", "lebenAuf", "leben auf", "optimiert", "forschen", "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "optimiert", "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "MethodenVerbessern", "verbessertMethodenVon", "verbessertMethoden", "forscht", "organisiert", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für", "Wohncontainer", "Astronaut", "Feldsphäre", "Forschungsstation", "Forschungsprojekt", "Nutztier", "Stallcontainer", "Weidesphäre", "Astronauten", "Feldsphären", "Forschungsstationen", "Forschungsprojekte", "Nutztiere", "Stallcontainer", "Weidesphären"};

    public List<string> edits1(string word)
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";
        List<string[]> splits = new List<string[]>();
        for (int i = 0; i < word.Length+1; i++)
        {
            splits.Add(new string[2] { word.Substring(0,i), word.Substring(i) });
        }
        List<string> deletes = new List<string>();
        for (int i = 0; i < splits.Count; i++)
        {

            if (splits[i][1].Length > 0)
            {
                deletes.Add(splits[i][0] + splits[i][1].Substring(1));
            }
        }
        for (int i = 0; i < splits.Count; i++)
        {
            if (splits[i][1].Length > 1)
            {
                deletes.Add(splits[i][0] + splits[i][1][1] + splits[i][1][0] + splits[i][1].Substring(2));
            }
        }
        for (int i = 0; i < splits.Count; i++)
        {
            foreach (char c in letters)
            {
                if (splits[i][1].Length > 0)
                {
                    deletes.Add(splits[i][0] + c + splits[i][1].Substring(1));
                }
                else
                {
                    deletes.Add(splits[i][0] + c );
                }
            }
        }
        for (int i = 0; i < splits.Count; i++)
        {
            foreach (char c in letters)
            {
                deletes.Add(splits[i][0] + c + splits[i][1]);
            }
        }
        List<string> ausgabe = new List<string>();
        foreach(string wort in deletes)
        {
            if (WORDS.Contains(wort)&&!ausgabe.Contains(wort))
            {
                ausgabe.Add(wort);
            }
        }
        return ausgabe;
    }
            // Update is called once per frame
    void Update()
    {
        
    }
}
