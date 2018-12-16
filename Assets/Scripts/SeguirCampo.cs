using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeguirCampo : MonoBehaviour {
    [SerializeField]
    private Text textoObjetivo;
    [SerializeField]
    private AudioClip somTeclado;

    private Text meuTexto;
    private int posicaoTexto;
    private int audioSource = 0;
    private float tempoSeguirTexto = 0.2f;
    private float tempoPausarTexto = 0.5f;
    private bool teclaPularPressionada = false;

    void Start () {
        meuTexto = GetComponent<Text>();
        posicaoTexto = 0;
        SeguirTexto();
	}
	
    private void SeguirTexto() {
        if ((posicaoTexto < textoObjetivo.text.Length || posicaoTexto == 0) && !meuTexto.text.Contains(textoObjetivo.text)) {
            meuTexto.text = textoObjetivo.text.Substring(0, posicaoTexto + 1);
            SoundManager.Instance.PlaySFX(somTeclado);
            posicaoTexto++;
            if (textoObjetivo.text[posicaoTexto - 1] == ',')
                Invoke("SeguirTexto", tempoPausarTexto);
            else if (textoObjetivo.text[posicaoTexto - 1] == '.' || textoObjetivo.text[posicaoTexto - 1] == ':')
                Invoke("SeguirTexto", tempoPausarTexto * 2);
            else
                Invoke("SeguirTexto", tempoSeguirTexto);
        }
    }

	void Update () {
        if (Input.GetKeyDown(GameManager.Instance.PegarTeclaPularTexto()) && !teclaPularPressionada) {
            if (meuTexto.text.Contains(textoObjetivo.text) && GameManager.Instance.PegarCena() == "TelaInicial"){
                GameManager.Instance.PassarFase();
            }
            teclaPularPressionada = true;
        }
        if (Input.GetKeyUp(GameManager.Instance.PegarTeclaPularTexto())) {
            teclaPularPressionada = false;
        }
        tempoSeguirTexto = GameManager.Instance.PegarTempoParaSeguirTexto();
        tempoPausarTexto = GameManager.Instance.PegarTempoDePausaDoTexto();
	}
}
