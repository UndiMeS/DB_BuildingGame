using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadER : MonoBehaviour
{
    public GameObject entityPrefab;
    public GameObject erCanvas;
    public ERErstellung eRErstellung;

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
        string[] splitEntitys = json.Split(';');
        for(int i =0; i<splitEntitys.Length-1;i++)
        {
            string[] eigenschaften = splitEntitys[i].Split(',');
            eRErstellung.erstelleObjekt(entityPrefab);
            GameObject entity= ERErstellung.selectedGameObjekt ;
            entity.name = eigenschaften[0];
            
            entity.transform.localPosition = new Vector3(float.Parse(eigenschaften[1]), float.Parse(eigenschaften[3]), float.Parse(eigenschaften[5]));
            if(eigenschaften[4].Equals("true"))
            {
                entity.GetComponent<Entitaet>().schwach = true;
            }
            else
            {
                entity.GetComponent<Entitaet>().schwach = false;
            }
            
        }

    }

    private void saveBeziehung()
    {
        string ausgabe = "";
        List<GameObject> beziehungen= new List<GameObject>();

        foreach (GameObject objekt in ERErstellung.modellObjekte)
        {
            if (objekt.CompareTag("Entitaet"))
            {
                if (objekt.GetComponent<Entitaet>().schwach)
                {
                    GameObject beziehung = objekt.GetComponent<Entitaet>().schwacheBeziehung;
                    beziehungen.Add(beziehung);
                    ausgabe += beziehung.GetComponent<Beziehung>().objekt1.name + ",";
                    ausgabe += beziehung.GetComponent<Beziehung>().kard1 + ",";
                    ausgabe += beziehung.GetComponent<Beziehung>().objekt2.name + ",";
                    ausgabe += beziehung.GetComponent<Beziehung>().kard2 + ",";
                    ausgabe += true + ",";
                    ausgabe += beziehung.transform.localPosition.x + "," + beziehung.transform.localPosition.y + "," + beziehung.transform.localPosition.z + ";";
                }
                foreach (GameObject beziehung in objekt.GetComponent<Entitaet>().beziehungen)
                {
                    if (!beziehungen.Contains(beziehung))
                    {
                        beziehungen.Add(beziehung);
                        ausgabe += beziehung.GetComponent<Beziehung>().objekt1.name + ",";
                        ausgabe += beziehung.GetComponent<Beziehung>().kard1 + ",";
                        ausgabe += beziehung.GetComponent<Beziehung>().objekt2.name + ",";
                        ausgabe += beziehung.GetComponent<Beziehung>().kard2 + ",";
                        ausgabe+= false + ",";
                        ausgabe += beziehung.transform.localPosition.x + "," + beziehung.transform.localPosition.y + "," + beziehung.transform.localPosition.z + ";";
                    }
                }
            }
        }
        File.WriteAllText(Application.dataPath + "/SaveState/Beziehungen.json", ausgabe);
    }

    private void saveAttribute()
    {
        string ausgabe = "";

        foreach (GameObject objekt in ERErstellung.modellObjekte)
        {
            if (objekt.CompareTag("Entitaet"))
            {
                foreach (GameObject attribut in objekt.GetComponent<Entitaet>().attribute)
                {
                    ausgabe += objekt.name + ",";
                    ausgabe += attribut.name + ",";
                    ausgabe += attribut.transform.localPosition.x + ",";
                    ausgabe += attribut.transform.localPosition.y + ",";
                    ausgabe += attribut.transform.localPosition.z + ",";
                    ausgabe+= objekt.GetComponent<Entitaet>().primaerschluessel.Contains(attribut) + ";";
                }
               
            }
        }

        File.WriteAllText(Application.dataPath + "/SaveState/Attribut.json", ausgabe);
    }

    public void saveEntity()
    {
        string ausgabe = "";
        
        foreach (GameObject objekt in ERErstellung.modellObjekte)
        {
            if (objekt.CompareTag("Entitaet"))
            {
                ausgabe += objekt.name + ",";
                ausgabe += objekt.transform.localPosition.x + ",";
                ausgabe += objekt.transform.localPosition.y + ",";
                ausgabe+= objekt.transform.localPosition.z + ",";
                ausgabe += objekt.GetComponent<Entitaet>().schwach + ";";                
            }
        }

        File.WriteAllText(Application.dataPath + "/SaveState/Entity.json", ausgabe);
    }
}
