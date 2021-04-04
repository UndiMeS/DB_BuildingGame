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
    public Canvas erModellflaeche;

    public static GameObject entitaet;
    public static GameObject attribut;
    public static GameObject beziehung;

    public static GameObject entitaetOberflaeche;
    public static GameObject attributOberflaeche;
    public static GameObject beziehOberflaeche;

    public Texture entity;
    public Texture schwachEntity;

    public GameObject leisteRechts;
    public GameObject leisteBottom;

    // Start is called before the first frame update
    // zuerst leer
    void Start()
    {
        lastselected = null;
        selectedGameObjekt = null;

        entitaetOberflaeche = gameObject.transform.GetChild(1).gameObject;
        attributOberflaeche = gameObject.transform.GetChild(2).gameObject;
        beziehOberflaeche = gameObject.transform.GetChild(3).gameObject;
    }


    /* wenn auf die 3 Tasten gedrueckt wird, wird das Objekt erstellt
    prefab istdas ER-Objekt (Entity, Attribut, Beziehung)*/
    public void erstelleObjekt(GameObject prefab)
    {
        //wenn es vorer schon ein Objekt gibt
        if (modellObjekte.Count != 0&& selectedGameObjekt!= null)
        {
            selectedGameObjekt.GetComponent<ERObjekt>().selected = false;//bei ERObjekt auswahl aufloesen
        }

        GameObject temp = Instantiate(prefab, transform);
        temp.transform.position=Utilitys.GetMouseWorldPosition(new Vector3(Screen.width / 4, Screen.height / 4, 0));

        
        //nur wenn vorhergehendes Objekt Entity kann Attribut erzeugt werden
        if (temp.CompareTag("Attribut") && modellObjekte.Count == 0)
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        if (temp.CompareTag("Attribut") && !selectedGameObjekt.CompareTag("Entitaet") )
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else //erzeugt neues Objekt und markiert es
        {
            temp.GetComponent<ERObjekt>().canvas = erModellflaeche;
            modellObjekte.Add(temp);
            changeSelectedGameobjekt(temp);
            selectedGameObjekt.transform.SetParent(erModellflaeche.transform);
            if (selectedGameObjekt.CompareTag("Attribut"))
            {
                selectedGameObjekt.transform.SetParent(lastselected.transform);
                lastselected.GetComponent<Entitaet>().attribute.Add(selectedGameObjekt);

            }
            
            selectedGameObjekt.transform.position = Utilitys.GetMouseWorldPosition(new Vector3(Screen.width / 4, Screen.height / 4, 0));
            selectedGameObjekt.GetComponent<ERObjekt>().leisteBottom = leisteBottom;
            selectedGameObjekt.GetComponent<ERObjekt>().leisteRechts = leisteRechts;
            
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

    


    //verändert die Farbe und aktuell ausgewaehltes/ vorheriges ER-Objekt
    public static void changeSelectedGameobjekt(GameObject newSelected)
    {
        lastselected = selectedGameObjekt;
        selectedGameObjekt = newSelected;
        selectedGameObjekt.GetComponent<ERObjekt>().changeSprite(true);

        if (lastselected != null&& modellObjekte.Count!=1&& !lastselected.Equals(selectedGameObjekt))
        {
            
            lastselected.GetComponent<ERObjekt>().selected = false;
            lastselected.GetComponent<ERObjekt>().changeSprite(false);
       }
        
        changeOberflaeche();

        
    }

  
    // hat Löschknopf als Methode
    public void loeschen()
    {
        if (selectedGameObjekt != null)
        {
            modellObjekte.Remove(selectedGameObjekt);
            if (selectedGameObjekt.CompareTag("Entitaet")&&selectedGameObjekt.GetComponent<Entitaet>().schwach)
            {
                modellObjekte.Remove(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                Destroy(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            }
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
        /*Vector3 position = objekt.transform.position;
        int abstandX = (int)Math.Abs(mousePosition.x - position.x);
        int abstandY = (int)Math.Abs(mousePosition.y - position.y);
        bool drin = abstandX < objekt.GetComponent<RectTransform>().sizeDelta.x / 2 && abstandY < objekt.GetComponent<RectTransform>().sizeDelta.y / 2;
        */
        bool drin = RectTransformUtility.RectangleContainsScreenPoint(objekt.GetComponent<RectTransform>(), mousePosition, Camera.main);
        return drin;
    }



    private static void changeOberflaeche()
    {
        if (selectedGameObjekt.CompareTag("Entitaet")){
            entitaetOberflaeche.SetActive(true);
            attributOberflaeche.SetActive(false);
            beziehOberflaeche.SetActive(false);
        }else if(selectedGameObjekt.CompareTag("Attribut")){
            entitaetOberflaeche.SetActive(false);
            attributOberflaeche.SetActive(true);
            beziehOberflaeche.SetActive(false);
        }
        else {
            entitaetOberflaeche.SetActive(false);
            attributOberflaeche.SetActive(false);
            beziehOberflaeche.SetActive(true);
        }
       
    }
}
