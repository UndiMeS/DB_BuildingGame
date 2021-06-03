using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* erstetzte Wörter:
    W = Wohncontainer
    A = Astronaut
    F = Feldspähre
    S = Forschungsstation
    P = Forschungsprojekt
*/
public class ERAufgabe : MonoBehaviour
{
    //Aufgabentext je LvL    
    private string[] aufgabe = { 
                    /*LvL 0*/  "Um den Mars zu besiedeln, müssen Astronauten eingeflogen werden. Damit diese auf dem Planeten leben können, werden Wohncontainer benötigt. Dafür wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte Baukosten eine genaue Bettenzahl, die die Menge an beherbergbaren Astronauten ausdrückt und ein Attribut für noch freie Betten. Jeder Container hat in der Siedlung eine eindeutige Containernummer, der Primärschlüssel." ,
                    /*LvL 1*/  "Astronauten wohnen in (wohntIn) Wohncontainer. Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (n:1). Wichtig ist, dass nur Astronauten eingeflogen werden können, wenn ausreichend Wohncontainer existieren (schwache Entitymenge). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmt Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung.",
                    /*LvL 2*/  "Eine Möglichkeit Erträge zu erzielen sind Feldsphären in denen Nahrung angebaut wird. Diese haben bestimmte Baukosten, eine genaue Arbeiterzahl und einen Ertrag, den du alle 5 Sol erhältst. Mehrere Astronauten arbeiten in einer Feldsphäre, wobei ein Astronaut nicht auf mehreren Feldsphären gleichzeitig arbeiten kann.",
                    /*LvL 3*/  "Die Siedlung dient vor allem der Forschung, um Sphären und Wohncontainer zu verbessern. Dafür werden Forschungsstationen gebaut. Eine Forschungsstation hat eine eindeutige Stationsnummer, Baukosten und eine bestimmte Spezialisierung. Diese gibt an, für welchen Objekttyp in der Forschungsstation geforscht wird. Für eine Forschungsstation ist genau ein Astronaut verantwortlich.",
                    /*LvL 4*/  "Verbesserungen werden durch Forschungsprojekte erreicht. Attribute von Sphären und Wohncontainer können X mal erforscht und so mehrfach verbessert werden. Ein Forschungsprojekt hat somit ein bestimmtes Forschungsmerkmal und eine Forschungsstufe. Darüber kann ein Forschungsprojekt eindeutig ermittelt werden. Jedes Forschungsprojekt erzielt einen Verbesserungsfaktor, benötigt eine bestimmte Arbeiterzahl und Projektkosten. Forschungsprojekte können nur angelegt werden, wenn die passende Forschungsstation bereits existiert. Eine Forschungsstation organisiert mehrere Forschungsprojekte. Mehrere Astronauten können in einem Forschungsprojekt forschen, jedoch kann ein Astronaut nur an einem Projekt forschen.",
                    /*LvL 5*/  "Bislang können in der Siedlung Wohncontainer und Feldsphären erbaut werden. Forschungsprojekte verbessern die Forschungsmerkmale immer für alle zukünftig gebauten Objekte. Ein Forschungsprojekt verbessert daher mehrere Wohncontainer und Feldsphären. Zugleich können mehrere Projekte an einer Feldsphäre, bzw. Wohncontainer forschen. Neben der Verbesserung von Containern und Sphären kann einmalig ein Forschungsprojekt durchgeführt werden, dass an neuen Methoden forscht und so für alle zukünftigen Forschungsprojekte der jeweiligen Station die Projektkosten verbessert. Diese Möglichkeit betrifft jede errichtete Forschungsstation.",
                    /*LvL 6*/  "Eine weitere Möglichkeit Erträge zu erzielen sind Weidesphären. Dafür werden zunächst Nutztiere und Stallcontainer benötigt. Um ein Nutztier einfliegen zu lassen, müssen vorher Stallcontainer existieren. Ein Stallcontainer hat Baukosten, eine Containernummer, eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig über Name und Art identifiziert werden.",
                    /*LvL 7*/  "Um Erträge zu erhalten arbeiten mehrere Nutztiere auf einer Weidesphäre. Diese hat eine eindeutige Weidenummer, einen Ertrag, eine Tieranzahl und eine Arbeiterzahl, die sie benötigt. Somit arbeiten mehrere Astronauten in einer Weidesphäre, jedoch wie bei Feldsphären arbeitet ein Astronaut nur in einer Weidesphäre. Wie bei Feldsphären, werden zukünftig erbaute Weidesphären von einem Forschungsprojekt verbessert und mehrere Projekte können eine Weidesphäre verbessern.",
                                
                    /*LvL Ziel*/   //ZIELAUFGABE FEHLT NOCH
                                };

    //Welche EM je Level
    private string[][] listeEntity = {
                                        new string[] { "W" },               /*LvL 0*/
                                        new string[] { "A" },                   /*LvL 1*/
                                        new string[] { "F" },                  /*LvL 2*/
                                        new string[] { "S" },           /*LvL 3*/
                                        new string[] { "P" },           /*LvL 4*/
                                        new string[] {  },                              /*LvL 5*/
                                        new string[] { "Nutztier", "Stallcontainer" },  /*LvL 6*/
                                        new string[] { "Weidesphäre" },                 /*LvL 7*/   
                                    };

    //Welche Attribute je EM
    private string[][] wohncontainer = {
                                        new string[] { "1", "Kosten", "Baukosten", "Preis", "Baupreis", "€" },
                                        new string[] { "2", "Containernummer", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id","Cnr" },
                                        new string[] { "3", "Bettenzahl", "Bettenanzahl", "Betten", "Kapazität" },
                                        new string[] { "4", "freie Betten", "freieBetten", "Betten frei" }
                                        };
    private string[][] astronaut = {
                                        new string[] { "1","Anreisegebühr", "Kosten", "Gebühren", "Reisekosten", "Preis" },
                                        new string[] { "2","Aufgabe", "Beruf", "Job", "Art"},
                                        new string[] { "3", "Name", "Namen"},
                                        new string[] { "4", "Geburtsdatum", "Geburtstag", "Datum"}
                                    };
    private string[][] feldspaehre = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis", "€" },
                                        new string[] { "2","Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Feldarbeiter", "Anzahl"},
                                        new string[] { "3","Ertrag", "Gewinn", "Gehalt"},
                                        new string[] { "4", "Feldnummer", "FNR", "fnr", "FNr", "FNR.", "Fnr.", "FNr.", "Feldnr.", "Nummer", "ID", "id", "Id" }
                                    };
    private string[][] weidespaehre = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis", "€" },
                                        new string[] { "2","Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Weidenarbeiter", "Weidearbeiter", "Anzahl"},
                                        new string[] { "3","Ertrag", "Gewinn", "Gehalt"},
                                        new string[] { "4","Weidennummer", "Weidenummer", "WNR", "wnr", "WNr", "WNR.", "Wnr.", "WNr.", "Weidenr.","Weidenr.", "Nummer", "ID", "id", "Id" },
                                        new string[] { "5","Tierzahl", "Tiere", "Tieranzahl", "Anzahl Tiere", "AnzahlTiere"}
                                    };
    private string[][] nutztier = {
                                        new string[] { "1","Name", "Namen" },
                                        new string[] { "2","Anreisegebühr", "Kosten", "Gebühren", "Reisekosten", "Preis", "Transportkosten", "Transportpreis" },
                                        new string[] { "3","Art", "Gattung", "Tierart"},
                                    };
    private string[][] stallcontainer = {
                                        new string[] {"1","Kosten", "Baukosten", "Preis", "Baupreis", "€", "Containerkosten" },
                                        new string[] {"2","Containernummer", "CNR", "cnr", "CNr", "CNR.", "cnr.", "CNr.", "Containernr.", "Nummer", "ID", "id", "Id", "Stallnummer", "SNR","Stallnr.", "snr", "SNr", "SNR.", "snr.", "SNr.", "Containernr."},
                                        new string[] {"3","Gehegezahl", "Gehegeanzahl", "Gehege", "Kapazität" },
                                        new string[] {"4","freie Gehege", "freieGehege", "Gehege frei" }
                                        };
    private string[][] forschungsstation ={
                                        new string[] {"1","Kosten", "Baukosten", "Preis", "Baupreis", "€", "Stationskosten" },
                                        new string[] {"2","Stationsnummer", "SNR", "snr", "SNr", "SNR.", "snr.", "SNr.", "Stationsnr.", "Nummer", "ID", "id", "Id"},
                                        new string[] {"3","Spezialisierung", "Gebiet", "Typ", "Bereich"},
                                        };
    private string[][] forschungsprojekt = {
                                        new string[] { "1","Kosten", "Baukosten", "Preis", "Baupreis", "€", "Projektkosten", "Forschungskosten" },
                                        new string[] { "2","Arbeiterzahl", "Astronautenzahl", "Astronautenanzahl", "Mitarbeiter", "Forschungsarbeiter", "Forschungsastronauten", "Anzahl"},
                                        new string[] { "3","Verbesserungsfaktor", "Gewinn", "Faktor", "Verbesserung"},
                                        new string[] { "4","Stufe", "Forschungsstufe", "Level", "LvL", "Forschungslevel"},
                                        new string[] { "5","Merkmal", "Forschungsmerkmal", "Attribut", "Forschungsattribut", "Projektmerkmal"}
                                    };

    //Relationen
    //EM1_EM2 = {Realtionsnamensvarianten}#
    //EM1_EM2_Eig = {EM1, EM2, EM2_schwach(1 ja), Kard1, Kard2}

    private string[] astronaut_forschungsstation = { "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für" };
    private string[] astronaut_forschungsstation_Eig = { "A", "S", "0", "1", "1" };

    private string[] wohncontainer_astronaut = { "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt" };
    private string[] wohncontainer_astronaut_Eig = { "W", "A", "1", "n", "1" };

    private string[] astronaut_forschungsprojekt = { "forschtIn", "forscht in", "forscht", "forschen", "erforschen", "erforscht" };
    private string[] astronaut_forschungsprojekt_Eig = { "A", "P", "0", "1", "n" };

    private string[] astronaut_feldsphaere = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften" };
    private string[] astronaut_feldsphaere_Eig = { "A", "F", "0", "1", "n" };

    private string[] astronaut_weidesphaere = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften" };
    private string[] astronaut_weidesphaere_Eig = { "A", "Weidesphäre", "0", "1", "n" };

    private string[] stallcontainer_nutztier = { "wohntIn", "wohnt", "wohnenIn", "wohnenIn", "beherbergt", "schläftIn", "PlatzFür" };
    private string[] stallcontainer_nutztier_Eig = { "Stallcontainer", "Nutztier", "1", "n", "1" };

    private string[] weidesphaere_nutztier = { "arbeitetAuf", "arbeitet auf", "arbeitet", "arbeiten", "arbeiten auf", "bewirtschaften", "grasenAuf", "grasen auf", "helfenAuf", "helfen auf" };
    private string[] weidesphaere_nutztier_Eig = { "Weidesphäre", "Nutztier", "0", "n", "1" };

    private string[] forschungsprojekt_wohncontainer = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_wohncontainer_Eig = { "P", "W", "0", "n", "n" };

    private string[] forschungsprojekt_feldsphaere = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_feldsphaere_Eig = { "P", "F", "0", "n", "n" };

    private string[] forschungsprojekt_stallcontainer = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_stallcontainer_Eig = { "P", "Stallcontainer", "0", "n", "n" };

    private string[] forschungsprojekt_weidesphaere = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern" };
    private string[] forschungsprojekt_weidesphaere_Eig = { "P", "Weidesphäre", "0", "n", "n" };

    private string[] forschungsprojekt_forschungsprojekt = { "verbessert", "erforscht", "forschtAn", "forscht an", "verbessertVon", "verbessert von", "erfoschtVon", "erforscht von", "verbessern", "MethodenVerbessern", "verbessertMethodenVon", "verbessertMethoden" };
    private string[] forschungsprojekt_forschungsprojekt_Eig = { "P", "P", "0", "1", "n" };

    private string[] forschungsstation_forschungsprojekt = { "organisiert", "verantwortlichFür", "verantwortlichfür", "verantwortlich", "istverantwortlichfür", "istVerantwortlichFür", "Verantwortung für", "verantwortlich für", "verantwortlich", "ist verantwortlich für", "Verantwortung für" };
    private string[] forschungsstation_forschungsprojekt_Eig = { "S", "P", "1", "n", "1" };

    //PS Attribut mit 1 setzten für das jeweilige Level
    // Reihenfolge von Attributen 0 kein Ps, 1 PS
    private int[][][] primarschluessel = {  
                     /*LvL 0*/            new int[][] { new int[] { 0, 1, 0, 0 } },
                     /*LvL 1*/            new int[][] { new int[] { 0, 0, 1, 1 } }, 
                     /*LvL 2*/            new int[][] { new int[] { 0, 0, 0, 1 } },
                     /*LvL 3*/            new int[][] { new int[] { 0, 1, 0, 0 } },                
                     /*LvL 4*/            new int[][] { new int[] { 0, 0, 0, 1, 1 } },
                     /*LvL 5*/            new int[0][],
                     /*LvL 6*/            new int[][] { new int[] { 1, 0, 1 }, new int[]{0, 1, 0, 0} },
                     /*LvL 7*/            new int[][] { new int[] { 0, 0, 0, 1, 0 } },
                                        };

    private string[][][][] listeAttribute = new string[8][][][]; //[Level][Entity][Attribnut][Namen]
    public string[][][] listeBeziehungen = new string[8][][]; //[Level][Beziehung][Namen]
    public string[][][] listeBeziehungsEigenschaften = new string[8][][];

    //Anzahl der Elemente pro Level      lvl{ 0, 1, 2, 3, 4, 5, 6, 7 }
    private int[] entitysRichtig =          { 1, 1, 1, 1, 1, 0, 2, 1 };
    private int[] attributeRichtig =        { 0, 0, 0, 0, 0, 0, 0, 0 };//{ 4, 4, 4, 3, 5, 0, 7, 5 };
    private int[] primaerschluesselRichtig ={ 0, 0, 0, 0, 0, 0, 0, 0 };//{ 1, 2, 1, 1, 2, 0, 3, 1 };
    private int[] beziehungenRichtig =      { 0, 1, 1, 1, 2, 3, 2, 3 };
    private int[] kardRichtig =             { 0, 2, 2, 2, 4, 6, 4, 6 }; //2 pro Relation

    private int[] entitysHat;
    private int[] attributeHat;
    private int[] primaerschluesselHat;
    private int[] beziehungenHat;
    private int[] kardHat;

    //Anzahl der Objekte, die im LvL sind (#EM + #Attribute + #Relationen)
    private int[] anzahlObjekte = { 1, 2, 2, 2, 3, 3, 4, 4 }; //{ 5, 6, 6, 5, 8, 3, 11, 9 };

    public GameObject dasIstSchonFertig;
    public GameObject aufgabenText;
    public List<GameObject> checkliste;
    public static List<GameObject> gespeicherteObjekte;
    public GameObject checkboxOhneRelation;
    public GameObject checkboxOhneEntity;

    public static bool missionCheck = true;
    public GameObject aufgabenFenster;
    public GameObject aufgabeButton;
    public GameObject checkbox;
    public GameObject checkboxButton;
    public GameObject bottomLeiste;

    public GameObject kreisHacken;
    public GameObject kreisKreuz;
    public GameObject missionHacken;
    public GameObject missionKreuz;

    private bool firsttime=true;

    // Start is called before the first frame update
    void Awake()
    {
        // Level 0
        listeAttribute[0] = new string[][][] { wohncontainer };
        listeBeziehungen[0] = new string[0][];
        listeBeziehungsEigenschaften[0] = new string[0][];
        // Level 1
        listeAttribute[1] = new string[][][] { astronaut };
        listeBeziehungen[1] = new string[][] { wohncontainer_astronaut };
        listeBeziehungsEigenschaften[1] = new string[][] { wohncontainer_astronaut_Eig };
        // Level 2
        listeAttribute[2] = new string[][][] { feldspaehre };
        listeBeziehungen[2] = new string[][] { astronaut_feldsphaere };
        listeBeziehungsEigenschaften[2] = new string[][] { astronaut_feldsphaere_Eig };
        // Level 3
        listeAttribute[3] = new string[][][] { forschungsstation };
        listeBeziehungen[3] = new string[][] { astronaut_forschungsstation };
        listeBeziehungsEigenschaften[3] = new string[][] { astronaut_forschungsstation_Eig };
        // Level 4
        listeAttribute[4] = new string[][][] { forschungsprojekt };
        listeBeziehungen[4] = new string[][] { astronaut_forschungsprojekt, forschungsstation_forschungsprojekt };
        listeBeziehungsEigenschaften[4] = new string[][] { astronaut_forschungsprojekt_Eig, forschungsstation_forschungsprojekt_Eig };
        // Level 5
        listeAttribute[5] = new string[0][][];
        listeBeziehungen[5] = new string[][] { forschungsprojekt_feldsphaere, forschungsprojekt_wohncontainer, forschungsprojekt_forschungsprojekt };
        listeBeziehungsEigenschaften[5] = new string[][] { forschungsprojekt_feldsphaere_Eig, forschungsprojekt_wohncontainer_Eig, forschungsprojekt_forschungsprojekt_Eig };
        // Level 6
        listeAttribute[6] = new string[][][] { nutztier, stallcontainer };
        listeBeziehungen[6] = new string[][] { stallcontainer_nutztier, forschungsprojekt_stallcontainer};
        listeBeziehungsEigenschaften[6] = new string[][] { stallcontainer_nutztier_Eig,forschungsprojekt_stallcontainer_Eig };
        // Level 7
        listeAttribute[7] = new string[][][] { weidespaehre };
        listeBeziehungen[7] = new string[][] { forschungsprojekt_weidesphaere, weidesphaere_nutztier, astronaut_weidesphaere };
        listeBeziehungsEigenschaften[7] = new string[][] { forschungsprojekt_weidesphaere_Eig, weidesphaere_nutztier_Eig, astronaut_weidesphaere_Eig };

        gespeicherteObjekte = new List<GameObject>();
        Utilitys.TextInTMP(dasIstSchonFertig, "");

        gespeicherteObjekteAus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Story.level < 8)
        {
            Utilitys.TextInTMP(aufgabenText, aufgabe[Story.level]);

            //wenn die Mission erfolgreich absolviert wurde, kann wieder im ER gebastelt werden und es wird chckObjekte() ausgeführt
            if(missionCheck)
            {
                bottomLeiste.SetActive(true);                
                aufgabeButton.SetActive(true);
                checkboxButton.SetActive(true);
                kreisHacken.SetActive(false);
                kreisKreuz.SetActive(true);
                if (firsttime)
                {
                    aufgabenFenster.SetActive(true);
                    checkbox.SetActive(true);
                }
                checkObjekte();
                firsttime=false;
            //Ist die Mission noch nciht erfüllt, bleibt alles verdeckt.
            }else
            {
                bottomLeiste.SetActive(false);
                aufgabenFenster.SetActive(false);
                checkbox.SetActive(false);
                aufgabeButton.SetActive(false);
                checkboxButton.SetActive(false);
                firsttime = true;
            }
            
        }
        else
        {
            FehlerAnzeige.fehlertext = "Du hast es geschafft.";
        }
        //Checkbox für Level 0 anpassen
        if (Story.level == 0)
        {
            checkboxOhneRelation.SetActive(true);
            checkliste[3].SetActive(false);
            checkliste[4].SetActive(false);
        }
        else
        {
            checkboxOhneRelation.SetActive(false);
        }
        //Checkbox für Level 5 anpassen
        if (Story.level == 5)
        {
            checkboxOhneEntity.SetActive(true);
            checkliste[0].SetActive(false);
            checkliste[1].SetActive(false);
            checkliste[2].SetActive(false);
        }
        else
        {
            checkboxOhneEntity.SetActive(false);
        }
    }

    private void checkObjekte()
    {
        entitysHat = new int[entitysRichtig.Length];
        attributeHat = new int[attributeRichtig.Length];
        primaerschluesselHat = new int[primaerschluesselRichtig.Length];
        beziehungenHat = new int[beziehungenRichtig.Length];
        kardHat = new int[kardRichtig.Length];

        int indexEntity = 0;
        checkBeziehung();
        foreach (string entityName in listeEntity[Story.level])
        {
            foreach (GameObject entity in ERErstellung.modellObjekte)
            {
                if (entity.name.Equals(entityName))
                {
                    entitysHat[Story.level]++;
                    checkAttribute(indexEntity, entity);
                }
            }

            indexEntity++;
        }

        if (checkAllesRichtig())
        {
            //wenn alles richtig ist wird default alles auf aus gesetzt (in Update wird es aber wieder auf true gesetzt, wenn missioncheck == true ist)
            bottomLeiste.SetActive(false);
            //aufgabenFenster.SetActive(false);
            //checkbox.SetActive(false);
            aufgabeButton.SetActive(false);
            checkboxButton.SetActive(false);
            //kreisHacken.SetActive(true);
            //kreisKreuz.SetActive(false); 
            FehlerAnzeige.fehlertext = "Du hast alles richtig gemacht!";
            

            //Nächste Zeile bleibt auskommentiert, da jetzt in Story NUR in abhängigkeit vom level das Array gesetzt wird für die Mission
            Story.lvl[Story.level] = true; //Markiere Level als erfüllt
            
            if(missionCheck == false){
                kreisHacken.SetActive(true);
                kreisKreuz.SetActive(false);
            }

            //ER bleibt ja bei dem Level stehen, wo Mission bearbeitet werden kann. Ist Mission erfolgreich (missionCheck = true), dann geht es weiter.
            if((Story.level == 1|| Story.level == 2 || Story.level == 5 || Story.level == 6 || Story.level == 7 ) && missionCheck == true){
                missionCheck = false;
                kreisHacken.SetActive(true);
                kreisKreuz.SetActive(false);
                missionKreuz.SetActive(true);
                missionHacken.SetActive(false);

            }


            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                if (!gespeicherteObjekte.Contains(obj))
                {
                    gespeicherteObjekte.Add(obj);
                    obj.transform.GetChild(1).gameObject.SetActive(false);
                    obj.transform.GetChild(0).gameObject.SetActive(true);
                    Utilitys.TextInTMP(obj.transform.GetChild(0).gameObject, obj.name);
                    if (obj.CompareTag("Attribut") && obj.GetComponent<Attribut>().primaerschluessel)
                    {
                        obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
                    }
                }
            }
            Story.level++;
        }
    }

    private void checkBeziehung()
    {
        List<GameObject> erfolgreichbetrachtet = new List<GameObject>();
        for (int i = 0; i < listeBeziehungen[Story.level].Length; i++)
        {

            foreach (GameObject obj in ERErstellung.modellObjekte)
            {
                bool allesDa = true;
                bool kardinalitaeten = true;
                if (obj.CompareTag("Beziehung") && !gespeicherteObjekte.Contains(obj) && !erfolgreichbetrachtet.Contains(obj))
                {
                    string nameAnderesEnitity = "";
                    int einsoderZwei = 0;
                    int dreiodervier = 0;

                    GameObject ob1 = null;
                    GameObject ob2 = null;
                    GameObject ob12 = null;

                    //Entitäten und Kardinalität prüfen
                    if (obj.GetComponent<Beziehung>().objekt1 != null && listeBeziehungsEigenschaften[Story.level][i][0].Equals(obj.GetComponent<Beziehung>().objekt1.name))
                    {
                        if (obj.GetComponent<Beziehung>().objekt2 != null)
                        {
                            ob1 = obj.GetComponent<Beziehung>().objekt1;
                            ob12 = obj.GetComponent<Beziehung>().objekt2;
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt2.name;
                        }
                        if (checkKard(obj, 1, i, 4))
                        {
                            einsoderZwei = 2;
                            dreiodervier = 3;
                            kardinalitaeten &= true;
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }
                    }
                    else if (obj.GetComponent<Beziehung>().objekt2 != null && listeBeziehungsEigenschaften[Story.level][i][0].Equals(obj.GetComponent<Beziehung>().objekt2.name))
                    {
                        if (obj.GetComponent<Beziehung>().objekt1 != null)
                        {
                            ob2 = obj.GetComponent<Beziehung>().objekt2;
                            ob12 = obj.GetComponent<Beziehung>().objekt1;
                            nameAnderesEnitity = obj.GetComponent<Beziehung>().objekt1.name;
                        }
                        if (checkKard(obj, 2, i, 4))
                        {
                            einsoderZwei = 1;
                            dreiodervier = 3;
                            kardinalitaeten &= true;
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }
                    }
                    if (i == 2)
                    {
                        Debug.Log("1");
                    }
                    if (listeBeziehungsEigenschaften[Story.level][i][1].Equals(nameAnderesEnitity))
                    {
                        allesDa &= true;
                        if (checkKard(obj, einsoderZwei, i, dreiodervier))
                        {
                            kardinalitaeten &= true;
                        }
                        else if((ob1!=null && ob1.Equals(ob12) || ob2 != null && ob2.Equals(ob12) )&& Story.level==5){
                            if(obj.GetComponent<Beziehung>().kard1.Equals("1")&& obj.GetComponent<Beziehung>().kard2.Equals("n"))
                            {
                                kardinalitaeten = true;
                            }else if (obj.GetComponent<Beziehung>().kard2.Equals("1") && obj.GetComponent<Beziehung>().kard1.Equals("n"))
                            {
                                kardinalitaeten = true;
                            }
                            else
                            {
                                kardinalitaeten = false;
                            }
                        }
                        else
                        {
                            kardinalitaeten &= false;
                        }

                    }
                    else
                    {
                        ob12 = null;
                        allesDa &= false;
                        kardinalitaeten &= false;
                    }
                    if (kardinalitaeten)
                    {
                        kardHat[Story.level] += 2;
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
                        if (ob12 != null && ob12.GetComponent<Entitaet>().schwach)
                        {

                            allesDa &= true;

                        }
                        else { allesDa &= false; }

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
                        erfolgreichbetrachtet.Add(obj);
                        beziehungenHat[Story.level]++;
                        break;
                    }
                    
                }
            }
        }

    }

    private bool checkKard(GameObject obj, int einsOderZwei, int i, int dreiOdervier)
    {
        string kard = "";
        if (einsOderZwei == 1)
        {
             kard= obj.GetComponent<Beziehung>().kard1;       
        }
        else
        {
            kard = obj.GetComponent<Beziehung>().kard2;
        }

        if (kard.Equals(listeBeziehungsEigenschaften[Story.level][i][dreiOdervier]))
        {
            
            return true;
        }
        
        else
        {
            
            return false;
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
        int count = 0;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (!gespeicherteObjekte.Contains(obj))
            {
                count++;
            }
        }
        if (count == anzahlObjekte[Story.level])
        {
            ausgabe &= true;
        }else if(count > anzahlObjekte[Story.level])
        {
            FehlerAnzeige.fehlertext = "Es sind zu viele Objekte.";
            ausgabe &= false;
        }
        else
        {
            ausgabe &= false;
        }


        return ausgabe;
    }

    private void checkAttribute(int indexEntity, GameObject entity)
    {
        int indexattribute = 0;
        bool schonGefunden = false;
        foreach (string[] attributNamesMoeglichkeiten in listeAttribute[Story.level][indexEntity])
        {
            foreach (GameObject attribut in entity.GetComponent<Entitaet>().attribute)
            {
                foreach (string attributName in attributNamesMoeglichkeiten)
                {
                    if (attribut.name.Equals(attributName))
                    {
                        attributeHat[Story.level]++;
                        if (primarschluessel[Story.level][indexEntity][indexattribute] == 1 && entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            primaerschluesselHat[Story.level]++;

                        }
                        schonGefunden = true;
                        break;

                    }
                }

                if (schonGefunden)
                {
                    schonGefunden = false;
                    break;
                }

            }
            indexattribute++;

        }


    }
    public static void gespeicherteObjekteAus()
    {
        foreach (GameObject game in ERAufgabe.gespeicherteObjekte)
        {
            game.transform.GetChild(1).gameObject.SetActive(false);
            game.transform.GetChild(0).gameObject.SetActive(true);
            Utilitys.TextInTMP(game.transform.GetChild(0).gameObject, game.name);
            if (game.CompareTag("Attribut") && game.GetComponent<Attribut>().primaerschluessel)
            {
                game.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
            }
        }
    }


}