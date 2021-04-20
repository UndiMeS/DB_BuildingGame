using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERAufgabe : MonoBehaviour
{
    private string[] aufgabe= { "Um den Mars zu besiedeln, m�ssen Astronauten eingeflogen werden. Damit diese auf dem Planeten leben k�nnen, werden <mark=#eb4034aa> Wohncontainer </mark>ben�tigt. Daf�r wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte <mark=#71eb2f80> Baukosten </mark>eine genaue<mark=#71eb2f80> Bettenzahl</mark>, die die Menge an beherbergbaren Astronauten ausdr�ckt und ein Attribut f�r noch <mark=#71eb2f80>freie Betten</mark>. Jeder Container hat in der Siedlung eine eindeutige<mark=#71eb2f80> Containernummer</mark>, der Prim�rschl�ssel." };
    private string[] listeEntity = { "Wohncontainer" };
    
    //Attribute
    private string[][] wohncontainer = {
                                        new string[] { "1", "Kosten", "Baukosten", "Preis", "Baupreis", "€" }, 
                                        new string[] { "2", "Containernummer", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id" }, 
                                        new string[] { "3", "Bettenzahl", "Bettenanzahl", "Betten", "Kapazität" }, 
                                        new string[] { "4", "freie Betten", "freieBetten", "Betten frei" } 
                                        };
    private string[][] astronaut = {    
                                        new string[] { "Anreisegebühr", "Kosten", "Gebühren", "Reisekosten", "Preis" }, 
                                        new string[] { "Aufgabe", "Beruf", "Job", "Art"}, 
                                        new string[] { "Name", "Namen"}, 
                                        new string[] { "Geburtsdatum", "Geburtstag", "Datum"} 
                                    };
    private string[][] feldspaehre = {  
                                        new string[] { "Kosten", "Baukosten", "Preis", "Baupreis", "€" }, 
                                        new string[] { "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Feldarbeiter", "Anzahl"}, 
                                        new string[] { "Ertrag", "Gewinn", "Gehalt"}, 
                                        new string[] { "Feldnummer", "FNR", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Nummer", "ID", "id", "Id" } 
                                    };
    private string[][] weidespaehre = { 
                                        new string[] { "Kosten", "Baukosten", "Preis", "Baupreis", "€" }, 
                                        new string[] { "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Weidenarbeiter", "Weidearbeiter", "Anzahl"}, 
                                        new string[] { "Ertrag", "Gewinn", "Gehalt"}, 
                                        new string[] { "Weidennummer", "Weidenummer", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.","Weidenr.", "Nummer", "ID", "id", "Id" },
                                        new string[] { "Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere"} 
                                    };
    private string[][] nutztier = {     
                                        new string[] { "Name", "Namen" }, 
                                        new string[] { "Anreisegebühr", "Kosten", "Gebühren", "Reisekosten", "Preis", "Transportkosten", "Transportpreis" }, 
                                        new string[] { "Art", "Gattung", "Tierart"}, 
                                    };
    private string[][] stallcontainer = {
                                        new string[] {"Kosten", "Baukosten", "Preis", "Baupreis", "€", "Containerkosten" }, 
                                        new string[] {"Containernummer", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id", "Stallnummer", "SNR","Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Containernr."}, 
                                        new string[] {"Gehegezahl", "Gehegeanzahl", "Gehege", "Kapazität" }, 
                                        new string[] {"freie Gehege", "freieGehege", "Gehege frei" } 
                                        };
    private string[][] forschungsstation ={
                                        new string[] {"Kosten", "Baukosten", "Preis", "Baupreis", "€", "Stationskosten" }, 
                                        new string[] {"Stationsnummer", "SNR", "snr", "SNr", "SNR.", "snr.", "SNr.", "Stationsnr.", "Nummer", "ID", "id", "Id"}, 
                                        new string[] {"Spezialisierung", "Gebiet", "Typ", "Bereich"}, 
                                        };
    private string[][] forschungsprojekt = { 
                                        new string[] { "Kosten", "Baukosten", "Preis", "Baupreis", "€", "Projektkosten", "Forschungskosten" }, 
                                        new string[] { "Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Forschungsarbeiter", "Forschungsastronauten", "Anzahl"}, 
                                        new string[] { "Verbesserungsfaktor", "Gewinn", "Faktor", "Verbesserung"}, 
                                        new string[] { "Stufe", "Forschungsstufe", "Level", "LvL", "Forschungslevel"},
                                        new string[] { "Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal"} 
                                    };
    
    //Relationen
    private string[] astronaut_forschungsstation = {"verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für"};
    private string[] astronaut_wohncontainer = {"wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt"};
    private string[] astronaut_forschungsprojekt = {"forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht"};
    private string[] astronaut_fedlsphaere = {"arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften"};
    private string[] astronaut_weidesphaere = {"arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften"};
    private string[] stallcontainer_nutztier = {"wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt", "schläftIn", "PlatzFür"};
    private string[] weidesphaere_nutztier = {"arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf"};
    private string[] forschungsprojekt_wohncontainer = {"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern"};
    private string[] forschungsprojekt_feldsphaere = {"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern"};
    private string[] forschungsprojekt_weidesphaere = {"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern"};
    private string[] forschungsprojekt_forschungsprojekt = {"verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern"};
    private string[] forschungsprojekt_forschungsstation = {"organsisiert", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für"};

    private string[][][] listeAttribute = new string[1][][];
    private int[][] primarschluessel = {new int[]{0,1,0,0} };

    private int[] entitysRichtig = { 1, 0 };
    private int[] attributeRichtig = { 5, 0 }; //++ pro Prim�rschl�ssel
    private int[] beziehungenRichtig = { 0, 0 };

    private int[] entitysHat;
    private int[] attributeHat;
    private int[] beziehungenHat;

    public GameObject dasIstSchonFertig;
    public GameObject aufgabenText;
    public PauseMenu pauseMenu;
 

    // Start is called before the first frame update
    void Start()
    {
        listeAttribute[0]= wohncontainer;
        Utilitys.TextInTMP(dasIstSchonFertig, "");
    } 

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(aufgabenText, aufgabe[Story.level]);
        checkObjekte();
    }

    private void checkObjekte()
    {
        entitysHat = new int[entitysRichtig.Length];
        attributeHat = new int[attributeRichtig.Length];
        beziehungenHat = new int[beziehungenRichtig.Length];

        string fertig="";
        int indexEntity = 0;
        foreach(string entityName in listeEntity)
        {

            foreach(GameObject entity in ERErstellung.modellObjekte)
            {
                if (entity.name.Equals(entityName))
                {
                    entitysHat[indexEntity]++;
                    fertig += entityName + ": ";
                   fertig = checkAttribute(indexEntity,entity,fertig);
                }
            }

            indexEntity++;
        }

        if (checkAllesRichtig()) {
            FehlerAnzeige.fehlertext = "Du hast alles richtig gemacht!";
            Invoke("schliessen", 5);
        }
            
        //Utilitys.TextInTMP(dasIstSchonFertig, fertig);
    }

    private bool checkAllesRichtig()
    {
        bool ausgabe=true;
        for(int i=0; i <= Story.level; i++)
        {
            ausgabe &= entitysHat[i] == entitysRichtig[i];
            ausgabe &= attributeHat[i] == attributeRichtig[i];
            ausgabe &= beziehungenRichtig[i] == beziehungenHat[i];
        }

        return ausgabe;
    }

    private string checkAttribute(int indexEntity, GameObject entity, string fertig)
    {
        int indexattribute = 0;
        foreach (string[] attributNamesMoeglichkeiten in listeAttribute[indexEntity])
        {
            foreach (GameObject attribut in entity.GetComponent<Entitaet>().attribute)
            {
                foreach (string attributName in attributNamesMoeglichkeiten)
                {
                    if (attribut.name.Equals(attributName))
                    {
                        attributeHat[indexEntity]++;
                        fertig += attribut.name + " ";
                        if(primarschluessel[indexEntity][indexattribute]==1&& entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            attributeHat[indexEntity]++;
                            fertig += "-PS ";
                        }
                    }
                }
            }
            indexattribute++;
        }

        return fertig;
    }

    private void schliessen()
    {
        pauseMenu.SwitchToBaumenue();
    }

}
