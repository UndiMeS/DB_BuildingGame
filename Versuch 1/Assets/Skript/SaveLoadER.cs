using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadER : MonoBehaviour
{

    public GameObject erCanvas;
    public ERErstellung eRErstellung;
    public GameObject prefabEntity;

    public GameObject erModell;
    public GameObject leisteRechts;
    public GameObject leisteBottom;
    public GameObject aufgabentext;
    public GameObject checkliste;

    public GameObject ddSchwach;
    public GameObject dd1;
    public GameObject dd2;


    public void speichern()
    {
        saveEntity();
        saveAttribute();
        saveBeziehung();       
    }

    public void laden()
    {
        erCanvas.transform.position = Vector3.zero;
        ladeEntity();
    }

    private void ladeEntity()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/Entity.json");
        json = json.Remove(json.Length - 1);//] löschen
        string[] split = json.Split('}');
        for (int i = 0; i < split.Length - 1; i++)
        {
            GameObject game = Instantiate(prefabEntity, erModell.transform);
            ERErstellung.selectedGameObjekt = game;
            JsonUtility.FromJsonOverwrite(split[i].Remove(0, 1) + "}", game.GetComponent<Entitaet>());//entfernt ,       
            game.GetComponent<ERObjekt>().canvas = erModell.GetComponent<Canvas>();
            ERErstellung.modellObjekte.Add(game);
            ERErstellung.changeSelectedGameobjekt(game);
            game.GetComponent<ERObjekt>().leisteBottom = leisteBottom;
            game.GetComponent<ERObjekt>().leisteRechts = leisteRechts;
            game.GetComponent<ERObjekt>().aufgabe = aufgabentext;
            game.GetComponent<ERObjekt>().checkliste = checkliste;
            game.GetComponent<ERObjekt>().dd1 = dd1;
            game.GetComponent<ERObjekt>().dd2 = dd2;
            game.GetComponent<ERObjekt>().dd3 = ddSchwach;

            game.transform.position = new Vector3(game.GetComponent<Entitaet>().x, game.GetComponent<Entitaet>().y);
        }
        }

    private void saveBeziehung()
    {
        string json = "[";
        foreach (GameObject ent in ERErstellung.modellObjekte)
        {
            if (ent.CompareTag("Beziehung"))
            {
                json += JsonUtility.ToJson(ent.GetComponent<Beziehung>()) + ",";
            }

        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Beziehungen.json", json);
    }

    private void saveAttribute()
    {
        string json = "[";
        foreach (GameObject ent in ERErstellung.modellObjekte)
        {
            if (ent.CompareTag("Attribut"))
            {
                json += JsonUtility.ToJson(ent.GetComponent<Attribut>()) + ",";
            }

        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Attribut.json", json);
    }

    public void saveEntity()
    {
        string json = "[";
        foreach (GameObject ent in ERErstellung.modellObjekte)
        {
            if (ent.CompareTag("Entitaet"))
            {
                json += JsonUtility.ToJson(ent.GetComponent<Entitaet>()) + ",";
            }
            
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/Entity.json", json);
    }
    
}
