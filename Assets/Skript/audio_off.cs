using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class audio_off : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public GameObject gameMusic;
    private bool musicOn = true;
    VideoPlayer p;
    public GameObject video;

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

    public void videoAudioOff(GameObject video)
    {
        p = video.GetComponent<VideoPlayer>();
        
        
        if(p.GetDirectAudioMute(0)){
            p.SetDirectAudioMute(0,false);
            on.SetActive(true);
            off.SetActive(false);
        }else{
            p.SetDirectAudioMute(0,true);
            on.SetActive(false);
            off.SetActive(true);
        }
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

    public void gameMusicOff()
    {
        if(musicOn){
            musicOn = false;
            gameMusic.SetActive(false);
            on.SetActive(false);
            off.SetActive(true);
        }else{
            musicOn = true;
            gameMusic.SetActive(true);
            on.SetActive(true);
            off.SetActive(false);
        }
    }
}
