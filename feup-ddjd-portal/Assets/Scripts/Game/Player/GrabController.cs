using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {
    
    // Player properties
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    // Cube properties
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
        // else{
        //     if(holding){
        //         cube.transform.position = boxHolder.position;
        //     }
        // }
    }

    private void GrabCube(RaycastHit2D grabCheck){
        cube = grabCheck.collider.gameObject; 
        cube.transform.parent = boxHolder;
        cube.transform.position = boxHolder.position;
        cube.GetComponent<Rigidbody2D>().isKinematic = true;

        
        Weapon.canShoot = false;
        holding = true;
    }

    private void DropCube(){
        cube.transform.parent = null;
        cube.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        
        Weapon.canShoot = true;
        holding = false;

    }
}
