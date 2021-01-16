using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class ERErstellung : MonoBehaviour
{
    public static GameObject selectedGameObjekt;
    public static GameObject lastselected;
    private ArrayList modellObjekte = new ArrayList(); //Liste an Objekten in ERD, vielleicht fuer spaeter
    public GameObject linie;
    public static GameObject entitaet;
    public static GameObject attribut;
    public static GameObject beziehung;


    // Start is called before the first frame update
    // zuerst leer
    void Start()
    {
        lastselected = null;
        selectedGameObjekt = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /* wenn auf die 3 Tasten gedrueckt wird, wird das Objekt erstellt
    prefab istdas ER-Objekt (Entity, Attribut, Beziehung)*/ 
    public void erstelleObjekt(GameObject prefab)
    {
        //wenn es vorer schon ein Objekt gibt
        if (modellObjekte.Count != 0) 
        {
            selectedGameObjekt.GetComponent<ERObjekt>().selected = false;//bei ERObjekt auswahl aufloesen
            selectedGameObjekt.GetComponent<RawImage>().color = Color.white; //Objekt nicht mehr hervorgehoben/gelb
            lastselected = selectedGameObjekt;
        }
        
        GameObject temp = Instantiate(prefab, transform);

        //nur wenn vorhergehendes Objekt Entity kann Attribut erzeugt werden
        if ((temp.CompareTag("Attribut") && !(selectedGameObjekt.CompareTag("Entitaet") || modellObjekte.Count == 0)))
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else //erzeugt neues Objekt und markiert es
        {
            selectedGameObjekt = temp;
            selectedGameObjekt.transform.Translate(Screen.width / 2, Screen.height / 2, 0);
            modellObjekte.Add(selectedGameObjekt);
            selectedGameObjekt.GetComponent<RawImage>().color = Color.yellow;
            if (selectedGameObjekt.CompareTag("Attribut") && lastselected.CompareTag("Entitaet"))
            {
                zeichneLinie();
            }
        }
    }

    private void zeichneLinie()
    {
        
    }

    //Namensanpassung, hat eingabefeld als Methode
    public void giveSelectedGameObjektName(string eingabe)
    {
        if (modellObjekte.Count != 0)
        {
            selectedGameObjekt.GetComponent<ERObjekt>().nameVonObjekt = eingabe;
        }
    }

    //verändert die Farbe und aktuell ausgewaehltes/ vorheriges ER-Objekt
    public static void changeSelectedGameobjekt(GameObject newSelected)
    { 
        lastselected = selectedGameObjekt;
        
        selectedGameObjekt = newSelected;
        selectedGameObjekt.GetComponent<RawImage>().color = Color.yellow;
        if (!(lastselected==null)) { lastselected.GetComponent<RawImage>().color = Color.white;
            lastselected.GetComponent<ERObjekt>().selected = false;
        }
       
    }

    //Kennzeichnung des Primärschlüssels bei Attributen, hat Ankreuzfeld als Methode
    public void unterstreichen()
    {

        if (selectedGameObjekt.CompareTag("Attribut") && selectedGameObjekt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().fontStyle.Equals(FontStyles.Normal))
        {
            selectedGameObjekt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
        }
        else if (selectedGameObjekt.CompareTag("Attribut") && selectedGameObjekt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().fontStyle.Equals(FontStyles.Underline))
        {
            selectedGameObjekt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        }
    }
    // hat Löschknopf als Methode
    public void loeschen()
    {
        if (!(selectedGameObjekt == null))
        {
            Destroy(selectedGameObjekt.GetComponent<ERObjekt>());
            Destroy(selectedGameObjekt);
            modellObjekte.Remove(selectedGameObjekt);
            if (lastselected== null)//wenn man das erste Objekt gleich wieder loescht
            {
                selectedGameObjekt = null;
            }
            else if (!selectedGameObjekt.Equals(lastselected))//standardfall
            {
                selectedGameObjekt = lastselected;
                changeSelectedGameobjekt(lastselected);
            }
            else if (selectedGameObjekt.Equals(lastselected))//wenn man 2 Objekte hintereinander loescht und als 2. Objekt vorher ausgewaehlt hat
            {
                selectedGameObjekt = null;
                lastselected = null;
            }
        }
    }
}
