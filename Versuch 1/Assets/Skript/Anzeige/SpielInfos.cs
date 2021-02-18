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

    public float currenttime;
    private int erdentag;
    private int soltag;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Utilitys.TextInTMP(maxAnzMenschen, Testing.summeAnzMenschen);
        Utilitys.TextInTMP(maxTiere, Testing.summeTiere);
        Utilitys.TextInTMP(maxForschungen, Testing.summeForschungen);

        Utilitys.TextInTMP(geld, Testing.geld );
        Utilitys.TextInTMP(umsatz, Testing.umsatz);

        if (!PauseMenu.SpielIstPausiert)
        {
            currenttime = Time.time;
            float neuSoltag = Mathf.RoundToInt(currenttime / 5 );
            if (neuSoltag % 10 == 0 && soltag != neuSoltag)
            {
                Testing.geld += Testing.umsatz;
            }

            soltag = Mathf.RoundToInt(neuSoltag);
            erdentag = Mathf.RoundToInt(currenttime / 2 );
        }
        

        Utilitys.TextInTMP(sol, soltag);
        Utilitys.TextInTMP(erde, erdentag);

        Utilitys.TextInTMP(tiere, Testing.tiere);
        Utilitys.TextInTMP(feldarbeiter, Testing.feldarbeiter );
        Utilitys.TextInTMP(tierpfleger, Testing.tierpfleger);
        Utilitys.TextInTMP(forscher,  Testing.forscher );
    }
}
