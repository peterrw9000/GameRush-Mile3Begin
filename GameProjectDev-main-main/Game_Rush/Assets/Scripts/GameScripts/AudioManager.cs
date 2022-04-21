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

        float startVolume = BGM.volume;

        BGM.Stop();
        BGM.clip = music;
        BGM.volume = startVolume;
        BGM.Play();
    }

    public IEnumerator ChangeBGM2(AudioClip music) {
        float currentTime = 0;
        float startVolume = BGM.volume;
        while (currentTime < 2) {

            currentTime += Time.deltaTime;
            BGM.volume = Mathf.Lerp(startVolume, 0, currentTime / 1);

            yield return null;
        }

        BGM.Stop();
        BGM.clip = music;
        BGM.volume = startVolume;
        BGM.Play();
    }


}
