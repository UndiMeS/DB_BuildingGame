using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Anpassung der Baupreise im Baumenü
*
*/
public class BauMenu : MonoBehaviour
{
    public GameObject preisWohncontainer;
    public GameObject preisStallcontainer;
    public GameObject preisWeidesphaere;
    public GameObject preisFeldsphaere;
    public GameObject preisForschungsstation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(preisWohncontainer, Wohncontainer.preis);
        Utilitys.TextInTMP(preisStallcontainer, Stallcontainer.preis);
        Utilitys.TextInTMP(preisWeidesphaere, Weide.preis);
        Utilitys.TextInTMP(preisFeldsphaere, Feld.preis);
        Utilitys.TextInTMP(preisForschungsstation, Forschung.preis);
    }
}
