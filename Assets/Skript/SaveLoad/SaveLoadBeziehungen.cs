using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadBeziehungen : MonoBehaviour
{
    public void speichern()
    {
        //astronautFeldspaehre();
        //astronautForschungsstation();
        //astronautForschungsprojekte();
        //astronautWeidespaehre();
        //nutztiereWeidespaehre();
        //forschungsprojektForschungsprojekt();
        forschungsprojektWohncontainer();
        forschungsprojektWeidesphaere();
        forschungsprojektFeldsphaere();
        forschungsprojektStallcontainer();
    }

    //Methoden
    private void forschungsprojektStallcontainer()
    {
        string json = "[";
        ForschungsprojektStallcontainer bezObj = new ForschungsprojektStallcontainer();
        foreach (Forschung fors in Testing.forschungsstationen)
        {
            if (fors.spezialisierung == "Stallcontainer")
            {
                bezObj.stationsnummer = fors.stationsnummer;
                foreach (Projekt pro in fors.projekte)
                {
                    if (pro.merkmal != "Projektkosten")
                    {
                        bezObj.forschungsattribut = pro.merkmal;
                        bezObj.forschungsstufe = pro.stufe;
                        foreach (Stallcontainer stall in Testing.stallcontainer)
                        {
                            if (pro.merkmal == "Baukosten" && stall.baukosten <= pro.verbesserterWert ||
                                pro.merkmal == "Gehegezahl" && stall.gehegezahl <= pro.verbesserterWert )
                            {
                                bezObj.containernummer = stall.containernummer;
                                json += JsonUtility.ToJson(bezObj) + ",";
                            }
                        }
                    }
                }
            }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/ForschungsprojektStallcontainer.json", json);
    }
    private void forschungsprojektFeldsphaere()
    {
        string json = "[";
        ForschungsprojektFeldsphaere bezObj = new ForschungsprojektFeldsphaere();
        foreach (Forschung fors in Testing.forschungsstationen)
        {
            if (fors.spezialisierung == "Feldsphäre")
            {
                bezObj.stationsnummer = fors.stationsnummer;
                foreach (Projekt pro in fors.projekte)
                {
                    if (pro.merkmal != "Projektkosten")
                    {
                        bezObj.forschungsattribut = pro.merkmal;
                        bezObj.forschungsstufe = pro.stufe;
                        foreach (Feld feld in Testing.felder)
                        {
                            if (pro.merkmal == "Baukosten" && feld.baukosten <= pro.verbesserterWert ||
                                pro.merkmal == "Arbeiterzahl" && feld.arbeiter <= pro.verbesserterWert||
                                pro.merkmal == "Ertrag" && feld.ertrag <= pro.verbesserterWert)
                            {
                                bezObj.feldnummer = feld.feldnummer;
                                json += JsonUtility.ToJson(bezObj) + ",";
                            }
                        }
                    }
                }
            }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/ForschungsprojektFeldsphaere.json", json);
    }
    private void forschungsprojektWohncontainer()
    {
        string json = "[";
        ForschungsprojektWohncontainer bezObj = new ForschungsprojektWohncontainer();
        foreach (Forschung fors in Testing.forschungsstationen)
        {
            if (fors.spezialisierung == "Wohncontainer")
            {
                bezObj.stationsnummer = fors.stationsnummer;
                foreach (Projekt pro in fors.projekte)
                {
                    if (pro.merkmal != "Projektkosten")
                    {
                        bezObj.forschungsattribut = pro.merkmal;
                        bezObj.forschungsstufe = pro.stufe;
                        foreach (Wohncontainer wohn in Testing.wohncontainer)
                        {
                            if (pro.merkmal == "Baukosten" && wohn.baukosten <= pro.verbesserterWert ||
                                pro.merkmal == "Bettenanzahl" && wohn.bettenanzahl <= pro.verbesserterWert )
                            {
                                bezObj.containernummer = wohn.containernummer;
                                json += JsonUtility.ToJson(bezObj) + ",";
                            }
                        }
                    }
                }
            }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/ForschungsprojektWohncontainer.json", json);
    }
    private void forschungsprojektWeidesphaere()
    {
        string json = "[";
        ForschungsprojektWeidesphaere bezObj = new ForschungsprojektWeidesphaere();
        foreach (Forschung fors in Testing.forschungsstationen)
        {
            if(fors.spezialisierung== "Weidesphäre")
            {
                bezObj.stationsnummer = fors.stationsnummer;
                foreach(Projekt pro in fors.projekte)
                {
                    if(pro.merkmal != "Projektkosten")
                    {
                        bezObj.forschungsattribut = pro.merkmal;
                        bezObj.forschungsstufe = pro.stufe;
                        foreach(Weide weide in Testing.weiden)
                        {
                            if(pro.merkmal== "Baukosten"&& weide.baukosten <=pro.verbesserterWert||
                                pro.merkmal == "Arbeiterzahl" && weide.arbeiter <= pro.verbesserterWert||
                                pro.merkmal == "Ertrag" && weide.ertrag >= pro.verbesserterWert||
                                pro.merkmal == "Tieranzahl" && weide.tiere <= pro.verbesserterWert)
                            {
                                bezObj.weidenummer = weide.weidennummer;
                                json += JsonUtility.ToJson(bezObj) + ",";
                            }
                        }                        
                    }
                }
            }
            
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/ForschungsprojektWeidesphaere.json", json);
    }
    private void forschungsprojektForschungsprojekt()
    {
        string json = "[";
        ForschungsprojektForschungsprojekt bezObj = new ForschungsprojektForschungsprojekt();
        foreach (Projekt pro in Testing.forschungsprojekte)
        {
           if(pro.merkmal== "Projektkosten")
            {
                bezObj.stationsnummer1 = pro.stationsnummer;
                bezObj.forschungsstufe1 = pro.stufe;
                bezObj.forschungsattribut1 = pro.merkmal;
                foreach (Forschung fors in Testing.forschungsstationen)
                {
                   
                    if (fors.stationsnummer == pro.stationsnummer)
                    {
                        foreach(Projekt proj in fors.projekte)
                        {
                            if (!proj.Equals(pro))
                            {
                                bezObj.stationsnummer2 = proj.stationsnummer;
                                bezObj.forschungsstufe2 = proj.stufe;
                                bezObj.forschungsattribut2 = proj.merkmal;
                                json += JsonUtility.ToJson(bezObj) + ",";
                            }
                        }
                    }
                }
           }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/ForschungsprojektForschungsprojekt.json", json);
    }
    private void nutztiereWeidespaehre()
    {
        string json = "[";
        NutztierWeidespaehre bezObj = new NutztierWeidespaehre();
        int zaehler = 0;
        foreach (Weide weide in Testing.weiden)
        {
            for (int i = 0; i < weide.tiere; i++)
            {
                bezObj.weidenummer = weide.weidennummer;
                bezObj.name = Testing.tier[zaehler].tiername;
                bezObj.art = Testing.tier[zaehler].art;
                zaehler++;
                json += JsonUtility.ToJson(bezObj) + ",";
            }
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/NutztierWeidespaehre.json", json);
    }
    private void astronautWeidespaehre()
    {
        string json = "[";
        AstronautWeidespaehre bezObj = new AstronautWeidespaehre();
        int zaehler = 0;
        foreach (Weide weide in Testing.weiden)
        {
            for (int i = 0; i < weide.arbeiter; i++)
            {
                bezObj.weidenummer = weide.weidennummer;
                while (Testing.menschen[zaehler].aufgabe != "Weide")
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
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/AstronautWeidespaehre.json", json);
    }
    private void astronautForschungsprojekte()
    {
        string json = "[";
        AstronautForschungsprojekt bezObj = new AstronautForschungsprojekt();
        int zaehler = 0;
        foreach (Projekt fors in Testing.forschungsprojekte)
        {
            for (int i = 0; i < fors.forscheranzahl; i++)
            {
                bezObj.stationsnummer = fors.stationsnummer;
                bezObj.forschungsattribut = fors.merkmal;
                bezObj.forschungsstufe = fors.stufe;
                while (Testing.menschen[zaehler].aufgabe != "Forschung")
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
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/AstronautForschungsprojekt.json", json);
    }
    private void astronautForschungsstation()
    {
        string json = "[";
        AstronautForschungsstation bezObj = new AstronautForschungsstation();
        int zaehler = 0;
        foreach (Forschung fors in Testing.forschungsstationen)
        {
            
                bezObj.stationsnummer = fors.stationsnummer;
                while (Testing.menschen[zaehler].aufgabe != "Forschung")
                {
                    zaehler++;
                }
                bezObj.name = Testing.menschen[zaehler].name;
                bezObj.geburtstag = Testing.menschen[zaehler].geburtstag;
                zaehler++;
                json += JsonUtility.ToJson(bezObj) + ",";
            
        }
        json = json.Remove(json.Length - 1) + "]";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/AstronautForschungsstation.json", json);
    }
    private void astronautFeldspaehre()
    {
        string json = "[";
        AstronautFeldspaehre bezObj = new AstronautFeldspaehre();
        int zaehler = 0;
        foreach (Feld feld in Testing.felder)
        {
            for (int i = 0; i < feld.arbeiter; i++)
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
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/SphERe_Speicherdaten/Datenbank/AstronautFeldspaehre.json", json);
    }



    //Klassen
    private class AstronautFeldspaehre
    {
        public int feldnummer;
        public string name;
        public string geburtstag;
    }
    private class AstronautForschungsstation
    {
        public int stationsnummer;
        public string name;
        public string geburtstag;
    }
    private class AstronautForschungsprojekt
    {
        public int stationsnummer;
        public string forschungsattribut;
        public int forschungsstufe;
        public string name;
        public string geburtstag;
    }
    private class AstronautWeidespaehre
    {
        public int weidenummer;
        public string name;
        public string geburtstag;
    }
    private class NutztierWeidespaehre
    {
        public int weidenummer;
        public string name;
        public string art;
    }
    private class ForschungsprojektForschungsprojekt
    {
        public int stationsnummer1;
        public int forschungsstufe1;
        public string forschungsattribut1;
        public int stationsnummer2;
        public int forschungsstufe2;
        public string forschungsattribut2;
    }
    private class ForschungsprojektWohncontainer
    {
        public int stationsnummer;
        public int forschungsstufe;
        public string forschungsattribut;
        public int containernummer;
    }
    private class ForschungsprojektWeidesphaere
    {
        public int stationsnummer;
        public int forschungsstufe;
        public string forschungsattribut;
        public int weidenummer;
    }
    private class ForschungsprojektFeldsphaere
    {
        public int stationsnummer;
        public int forschungsstufe;
        public string forschungsattribut;
        public int feldnummer;
    }
    private class ForschungsprojektStallcontainer
    {
        public int stationsnummer;
        public int forschungsstufe;
        public string forschungsattribut;
        public int containernummer;
    }
}
