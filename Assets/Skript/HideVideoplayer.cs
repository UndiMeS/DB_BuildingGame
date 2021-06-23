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

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
    }
    void Update() {
        if (isPlayerStarted == false && videoPlayer.isPlaying == true) {
            // When the player is started, set this information
            isPlayerStarted = true;
        }
        if (isPlayerStarted == true && videoPlayer.isPlaying == false ) {
            // Wehen the player stopped playing, hide it
            intro.SetActive(false);
            isPlayerStarted = false;
        }

    }   
}
