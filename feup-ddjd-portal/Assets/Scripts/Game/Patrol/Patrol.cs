using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float groundDistance = 1f;
    public float wallDistance = 0.125f;
    private bool movingRight = true ;
    public Transform groundDetection;
    public GameObject player;
    private GameObject followArea;


    // void Start(){
    //     followArea = gameObject.transform.GetChild(1).gameObject;
    // }


    // public void MoveAimlessly(bool direction){

    //     movingRight = direction;
        
        
    //     // Change Direction at platform end
    //     RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance);
    //     RaycastHit2D wallInfoLeft = Physics2D.Raycast(groundDetection.position, Vector2.left, wallDistance);
    //     RaycastHit2D wallInfoRight = Physics2D.Raycast(groundDetection.position, Vector2.right, wallDistance);

    //     Debug.Log(movingRight);
    //     Debug.Log(wallInfoLeft.collider);

    //     // Ground Collision
    //     if(groundInfo.collider == false){
    //         if(movingRight){
    //             transform.eulerAngles = new Vector3(0,-180,0);
    //             movingRight = false;
    //         }
    //         else{
    //             transform.eulerAngles = new Vector3(0,0,0);
    //             movingRight = true;
    //         }
    //     }else{
            

    //     }


    //     // // Left Wall Collision
    //     // if(!movingRight && wallInfoLeft.collider.tag == "Ground"){
    //     //     transform.eulerAngles = new Vector3(0,0,0);
    //     //     movingRight = true;
    //     // }

    //     // Left Wall Collision
    //     if(!movingRight && wallInfoLeft.collider != null){
    //         if(wallInfoLeft.collider.tag == "Ground"){
    //             transform.eulerAngles = new Vector3(0,0,0);
    //             movingRight = true;
    //         }
            
    //     }

    //     // Right Wall Collision
    //     // if(movingRight && wallInfoRight.collider.tag == "Ground"){
    //     //     transform.eulerAngles = new Vector3(0,-180,0);
    //     //     movingRight = false;
    //     // }

    //     // Move Patrolling unit
    //     transform.Translate(Vector2.right * speed * Time.deltaTime);
    // }


    // void Update(){
    //     Move();
    // }

    // void OnTriggerEnter2D(Collider2D collider){
    
    //     // End Game on teacher collision
    //     if(collider.name == "Player"){
    //         Debug.Log("TEACHER FOUND YOU. GAME OVER");
    //     }        
    // }



    // void OnTriggerExit2D(Collider2D collider){
        
    //     Debug.Log(collider.name);

    //     if(collider.name == "Follow Area"){
    //         Debug.Log("Exiting collision");
    //         // Move();
    //     }
    // }

    //  void SwapDirection(){
    //     if(movingRight) movingRight = false;
    //     else movingRight = true;

    // }

    // void Move(){
    //     if(movingRight) transform.Translate(Vector2.right * speed * Time.deltaTime);
    //     else transform.Translate(Vector2.left * speed * Time.deltaTime);
    // }


    // void OnTriggerStayt2D(Collider2D collider){
        
    //     Debug.Log(collider.name);


    // }
}
