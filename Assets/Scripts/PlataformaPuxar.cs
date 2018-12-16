using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPuxar : PlataformaSubirDescer {
    [SerializeField]
    private GameObject player;

    private void OnGUI() {
        base.OnGUI();
        Event ev = Event.current;
        if (ev.type == EventType.KeyDown && ev.keyCode.ToString().Length == 1 && char.IsLetter(ev.keyCode.ToString()[0])) {
            if (ev.keyCode.ToString() == "R" && textoPlataforma.Length >= 5) {
                if (textoPlataforma[textoPlataforma.Length - 2] == 'A' && textoPlataforma[textoPlataforma.Length - 3] == 'X'
                    && textoPlataforma[textoPlataforma.Length - 4] == 'U' && textoPlataforma[textoPlataforma.Length - 5] == 'P') {
                    player.GetComponent<Player>().Puxar();
                }
            }
        }
    }
}
