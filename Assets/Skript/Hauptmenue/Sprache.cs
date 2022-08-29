using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sprache : MonoBehaviour
{
    public static string sprache="ge"; //ge-Deutsch, en-Englisch
    public List<GameObject> entitymengenSingular;
    public List<GameObject> relationshipsSingular;
    public List<GameObject> relationshipsPlural;

    public GameObject prefabEM;
    public GameObject prefabAtt;
    public GameObject prefabBez;

    private void Start()
    {
        Debug.Log(prefabBez.transform.GetChild(1).GetChild(0).name);
        if (sprache == "en")
        {
            prefabBez.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text= "Relationshipname";
            prefabEM.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Entitymengenname";

            foreach (GameObject game in entitymengenSingular)
            {
                string text = game.GetComponent<TMPro.TextMeshProUGUI>().text;
                Debug.Log(text);
                text = text.Replace("Entitätsmenge", "Entitymenge");
                Debug.Log(text);
                game.GetComponent<TMPro.TextMeshProUGUI>().SetText(text);
            }

            foreach (GameObject game in relationshipsSingular)
            {
                string text = game.GetComponent<TMPro.TextMeshProUGUI>().text;
                Debug.Log(text);
                text = text.Replace("Beziehung", "Relationship");
                Debug.Log(text);
                game.GetComponent<TMPro.TextMeshProUGUI>().SetText(text);
            }
            foreach (GameObject game in relationshipsPlural)
            {
                string text = game.GetComponent<TMPro.TextMeshProUGUI>().text;
                Debug.Log(text);
                text = text.Replace("Beziehungen", "Relationships");
                Debug.Log(text);
                game.GetComponent<TMPro.TextMeshProUGUI>().SetText(text);
            }
        }
    } 
}
