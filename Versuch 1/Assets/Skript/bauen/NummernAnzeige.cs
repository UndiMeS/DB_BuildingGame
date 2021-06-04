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
        if (gameObject.TryGetComponent(out wohn))
        {
            nummer = wohn.containernummer.ToString();
        }
        

        Utilitys.TextInTMP(text, nummer);
    }
}
