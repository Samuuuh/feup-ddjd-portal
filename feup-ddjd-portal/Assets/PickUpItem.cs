// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpItem : MonoBehaviour{

//     private bool pickUpAllowed = false;
//     // // Start is called before the first frame update
//     // void Start()
//     // {
        
//     // }

//     // // Update is called once per frame
//     void Update(){
//         if (pickUpAllowed){

//             if(Input.GetKeyDown(KeyCode.E)){
//                 PickUp();
//             }
//         }
//     }


//     void OnTriggerEnter2D(Collider2D col){

//         if (col.tag == "Player"){

//             pickUpAllowed = true
//         }

//     }

//     void OnTriggerExit2D(Collider2D col){

//         if (col.tag == "Player"){

//             pickUpAllowed = false
//         }

//     }

//     void Pickup(){

//     }


// }
