using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour {
    [SerializeField]
    private GameObject nextFile = null;

    private void OnDestroy() {
        if (nextFile != null)
            nextFile.SetActive(true);
    }
}
