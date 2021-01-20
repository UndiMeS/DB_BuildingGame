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
    public static ArrayList modellObjekte = new ArrayList(); //Liste an Objekten in ERD, vielleicht fuer spaeter

    public GameObject linie;
    public GameObject linienOrdner;
    public GameObject erModellflaeche;

    public static GameObject entitaet;
    public static GameObject attribut;
    public static GameObject beziehung;

    public static GameObject entitaetOberflaeche;
    public static GameObject attributOberflaeche;
    public static GameObject beziehOberflaeche;

    public Texture entity;
    public Texture schwachEntity;


    // Start is called before the first frame update
    // zuerst leer
    void Start()
    {
        lastselected = null;
        selectedGameObjekt = null;

        entitaetOberflaeche = gameObject.transform.GetChild(3).gameObject;
        attributOberflaeche = gameObject.transform.GetChild(4).gameObject;
        beziehOberflaeche = gameObject.transform.GetChild(5).gameObject;

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
        if (temp.CompareTag("Attribut") && !(selectedGameObjekt.CompareTag("Entitaet") || modellObjekte.Count == 0))
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else //erzeugt neues Objekt und markiert es
        {
            selectedGameObjekt = temp;
            selectedGameObjekt.transform.SetParent(erModellflaeche.transform);
            if (selectedGameObjekt.CompareTag("Attribut"))
            {
                selectedGameObjekt.transform.SetParent(lastselected.transform);
            }
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
        GameObject templinie = Instantiate(linie, transform);

        templinie.GetComponent<Linienzeichner>().setzeGameObjekte(lastselected, selectedGameObjekt);
        templinie.GetComponent<Linienzeichner>().zeichnen = true;
        templinie.transform.SetParent(linienOrdner.transform);
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
        if (lastselected != null)
        {
            lastselected.GetComponent<RawImage>().color = Color.white;
            lastselected.GetComponent<ERObjekt>().selected = false;
        }
        changeOberflaeche();

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
        if (selectedGameObjekt != null)
        {
            modellObjekte.Remove(selectedGameObjekt);
            for(int i =0; i< selectedGameObjekt.transform.childCount; i++)
            {
                modellObjekte.Remove(selectedGameObjekt.transform.GetChild(i).gameObject);
            }            
            Destroy(selectedGameObjekt.GetComponent<ERObjekt>());
            Destroy(selectedGameObjekt);
            
            if (lastselected == null)//wenn man das erste Objekt gleich wieder loescht
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

    public static GameObject testAufGleicherPosition(Vector3 pos)
    {
        foreach (GameObject objekt in modellObjekte)
        {
            if (checkMausIn(pos, objekt))
            {
                return objekt;
            }
        }
        return null;
    }

    private static bool checkMausIn(Vector3 mousePosition, GameObject objekt)
    {
        Vector3 position = objekt.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < objekt.GetComponent<RectTransform>().sizeDelta.x / 2 && abstandY < objekt.GetComponent<RectTransform>().sizeDelta.y / 2;
        return drin;
    }

    public void schwacheEntity()
    {
        if (selectedGameObjekt.CompareTag("Entitaet"))
        {
            if (selectedGameObjekt.GetComponent<RawImage>().texture.Equals(entity)){
                selectedGameObjekt.GetComponent<RawImage>().texture = schwachEntity;
            }
            else
            {
                selectedGameObjekt.GetComponent<RawImage>().texture = entity;
            }
        }
    }

    private static void changeOberflaeche()
    {
        GameObject oberflaeche;
        if (selectedGameObjekt.CompareTag("Entitaet")){
            entitaetOberflaeche.SetActive(true);
            attributOberflaeche.SetActive(false);
            beziehOberflaeche.SetActive(false);
             oberflaeche = entitaetOberflaeche;
        }else if(selectedGameObjekt.CompareTag("Attribut")){
            entitaetOberflaeche.SetActive(false);
            attributOberflaeche.SetActive(true);
            beziehOberflaeche.SetActive(false);
             oberflaeche = attributOberflaeche;
        }
        else {
            entitaetOberflaeche.SetActive(false);
            attributOberflaeche.SetActive(false);
            beziehOberflaeche.SetActive(true);
             oberflaeche = beziehOberflaeche;
        }
        GameObject inputfield = oberflaeche.transform.GetChild(0).gameObject;
        GameObject textArea = inputfield.transform.GetChild(0).gameObject;
        GameObject text = textArea.transform.GetChild(2).gameObject;

        Utilitys.TextInTMP(text, selectedGameObjekt.name);
    }
}
