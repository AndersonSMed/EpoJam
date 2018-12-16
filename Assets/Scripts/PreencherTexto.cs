using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreencherTexto : MonoBehaviour {
    [SerializeField]
    private Text textoAtual;
    [SerializeField]
    private Text textoObjetivo;
	
	void Update () {
        if (Input.GetKeyDown(GameManager.Instance.PegarTeclaPularTexto())) {
            textoAtual.text = textoObjetivo.text;
        }
	}
}
