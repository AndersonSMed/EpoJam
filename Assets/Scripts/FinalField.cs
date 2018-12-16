using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalField : MonoBehaviour {
    [SerializeField]
    private Text campoPreenchido;
    [SerializeField]
    private Text campoObjetivo;

    private Animation anim;
    private bool animacao = false;

    private void Start() {
        anim = GetComponent<Animation>();
    }

    void Update() {
        if (campoPreenchido.text.Contains(campoObjetivo.text) && !animacao) {
            anim.Play();
            animacao = true;
        }
        if (animacao == true && !anim.isPlaying && Input.GetKeyDown(KeyCode.Space))
            if (GameManager.Instance.PegarCena() == "LogFinal") {
                GameManager.Instance.SairDoJogo();
            }else if (GameManager.Instance.PegarCena() == "TelaFinal") {
                GameManager.Instance.PassarFase();
            }
    }
}
