using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {
    [SerializeField] private PlayerData data;

    [HideInInspector] public bool isJumping = true;
    [HideInInspector] public bool isGrounded = false;

    private float jumpTime;
    private float lastGroundedTime;
    private float mx;

    private Rigidbody2D rigidBody;
    private BoxCollider2D playerCollider;

    private void Start() {
        playerCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");
 
        #region Jump
        lastGroundedTime -= Time.deltaTime;
        jumpTime -= Time.deltaTime;

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, data.jumpGround);
        if (raycastHit2d.collider != null && jumpTime < 0f) {
            isJumping = false;
            lastGroundedTime = data.coyoteTime;
        } else if (rigidBody.velocity.y < 0f) {
            isJumping = true;
            jumpTime = 0f;
            lastGroundedTime = 0f;
        }
        #endregion
    }

    private void FixedUpdate() {
        #region Run
        float targetSpeed = mx * data.movementSpeed;
        float speedDiff = targetSpeed - rigidBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? data.acceleration : data.deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, data.velocityPower) * Mathf.Sign(speedDiff);
        
        if (!float.IsNaN(movement)) {
            rigidBody.AddForce(movement * Vector2.right);   
        }
        #endregion

        #region Gravity
        if (rigidBody.velocity.y < 0f) {
            rigidBody.gravityScale = data.gravityScale * data.fallGravityMultiplier;
        } else {
            rigidBody.gravityScale = data.gravityScale;
        }
        #endregion
        
        #region Friction
        if (lastGroundedTime > 0f && Mathf.Abs(mx) < 0.01f) {
            float amount = Mathf.Min(Mathf.Abs(rigidBody.velocity.x), Mathf.Abs(data.frictionAmount));
            amount *= Mathf.Sign(rigidBody.velocity.x);

            rigidBody.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);    
        }
        #endregion
    }

    public void Jump() {
        if (lastGroundedTime > 0f && !isJumping) {
            lastGroundedTime = 0f;
            jumpTime = 0.5f;

            isJumping = true;
            rigidBody.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
        }
    }
}