using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audio_off : MonoBehaviour
{
    public GameObject on;
    public GameObject off;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;
        on.SetActive(true);
        off.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void audioOff()
    {
        if(AudioListener.volume == 0){
            AudioListener.volume = 1;
            on.SetActive(true);
            off.SetActive(false);
        }else{
            AudioListener.volume = 0;
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}
