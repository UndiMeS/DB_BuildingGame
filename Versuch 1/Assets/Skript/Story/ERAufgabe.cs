using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERAufgabe : MonoBehaviour
{
    private string[] aufgabe = { "Um den Mars zu besiedeln, m�ssen Astronauten eingeflogen werden. Damit diese auf dem Planeten leben k�nnen, werden <mark=#eb4034aa> Wohncontainer </mark>ben�tigt. Daf�r wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte <mark=#71eb2f80> Baukosten </mark>eine genaue<mark=#71eb2f80> Bettenzahl</mark>, die die Menge an beherbergbaren Astronauten ausdr�ckt und ein Attribut f�r noch <mark=#71eb2f80>freie Betten</mark>. Jeder Container hat in der Siedlung eine eindeutige<mark=#71eb2f80> Containernummer</mark>, der Prim�rschl�ssel." ,
                                "Astronauten wohnen in (wohntIn) Wohncontainer. Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (n:1). Wichtig ist, dass nur Astronauten eingeflogen werden können, wenn ausreichend Wohncontainer existieren (schwache Entitymenge). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmt Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung.",
                                "Eine Möglichkeit Erträge zu erzielen sind Feldsphären in denen Nahrung angebaut wird. Diese haben bestimmte Baukosten, eine genaue Arbeiterzahl und einen Ertrag, den du alle 5 Sol erhältst. Mehrere Astronauten arbeiten in einer Feldsphäre, wobei ein Astronaut nicht auf mehreren Feldsphären gleichzeitig arbeiten kann"};
    private string[][] listeEntity = { new string[] { "Wohncontainer" }, new string[] {"Astronaut" }, new string[] { "Feldsphäre" } };

    //Attribute
    private string[][] wohncontainer = {
                                        new string[] { "1", "Kosten", "Baukosten", "Preis", "Baupreis", "€" },
                                        new string[] { "2", "Containernummer", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id","Cnr" },
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
    private string[] astronaut_forschungsstation = { "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für" };
    private string[] astronaut_wohncontainer = {  "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt" };
    private string[] astronaut_forschungsprojekt = { "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht" };
    private string[] astronaut_fedlsphaere = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften" };
    private string[] astronaut_weidesphaere = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften" };
    private string[] stallcontainer_nutztier = { "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt", "schläftIn", "PlatzFür" };
    private string[] weidesphaere_nutztier = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf" };
    private string[] forschungsprojekt_wohncontainer = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_feldsphaere = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_weidesphaere = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_forschungsprojekt = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_forschungsstation = { "organsisiert", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für" };

    private string[] astronaut_wohncontainer_Eig = { "Wohncontainer", "Astronaut", "1", "n", "1" };
    private string[] astronaut_fedlsphaere_Eig = { "Feldsphäre", "Astronaut", "0", "n", "1" };


    private string[][][][] listeAttribute = new string[3][][][]; //[Level][Entity][Attribnut][Namen]
    private int[][][] primarschluessel = { new int[][] { new int[] { 0, 1, 0, 0 } }, new int[][] { new int[] { 0, 0, 1, 1 } } , new int[][] { new int[] { 0, 0, 0, 1 } } };// Reihenfolge von Attributen 0 kein Ps, 1 PS
    public string[][][] listeBeziehungen = new string[3][][]; //[Level][Beziehung][Namen]
    public string[][][] listeBeziehungsEigenschaften = new string[3][][];

    private int[] entitysRichtig = { 1, 1,1 };
    private int[] attributeRichtig = { 4, 4 ,4};
    private int[] primaerschluesselRichtig = { 1, 2,1 };
    private int[] beziehungenRichtig = { 0, 1 ,1};
    private int[] kardRichtig = { 0, 2,2 };

    private int[] entitysHat;
    private int[] attributeHat;
    private int[] primaerschluesselHat;
    private int[] beziehungenHat;
    private int[] kardHat;

    public GameObject dasIstSchonFertig;
    public GameObject aufgabenText;
    public PauseMenu pauseMenu;

    public List<GameObject> checkliste;

    public static List<GameObject> gespeicherteObjekte;

    // Start is called before the first frame update
    void Start()
    {
        listeAttribute[0] = new string[][][] { wohncontainer };
        listeAttribute[1] = new string[][][] { astronaut };
        listeAttribute[2] = new string[][][] { feldspaehre };

        listeBeziehungen[0] = new string[0][];
        listeBeziehungen[1] = new string[][] { astronaut_wohncontainer };
        listeBeziehungen[2] = new string[][] { astronaut_fedlsphaere};


        listeBeziehungsEigenschaften[0] = new string[0][];
        listeBeziehungsEigenschaften[1] = new string[][] { astronaut_wohncontainer_Eig };
        listeBeziehungsEigenschaften[2] = new string[][] { astronaut_fedlsphaere_Eig };

        gespeicherteObjekte = new List<GameObject>();
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
        primaerschluesselHat = new int[primaerschluesselRichtig.Length];
        beziehungenHat = new int[beziehungenRichtig.Length];
        kardHat = new int[kardRichtig.Length];

        string fertig = "";
        int indexEntity = 0;
        foreach (string entityName in listeEntity[Story.level])
        {

            foreach (GameObject entity in ERErstellung.modellObjekte)
            {
                if (entity.name.Equals(entityName))
                {
                    entitysHat[Story.level]++;
                    fertig += entityName + ": ";
                    fertig = checkAttribute(indexEntity, entity, fertig);

                }
            }
            checkBeziehung();
            indexEntity++;
        }

        if (checkAllesRichtig())
        {
            FehlerAnzeige.fehlertext = "Du hast alles richtig gemacht!";
            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                if (!gespeicherteObjekte.Contains(obj))
                {
                    gespeicherteObjekte.Add(obj);
                }
            }
            Story.level++;
        }

        //Utilitys.TextInTMP(dasIstSchonFertig, fertig);
    }

    private void checkBeziehung()
    {
        for (int i =0; i < listeBeziehungen[Story.level].Length; i++)
        {
            bool allesDa = true;
            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                
                if (obj.CompareTag("Beziehung"))
                {
                    string nameAnderesEnitity = "";
                    int einsoderZwei = 0;
                    
                    //Entitäten und Kardinalität prüfen
                    if (obj.GetComponent<Beziehung>().objekt1!= null&&listeBeziehungsEigenschaften[Story.level][i][0].Equals(obj.GetComponent<Beziehung>().objekt1.name))
                    {
                        if (obj.GetComponent<Beziehung>().objekt2 != null ) {
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt2.name; }
                        if (checkKard(obj,1,i))
                        {
                            einsoderZwei = 2;
                            kardHat[Story.level]++;
                        }
                    }
                    else if (obj.GetComponent<Beziehung>().objekt2 != null && listeBeziehungsEigenschaften[Story.level][i][0].Equals(obj.GetComponent<Beziehung>().objekt2.name))
                    {
                        if (obj.GetComponent<Beziehung>().objekt1 != null)
                        {
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt1.name;
                        }
                        if (checkKard(obj, 2, i))
                        {
                            einsoderZwei = 1;
                            kardHat[Story.level]++;
                        }
                    }
                    if (listeBeziehungsEigenschaften[Story.level][i][1].Equals(nameAnderesEnitity)){
                        allesDa &= true;
                        if (checkKard(obj, einsoderZwei, i))
                        {
                            kardHat[Story.level]++;
                        }
                        Debug.Log("Hurra");
                    }
                    else
                    {
                        allesDa &= false;
                    }
                    //name prüfen
                    bool temp = true;
                    foreach (string name in listeBeziehungen[Story.level][i])
                    {
                        if (obj.name.Equals(name))
                        {
                            allesDa &= true;
                            temp = false;
                            break;
                        }
                    }
                    if (temp)
                    {
                        allesDa &= false;
                    }

                    //schwache Entity
                    if (obj.GetComponent<Beziehung>().schwach && listeBeziehungsEigenschaften[Story.level][i][2].Equals("1"))
                    {
                        allesDa &= true;
                    }
                    else if (!obj.GetComponent<Beziehung>().schwach && listeBeziehungsEigenschaften[Story.level][i][2].Equals("0"))
                    {
                        allesDa &= true;
                    }
                    else
                    {
                        allesDa &= false;
                    }
                    if (allesDa)
                    {
                        beziehungenHat[Story.level]++;
                    }
                }
            }
        }
        
    }

    private bool checkKard(GameObject obj, int einsOderZwei, int i)
    {
        if (einsOderZwei == 1)
        {
            return obj.GetComponent<Beziehung>().kard1.Equals(listeBeziehungsEigenschaften[Story.level][i][3])
                || ((obj.GetComponent<Beziehung>().kard1.Equals("n") || obj.GetComponent<Beziehung>().kard1.Equals("m"))
                && (listeBeziehungsEigenschaften[Story.level][i][3].Equals("n") || listeBeziehungsEigenschaften[Story.level][i][3].Equals("m")));
        }
        else
        {
            return obj.GetComponent<Beziehung>().kard2.Equals(listeBeziehungsEigenschaften[Story.level][i][4])
               || ((obj.GetComponent<Beziehung>().kard2.Equals("n") || obj.GetComponent<Beziehung>().kard2.Equals("m"))
               && (listeBeziehungsEigenschaften[Story.level][i][4].Equals("n") || listeBeziehungsEigenschaften[Story.level][i][4].Equals("m")));
        }
    }

    private bool checkAllesRichtig()
    {
        foreach (GameObject check in checkliste)
        {
            check.SetActive(false);
        }
        bool ausgabe = true;
        int i = Story.level;
            ausgabe &= entitysHat[i] == entitysRichtig[i];
            if (entitysHat[i] == entitysRichtig[i])
            {
                checkliste[0].SetActive(true);
            }
            else
            {
                checkliste[0].SetActive(false);
            }
            ausgabe &= attributeHat[i] == attributeRichtig[i];
            if (attributeHat[i] == attributeRichtig[i])
            {
                checkliste[1].SetActive(true);
            }
            else
            {
                checkliste[1].SetActive(false);
            }
            ausgabe &= primaerschluesselHat[i] == primaerschluesselRichtig[i];
            if (primaerschluesselHat[i] == primaerschluesselRichtig[i])
            {
                checkliste[2].SetActive(true);
            }
            else
            {
                checkliste[2].SetActive(false);
            }
            ausgabe &= beziehungenRichtig[i] == beziehungenHat[i];
            if (beziehungenRichtig[i] == beziehungenHat[i])
            {
                checkliste[3].SetActive(true);
            }
            else
            {
                checkliste[3].SetActive(false);
            }
            ausgabe &= kardHat[i] == kardRichtig[i];
            if (kardRichtig[i] == kardHat[i])
            {
                checkliste[4].SetActive(true);
            }
            else
            {
                checkliste[4].SetActive(false);
            }
        

        return ausgabe;
    }

    private string checkAttribute(int indexEntity, GameObject entity, string fertig)
    {
        int indexattribute = 0;
        foreach (string[] attributNamesMoeglichkeiten in listeAttribute[Story.level][indexEntity])
        {
            foreach (GameObject attribut in entity.GetComponent<Entitaet>().attribute)
            {
                foreach (string attributName in attributNamesMoeglichkeiten)
                {
                    if (attribut.name.Equals(attributName))
                    {
                        attributeHat[Story.level]++;
                        fertig += attribut.name + " ";
                        if (primarschluessel[Story.level][indexEntity][indexattribute] == 1 && entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            primaerschluesselHat[Story.level]++;
                            fertig += "-PS ";
                        }
                    }
                }
            }
            indexattribute++;
        }

        return fertig;
    }



}
