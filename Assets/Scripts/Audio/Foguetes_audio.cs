using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Foguetes_audio : MonoBehaviour
{
    public AudioSource audio;
    public static Foguetes_audio instance;

    public void AudioFoguestesPlay(AudioClip sons)
    {
        audio.clip = sons;
        audio.Play();
    }

    public void AudioFoguestesStop(AudioClip sons)
    {
        audio.clip = sons;
        audio.Stop();
    }
}
