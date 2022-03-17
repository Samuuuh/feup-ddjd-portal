using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour{
    
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;


    private bool holding = false;

    // // Update is called once per frame
    void Update(){


        RaycastHit2D grabCheckRight = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        RaycastHit2D grabCheckLeft = Physics2D.Raycast(grabDetect.position, Vector2.left * transform.localScale, rayDist);


        if(grabCheckRight.collider != null){
            ToggleGrab(grabCheckRight);
        }
        if(grabCheckLeft.collider != null){
            ToggleGrab(grabCheckLeft);
        }


        


        

    }


    private void ToggleGrab(RaycastHit2D grabCheck){


        

        if(grabCheck.collider.tag == "Cube" && Input.GetKeyDown(KeyCode.E)){

            if(!holding){
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                // grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                // grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass = 0f;
                
                holding = true;
            }else{
                grabCheck.collider.gameObject.transform.parent = null;
                // grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                holding = false;
            }
                    
        }
        // else if(grabCheck.collider.tag == "Cube" && holding){
        //     grabCheck.collider.gameObject.transform.parent = boxHolder;
        //     grabCheck.collider.gameObject.transform.position = boxHolder.position;
        // }
    }

}
