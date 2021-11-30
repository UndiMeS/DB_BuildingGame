using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fortschritt : MonoBehaviour
{
    public List<GameObject> Ziffern;

    public Sprite white;
    public Sprite whiteTransparent;
    public Sprite green;

    void Start()
    {
        foreach(GameObject game in Ziffern)
        {
            game.transform.GetChild(0).GetComponent<Image>().sprite = whiteTransparent;
            game.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<Ziffern.Count; i++)
        {
            if (i < Story.level)
            {
                Ziffern[i].transform.GetChild(0).GetComponent<Image>().sprite = green;
                Ziffern[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.white;
            }else if (i == Story.level)
            {
                Ziffern[i].transform.GetChild(0).GetComponent<Image>().sprite = white;
                Ziffern[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.black;
            }
            else
            {
                Ziffern[i].transform.GetChild(0).GetComponent<Image>().sprite = whiteTransparent;
                Ziffern[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.black;
            }
        }
    }
}
