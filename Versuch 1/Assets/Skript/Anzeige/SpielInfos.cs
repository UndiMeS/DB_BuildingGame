using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielInfos : MonoBehaviour
{
    public GameObject maxAnzMenschen;
    public GameObject maxTiere;
    public GameObject maxForschungen;

    public GameObject geld;
    public GameObject umsatz;
    public GameObject sol;
    public GameObject erde;

    public GameObject forscher;
    public GameObject tierpfleger;
    public GameObject feldarbeiter;
    public GameObject tiere;



    public static float currenttime;
    public static int erdenTag;
    public static int marsTag;
    public static float lasttime;
    public static float pausedtime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(maxAnzMenschen, Testing.summeMenschen);
        Utilitys.TextInTMP(maxTiere, Testing.summeTiere);
        Utilitys.TextInTMP(maxForschungen, Testing.summeForschungen);
        Utilitys.TextInTMP(maxForschungen, Testing.summeForschungen);

        Utilitys.TextInTMP(geld, Testing.geld);
        Utilitys.TextInTMP(umsatz, Testing.umsatz);


        if (!PauseMenu.SpielIstPausiert&&!PauseMenu.ERon)
        {
            currenttime = Time.time-pausedtime;
            float neuSoltag = Mathf.RoundToInt(currenttime / 10.274f ) + 1; // +1 da es keinen Tag 0  gibt/ Marstag = 1,02748 * Erdtag --> 20* 1,02748
            if (neuSoltag % 5 == 0 && marsTag != neuSoltag)
            {
                Testing.geld += Testing.umsatz;
            }

            marsTag = Mathf.RoundToInt(neuSoltag);
            erdenTag = Mathf.RoundToInt(currenttime / 10 ) + 1;
            lasttime = currenttime;
        }
        else if(PauseMenu.ERon)
        {
            pausedtime = Time.time-currenttime;
        }  
        Utilitys.TextInTMP(sol, marsTag);
        Utilitys.TextInTMP(erde, erdenTag);

        Utilitys.TextInTMP(tiere, Testing.tiere);
        Utilitys.TextInTMP(feldarbeiter, Testing.feldarbeiter );
        Utilitys.TextInTMP(tierpfleger, Testing.tierpfleger);
        Utilitys.TextInTMP(forscher,  Testing.forscher );
    }

}
