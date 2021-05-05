using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;

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

    public  GameObject entitaetOberflaeche;
    public  GameObject attributOberflaeche;
    public  GameObject beziehOberflaeche;

    public Texture entity;
    public Texture schwachEntity;

    public GameObject leisteRechts;
    public GameObject leisteBottom;
    public static bool schwach=false;

    // Start is called before the first frame update
    // zuerst leer
    void Start()
    {
        lastselected = null;
        selectedGameObjekt = null;
        modellObjekte.Clear();
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
        if (temp.CompareTag("Beziehung"))
        {
            temp.GetComponent<Beziehung>().setLinienordner(linienOrdner);
        }

        //nur wenn vorhergehendes Objekt Entity kann Attribut erzeugt werden
        if (temp.CompareTag("Attribut") && modellObjekte.Count == 0)
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else if (temp.CompareTag("Attribut") && selectedGameObjekt!= null &&(!selectedGameObjekt.CompareTag("Entitaet") &&!selectedGameObjekt.CompareTag("Attribut")))
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
            if (selectedGameObjekt.CompareTag("Attribut") && lastselected.CompareTag("Entitaet"))
            {
                selectedGameObjekt.transform.SetParent(lastselected.transform);
                zeichneLinie(lastselected, selectedGameObjekt);
                lastselected.GetComponent<Entitaet>().attribute.Add(selectedGameObjekt);
                selectedGameObjekt.GetComponent<Attribut>().vater = lastselected;
            }
            else if (selectedGameObjekt.CompareTag("Attribut") && lastselected.CompareTag("Attribut"))
            {
                GameObject vater = lastselected.GetComponent<Attribut>().vater;
                vater.GetComponent<Entitaet>().attribute.Add(selectedGameObjekt);
                zeichneLinie(selectedGameObjekt, vater);
                selectedGameObjekt.transform.SetParent(vater.transform);
                selectedGameObjekt.GetComponent<Attribut>().vater = vater;
            }

            Random rand = new Random();
            temp.transform.position = Utilitys.GetMouseWorldPosition(new Vector3(rand.Next(Screen.width / 10, 9 * Screen.width / 10), rand.Next(Screen.height / 6, 5 * Screen.height / 6), 0));
            selectedGameObjekt.GetComponent<ERObjekt>().leisteBottom = leisteBottom;
            selectedGameObjekt.GetComponent<ERObjekt>().leisteRechts = leisteRechts;
            
            
            if (selectedGameObjekt.CompareTag("Beziehung")&&!schwach)
            {
                selectedGameObjekt.GetComponent<Beziehung>().erstelleBeziehung();
            }
        }
    }

    private GameObject zeichneLinie(GameObject last, GameObject select)
    {
        GameObject templinie = Instantiate(linie, transform);

        templinie.GetComponent<Linienzeichner>().setzeGameObjekte(last, select);
        templinie.GetComponent<Linienzeichner>().zeichnen = true;
        templinie.transform.SetParent(linienOrdner.transform);

        return templinie;
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
    }

  
    // hat Löschknopf als Methode
    public void loeschen()
    {
        if (selectedGameObjekt != null)
        {
            if (ERAufgabe.gespeicherteObjekte.Contains(selectedGameObjekt))
            {
                FehlerAnzeige.fehlertext = "Objekt kann nicht mehr gelöscht werden.";
                return;
            }

            modellObjekte.Remove(selectedGameObjekt);
            if (selectedGameObjekt.CompareTag("Entitaet")&&selectedGameObjekt.GetComponent<Entitaet>().schwach)
            {
                modellObjekte.Remove(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                Destroy(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            }
            if (selectedGameObjekt.CompareTag("Attribut")){
                foreach (GameObject obj in modellObjekte)
                {
                    if (obj.CompareTag("Entitaet"))
                    {
                        obj.GetComponent<Entitaet>().attributloeschen(selectedGameObjekt);
                    }
                }
            }
            if (selectedGameObjekt.CompareTag("Beziehung") && selectedGameObjekt.GetComponent<Beziehung>().schwach)
            {
                GameObject temp = selectedGameObjekt;
                selectedGameObjekt = temp.GetComponent<Beziehung>().objekt1;
                leisteBottom.GetComponent<LeisteBottom>().SchwacheEntitaet(false);
                selectedGameObjekt = temp;
                selectedGameObjekt.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().vaterEntitaet = null;
                selectedGameObjekt.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().schwacheBeziehung = null;
                
            }
            if (selectedGameObjekt.CompareTag("Beziehung")){
                selectedGameObjekt.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().beziehungen.Remove(selectedGameObjekt);
                selectedGameObjekt.GetComponent<Beziehung>().objekt2.GetComponent<Entitaet>().beziehungen.Remove(selectedGameObjekt);
            }
            if (selectedGameObjekt.CompareTag("Entitaet"))
            {
                foreach(GameObject bez in selectedGameObjekt.GetComponent<Entitaet>().beziehungen)
                {
                    if (bez.GetComponent<Beziehung>().objekt1.Equals(selectedGameObjekt))
                    {
                        bez.GetComponent<Beziehung>().objekt1 = null;
                    }
                    if(bez.GetComponent<Beziehung>().objekt2.Equals(selectedGameObjekt))
                    {
                        bez.GetComponent<Beziehung>().objekt2 = null;
                    }
                }
            }
            for (int i =0; i< selectedGameObjekt.transform.childCount; i++)
            {
                modellObjekte.Remove(selectedGameObjekt.transform.GetChild(i).gameObject);
            }            
            Destroy(selectedGameObjekt.GetComponent<ERObjekt>());
            Destroy(selectedGameObjekt);
            
            if (lastselected == null)//wenn man das erste Objekt gleich wieder loescht
            {
                selectedGameObjekt = null;
            }
            
            else if (selectedGameObjekt.Equals(lastselected))//wenn man 2 Objekte hintereinander loescht und als 2. Objekt vorher ausgewaehlt hat
            {
                selectedGameObjekt = null;
                lastselected = null;
            }
            else 
            {
                selectedGameObjekt = lastselected;
                changeSelectedGameobjekt(lastselected);
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



    public void Update()
    {
        if (selectedGameObjekt == null) { }
        else if (selectedGameObjekt.CompareTag("Entitaet")){
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
