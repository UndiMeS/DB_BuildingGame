using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBeschreibungPosition : MonoBehaviour
{
    public GameObject scrollbar;
    Scrollbar sbar;
    // Start is called before the first frame update
    void Start()
    {  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        sbar = scrollbar.GetComponent<Scrollbar>();
        sbar.value = 1;
    }
}
