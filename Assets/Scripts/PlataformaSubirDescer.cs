using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSubirDescer : PlataformaSubir {
    protected bool descendo = false;

    private void OnGUI() {
        base.OnGUI();
        Event ev = Event.current;
        if (ev.type == EventType.KeyDown && ev.keyCode.ToString().Length == 1 && char.IsLetter(ev.keyCode.ToString()[0])) {
            if (ev.keyCode.ToString() == "R" && textoPlataforma.Length >= 6) {
                if (textoPlataforma[textoPlataforma.Length - 2] == 'E' && textoPlataforma[textoPlataforma.Length - 3] == 'C'
                    && textoPlataforma[textoPlataforma.Length - 4] == 'S' && textoPlataforma[textoPlataforma.Length - 5] == 'E'
                    && textoPlataforma[textoPlataforma.Length - 6] == 'D') {
                    descendo = true;
                    Invoke("PararDeDescer", force * 2);
                }
            }
        }
    }

    protected void PararDeDescer() {
        descendo = false;
    }

    void Update () {
        base.Update();
        if (descendo) {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
