using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NummernAnzeige : MonoBehaviour
{
    public GameObject text;
    void Update()
    {
        string nummer ="";
        Wohncontainer wohn;
        Feld feld;
        Forschung fors;
        Weide weide;
        Stallcontainer stall;
        if (gameObject.TryGetComponent(out wohn))
        {
            nummer = wohn.containernummer.ToString();
        }
        if (gameObject.TryGetComponent(out feld))
        {
            nummer = feld.feldnummer.ToString();
        }
        if (gameObject.TryGetComponent(out fors))
        {
            nummer = fors.stationsnummer.ToString();
        }
        if (gameObject.TryGetComponent(out weide))
        {
            nummer = weide.weidennummer.ToString();
        }
        if (gameObject.TryGetComponent(out stall))
        {
            nummer = stall.containernummer.ToString();
        }


        Utilitys.TextInTMP(text, nummer);
    }
}
