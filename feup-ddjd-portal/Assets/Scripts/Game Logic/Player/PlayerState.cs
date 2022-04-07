using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    private PlayerMovement playerMovement;

    public bool facingRight = true;
    private Rigidbody2D rigidBody;
    private Animator animator;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update() {
        float mx = Input.GetAxisRaw("Horizontal");

        if (playerMovement.isJumping) {
            animator.SetFloat("Jump", 1.0f);
        } else {
            animator.SetFloat("Jump", 0.0f);
        }

        if (mx != 0) {
            if (rigidBody.velocity.x < -0.01f) {
                if (facingRight) {
                    transform.eulerAngles = new Vector2(0, 180);
                    FlipPlayer();
                }

                animator.SetFloat("Speed", 1.0f);
            } else if (rigidBody.velocity.x > 0.01f) {
                if (!facingRight) {
                    transform.eulerAngles = new Vector2(0, 0);
                    FlipPlayer();
                }

                animator.SetFloat("Speed", 1.0f);
            }  else {
                animator.SetFloat("Speed", 0.0f);
            }
        } else {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    private void FlipPlayer() {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        foreach (Transform child in transform) {
                Vector3 childScale = transform.localScale;
                childScale.x  *= -1;
                transform.localScale = childScale;
        }
    }
}
