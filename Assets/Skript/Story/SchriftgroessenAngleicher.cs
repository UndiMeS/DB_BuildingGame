using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchriftgroessenAngleicher : MonoBehaviour
{
    List<TMPro.TextMeshProUGUI> texte; 
    // Start is called before the first frame update
    void Awake()
    {
        texte = new List<TMPro.TextMeshProUGUI>();
        texte.AddRange(gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>());
    }

    // Update is called once per frame
    void Update()
    {
        float min=50;
        foreach(TMPro.TextMeshProUGUI text in texte)
        {
            min = Mathf.Min(min, text.fontSize);
        }foreach (TMPro.TextMeshProUGUI text in texte)
        { text.fontSize = min; }
        }
}
