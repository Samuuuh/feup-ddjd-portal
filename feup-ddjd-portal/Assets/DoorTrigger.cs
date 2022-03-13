using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    // bool isOpened = false;

    void OnTriggerEnter2D(Collider2D col){

        // if( !isOpened ){
        
        Debug.Log("Triggered the Script");
        door.transform.position += new Vector3(0,2,0); // Change y value later
            // isOpened = true
        // }
        
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update(){
    //     if (isOpened){
    //         door.transform.position += new Vector2(0,-0.01)
    //     }
    //     else if
    // }
}
