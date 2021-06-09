using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startIntro : MonoBehaviour
{
    public GameObject intro;
    public GameObject menu_song;
    public static bool played = false;
    
    /*
    *   Skrip, damit Introvideo beim Zurückkehren ins hauptmenü aus dem Spiel nicht mehr gespielt wird.
    *   Wenn Intro am Spielbeginn gesielt wurde und "Skip" gedrückt wurde wird played = true und die Hauptmenümusik wird nicht mehr gestoppt.
    *   
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(played){
            intro.SetActive(false);
        }else{
            AudioSource x = menu_song.GetComponent<AudioSource>();
            x.Stop();
        }
    }

    public void setPlayed()
    {
        played = true;
    }
}
