using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    bool isPressed = false;

    //movement speed in units per second
    private float movementSpeed = 0.5f;
    private float baseYAxis;
    private Vector3 basePosition;

    

    // Start is called before the first frame update
    void Start(){
        baseYAxis = door.transform.position.y;
        basePosition = door.transform.position;
    }

    // Update is called once per frame
    void Update(){

        if(isPressed && door.transform.position.y < baseYAxis + 2.0){
            if(door.transform.position.y < baseYAxis + 2.0){
             door.transform.position += new Vector3(0, 2*movementSpeed * Time.deltaTime, 0);
            }
        }
        else if (!isPressed){

            if(door.transform.position.y - movementSpeed * Time.deltaTime >= baseYAxis)
                //update the position
                door.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
            else{
                door.transform.position = basePosition;
            }
        }
       
    }

    // void OnTriggerEnter2D(Collider2D col){
    //     isPressed = true;
    // }

    void OnTriggerExit2D(Collider2D col){
        isPressed = false;
    }

    void OnTriggerStay2D(Collider2D col){
        isPressed = true;
    }



    

    
}
