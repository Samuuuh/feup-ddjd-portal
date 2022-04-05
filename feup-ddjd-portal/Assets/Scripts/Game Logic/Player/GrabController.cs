using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabController : MonoBehaviour {
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    private bool holding = false;
    private GameObject cube;

    void Update() {

        
        RaycastHit2D[] grabRight1 = Physics2D.RaycastAll(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabRight2 = Physics2D.RaycastAll(grabDetect.position + new Vector3(0,1f,0), Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabRight3 = Physics2D.RaycastAll(grabDetect.position - new Vector3(0,1f,0), Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabCheckRight = ConcatArray(ConcatArray(grabRight1,grabRight2),grabRight3);

        RaycastHit2D[] grabLeft1 = Physics2D.RaycastAll(grabDetect.position, Vector2.left * transform.localScale, rayDist);
        RaycastHit2D[] grabLeft2 = Physics2D.RaycastAll(grabDetect.position + new Vector3(0,1f,0), Vector2.left * transform.localScale, rayDist);
        RaycastHit2D[] grabLeft3 = Physics2D.RaycastAll(grabDetect.position - new Vector3(0,1f,0), Vector2.left * transform.localScale, rayDist);
        RaycastHit2D[] grabCheckLeft = ConcatArray(ConcatArray(grabLeft1,grabLeft2),grabLeft3);

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
    else{
            if(holding){
                cube.transform.position = boxHolder.position;
            }
        }
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
        cube.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cube.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        
        Weapon.canShoot = true;
        holding = false;
    }


    private RaycastHit2D[] ConcatArray(RaycastHit2D[] front, RaycastHit2D[] back){

        RaycastHit2D[] combined = new RaycastHit2D[front.Length + back.Length];
        Array.Copy(front, combined, front.Length);
        Array.Copy(back, 0, combined, front.Length, back.Length);

        return combined;
    }
}
