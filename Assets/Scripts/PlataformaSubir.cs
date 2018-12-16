using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSubir : PlataformaDefault {
    [SerializeField]
    protected float target;
    [SerializeField]
    protected float force = 0.6f;
    [SerializeField]
    protected float speed = 5;
    [SerializeField]
    protected float maximumY;

    protected bool subindo = false;
    protected Vector2 newPosition;
    protected bool podeSeMover = true;

    protected void OnGUI() {
        base.OnGUI();
        Event ev = Event.current;
        if (ev.type == EventType.KeyDown && ev.keyCode.ToString().Length == 1 && char.IsLetter(ev.keyCode.ToString()[0])) {
            if(ev.keyCode.ToString() == "R" && textoPlataforma.Length >= 5) {
                if (textoPlataforma[textoPlataforma.Length - 2] == 'I' && textoPlataforma[textoPlataforma.Length - 3] == 'B'
                    && textoPlataforma[textoPlataforma.Length - 4] == 'U' && textoPlataforma[textoPlataforma.Length - 5] == 'S') {
                    subindo = true;
                    Invoke("PararDeSubir", force);
                }
            }
        }
    }

    protected void PararDeSubir() {
        subindo = false;
    }

    protected void Update () {
        base.Update();
        if (GetComponent<RectTransform>().anchoredPosition.y < maximumY) {
            if (subindo) {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
        }
	}
}
