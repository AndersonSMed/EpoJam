using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour {
    [SerializeField]
    private List<GameObject> files;
    [SerializeField]
    private Text esperarTexto;

    private int file = 0;
    private bool passouFase = false;

    private bool mostrarArquivo = false;

    void ShowFile() {
        if(file < files.Count) {
            files[file].SetActive(true);
            file++;
            Invoke("ShowFile", 10f);
        }
    }

    private void Update() {
        for (int i = 0; i < files.Count; i++) {
            if(files[i] == null) {
                files.Remove(files[i]);
                file--;
            }
        }
        if(files.Count == 0 && !passouFase) {
            GameManager.Instance.PassarFase();
            passouFase = true;
        }
        if (esperarTexto.color.a == 0 && !mostrarArquivo) {
            mostrarArquivo = true;
            Invoke("ShowFile", 10f);
        }
    }

}
