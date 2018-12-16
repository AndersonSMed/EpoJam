using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    [SerializeField]
    private GameObject [] pontosInicio;
    [SerializeField]
    private GameObject [] pontosFinal;
    [SerializeField]
    private float velocidade = 1f;
    [SerializeField]
    private Text esperarTexto;

    private int caminho;
    private bool andando = false;
    private bool escolheu = false;
	
    private void EscolherCaminho() {
        caminho = Random.Range(0, pontosInicio.Length);
        GameObject inicio = pontosInicio[caminho];
        transform.position = new Vector2(inicio.transform.position.x, inicio.transform.position.y);
        andando = true;
    }

	void FixedUpdate () {
        if (andando) {
            GameObject objetivo = pontosFinal[caminho];
            if(objetivo.transform.position.y < pontosInicio[caminho].transform.position.y) {
                transform.Translate((objetivo.transform.position - pontosInicio[caminho].transform.position) * Time.deltaTime * velocidade * 2);
            } else {
                transform.Translate((objetivo.transform.position - pontosInicio[caminho].transform.position) * Time.deltaTime * velocidade);
            }
        }
	}

    private void Update() {
        if(esperarTexto.color.a == 0 && !escolheu) {
            escolheu = true;
            EscolherCaminho();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Boss") && collision.gameObject != pontosInicio[caminho]) {
            andando = false;
            EscolherCaminho();
        }
    }
}
