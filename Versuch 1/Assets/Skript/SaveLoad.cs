using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        
    }


    public void speichern()
    {
        playerData = new PlayerData();
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);

        

    }

    public void laden()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        PauseMenu.SpielIstPausiert = false;
        KameraKontroller.aktiviert = true;

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        LoadedPlayerData loadedplayerData = JsonUtility.FromJson<LoadedPlayerData>(json);
        loadedplayerData.setData();
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
