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
    private ArrayList modellObjekte = new ArrayList();
    public GameObject linie;
    public static GameObject entitaet;
    public static GameObject attribut;
    public static GameObject beziehung;


    // Start is called before the first frame update
    void Start()
    {
        lastselected = null;
        selectedGameObjekt = null;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void erstelleObjekt(GameObject prefab)
    {
        if (modellObjekte.Count != 0)
        {
            selectedGameObjekt.GetComponent<ERObjekt>().selected = false;
            selectedGameObjekt.GetComponent<RawImage>().color = Color.white;
            lastselected = selectedGameObjekt;
        }
        
        GameObject temp = Instantiate(prefab, transform);

        if ((temp.CompareTag("Attribut") && !(selectedGameObjekt.CompareTag("Entitaet") || modellObjekte.Count == 0)))
        {
            Destroy(temp.GetComponent<ERObjekt>());
            FehlerAnzeige.fehlertext = "Wähle zuerst die Entität aus zu der das Attribute gehören soll.";
            Destroy(temp);
        }
        else
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

    public void giveSelectedGameObjektName(string eingabe)
    {
        if (modellObjekte.Count != 0)
        {
            selectedGameObjekt.GetComponent<ERObjekt>().nameVonObjekt = eingabe;
        }
    }

    public static void changeSelectedGameobjekt(GameObject newSelected)
    { 
        lastselected = selectedGameObjekt;
        
        selectedGameObjekt = newSelected;
        selectedGameObjekt.GetComponent<RawImage>().color = Color.yellow;
        if (!(lastselected==null)) { lastselected.GetComponent<RawImage>().color = Color.white;
            lastselected.GetComponent<ERObjekt>().selected = false;
        }
       
    }

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

    public void loeschen()
    {
        if (!(selectedGameObjekt == null))
        {
            Destroy(selectedGameObjekt.GetComponent<ERObjekt>());
            Destroy(selectedGameObjekt);
            modellObjekte.Remove(selectedGameObjekt);
            if (lastselected== null)
            {
                selectedGameObjekt = null;
            }
            else if (!selectedGameObjekt.Equals(lastselected))
            {
                selectedGameObjekt = lastselected;
                changeSelectedGameobjekt(lastselected);
            }
            else if (selectedGameObjekt.Equals(lastselected))
            {
                selectedGameObjekt = null;
                lastselected = null;
            }
        }
    }
}
