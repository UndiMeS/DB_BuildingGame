using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WohncontainerTutorialPfeil : MonoBehaviour
{
    public static bool anzeigen = false;

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.GetChild(0).gameObject.SetActive(anzeigen); 
    }
}
