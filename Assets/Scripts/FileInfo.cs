using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileInfo : MonoBehaviour {
    [SerializeField]
    private Text files;

	void Update () {
        files.text = GameManager.Instance.PegarArquivos() + "X";
	}
}
