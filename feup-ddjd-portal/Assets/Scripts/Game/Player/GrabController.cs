using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    private bool holding = false;
    private GameObject cube;

    // // Update is called once per frame
    void Update() {
        RaycastHit2D[] grabCheckRight = Physics2D.RaycastAll(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabCheckLeft = Physics2D.RaycastAll(grabDetect.position, Vector2.left * transform.localScale, rayDist);

        if(Input.GetKeyDown(KeyCode.E)){
            if(!holding){
                foreach (RaycastHit2D i in grabCheckRight){
                    if(i.collider.tag == "Cube"){
                        GrabCube(i);
                        break;
                    }
                }

                foreach (RaycastHit2D i in grabCheckLeft){
                    if(i.collider.tag == "Cube"){
                        GrabCube(i);
                        break;
                    }
                }
            }
            else {
                DropCube();
            }   
        }
    }

    private void GrabCube(RaycastHit2D grabCheck){
        grabCheck.collider.gameObject.transform.parent = boxHolder;
        grabCheck.collider.gameObject.transform.position = boxHolder.position;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        cube = grabCheck.collider.gameObject; 

        holding = true;
    }

    private void DropCube(){
        cube.transform.parent = null;
        cube.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        holding = false;
    }
}
