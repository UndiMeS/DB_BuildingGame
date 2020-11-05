using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelKnopf : MonoBehaviour
{
    public int gebaeudeNummer;
    public GameObject gebaeude;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void KnopfGedrueckt()
    {
        Testing.objektGebaut = gebaeudeNummer;
        Instantiate(gebaeude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
