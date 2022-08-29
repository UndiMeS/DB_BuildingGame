﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class SaveLoad : MonoBehaviour
{
    private PlayerData playerData;

    public GameObject wohncontainerPrefab;
    public GameObject feldPrefab;
    public GameObject forschungPrefab;
    public GameObject weidePrefab;
    public GameObject stallPrefab;

    public TMPro.TMP_Dropdown dropDownProjekt;
    public GameObject merkmalGO;

    public SaveLoadER saveLoadER;
    public SaveLoadBeziehungen saveLoadBeziehungen;
    public GameObject gebauedeOrdner;

    public InputField missionsEingabe;
    public GameObject FrageMars;
    public GameObject FrageER;

    public void speichern()
    {
        //überall Application.persistentDataPath
        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/"))
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/");
        }
        playerData = new PlayerData();
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/saveFile.json", json);

        StaticWerte staticWerte = new StaticWerte();
        json = JsonUtility.ToJson(staticWerte);
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/staticsGebaeude.json", json);

        json = "[";
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {
            json += JsonUtility.ToJson(wohn) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Wohncontainer.json", json);

        json = "[";
        foreach (Feld feld in Testing.felder)
        {
            json += JsonUtility.ToJson(feld) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Feldsphaere.json", json);

        json = "[";
        foreach (Forschung obj in Testing.forschungsstationen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Forschungsstation.json", json);

        json = "[";
        foreach (Projekt obj in Testing.forschungsprojekte)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Forschungsprojekte.json", json);

        json = "[";
        foreach (Weide obj in Testing.weiden)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Weidesphaere.json", json);

        json = "[";
        foreach (Stallcontainer obj in Testing.stallcontainer)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Stallcontainer.json", json);

        json = "[";
        foreach (Mensch obj in Testing.menschen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Astronaut.json", json);

        json = "[";
        foreach (Tiere obj in Testing.tier)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Tiere.json", json);

        saveLoadER.speichern();
        saveLoadBeziehungen.speichern();

        if (!ZertifikatErstellen.abkuerzer)
        {
            FrageMars.SetActive(true);
            FrageER.SetActive(true);
        }
        else
        {
            Mission.screenshotMission = true;
        }
    }

    public void laden()
    {
        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/"))
        {
            return;
        }
        
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/saveFile.json");
        LoadedPlayerData loadedplayerData = JsonUtility.FromJson<LoadedPlayerData>(json);
        loadedplayerData.setData();

        

        json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/staticsGebaeude.json");
        LoadedStaticWerte loadedstaticWerte = JsonUtility.FromJson<LoadedStaticWerte>(json);
        loadedstaticWerte.setData();

        

        wohncontainerLaden();
        feldLaden();
        forschungLaden();
        projekteLaden();
        weideLaden();
        stallLaden();
        menschenLaden();
        tiereLaden();

        if (loadedplayerData.missionsTeilLevel0[1] && loadedplayerData.level <3)
        {
            missionsEingabe.text= Testing.menschen[0].name;
        }

        ObjektBewegung.selected = false;
        saveLoadER.laden();

        
    }

   

    private void tiereLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Tiere.json");
        json = json.Remove(json.Length - 1);//] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            Tiere tier = JsonUtility.FromJson<Tiere>(split[i].Remove(0, 1) + "}");//entfernt ,
            Testing.tier.Add(tier);
            foreach (Stallcontainer stall in Testing.stallcontainer)
            {
                if (stall.containernummer == tier.stallnummer)
                {
                    stall.tiere.Add(tier);
                }
            }
        }
    }

    private void menschenLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Astronaut.json");
        json = json.Remove(json.Length - 1);//] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            Mensch mensch = JsonUtility.FromJson<Mensch>(split[i].Remove(0, 1) + "}");//entfernt ,
            Testing.menschen.Add(mensch);
            foreach (Wohncontainer wohn in Testing.wohncontainer)
            {
                if (wohn.containernummer == mensch.containerNummer)
                {
                    wohn.bewohner.Add(mensch);
                }
            }
        }
    }

    private void projekteLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Forschungsprojekte.json");
        json = json.Remove(json.Length - 1);//] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            Projekt projekt = JsonUtility.FromJson<Projekt>(split[i].Remove(0, 1) + "}");//entfernt ,
            Testing.forschungsprojekte.Add(projekt);
            if (projekt.merkmalInt != 11 && GebaeudeAnzeige.projektMerkmalStufen[projekt.merkmalInt] < projekt.stufe + 1)
            {
                GebaeudeAnzeige.projektMerkmalStufen[projekt.merkmalInt] = projekt.stufe + 1;
            }
            foreach (Forschung fors in Testing.forschungsstationen)
            {
                if (fors.stationsnummer == projekt.stationsnummer)
                {
                    fors.addProjekt(projekt);
                    fors.setProjekt();
                    break;
                }
                
            }
        }
    }
    private void stallLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Stallcontainer.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(stallPrefab, gebauedeOrdner.transform);
            Stallcontainer stall = geb.AddComponent<Stallcontainer>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", stall);//entfernt ,
            geb.GetComponent<ObjektBewegung>().GrünesGebäude.SetActive(false);
            geb.GetComponent<ObjektBewegung>().FinalGebäude.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.SetActive(true);

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.lossyScale.Set(250,250,250);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(stall.x, stall.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(stall.x, stall.y, 5, geb);

            Testing.stallcontainer.Add(stall);
            Testing.gebauedeListe.Add(geb);
        }
    }
    private void weideLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Weidesphaere.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(weidePrefab, gebauedeOrdner.transform);
            Weide weide = geb.AddComponent<Weide>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", weide);//entfernt ,
            geb.GetComponent<ObjektBewegung>().GrünesGebäude.SetActive(false);
            geb.GetComponent<ObjektBewegung>().FinalGebäude.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.SetActive(true);

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(weide.x, weide.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(weide.x, weide.y, 4, geb);

            Testing.weiden.Add(weide);
            Testing.gebauedeListe.Add(geb);
        }
    }
    private void feldLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Feldsphaere.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(feldPrefab, gebauedeOrdner.transform);
            Feld feld = geb.AddComponent<Feld>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", feld);//entfernt ,
            geb.GetComponent<ObjektBewegung>().GrünesGebäude.SetActive(false);
            geb.GetComponent<ObjektBewegung>().FinalGebäude.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.transform.localPosition = new Vector3( -3.9f, -15.8f, -1.7f);
            Destroy(geb.GetComponent<GebäudeAnimation>());

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(feld.x, feld.y) + new Vector3(Testing.zellengroesse / 2, 3*Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(feld.x, feld.y, 2, geb);

            Testing.felder.Add(feld);
            Testing.gebauedeListe.Add(geb);
        }
    }
    private void forschungLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Forschungsstation.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(forschungPrefab, gebauedeOrdner.transform);
            Forschung fos = geb.AddComponent<Forschung>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", fos);//entfernt ,
            geb.GetComponent<ObjektBewegung>().GrünesGebäude.SetActive(false);
            geb.GetComponent<ObjektBewegung>().FinalGebäude.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.SetActive(true);

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(fos.x, fos.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, -1);
            Testing.grid.SetWert(fos.x, fos.y, 3, geb);

            Testing.forschungsstationen.Add(fos);
            Testing.gebauedeListe.Add(geb);

            fos.projekte = new List<Projekt>();
            fos.verbesserung(dropDownProjekt, merkmalGO);
        }
    }
    private void wohncontainerLaden()
    {
        string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/Wohncontainer.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(wohncontainerPrefab, gebauedeOrdner.transform);
            Wohncontainer wohn = geb.AddComponent<Wohncontainer>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", wohn);//entfernt ,
            geb.GetComponent<ObjektBewegung>().GrünesGebäude.SetActive(false);
            geb.GetComponent<ObjektBewegung>().FinalGebäude.SetActive(true);
            geb.GetComponent<GebäudeAnimation>().GebäudeAnzeige.SetActive(true);
            Destroy(geb.GetComponent<GebäudeAnimation>());

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.rotation = Quaternion.Euler(0, 0, -180);
            geb.transform.position = Testing.grid.GetWorldPosition(wohn.x, wohn.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(wohn.x, wohn.y, 1, geb);

            Testing.wohncontainer.Add(wohn);
            Testing.gebauedeListe.Add(geb);
        }
    }

    private class PlayerData
    {
        public int geld = Testing.geld;
        public int umsatz = Testing.umsatz;
        public int forscher = Testing.forscher;
        public int tierpfleger = Testing.tierpfleger;
        public int feldarbeiter = Testing.feldarbeiter;
        public int tiere = Testing.tiere;
        public int summeMenschen = Testing.summeMenschen;
        public int summeTiere = Testing.summeTiere;
        public int summeForschungen = Testing.summeForschungen;

        public int marsTag = SpielInfos.marsTag;
        public int erdenTag = SpielInfos.erdenTag;

        public int level = Story.level;
        public bool mission1 = Mission.mission1;
        public bool mission3 = Mission.mission3;
        public bool[] lvl = Story.lvl;
        public bool[] missionsLevel = Mission.missionsLevel;

        public bool [] missionsTeilLevel0 = Mission.missionsTeilLevel0;
        public bool [] missionsTeilLevel1 = Mission.missionsTeilLevel1;
        public bool [] missionsTeilLevel2 = Mission.missionsTeilLevel2;
        public bool [] missionsTeilLevel3 = Mission.missionsTeilLevel3;
        public bool [] missionsTeilLevel4 = Mission.missionsTeilLevel4;
        public bool [] missionsTeilLevel5 = Mission.missionsTeilLevel5;
        public bool [] missionsTeilLevel6 = Mission.missionsTeilLevel6;
        public bool [] missionsTeilLevel7 = Mission.missionsTeilLevel7;
        public bool [] missionsTeilLevel8 = Mission.missionsTeilLevel8;
        public bool [] missionsTeilLevel9 = Mission.missionsTeilLevel9;

        public bool finale = false;
        public bool screenshotMission = false;

        public bool missionCheck = ERAufgabe.missionCheck;
        

        public int welcheZusatzaufgabe = Aufgaben.welcheAufgabe +1;
    }

    private class LoadedPlayerData
    {
        public int geld;
        public int umsatz;
        public int forscher;
        public int tierpfleger;
        public int feldarbeiter;
        public int tiere;
        public int summeMenschen;
        public int summeTiere;
        public int summeForschungen;

        public int marsTag;
        public int erdenTag;

        public int level;
        public bool mission1;
        public bool mission3;
        public bool[] lvl;
        public bool[] missionsLevel;

        public bool [] missionsTeilLevel0;
        public bool [] missionsTeilLevel1;
        public bool [] missionsTeilLevel2;
        public bool [] missionsTeilLevel3;
        public bool [] missionsTeilLevel4;
        public bool [] missionsTeilLevel5;
        public bool [] missionsTeilLevel6;
        public bool [] missionsTeilLevel7;
        public bool [] missionsTeilLevel8;
        public bool [] missionsTeilLevel9;

        public bool finale;
        public bool screenshotMission;

        public bool missionCheck;

        public int welcheZusatzaufgabe;

        public void setData()
        {
            Testing.geld = geld;
            Testing.umsatz = umsatz;

            Testing.forscher = forscher;
            Testing.tierpfleger = tierpfleger;
            Testing.feldarbeiter = feldarbeiter;
            Testing.tiere = tiere;
            Testing.summeMenschen = summeMenschen;
            Testing.summeTiere = summeTiere;
            Testing.summeForschungen = summeForschungen;

            SpielInfos.deltaMarsTag = marsTag;
            SpielInfos.deltaErdenTag = erdenTag;

            Story.level = level;
            Mission.mission1 = mission1;
            Mission.mission3 = mission3;
            Story.lvl = lvl;
            Mission.missionsLevel = missionsLevel;

            Mission.missionsTeilLevel0 = missionsTeilLevel0;
            Mission.missionsTeilLevel1 = missionsTeilLevel1;
            Mission.missionsTeilLevel2 = missionsTeilLevel2;
            Mission.missionsTeilLevel3 = missionsTeilLevel3;
            Mission.missionsTeilLevel4 = missionsTeilLevel4;
            Mission.missionsTeilLevel5 = missionsTeilLevel5;
            Mission.missionsTeilLevel6 = missionsTeilLevel6;
            Mission.missionsTeilLevel7 = missionsTeilLevel7;
            Mission.missionsTeilLevel8 = missionsTeilLevel8;
            Mission.missionsTeilLevel9 = missionsTeilLevel9;

            Mission.finale = finale;
            Mission.screenshotMission = screenshotMission;

            ERAufgabe.missionCheck = missionCheck;
            
            
            Aufgaben.welcheAufgabe = welcheZusatzaufgabe;
        }
    }

    private class StaticWerte
    {
        public int WnummerZaehler = Wohncontainer.nummerZaehler;
        public int Wbetten = Wohncontainer.betten;
        public int Wpreis = Wohncontainer.preis;

        public int FEneuErtrag = Feld.neuErtrag;
        public int FEnummerZaehler = Feld.nummerZaehler;
        public int FEpreis = Feld.preis;
        public int FEarbeiterzahl = Feld.arbeiterzahl;

        public int FOnummerZaehler = Forschung.nummerZaehler;

        public int WEnummerZaehler = Weide.nummerZaehler;
        public int WEpreis = Weide.preis;
        public int WEarbeiterzahl = Weide.arbeiterzahl;
        public int WEneuErtrag = Weide.neuErtrag;
        public int WEtierAnzahl = Weide.tierAnzahl;

        public int SnummerZaehler = Stallcontainer.nummerZaehler;
        public int Spreis = Stallcontainer.preis;
        public int Sgehege = Stallcontainer.gehege;

    }
    private class LoadedStaticWerte
    {
        public int WnummerZaehler;
        public int Wbetten;
        public int Wpreis;

        public int FEneuErtrag;
        public int FEnummerZaehler;
        public int FEpreis;
        public int FEarbeiterzahl;

        public int FOnummerZaehler;

        public int WEnummerZaehler;
        public int WEpreis;
        public int WEarbeiterzahl;
        public int WEneuErtrag;
        public int WEtierAnzahl;

        public int SnummerZaehler;
        public int Spreis;
        public int Sgehege;

        

        public void setData()
        {
            Wohncontainer.nummerZaehler = WnummerZaehler;
            Wohncontainer.betten = Wbetten;
            Wohncontainer.preis = Wpreis;

            Feld.neuErtrag = FEneuErtrag;
            Feld.nummerZaehler = FEnummerZaehler;
            Feld.preis = FEpreis;
            Feld.arbeiterzahl = FEarbeiterzahl;

            Forschung.nummerZaehler = FOnummerZaehler;

            Weide.nummerZaehler = WEnummerZaehler;
            Weide.preis = WEpreis;
            Weide.arbeiterzahl = WEarbeiterzahl;
            Weide.neuErtrag = WEneuErtrag;
            Weide.tierAnzahl = WEtierAnzahl;

            Stallcontainer.nummerZaehler = SnummerZaehler;
            Stallcontainer.preis = Spreis;
            Stallcontainer.gehege = Sgehege;

            
        }
    }
}
