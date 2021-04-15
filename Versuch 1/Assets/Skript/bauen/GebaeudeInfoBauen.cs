using System;
using System.Collections.Generic;
using UnityEngine;

public class GebaeudeInfoBauen : MonoBehaviour
{
    public List<GameObject> anzeigen;

    public GameObject wohncontainerTabelle;
    public GameObject feldTabelle;
    public GameObject stallTabelle;
    public GameObject forschungsTabelle;
    public GameObject weidenTabelle;

    public static int wertFest=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int wert = 0;
        if (wertFest == 0)
        {
             wert = Testing.objektGebaut;
        }
        else
        {
            wert = wertFest;
        }
        int i = 1;
            foreach (GameObject anzeige in anzeigen)
            {

                if (i != wert)
                {
                    anzeige.SetActive(false);
                }
                else
                {
                    anzeige.SetActive(true);
                    ObjektBewegung.infoAnzeige = anzeige;
                }
                i++;
            }
        

        switch (wert)
        {
            case 0:
                break;
            case 1:
                HausAnzeige();
                break;
            case 2:
                FeldAnzeigen();
                break;
            case 3:
                ForschungAnzeigen();
                break;
            case 4:
                WeideAnzeigen();
                break;
            case 5:
                StallAnzeigen();
                break;
        }
    }

    private void StallAnzeigen()
    {
        Utilitys.TextInTMP(stallTabelle.transform.GetChild(0).gameObject, Stallcontainer.nummerZaehler);
        Utilitys.TextInTMP(stallTabelle.transform.GetChild(1).gameObject, Stallcontainer.preis);
        Utilitys.TextInTMP(stallTabelle.transform.GetChild(2).gameObject, Stallcontainer.gehege);
        Utilitys.TextInTMP(stallTabelle.transform.GetChild(3).gameObject, Stallcontainer.gehege);
    }

    private void WeideAnzeigen()
    {
        Utilitys.TextInTMP(weidenTabelle.transform.GetChild(0).gameObject, Weide.nummerZaehler);
        Utilitys.TextInTMP(weidenTabelle.transform.GetChild(1).gameObject, Weide.preis);
        Utilitys.TextInTMP(weidenTabelle.transform.GetChild(2).gameObject, Weide.arbeiterzahl);
        Utilitys.TextInTMP(weidenTabelle.transform.GetChild(3).gameObject, Weide.neuErtrag);
        Utilitys.TextInTMP(weidenTabelle.transform.GetChild(4).gameObject, Weide.tierAnzahl);
    }

    private void ForschungAnzeigen()
    {
        Utilitys.TextInTMP(forschungsTabelle.transform.GetChild(0).gameObject, Forschung.nummerZaehler);
        Utilitys.TextInTMP(forschungsTabelle.transform.GetChild(1).gameObject, Forschung.preis);
    }

    private void FeldAnzeigen()
    {
        Utilitys.TextInTMP(feldTabelle.transform.GetChild(0).gameObject, Feld.nummerZaehler);
        Utilitys.TextInTMP(feldTabelle.transform.GetChild(1).gameObject, Feld.preis);
        Utilitys.TextInTMP(feldTabelle.transform.GetChild(2).gameObject, Feld.arbeiterzahl);
        Utilitys.TextInTMP(feldTabelle.transform.GetChild(3).gameObject, Feld.neuErtrag);
    }

    private void HausAnzeige()
    {
        Utilitys.TextInTMP(wohncontainerTabelle.transform.GetChild(0).gameObject, Wohncontainer.nummerZaehler);
        Utilitys.TextInTMP(wohncontainerTabelle.transform.GetChild(1).gameObject, Wohncontainer.preis);
        Utilitys.TextInTMP(wohncontainerTabelle.transform.GetChild(2).gameObject, Wohncontainer.betten);
        Utilitys.TextInTMP(wohncontainerTabelle.transform.GetChild(3).gameObject, Wohncontainer.betten);
    }
}
