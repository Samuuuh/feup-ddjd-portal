using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArea : MonoBehaviour
{

    public GameObject player;
    public GameObject patrol;
    public GameObject collisionArea;
    
    // private float directionValue;
    private float speed = 2f;
    private Vector3 direction;
    public bool foundPlayer = false;
    private bool movingRight = true;

    private float rightEdge;
    private float leftEdge;


    void Start(){

        // Get Area Width
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
        
        if(!foundPlayer){
            Move();
        }else{
            FollowPlayer();
        }
    }

    void FollowPlayer(){
        direction = player.transform.position - patrol.transform.position;

        Debug.Log("Following Player");

        if(direction.x < 0){
            // Move Left
            movingRight = false;
            Move();
        }
        else if (direction.x > 0){
            // Move Right
            movingRight = true;
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.name == "Player"){
            foundPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.name == "Player"){
            foundPlayer = false;
        }
    }

    void SwapDirection(){
        if(movingRight) movingRight = false;
        else movingRight = true;
    }

    void Move(){

        // Check direction before moving
        if(movingRight && patrol.transform.position.x >= rightEdge) SwapDirection();
        else if(!movingRight && patrol.transform.position.x <= leftEdge) SwapDirection();
        
        // Move in the selected direction
        if(movingRight) patrol.transform.Translate(Vector2.right * speed * Time.deltaTime);
        else patrol.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

}
