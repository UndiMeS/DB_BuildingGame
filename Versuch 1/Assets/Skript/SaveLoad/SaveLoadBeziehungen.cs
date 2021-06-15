using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadBeziehungen : MonoBehaviour
{
    public void speichern()
    {
        string json = "[";
        AstronautFeldspaehre bezObj = new AstronautFeldspaehre();
        int zaehler = 0;
        foreach (Feld feld in Testing.felder)
        {
            for(int i=0;i< feld.arbeiter; i++)
            {
                bezObj.feldnummer = feld.feldnummer;
                while (Testing.menschen[zaehler].aufgabe != "Feld")
                {
                    zaehler++;
                }
                bezObj.name = Testing.menschen[zaehler].name;
                bezObj.geburtstag = Testing.menschen[zaehler].geburtstag;
                zaehler++;
                json += JsonUtility.ToJson(bezObj) + ",";
            }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Application.dataPath + "/SaveState/DB/AstronautFeldspaehre.json", json);
    }


    private class AstronautFeldspaehre
    {
        public int feldnummer;
        public string name;
        public string geburtstag;
    }
}
