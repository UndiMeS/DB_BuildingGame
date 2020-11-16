using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERErstellung : MonoBehaviour
{
    private GameObject selectedGameObjekt;
    private ArrayList modellObjekte = new ArrayList();

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
        if (modellObjekte.Count != 0) { selectedGameObjekt.GetComponent<ERObjekt>().selected = false; }
        selectedGameObjekt = Instantiate(prefab, transform);
        selectedGameObjekt.transform.Translate(Screen.width / 2, Screen.height / 2, 0);
        modellObjekte.Add(selectedGameObjekt);
    }

    public void giveSelectedGameObjektName(string eingabe)
    {
        selectedGameObjekt.GetComponent<ERObjekt>().nameVonObjekt = eingabe;
    }

}
