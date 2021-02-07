using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielInfos : MonoBehaviour
{
    public GameObject geldText;
    public GameObject menschen;
    public GameObject forscher;
    public GameObject tierpfleger;
    public GameObject feldarbeiter;
    public GameObject maxAnzMenschen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(geldText, "Geld: " + Testing.geld + "€");
        Utilitys.TextInTMP(menschen, Testing.feldarbeiter+Testing.forscher+Testing.tierpfleger);
        Utilitys.TextInTMP(feldarbeiter, Testing.feldarbeiter );
        Utilitys.TextInTMP(tierpfleger, Testing.tierpfleger);
        Utilitys.TextInTMP(forscher,  Testing.forscher );
        Utilitys.TextInTMP(maxAnzMenschen, Testing.maxAnzMenschen);
    }
}
