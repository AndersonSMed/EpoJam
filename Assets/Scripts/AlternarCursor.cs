using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternarCursor : MonoBehaviour {
    private Text campoTexto;

    private char caractere = '█';

	void Start () {
        campoTexto = GetComponent<Text>();
        Invoke("Alternar", 0.5f);
	}
    
    void Alternar() {
        if (caractere == '█')
            caractere = '_';
        else
            caractere = '█';
        if(campoTexto.text[campoTexto.text.Length - 1] == '█' || campoTexto.text[campoTexto.text.Length - 1] == '_') {
            campoTexto.text = campoTexto.text.Substring(0, campoTexto.text.Length - 1) + caractere;
        }
        Invoke("Alternar", 0.5f);
    }

    void Update () {
        if (campoTexto.text.Length > 0) {
            if (campoTexto.text[campoTexto.text.Length - 1] != '█' && campoTexto.text[campoTexto.text.Length - 1] != '_') {
                campoTexto.text = campoTexto.text + caractere;
            }
        } else {
            campoTexto.text = campoTexto.text + caractere;
        }
    }
}
