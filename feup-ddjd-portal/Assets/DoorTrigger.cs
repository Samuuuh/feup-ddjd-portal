using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    // bool isOpened = false;

    //movement speed in units per second
    private float movementSpeed = 0.5f;
    private float baseYAxis;

    

    // Start is called before the first frame update
    void Start(){
        baseYAxis = door.transform.position.y;
    }

    // Update is called once per frame
    void Update(){
        if (door.transform.position.y > baseYAxis){

            //update the position
            door.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }
        // if (door.transform.position.y <= baseYAxis + 2){
        //     isOpened = false;
        // }
    }

    void OnTriggerEnter2D(Collider2D col){

        // if(!isOpened ){
        //     door.transform.position += new Vector3(0,baseYAxis + 2,0); // Change y value later
        //     isOpened = true;
        // }

        if(door.transform.position.y >= baseYAxis && door.transform.position.y < baseYAxis + 2.0){
             door.transform.position += new Vector3(0, 2*movementSpeed * Time.deltaTime, 0);
        }
       
        
    }
}
