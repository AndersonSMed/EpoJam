using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioSource soundFX;

    private static SoundManager instance;

    public static SoundManager Instance{
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip) {
        soundFX.Stop();
        soundFX.clip = clip;
        soundFX.Play();
    }

    public void PlaySFX(AudioClip clip) {
        soundFX.Stop();
        soundFX.clip = clip;
        soundFX.Play();
    }
}
