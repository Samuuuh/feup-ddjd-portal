using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArea : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject patrol;
    private Vector3 direction;
    private bool movingRight = true;

    [SerializeField] private float speed = 2f;

    [SerializeField] private GameObject collisionArea;
    
    private float rightEdge;
    private float leftEdge;
    private Vector3 topLeft;
    private Vector3 bottomRight;

    void Start() {
        SpriteRenderer followAreaRenderer = GetComponent<SpriteRenderer>();
        float followWidth = followAreaRenderer.sprite.bounds.size.x * gameObject.transform.lossyScale.x;
        float followHeight = followAreaRenderer.sprite.bounds.size.y * gameObject.transform.lossyScale.y;

        topLeft = gameObject.transform.position + new Vector3(-followWidth / 2, followHeight / 2, 0);
        bottomRight = gameObject.transform.position + new Vector3(followWidth / 2, -followHeight / 2, 0);

        // Get Collision Area Width
        SpriteRenderer collisionAreaRenderer = collisionArea.GetComponent<SpriteRenderer>();
        float spriteWidth = collisionAreaRenderer.sprite.bounds.size.x * collisionArea.transform.lossyScale.x;

        // Get Player Width
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        float playerWidth = playerRenderer.sprite.bounds.size.x * player.transform.lossyScale.x;

        // Calculate Edges
        leftEdge = collisionArea.transform.position.x - (spriteWidth / 2) + (playerWidth/2);
        rightEdge = collisionArea.transform.position.x + (spriteWidth / 2) - (playerWidth/2);
    }

    void Update(){
        if (FindingPlayer()) {
            FollowPlayer();
        } else {
            Move();
        }
    }

    void FollowPlayer() {
        direction = player.transform.position - patrol.transform.position;

        if(direction.x < 0) { 
            movingRight = false;
            patrol.GetComponent<SpriteRenderer>().flipX = true;
            Move();
        } else if (direction.x > 0) { 
            movingRight = true;
            patrol.GetComponent<SpriteRenderer>().flipX = false;
            Move();
        }
    }

    void SwapDirection() {
        if (movingRight) {
            movingRight = false;
            patrol.GetComponent<SpriteRenderer>().flipX = true;
        } else{
            movingRight = true;
            patrol.GetComponent<SpriteRenderer>().flipX = false;
        } 
    }

    void Move() {
        // Check direction before moving
        if (movingRight && patrol.transform.position.x >= rightEdge) SwapDirection();
        else if (!movingRight && patrol.transform.position.x <= leftEdge) SwapDirection();
        
        // Move in the selected direction
        if (movingRight) patrol.transform.Translate(Vector2.right * speed * Time.deltaTime);
        else patrol.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    bool FindingPlayer() {
        return player.transform.position.x >= topLeft.x && player.transform.position.x <= bottomRight.x && player.transform.position.y <= topLeft.y && player.transform.position.y >= bottomRight.y;
    }
}
