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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void erstelleObjekt(GameObject prefab)
    {
        if (modellObjekte.Count != 0) { 
            selectedGameObjekt.GetComponent<ERObjekt>().selected = false;
            selectedGameObjekt.GetComponent<RawImage>().color = Color.white;
            lastselected = selectedGameObjekt;
        }
        selectedGameObjekt = Instantiate(prefab, transform);
        selectedGameObjekt.transform.Translate(Screen.width / 2, Screen.height / 2, 0);
        modellObjekte.Add(selectedGameObjekt);
        selectedGameObjekt.GetComponent<RawImage>().color = Color.yellow;
        if (selectedGameObjekt.CompareTag("Attribut")&& lastselected.CompareTag("Entitaet"))
        {
            zeichneLinie();
        }
    }

    private void zeichneLinie()
    {
        LineAlignment= 
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
        selectedGameObjekt.GetComponent<RawImage>().color = Color.white;
        lastselected = selectedGameObjekt;
        selectedGameObjekt = newSelected;
        selectedGameObjekt.GetComponent<RawImage>().color = Color.yellow;
    }

    public void unterstreichen()
    {
        if (selectedGameObjekt.CompareTag("Attribut"))
        {
            selectedGameObjekt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
        }
    }



    

}
