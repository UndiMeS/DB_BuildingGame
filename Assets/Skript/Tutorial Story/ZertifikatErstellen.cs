using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZertifikatErstellen : MonoBehaviour
{
    public static bool abkuerzer=false;
    private bool first1 = true;
    private bool first2 = true;

    public void Update()
    {
        if (first1 && Story.lvl[0] == false && Mission.missionsLevel[6] == false)
        {
            gameObject.GetComponent<Button>().interactable = false;
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Button>().image.color = MinusA(gameObject.GetComponent<Button>().image.color, new Color(0, 0, 0, 0.5f));
            first1 = false;
        }
        else if(first2&& Story.lvl[0] == true && Mission.missionsLevel[6] == false) {
            gameObject.GetComponent<Button>().interactable = true;
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Button>().image.color = MinusA(gameObject.GetComponent<Button>().image.color, new Color(0, 0, 0,- 0.5f));
            first2 = false;
        }
    }

    public void KnopfGedrueckt()
    {
        Mission.screenshotMission = true;
        abkuerzer = true;
        Tutorial.missionClick = false;        
    }

    private Color MinusA(Color ausgabe, Color subtrahend)
    {
        float a = ausgabe.a - subtrahend.a;
        ausgabe.a = a;
        return ausgabe;
    }
}
