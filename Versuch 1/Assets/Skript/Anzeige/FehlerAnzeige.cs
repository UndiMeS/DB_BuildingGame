using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*rote Fehleranzeige besitzt dieses Script
 * String fehlertext wird in anderen Sript verändert
 */
public class FehlerAnzeige : MonoBehaviour
{
    public GameObject fehlerObject;
    public static string fehlertext="";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!fehlertext.Equals(""))
        {
            Invoke("Zuruek", 5);//anzeige des Fehlertextes fuer 2s, dann wieder auf "" zurückgesetzt
        }
        Utilitys.TextInTMP(fehlerObject, fehlertext);
    }

    private void Zuruek()
    {
        fehlertext = "";
    }

 }
