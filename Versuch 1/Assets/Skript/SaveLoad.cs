using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SaveLoad : MonoBehaviour
{
    public PlayerData playerData;

    public GameObject wohncontainerPrefab;
    public GameObject feldPrefab;
    public GameObject forschungPrefab;
    public GameObject weidePrefab;
    public GameObject stallPrefab;

    public TMPro.TMP_Dropdown dropDownProjekt;
    public GameObject merkmalGO;


    public void speichern()
    {
        playerData = new PlayerData();
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/SaveState/saveFile.json", json);

        json = "[";
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {
            json +=JsonUtility.ToJson(wohn)+",";
        }
        json = json.Remove(json.Length - 1)+"]";
        File.WriteAllText(Application.dataPath + "/SaveState/Wohncontainer.json", json);

        json = "[";
        foreach (Feld feld in Testing.felder)
        {
            json += JsonUtility.ToJson(feld) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Feldsphaere.json", json);

        json = "[";
        foreach (Forschung obj in Testing.forschungsstationen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Forschungsstation.json", json);

        json = "[";
        foreach (Projekt obj in Testing.forschungsprojekte)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Forschungsprojekte.json", json);

        json = "[";
        foreach (Weide obj in Testing.weiden)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Weidesphaere.json", json);

        json = "[";
        foreach (Stallcontainer obj in Testing.stallcontainer)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Stallcontainer.json", json);
    }

    public void laden()
    {
     
        string json = File.ReadAllText(Application.dataPath + "/SaveState/saveFile.json");
        LoadedPlayerData loadedplayerData = JsonUtility.FromJson<LoadedPlayerData>(json);
        loadedplayerData.setData();

        wohncontainerLaden();
        feldLaden();
        forschungLaden();
        projekteLaden();
        weideLaden();
        stallLaden();
        GebaeudeAnzeige.forschungsauswahl = false;
    }

    private void projekteLaden()
    {
        int nr = 0;
        string merkmal = "";
        int merkmalInt = 0;
        int stufe = 0;
        int kosten = 0;
        int forscherAnz = 0;
        int pos = 0;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Forschungsprojekte.json");
        string[] split = json.Split(':');
        Debug.Log(split.Length);
        for (int i = 1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 7 == 0)
            {
                nr = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 7 == 1)
            {
                merkmal = tmp[0].Split('"')[1];
            }
            else if ((i - 1) % 7 == 2)
            {
                merkmalInt = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 7 == 3)
            {
                stufe = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 7 == 4)
            {
                kosten = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 7 == 5)
            {
                forscherAnz = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 7 == 6)
            {
                if (i + 1 == split.Length)
                {
                    pos = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                }
                else
                {
                    pos = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                }
                Debug.Log("!");
                new Projekt(nr,merkmal, merkmalInt,stufe, kosten,forscherAnz,pos);
            }
        }
    }

    private void stallLaden()
    {
        int nr = 0;
        int gehege = 0;
        int kosten = 0;
        int freiGeh = 0;
        int x = 0;
        int y = 0;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Stallcontainer.json");
        string[] split = json.Split(':');
        for (int i = 1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 6 == 0)
            {
                nr = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 1)
            {
                gehege = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 2)
            {
                kosten = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 3)
            {
                freiGeh = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 4)
            {
                x = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 5)
            {
                if (i + 1 == split.Length)
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                }
                else
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                }

                GameObject geb = Instantiate(stallPrefab, transform);
                Destroy(geb.GetComponent<ObjektBewegung>());
                geb.AddComponent<Stallcontainer>();
                geb.transform.parent = null;
                geb.transform.localScale = new Vector3(10, 10, 1);
                geb.transform.rotation = Quaternion.Euler(0, 0, 0);
                geb.transform.position = Testing.grid.GetWorldPosition(x, y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
                Testing.grid.SetWert(x, y, 5, geb);
                geb.GetComponent<Stallcontainer>().setAll(nr, gehege, kosten, freiGeh, x, y);
            }
        }
    }
    private void weideLaden()
    {
        {
            int nr = 0;
            int kosten = 0;
            int arbeiter = 0;
            int ertrag = 0;
            int tiere = 0;
            int x = 0;
            int y = 0;

            string json = File.ReadAllText(Application.dataPath + "/SaveState/Weidesphaere.json");
            string[] split = json.Split(':');
            for (int i = 1; i < split.Length; i++)
            {
                string[] tmp = split[i].Split(',');
                if ((i - 1) % 7 == 0)
                {
                    nr = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 1)
                {
                    kosten = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 2)
                {
                    arbeiter = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 3)
                {
                    ertrag = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 4)
                {
                    tiere = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 5)
                {
                    x = int.Parse(tmp[0]);
                }
                else if ((i - 1) % 7 == 6)
                {
                    if (i + 1 == split.Length)
                    {
                        y = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                    }
                    else
                    {
                        y = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                    }

                    GameObject geb = Instantiate(weidePrefab, transform);
                    geb.AddComponent<Weide>();
                    Destroy(geb.GetComponent<ObjektBewegung>());
                    geb.transform.parent = null;
                    geb.transform.localScale = new Vector3(1, 1, 1);
                    geb.transform.rotation = Quaternion.Euler(0, 0, 0);
                    geb.transform.position = Testing.grid.GetWorldPosition(x, y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
                    Testing.grid.SetWert(x, y, 4, geb);
                    geb.GetComponent<Weide>().setAll(nr, kosten, arbeiter, ertrag,tiere, x, y);
                }
            }
        }
    }
    private void feldLaden()
    {
        int nr = 0;
        int kosten = 0;
        int arbeiter = 0;
        int ertrag = 0;
        int x = 0;
        int y = 0;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Feldsphaere.json");
        string[] split = json.Split(':');
        for (int i = 1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 6 == 0)
            {
                nr = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 1)
            {
                kosten = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 2)
            {
                arbeiter = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 3)
            {
                ertrag = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 4)
            {
                x = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 5)
            {
                if (i + 1 == split.Length)
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                }
                else
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                }

                GameObject geb = Instantiate(feldPrefab, transform);
                Destroy(geb.GetComponent<ObjektBewegung>());
                geb.AddComponent<Feld>();
                geb.transform.parent = null;
                geb.transform.localScale = new Vector3(1, 1, 1);
                geb.transform.rotation = Quaternion.Euler(0, 0, 0);
                geb.transform.position = Testing.grid.GetWorldPosition(x, y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
                Testing.grid.SetWert(x, y,2, geb);
                geb.GetComponent<Feld>().setAll(nr, kosten, arbeiter, ertrag, x, y);
            }
        }
    }
    private void forschungLaden()
    {
        int nr = 0;
        String spez = "";
        int anzProj = 0;
        int maxAnz = 0;
        int x = 0;
        int y = 0;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Forschungsstation.json");
        string[] split = json.Split(':');
        for (int i = 1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 6 == 0)
            {
                nr = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 1)
            {
                spez = tmp[0].Split('"')[1];
            }
            else if ((i - 1) % 6 == 2)
            {
                anzProj = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 3)
            {
                maxAnz = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 4)
            {
                x = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 5)
            {
                if (i + 1 == split.Length)
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                }
                else
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                }
                GameObject geb = Instantiate(forschungPrefab, transform);
                geb.AddComponent<Forschung>();
                geb.GetComponent<Forschung>().setAll(nr, spez, anzProj, maxAnz, x, y, dropDownProjekt, merkmalGO);
              
                Destroy(geb.GetComponent<ObjektBewegung>());
                geb.transform.parent = null;
                geb.transform.localScale = new Vector3(1, 1, 1);
                geb.transform.rotation = Quaternion.Euler(0, 0, 0);
                geb.transform.position = Testing.grid.GetWorldPosition(x, y) + new Vector3(Testing.zellengroesse / 2, Testing.zellengroesse / 2, 0);
                Testing.grid.SetWert(x, y, 3, geb);
                
            }
        }
        GebaeudeAnzeige.forschungsauswahl = false;
    }
    private void wohncontainerLaden()
    {
        int nr=0;
        int kosten = 0;
        int bettenAnz = 0;
        int freieBetten = 0;
        int x = 0;
        int y = 0;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Wohncontainer.json");
        string[] split=json.Split(':');
        for(int i =1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 6 == 0)
            {
                nr = int.Parse(tmp[0]);
            }else if((i - 1) %6 == 1)
            {
                kosten = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 2)
            {
                bettenAnz = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 3)
            {
                freieBetten = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 4)
            {
                x = int.Parse(tmp[0]);
            }
            else if ((i - 1) % 6 == 5)
            {
                if (i + 1 == split.Length)
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 2));
                }
                else
                {
                    y = int.Parse(tmp[0].Remove(tmp[0].Length - 1));
                }
                GameObject geb = Instantiate(wohncontainerPrefab, transform);
                geb.AddComponent<Wohncontainer>();
                Destroy( geb.GetComponent<ObjektBewegung>());
                geb.transform.parent = null;
                geb.transform.localScale= new Vector3(1, 1, 1);
                geb.transform.rotation = Quaternion.Euler(0,0,0);
                geb.transform.position= Testing.grid.GetWorldPosition(x, y)+new Vector3(Testing.zellengroesse/2,Testing.zellengroesse/2,0);
                Testing.grid.SetWert(x, y, 1, geb);
                geb.GetComponent<Wohncontainer>().setAll(nr, kosten, bettenAnz, freieBetten, x, y);
            }
        }
    }

    public class PlayerData
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

    public class LoadedPlayerData
    {
        public int geld;
        public int umsatz;
        public int forscher;
        public int tierpfleger;
        public int feldarbeiter;
        public int tiere ;
        public int summeMenschen ;
        public int summeTiere ;
        public int summeForschungen;

        public int marsTag ;
        public int erdenTag;

        public void setData()
        {
            Testing.geld = geld;
            Testing.umsatz = umsatz;

            Testing.forscher = forscher;
            Testing.tierpfleger =tierpfleger;
            Testing.feldarbeiter = feldarbeiter;
            Testing.tiere =tiere;
            Testing.summeMenschen =summeMenschen;
            Testing.summeTiere =summeTiere;
            Testing.summeForschungen = summeForschungen;

            SpielInfos.marsTag = marsTag;
            SpielInfos.erdenTag = erdenTag;
    }
    }
}
