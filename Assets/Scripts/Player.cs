using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    private Animator anim;
    private Rigidbody2D rb;
    private bool walkingLeft = false;
    private bool walkingRight = false;

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
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (walkingRight) {
            rb.AddForce(Vector2.right * speed);
            anim.SetBool("walking", true);
        }else if (walkingLeft) {
            anim.SetBool("walking", true);
            rb.AddForce(Vector2.left * speed);
        } else {
            anim.SetBool("walking", false);
            rb.velocity = Vector2.zero;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            GameManager.Instance.GameOver();
        }
    }
}
