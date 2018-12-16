using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    private Animator anim;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Horizontal") > 0f) {
            rb.AddForce(Vector2.right * speed);
        }else if (Input.GetAxis("Horizontal") < 0f) {
            rb.AddForce(Vector2.left * speed);
        } else {
            rb.velocity = Vector2.zero;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            GameManager.Instance.GameOver();
        }
    }
}
