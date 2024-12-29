using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosorceSomdeFundo;
    public AudioClip[] musicasdeFundo;
    public AudioSource audiosorceSomsdoJogo;
   
    // Start is called before the first frame update
    void Start()
    {
        AudioClip audioClip = musicasdeFundo[0];
        audiosorceSomdeFundo.clip = audioClip;
        audiosorceSomdeFundo.Play();   
    }

    public void AudioFoguestesPlay(AudioClip sons)
    {
        audiosorceSomsdoJogo.PlayOneShot(sons);
    }

    public void AudioFoguestesStop()
    {
        audiosorceSomsdoJogo.Stop();
    }
}
