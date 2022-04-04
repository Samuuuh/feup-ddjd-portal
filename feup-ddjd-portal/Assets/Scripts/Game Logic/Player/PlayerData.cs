using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Settings")]
public class PlayerData : ScriptableObject {
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
    public LayerMask jumpGround;
}
