using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioClip[] musics;
    public AudioSource BGM;

    AudioSource underscoreAudio;
    // Start is called before the first frame update
    void Start()
    {
        underscoreAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBGM(AudioClip music) {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }


}
