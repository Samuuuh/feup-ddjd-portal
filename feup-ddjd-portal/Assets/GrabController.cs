using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour{
    
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    // public float pickUpRange = 5;
    // private GameObject heldObj;
    // public Transform holdParent;
    // public float moveForce = 250;


    // // Update is called once per frame
    void Update(){


        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Cube"){

            if(Input.GetKey(KeyCode.E)){
                    grabCheck.collider.gameObject.transform.parent = boxHolder;
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else{
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            
        
        }
    }

}
