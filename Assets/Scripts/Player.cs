using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private GameObject hook;
    private Animator anim;
    private Rigidbody2D rb;
    private bool walkingLeft = false;
    private bool walkingRight = false;
    private bool puxando = false;

    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            walkingRight = true;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            walkingLeft = true;
        if (Input.GetKeyUp(KeyCode.RightArrow))
            walkingRight = false;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            walkingLeft = false;
        if (puxando)
            hook.SetActive(true);
        else
            hook.SetActive(false);
    }

    void FixedUpdate () {
        if (walkingRight) {
            rb.AddForce(Vector2.right * speed);
            transform.rotation = new Quaternion(0,0,0,transform.rotation.w);
            anim.SetBool("walking", true);
        }else if (walkingLeft) {
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.w);
            anim.SetBool("walking", true);
            rb.AddForce(Vector2.left * speed);
        } else {
            anim.SetBool("walking", false);
            rb.velocity = Vector2.zero;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Kill")) {
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject.CompareTag("File")) {
            GameManager.Instance.AumentarArquivos();
            Destroy(collision.gameObject);
        }
    }

    private void MudarHook() {
        puxando = !puxando;
        if (puxando)
            Invoke("MudarHook", 0.4f);
    }

    public void Puxar() {
        Invoke("MudarHook", 0.4f);
        anim.SetBool("hooking", true);
    }
}
