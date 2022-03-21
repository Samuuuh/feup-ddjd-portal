using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float groundDistance = 1f;
    public float wallDistance = 0.125f;
    private bool movingRight = true;
    public Transform groundDetection;

    // Update is called once per frame
    void Update(){
        
        // Move Patrolling unit
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Change Direction at platform end
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance);
        RaycastHit2D wallInfoLeft = Physics2D.Raycast(groundDetection.position, Vector2.left, wallDistance);
        RaycastHit2D wallInfoRight = Physics2D.Raycast(groundDetection.position, Vector2.right, wallDistance);

        // Ground Collision
        if(groundInfo.collider == false){
            if(movingRight){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }

        // Left Wall Collision
        else if(!movingRight && wallInfoLeft.collider.tag == "Ground"){
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true;
        }

         // Right Wall Collision
        if(movingRight && wallInfoRight.collider.tag == "Ground"){
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;
        }


    }
}
