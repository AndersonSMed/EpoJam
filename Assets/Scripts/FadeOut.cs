using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    [SerializeField]
    private Text textoPreenchido;
    [SerializeField]
    private Text textoObjetivo;

    private Animation anim;
    private bool animationPlayed = false;

    private void Start() {
        anim = GetComponent<Animation>();
    }

    void Update () {
        if (!anim.isPlaying && textoPreenchido.text.Contains(textoObjetivo.text) && !animationPlayed) {
            anim.Play();
            animationPlayed = true;
        }
	}
}
