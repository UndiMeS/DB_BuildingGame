using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Optionsmenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetLaustsaerke(float lautstaerke)
    {
        audioMixer.SetFloat("Volume", lautstaerke);
    }
}
