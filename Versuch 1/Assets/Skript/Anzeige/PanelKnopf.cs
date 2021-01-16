using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelKnopf : MonoBehaviour
{
    public int gebaeudeNummer;//10,11,12 haus; 20,21,22 weide; 30,31,32 feld; ...1 klein;...2 mittel;...3 groß
    public GameObject gebaeude;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Methode beim erzeugen eines Gebaeudes
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
