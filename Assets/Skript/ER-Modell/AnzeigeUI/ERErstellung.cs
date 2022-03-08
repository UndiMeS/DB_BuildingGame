﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
//using System;
//using Random = System.Random;

public class ERErstellung : MonoBehaviour
{
    public static GameObject selectedGameObjekt;
    public static GameObject lastselected;
    public static List<GameObject> modellObjekte = new List<GameObject>(); //Liste an Objekten in ERD, vielleicht fuer spaeter

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

    public GameObject aufgabentext;
    public GameObject checkliste;
    public GameObject infobox;

    public GameObject ddSchwach;
    public GameObject dd1;
    public GameObject dd2;


    public float minX = 0;
    public float maxX = 175;
    public float minY = -15;
    public float maxY = 130;
    public Vector3 SpawnLimit;

    public TargetSelector Target;
    public RTS_Cam.RTS_Camera RTS_Camera;
    public Camera MainCamera;
    public int SpawnRadius;


    // Start is called before the first frame update
    // zuerst leer
    void Awake()
    {
        lastselected = null;
        selectedGameObjekt = null;
        schwach = false;
        modellObjekte.Clear();

        RTS_Camera = GameObject.FindWithTag("MainCamera").GetComponent<RTS_Cam.RTS_Camera>();
        //Target = Camera.TargetSelector;
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
        if (prefab.CompareTag("Beziehung") && modellObjekte.Count == 0)
        {
            FehlerAnzeige.fehlertext = "Erstelle zuerst einen Entität.";
            return;
        }

        GameObject temp = Instantiate(prefab, transform, true);
        if (temp.CompareTag("Beziehung"))
        {
            temp.GetComponent<Beziehung>().setLinienordner(linienOrdner);
        }
        
        //nur wenn vorhergehendes Objekt Entity kann Attribut erzeugt werden
        if (temp.CompareTag("Attribut") && modellObjekte.Count == 0)
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus, zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else if (temp.CompareTag("Attribut") && selectedGameObjekt!= null &&(!selectedGameObjekt.CompareTag("Entitaet") &&!selectedGameObjekt.CompareTag("Attribut")))
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus, zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else //erzeugt neues Objekt und markiert es
        {
            temp.GetComponent<ERObjekt>().canvas = erModellflaeche;
            
            // SpawnLimit.x = Mathf.Clamp(SpawnLimit.x, minX, maxX);
            // SpawnLimit.y = Mathf.Clamp(SpawnLimit.y, minY, maxY);
            //temp.gameObject.transform.position = SpawnLimit;
            setRandomPosition(temp);
            modellObjekte.Add(temp);
            changeSelectedGameobjekt(temp);
            selectedGameObjekt.transform.SetParent(erModellflaeche.transform);
            RTS_Camera.targetFollow = temp.transform;
            if (!selectedGameObjekt.CompareTag("Attribut"))
            {
                
            }
           
            if (selectedGameObjekt.CompareTag("Attribut") && lastselected!=null&& lastselected.CompareTag("Entitaet"))
            {
                selectedGameObjekt.transform.SetParent(lastselected.transform);
                zeichneLinie(lastselected, selectedGameObjekt);
                lastselected.GetComponent<Entitaet>().attribute.Add(selectedGameObjekt);
                selectedGameObjekt.GetComponent<Attribut>().vater = lastselected;
            }
            else if (selectedGameObjekt.CompareTag("Attribut") && lastselected != null && lastselected.CompareTag("Attribut"))
            {
                GameObject vater = lastselected.GetComponent<Attribut>().vater;
                vater.GetComponent<Entitaet>().attribute.Add(selectedGameObjekt);
                zeichneLinie(selectedGameObjekt, vater);
                selectedGameObjekt.transform.SetParent(vater.transform);
                selectedGameObjekt.GetComponent<Attribut>().vater = vater;
            }

            
            selectedGameObjekt.GetComponent<ERObjekt>().leisteBottom = leisteBottom;
            selectedGameObjekt.GetComponent<ERObjekt>().leisteRechts = leisteRechts;
            selectedGameObjekt.GetComponent<ERObjekt>().aufgabe = aufgabentext;
            selectedGameObjekt.GetComponent<ERObjekt>().checkliste = checkliste;
            selectedGameObjekt.GetComponent<ERObjekt>().dd1 = dd1;
            selectedGameObjekt.GetComponent<ERObjekt>().dd2 = dd2;
            selectedGameObjekt.GetComponent<ERObjekt>().dd3 = ddSchwach;

            nameGeben();

            if (selectedGameObjekt.CompareTag("Beziehung")&&!schwach)
            {
                selectedGameObjekt.GetComponent<Beziehung>().erstelleBeziehung();
            }
        }
    }

    private void nameGeben()
    {
        if (selectedGameObjekt.CompareTag("Entitaet"))
        {
            selectedGameObjekt.name = "neue Entität";
        }
        else if (selectedGameObjekt.CompareTag("Attribut"))
        {
            selectedGameObjekt.name = "neues Attribut";
        }
        else if (selectedGameObjekt.CompareTag("Beziehung"))
        {
            selectedGameObjekt.name = "neue Beziehung";
        }
    }

    private void setRandomPosition(GameObject gameObject)
    {
        //Random rand = new Random();
        Vector3 pos= new Vector3();
        bool ausserhalb = true;
        int zaehler = 0;
        while (ausserhalb) {
            zaehler++;
            //pos = new Vector3(rand.Next(Screen.width / 10, 9 * Screen.width / 10), rand.Next(Screen.height / 6, 5 * Screen.height / 6), 0);
            
            // SpawnLimit = new Vector3(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x),Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y),0);
            // SpawnLimit = new Vector3(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x),Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y),0);

            // pos.x = Mathf.Clamp(pos.x, minX, maxX);
            // pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // if(pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
            // {
            //     ausserhalb = true;
            // }

            //SpawnLimit = Utilitys.GetMouseWorldPosition(pos);


            //SpawnLimit.y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            //SpawnLimit.x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            //SpawnLimit = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height),0));
            
            float RandX = Random.Range(minX, maxX);
            float RandY = Random.Range(minY, maxY);

            //SpawnLimit = MainCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0.0f));
            

            SpawnLimit.x = Random.Range(MainCamera.transform.position.x - SpawnRadius, MainCamera.transform.position.x + SpawnRadius);
            SpawnLimit.y = Random.Range(MainCamera.transform.position.y - SpawnRadius, MainCamera.transform.position.y + SpawnRadius);


            //SpawnLimit = new Vector3(RandX, RandY, 1.0f);
            //SpawnLimit = MainCamera.ScreenToWorldPoint(new Vector3((Screen.width / 3), (Screen.height / 3), 0.0f));
            //SpawnLimit = MainCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height),1.0f));
            SpawnLimit.z = 0.0f;

            SpawnLimit.x = Mathf.Clamp(SpawnLimit.x, minX, maxX);
            SpawnLimit.y = Mathf.Clamp(SpawnLimit.y, minY, maxY);
            //gameObject.transform.position = Utilitys.GetMouseWorldPosition(pos);
            //gameObject.transform.position = SpawnLimit;

            gameObject.transform.position = SpawnLimit;
            if (!RectTransformUtility.RectangleContainsScreenPoint(aufgabentext.GetComponent<RectTransform>(), pos, null)
                && !RectTransformUtility.RectangleContainsScreenPoint(checkliste.GetComponent<RectTransform>(), pos, null)
                && !RectTransformUtility.RectangleContainsScreenPoint(infobox.GetComponent<RectTransform>(), pos, null)
                &&!nichtInAnderen(gameObject))
            {                
                ausserhalb = false;
            }
            //Grenze, denn sonst wird es zur Unendlich Schleife
            if (zaehler>40
                && !RectTransformUtility.RectangleContainsScreenPoint(aufgabentext.GetComponent<RectTransform>(), pos, null)
                && !RectTransformUtility.RectangleContainsScreenPoint(checkliste.GetComponent<RectTransform>(), pos, null)
                && !RectTransformUtility.RectangleContainsScreenPoint(infobox.GetComponent<RectTransform>(), pos, null)) 
            {
                ausserhalb = false;
            }
        }
    }

    private bool nichtInAnderen(GameObject gameObject)
    {
        bool drin = false;
        Vector3[] ecken= new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(ecken);
          
        foreach (GameObject go in modellObjekte)
        {            
            if (RectTransformUtility.RectangleContainsScreenPoint(go.GetComponent<RectTransform>(), ecken[0], null)
                || RectTransformUtility.RectangleContainsScreenPoint(go.GetComponent<RectTransform>(), ecken[1], null)
                || RectTransformUtility.RectangleContainsScreenPoint(go.GetComponent<RectTransform>(), ecken[2], null)
                || RectTransformUtility.RectangleContainsScreenPoint(go.GetComponent<RectTransform>(), ecken[3], null))
            {
                drin = true;
                break;
            }
        }       
        return drin;
    }

    public GameObject zeichneLinie(GameObject last, GameObject select)
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
        selectedGameObjekt.GetComponent<ERObjekt>().selected = true;

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
                selectedGameObjekt.GetComponent<Entitaet>().beziehungen.Remove(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet.GetComponent<Entitaet>().beziehungen.Remove(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                modellObjekte.Remove(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                Destroy(selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
                selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung = null;
                selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet = null;
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
                leisteBottom.GetComponent<LeisteBottom>().SchwacheEntitaetObj(false, selectedGameObjekt.GetComponent<Beziehung>().objekt1);

                selectedGameObjekt.GetComponent<Beziehung>().objekt1.GetComponent<Entitaet>().schwach = false;
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
                    if (bez.GetComponent<Beziehung>().schwach&& selectedGameObjekt == bez.GetComponent<Beziehung>().objekt2)
                    {
                        FehlerAnzeige.fehlertext = "Lösche zuerst die schwache Beziehung ''"+ bez.name+"''.";
                        return;
                    }
                    if (bez.GetComponent<Beziehung>().objekt1!=null&&bez.GetComponent<Beziehung>().objekt1.Equals(selectedGameObjekt))
                    {
                        bez.GetComponent<Beziehung>().objekt1 = null;
                    }
                    if(bez.GetComponent<Beziehung>().objekt2 != null && bez.GetComponent<Beziehung>().objekt2.Equals(selectedGameObjekt))
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
            if (selectedGameObjekt == null&&modellObjekte.Count!=0)
            {
                selectedGameObjekt = modellObjekte[0];
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
        bool drin = RectTransformUtility.RectangleContainsScreenPoint(objekt.GetComponent<RectTransform>(), Utilitys.GetMouseWorldPosition(mousePosition),null);
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