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
        json = json.Remove(0, 1);
        json = json.Remove(json.Length - 1);
        foreach(string str in json.Split(','))
        {
            eRErstellung.erstelleObjekt(prefabEntity);
            Entitaet tmp = JsonUtility.FromJson<Entitaet>(str);
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().setWerte(tmp);
            ERErstellung.selectedGameObjekt.transform.position = new Vector3(tmp.x, tmp.y, 0);
        }
        
       
            
            
            /*string name = "";
        bool schwach = false;
        int instanceID = 0;
        int vaterID;
        int schwacheBezID;
        List<int> attributID= new List<int>();
        List<int> primaerschluesselID= new List<int>();
        List<int> beziehungsID= new List<int>();
        int x;
        int y;

        string json = File.ReadAllText(Application.dataPath + "/SaveState/Entity.json");
        
        string[] split = json.Split(':');
        for (int i = 1; i < split.Length; i++)
        {
            string[] tmp = split[i].Split(',');
            if ((i - 1) % 10 == 0)
            {
                name = tmp[0];
            }else if ((i - 1) % 10 == 1)
            {
                schwach =bool.Parse( tmp[1]);
            }
            else if ((i - 1) % 10 == 2)
            {
                instanceID = int.Parse(tmp[2]);
            }
            else if ((i - 1) % 10 == 3)
            {
                string[] temp= tmp[3].Split(':');
                vaterID = int.Parse(temp[1]);
            }
            else if ((i - 1) % 10 == 4)
            {
                string[] temp = tmp[4].Split(':');
                schwacheBezID = int.Parse(temp[1]);
            }
            else if ((i - 1) % 10 == 5)
            {
                string[] temp = tmp[5].Split(':');
                for (int k =1; k < temp.Length; k =+ 2)
                {
                    attributID.Add( int.Parse(temp[k]));
                }                
            }
            else if ((i - 1) % 10 == 6)
            {
                string[] temp = tmp[6].Split(':');
                
                for (int k = 1; k < temp.Length; k = +2)
                {
                    primaerschluesselID.Add(int.Parse(temp[k]));
                }
            }*/


        //nr = int.Parse(tmp[0]);
        //}
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
    class LoadedEntitys
    {
        public List<LoadedEntity> liste;
    }
    class LoadedEntity
    {
        string name;
        bool schwach;
        int instanceID;
        int vaterID;
        int schwacheBezID;
        List<int> attributID = new List<int>();
        List<int> primaerschluesselID = new List<int>();
        List<int> beziehungsID = new List<int>();
        int x;
        int y;

        public void set(ERErstellung eRErstellung, GameObject prefabEntity)
        {
            eRErstellung.erstelleObjekt(prefabEntity);
            ERErstellung.selectedGameObjekt.transform.position = new Vector3(x, y, 0);
        }
    }
}
