using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlataformaDefault : MonoBehaviour {
    protected Text platform;
    protected string textoPlataforma = "";
    protected string cursor = "█";
    protected int cursorPosition = 0;
    protected bool teclaPressionadaBackspace = false;
    protected BoxCollider2D bc;
    protected Rigidbody2D rb;

    protected void Start () {
        platform = GetComponent<Text>();
        platform.text = cursor;
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected void OnGUI() {
        Event ev = Event.current;
        if(ev.type == EventType.KeyDown && ev.keyCode.ToString().Length == 1 && char.IsLetter(ev.keyCode.ToString()[0])) {
            if(platform.text.Length <= 20) {
                textoPlataforma += ev.keyCode.ToString();
                platform.text = textoPlataforma;
            }
        }
    }

    protected void Update() {
        bc.size = new Vector2(platform.fontSize * platform.text.Length * 0.7f, bc.size.y);
        bc.offset = new Vector2(-960f + (platform.fontSize * platform.text.Length * 0.7f)/2, bc.offset.y);
        if (Input.GetKeyDown(KeyCode.Backspace) && !teclaPressionadaBackspace){
            textoPlataforma = textoPlataforma.Substring(0, textoPlataforma.Length - 1);
            platform.text = textoPlataforma;
            teclaPressionadaBackspace = true;
        }
        if (Input.GetKeyUp(KeyCode.Backspace)) {
            teclaPressionadaBackspace = false;
        }
    }

}
