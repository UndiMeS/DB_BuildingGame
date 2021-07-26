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

    public static int deltaErdenTag;
    public static int deltaMarsTag;

    public static float lasttime;
    public static float pausedtime;

    public static int neueZusatzaufgabe = 3;
    public static int neuerUmsatz = 5;

    //Buttons um Zusatzaufgabefenster zeitabhängig anzeigen zu lassen
    public GameObject zusatzButton; 
    public GameObject zusatzButton_transparent;

    private bool nurEinmalGeldDazu = true;

    // Start is called before the first frame update
    void Start()
    {
        //PostFX.SetActive(false);
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
            
            marsTag = deltaMarsTag + Mathf.RoundToInt(currenttime / 10.274f) + 1; // +1 da es keinen Tag 0  gibt/ Marstag = 1,02748 * Erdtag --> 20* 1,02748
            erdenTag = deltaErdenTag + Mathf.RoundToInt(currenttime / 10) + 1;

            if (marsTag % neuerUmsatz == 0 && nurEinmalGeldDazu)
            {
                Testing.geld += Testing.umsatz;
                nurEinmalGeldDazu = false;
            }else if(marsTag % neuerUmsatz != 0 && !nurEinmalGeldDazu)
            {
                nurEinmalGeldDazu = true;
            }
            
            if (marsTag % neueZusatzaufgabe == 0) //alle 3 Tage eine neue Zusatzaufgabe
            {
                if(Aufgaben.welcheAufgabe <= 25){
                    zusatzButton.SetActive(true);
                    zusatzButton_transparent.SetActive(false);
                }else{
                    zusatzButton.SetActive(false);

                }
                
            }
            
            
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
