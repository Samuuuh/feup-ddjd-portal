using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    [Header("Player Rigid Body")]
    public Rigidbody2D rigidBody;

    [Header("Gravity")]
    public float gravityScale;
    public float fallGravityMultiplier;

    [Header("Friction")]
	public float frictionAmount;

    [Header("Other Physics")]
    public float coyoteTime;

    [Header("Movement")]
    public float movementSpeed;
    public float velocityPower;
    public float acceleration;
    public float deceleration;

    [Header("Jump")]
    public float jumpForce;

    // Jump
    private float lastGroundedTime;

    private bool isGrounded = true;
    private bool isJumping;
    private float mx;

    void Update() {
        mx = Input.GetAxisRaw("Horizontal");

        #region Jump
        lastGroundedTime -= Time.deltaTime;

        if (isGrounded) {
            isJumping = false;
            lastGroundedTime = coyoteTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (lastGroundedTime > 0f && !isJumping) {
			    Jump();
            }
        }
        #endregion
    }

    void FixedUpdate() {
        #region Run
        float targetSpeed = mx * movementSpeed;
        float speedDiff = targetSpeed - rigidBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, velocityPower) * Mathf.Sign(speedDiff);
        
        if (!float.IsNaN(movement)) {
            rigidBody.AddForce(movement * Vector2.right);   
        }
        #endregion

        #region Gravity
        if (rigidBody.velocity.y < 0f) {
            rigidBody.gravityScale = gravityScale * fallGravityMultiplier;
        } else {
            rigidBody.gravityScale = gravityScale;
        }
        #endregion
        
        #region Friction
        if (lastGroundedTime > 0f && Mathf.Abs(mx) < 0.01f) {
            float amount = Mathf.Min(Mathf.Abs(rigidBody.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rigidBody.velocity.x);

            rigidBody.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);    
        }
        #endregion
    }

    private void Jump() {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        lastGroundedTime = 0f;
        isJumping = true;
    }
}