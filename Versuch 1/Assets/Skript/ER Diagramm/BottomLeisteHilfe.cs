using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLeisteHilfe : MonoBehaviour
{
    public GameObject Leiste;
    public GameObject HLeiste;
  

    public void Einblenden()
    {
        Leiste.SetActive(false);

        HLeiste.SetActive(true);

    }
        public void Ausblenden()
    {
        Leiste.SetActive(true);

        HLeiste.SetActive(false);

    }


}
