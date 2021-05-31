using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void speichern()
    {
        playerData = new PlayerData();
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/SaveState/saveFile.json", json);

        StaticWerte staticWerte = new StaticWerte();
        json = JsonUtility.ToJson(staticWerte);
        File.WriteAllText(Application.dataPath + "/SaveState/staticsGebaeude.json", json);

        json = "[";
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {
            json += JsonUtility.ToJson(wohn) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Wohncontainer.json", json);

        json = "[";
        foreach (Feld feld in Testing.felder)
        {
            json += JsonUtility.ToJson(feld) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Feldsphaere.json", json);

        json = "[";
        foreach (Forschung obj in Testing.forschungsstationen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Forschungsstation.json", json);

        json = "[";
        foreach (Projekt obj in Testing.forschungsprojekte)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Forschungsprojekte.json", json);

        json = "[";
        foreach (Weide obj in Testing.weiden)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Weidesphaere.json", json);

        json = "[";
        foreach (Stallcontainer obj in Testing.stallcontainer)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Stallcontainer.json", json);

        json = "[";
        foreach (Mensch obj in Testing.menschen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Menschen.json", json);

        json = "[";
        foreach (Tiere obj in Testing.tier)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/Tiere.json", json);

        saveLoadER.speichern();
        saveLoadBeziehungen.speichern();
    }

    public void laden()
    {

        string json = File.ReadAllText(Application.dataPath + "/SaveState/saveFile.json");
        LoadedPlayerData loadedplayerData = JsonUtility.FromJson<LoadedPlayerData>(json);
        loadedplayerData.setData();

        json = File.ReadAllText(Application.dataPath + "/SaveState/staticsGebaeude.json");
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

        ObjektBewegung.selected = false;
        saveLoadER.laden();
    }

    private void tiereLaden()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Tiere.json");
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
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Menschen.json");
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
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Forschungsprojekte.json");
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
                }
                fors.setProjekt();
            }
        }
    }
    private void stallLaden()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Stallcontainer.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(feldPrefab, gebauedeOrdner.transform);
            Stallcontainer stall = geb.AddComponent<Stallcontainer>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", stall);//entfernt ,

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(stall.x, stall.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(stall.x, stall.y, 5, geb);

            Testing.stallcontainer.Add(stall);
            Testing.gebauedeListe.Add(geb);
        }
    }
    private void weideLaden()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Weidesphaere.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(weidePrefab, gebauedeOrdner.transform);
            Weide weide = geb.AddComponent<Weide>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", weide);//entfernt ,

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
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Feldsphaere.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(feldPrefab, gebauedeOrdner.transform);
            Feld feld = geb.AddComponent<Feld>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", feld);//entfernt ,

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(feld.x, feld.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(feld.x, feld.y, 2, geb);

            Testing.felder.Add(feld);
            Testing.gebauedeListe.Add(geb);
        }
    }
    private void forschungLaden()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Forschungsstation.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(forschungPrefab, gebauedeOrdner.transform);
            Forschung fos = geb.AddComponent<Forschung>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", fos);//entfernt ,

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(1, 1, 1);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
            geb.transform.position = Testing.grid.GetWorldPosition(fos.x, fos.y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
            Testing.grid.SetWert(fos.x, fos.y, 3, geb);

            Testing.forschungsstationen.Add(fos);
            Testing.gebauedeListe.Add(geb);

            fos.projekte = new List<Projekt>();
            fos.verbesserung(dropDownProjekt, merkmalGO);
        }
    }
    private void wohncontainerLaden()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/DB/Wohncontainer.json");
        json = json.Remove(json.Length - 1);//[] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject geb = Instantiate(wohncontainerPrefab, gebauedeOrdner.transform);
            Wohncontainer wohn = geb.AddComponent<Wohncontainer>();
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", wohn);//entfernt ,

            Destroy(geb.GetComponent<ObjektBewegung>());
            geb.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            geb.transform.rotation = Quaternion.Euler(0, 0, 0);
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

            SpielInfos.marsTag = marsTag;
            SpielInfos.erdenTag = erdenTag;
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

        public int level = Story.level;
        public bool[] lvl = Story.lvl;
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

        public int level;

        public bool[] lvl;
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

            Story.level = level;
            Story.lvl = lvl;
        }
    }
}
