using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadER : MonoBehaviour
{
    public GameObject prefabEntity;
    public GameObject prefabAttribut;
    public GameObject prefabBeziehung;

    public GameObject erCanvas;
    public ERErstellung eRErstellung;
    public GameObject erModell;
    public GameObject leisteRechts;
    public GameObject leisteBottom;
    public GameObject aufgabentext;
    public GameObject checkliste;
    public GameObject ddSchwach;
    public GameObject dd1;
    public GameObject dd2;
    public GameObject linienordner;

    public KameraKontroller kamerakontroller;

    public Sprite schwachEntSelected;
    public Sprite schwachEnt;
    public Sprite schwachBezSelected;
    public Sprite schwachBez;

    public void speichern()
    {
        saveEntity();
        saveAttribute();
        saveBeziehung();
        saveFertigeObjekte();
    }

    public void laden()
    {
        //erCanvas.transform.position = Vector3.zero;
        kamerakontroller.changeHintergrund(1);
        ladeEntity();
        ladeAttribute();
        ladeBeziehungen();

        kamerakontroller.changeHintergrund(0);

        string json = File.ReadAllText(Application.dataPath + "/SaveState/fertigeObjekte.json");
        FertigeObjekte fertige = JsonUtility.FromJson<FertigeObjekte>(json);
        fertige.setData();

        foreach (GameObject ent in ERErstellung.modellObjekte)
        {
            if (ent.CompareTag("Entitaet"))
            {
                ent.GetComponent<Entitaet>().instanceID = ent.GetInstanceID();
            }
            if (ent.CompareTag("Attribut"))
            {
                ent.GetComponent<Attribut>().instanceID = ent.GetInstanceID();
            }
            if (ent.CompareTag("Beziehung"))
            {
                ent.GetComponent<Beziehung>().instanceID = ent.GetInstanceID();
            }
        }
    }

    private void ladeBeziehungen()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/Beziehungen.json");
        json = json.Remove(json.Length - 1);//] l�schen

        string[] split = json.Split('{');
        for (int i = 1; i < split.Length - 1; i++)
        {
            if (split[i].StartsWith("\"beziehungsName"))
            {
                LoadedBeziehung bez = JsonUtility.FromJson<LoadedBeziehung>("{" + split[i].Substring(0, split[i].Length - 11) + "}");//entfernt objekt1:
                GameObject game = Instantiate(prefabBeziehung, erModell.transform);

                game.GetComponent<Beziehung>().setWerte(bez);
                game.GetComponent<Beziehung>().setLinienordner(linienordner);
                foreach (GameObject ent in ERErstellung.modellObjekte)
                {
                    if (ent.CompareTag("Entitaet") && ent.GetComponent<Entitaet>().instanceID == game.GetComponent<Beziehung>().objekt1ID)
                    {
                        game.GetComponent<Beziehung>().linie1 = eRErstellung.zeichneLinie(ent, game);
                        game.GetComponent<Beziehung>().objekt1 = ent;
                        ent.GetComponent<Entitaet>().beziehungen.Add(game);
                        if (game.GetComponent<Beziehung>().schwach)
                        {
                            ent.GetComponent<Entitaet>().schwacheBeziehung = ERErstellung.selectedGameObjekt;
                        }
                    }
                    if (ent.CompareTag("Entitaet") && ent.GetComponent<Entitaet>().instanceID == game.GetComponent<Beziehung>().objekt2ID)
                    {
                        game.GetComponent<Beziehung>().linie2 = eRErstellung.zeichneLinie(ent, game);
                        game.GetComponent<Beziehung>().objekt2 = ent;
                        ent.GetComponent<Entitaet>().beziehungen.Add(game);
                    }
                }

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
                game.GetComponent<Beziehung>().linienOrdner = linienordner;

                game.transform.position = new Vector3(game.GetComponent<Beziehung>().x, game.GetComponent<Beziehung>().y);

                game.GetComponent<TMPro.TMP_InputField>().text = game.GetComponent<Beziehung>().name;
            }
        }
    }

    private void ladeAttribute()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveState/Attribut.json");
        json = json.Remove(json.Length - 1);//] l�schen

        string[] split = json.Split('{');
        for (int i = 1; i < split.Length - 1; i++)
        {
            if (split[i].StartsWith("\"attributName"))
            {
                LoadedAttribut attribut = JsonUtility.FromJson<LoadedAttribut>("{" + split[i].Substring(0, split[i].Length - 9) + "}");//entfernt vater:
                GameObject game = Instantiate(prefabAttribut, erModell.transform);

                game.GetComponent<Attribut>().setWerte(attribut);
                foreach (GameObject ent in ERErstellung.modellObjekte)
                {
                    if (ent.CompareTag("Entitaet") && ent.GetComponent<Entitaet>().instanceID == game.GetComponent<Attribut>().vaterID)
                    {
                        game.transform.SetParent(ent.transform);
                        eRErstellung.zeichneLinie(ent, game);
                        ent.GetComponent<Entitaet>().attribute.Add(game);
                        game.GetComponent<Attribut>().vater = ent;
                        if (game.GetComponent<Attribut>().primaerschluessel)
                        {
                            ent.GetComponent<Entitaet>().primaerschluessel.Add(ERErstellung.selectedGameObjekt);
                            game.transform.GetChild(1).GetChild(2).transform.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
                        }
                    }
                }

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

                game.transform.position = new Vector3(game.GetComponent<Attribut>().x, game.GetComponent<Attribut>().y);

                game.GetComponent<TMPro.TMP_InputField>().text = game.GetComponent<Attribut>().name;
            }
        }
    }

    private void ladeEntity()
    {
        ERErstellung.modellObjekte.Clear();

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Entity.json");
        json = json.Remove(json.Length - 1);//] l�schen

        string[] split = json.Split('{');
        for (int i = 1; i < split.Length - 1; i++)
        {
            if (split[i].StartsWith("\"entitaetsName"))
            {
                GameObject game = Instantiate(prefabEntity, erModell.transform);
                LoadedEntity ent = JsonUtility.FromJson<LoadedEntity>("{" + split[i].Substring(0, split[i].Length - 17) + "}");//17="vaterentitaet"
                game.GetComponent<Entitaet>().setWerte(ent);
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

                if (game.GetComponent<Entitaet>().schwach)
                {
                    game.GetComponent<ERObjekt>().originalSprite = schwachEnt;
                    game.GetComponent<ERObjekt>().selectedSprite = schwachEntSelected;
                }

                game.transform.position = new Vector3(game.GetComponent<Entitaet>().x, game.GetComponent<Entitaet>().y);
                game.GetComponent<TMPro.TMP_InputField>().text = game.GetComponent<Entitaet>().name;
            }
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

    private void saveEntity()
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

    private void saveFertigeObjekte()
    {
        FertigeObjekte fertigObjekte = new FertigeObjekte();
        fertigObjekte.instanceIDsErstellen();
        string json = JsonUtility.ToJson(fertigObjekte);
        File.WriteAllText(Application.dataPath + "/SaveState/fertigeObjekte.json", json);
    }

    private class FertigeObjekte
    {
        public List<int> fertigeInstanceID;

        public void instanceIDsErstellen()
        {
            fertigeInstanceID = new List<int>();
            if (ERAufgabe.gespeicherteObjekte != null) { 
            foreach (GameObject game in ERAufgabe.gespeicherteObjekte)
            {
               
                    fertigeInstanceID.Add(game.GetInstanceID());
               
            }
            }
        }

        public void setData()
        {
           foreach(GameObject game in ERErstellung.modellObjekte)
            {
                if(game!= null &&(game.CompareTag("Entitaet")&& fertigeInstanceID.Contains(game.GetComponent<Entitaet>().instanceID)
                    || game.CompareTag("Attribut") && fertigeInstanceID.Contains(game.GetComponent<Attribut>().instanceID)
                    || game.CompareTag("Beziehung") && fertigeInstanceID.Contains(game.GetComponent<Beziehung>().instanceID)))
                {
                    ERAufgabe.gespeicherteObjekte.Add(game);
                }
                
            }
            ERAufgabe.gespeicherteObjekteAus();
        }
    }

}
