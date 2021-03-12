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


    public void speichern()
    {
        playerData = new PlayerData();
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);

        json = "[";
        foreach (Wohncontainer wohn in Testing.wohncontainer)
        {
            json +=JsonUtility.ToJson(wohn)+",";
        }
        json = json.Remove(json.Length - 1)+"]";
        File.WriteAllText(Application.dataPath + "/Wohncontainer.json", json);

        json = "[";
        foreach (Feld feld in Testing.felder)
        {
            json += JsonUtility.ToJson(feld) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/Feldsphaere.json", json);

        json = "[";
        foreach (Forschung obj in Testing.forschungsstationen)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/Forschungsstation.json", json);

        json = "[";
        foreach (Projekt obj in Testing.forschungsprojekte)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/Forschungsprojekte.json", json);

        json = "[";
        foreach (Weide obj in Testing.weiden)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/Weidesphaere.json", json);

        json = "[";
        foreach (Stallcontainer obj in Testing.stallcontainer)
        {
            json += JsonUtility.ToJson(obj) + ",";
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/Stallcontainer.json", json);
    }

    public void laden()
    {
        

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        LoadedPlayerData loadedplayerData = JsonUtility.FromJson<LoadedPlayerData>(json);
        loadedplayerData.setData();

        wohncontainerLaden();
    }

    private void wohncontainerLaden()
    {
        int nr=0;
        int kosten = 0;
        int bettenAnz = 0;
        int freieBetten = 0;
        int x = 0;
        int y = 0;

        string json = File.ReadAllText(Application.dataPath + "/Wohncontainer.json");
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
