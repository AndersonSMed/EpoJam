using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioSource soundFX;

    private List<AudioClip> musics;

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

    private void Start() {
        musics = new List<AudioClip>();
    }

    public void PlayMusicLevel(AudioClip clip) {
        if (music.isPlaying) {
            float time = music.time;
            music.Stop();
            music.clip = clip;
            music.Play();
            music.time = time;
        }
        else {
            music.clip = clip;
            music.Play();
        }
    }

    public void PlaySFX(AudioClip clip) {
        soundFX.Stop();
        soundFX.clip = clip;
        soundFX.Play();
    }
}
