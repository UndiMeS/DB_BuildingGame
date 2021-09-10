using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HideVideoplayer : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public GameObject video;
    public bool isPlayerStarted = false;
    public GameObject intro;
    public GameObject go_button;
    public GameObject skip_button;
    public GameObject audio_button;

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
        go_button.SetActive(false);
        skip_button.SetActive(false);
        audio_button.SetActive(false);


    }
    void Update() {
        if (isPlayerStarted == false && videoPlayer.isPlaying == true) {
            // When the player is started, set this information
            isPlayerStarted = true;            
        }
        if (isPlayerStarted == true && videoPlayer.isPlaying == false ) {
            // Wehen the player stopped playing, hide it
            isPlayerStarted = false;
            go_button.SetActive(true);
            skip_button.SetActive(false);
            audio_button.SetActive(false);
        }

        if(go_button.activeSelf == false){
            if(Input.anyKey){
                skip_button.SetActive(true);
                audio_button.SetActive(true);

            }
        }
    }   
}
