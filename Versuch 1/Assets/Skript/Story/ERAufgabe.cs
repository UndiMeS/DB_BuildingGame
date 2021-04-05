using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERAufgabe : MonoBehaviour
{
    private string[] aufgabe= { "Um den Mars zu besiedeln, müssen Astronauten eingeflogen werden. Damit diese auf dem Planeten leben können, werden <mark=#eb4034aa> Wohncontainer </mark>benötigt. Dafür wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte <mark=#71eb2f80> Baukosten </mark>eine genaue<mark=#71eb2f80> Bettenzahl</mark>, die die Menge an beherbergbaren Astronauten ausdrückt und ein Attribut für noch <mark=#71eb2f80>freie Betten</mark>. Jeder Container hat in der Siedlung eine eindeutige<mark=#71eb2f80> Containernummer</mark>, der Primärschlüssel." };
    private string[] listeEnity = { "Wohncontainer" };
    private string[][] wohncontainer = { new string[] { "1", "Kosten", "Baukosten" }, new string[] { "2", "Containernummer" }, new string[] { "3", "Bettenzahl", "Bettenanzahl", "Betten" }, new string[] { "4", "freie Betten", "freieBetten" } };
    private string[][][] listeAttribute = new string[1][][];
    private int[][] primarschluessel = {new int[]{0,1,0,0} };

    private int[] entitysRichtig = { 1, 0 };
    private int[] attributeRichtig = { 5, 0 }; //++ pro Primärschlüssel
    private int[] beziehungenRichtig = { 0, 0 };

    private int[] entitysHat;
    private int[] attributeHat;
    private int[] beziehungenHat;

    public GameObject dasIstSchonFertig;
    public GameObject aufgabenText;
    public PauseMenu pauseMenu;
 

    // Start is called before the first frame update
    void Start()
    {
        listeAttribute[0]= wohncontainer;
        Utilitys.TextInTMP(dasIstSchonFertig, "");
    } 

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(aufgabenText, aufgabe[Story.level]);
        checkObjekte();
    }

    private void checkObjekte()
    {
        entitysHat = new int[entitysRichtig.Length];
        attributeHat = new int[attributeRichtig.Length];
        beziehungenHat = new int[beziehungenRichtig.Length];

        string fertig="";
        int indexEntity = 0;
        foreach(string entityName in listeEnity)
        {

            foreach(GameObject entity in ERErstellung.modellObjekte)
            {
                if (entity.name.Equals(entityName))
                {
                    entitysHat[indexEntity]++;
                    fertig += entityName + ": ";
                   fertig = checkAttribute(indexEntity,entity,fertig);
                }
            }

            indexEntity++;
        }

        if (checkAllesRichtig()) {
            FehlerAnzeige.fehlertext = "Du hast alles richtig gemacht!";
            Invoke("schliessen", 5);
        }
            
        //Utilitys.TextInTMP(dasIstSchonFertig, fertig);
    }

    private bool checkAllesRichtig()
    {
        bool ausgabe=true;
        for(int i=0; i <= Story.level; i++)
        {
            ausgabe &= entitysHat[i] == entitysRichtig[i];
            ausgabe &= attributeHat[i] == attributeRichtig[i];
            ausgabe &= beziehungenRichtig[i] == beziehungenHat[i];
        }

        return ausgabe;
    }

    private string checkAttribute(int indexEntity, GameObject entity, string fertig)
    {
        int indexattribute = 0;
        foreach (string[] attributNamesMoeglichkeiten in listeAttribute[indexEntity])
        {
            foreach (GameObject attribut in entity.GetComponent<Entitaet>().attribute)
            {
                foreach (string attributName in attributNamesMoeglichkeiten)
                {
                    if (attribut.name.Equals(attributName))
                    {
                        attributeHat[indexEntity]++;
                        fertig += attribut.name + " ";
                        if(primarschluessel[indexEntity][indexattribute]==1&& entity.GetComponent<Entitaet>().primaerschluessel.Contains(attribut))
                        {
                            attributeHat[indexEntity]++;
                            fertig += "-PS ";
                        }
                    }
                }
            }
            indexattribute++;
        }

        return fertig;
    }

    private void schliessen()
    {
        pauseMenu.SwitchToBaumenue();
    }

}
