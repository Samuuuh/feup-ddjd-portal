using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArea : MonoBehaviour
{

    public GameObject player;
    public GameObject patrol;
    
    // private float directionValue;
    private float speed = 2f;
    private Vector3 direction;
    public bool foundPlayer = false;
    private bool movingRight = true;



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
        else if(collider.name == "Patrol"){
            Debug.Log("Lost Contact With Patrol");
            SwapDirection();
            // movingRight = false;
        }
    }

    void SwapDirection(){
        if(movingRight) movingRight = false;
        else movingRight = true;

    }

    void Move(){
        if(movingRight) patrol.transform.Translate(Vector2.right * speed * Time.deltaTime);
        else patrol.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


}
