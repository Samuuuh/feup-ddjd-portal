using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public bool isOrange;
    public float speed;
    public LayerMask whatIsSolid;
    public GameObject portalEffect;

    private Vector3 startPosition, endPosition;

    private float bottomEdge, topEdge, rightEdge, leftEdge;

    void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0, whatIsSolid);

        if (hitInfo.collider != null) {
            endPosition = transform.position - startPosition;
            
            GetWallEdges(hitInfo.collider.gameObject);

            if (hitInfo.collider.tag == "SurfaceVer") {
                if (endPosition.x < 0f) {
                    endPosition.x = -1.5f;

                    Debug.Log(1);
                    CreatePortal(Quaternion.Euler(0f, 0f, 180f), endPosition.x, "vertical");
                } else {
                    endPosition.x = 1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, 0f), endPosition.x, "vertical");

                }
            } else if (hitInfo.collider.tag == "SurfaceHor") {
                 if (endPosition.y < 0f) {
                    endPosition.y = -1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, -90f), endPosition.y, "horizontal");
                } else {
                    endPosition.y = 1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, 90f), endPosition.y, "horizontal");
                }
            } else {
                Destroy(gameObject);
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void CreatePortal(Quaternion value, float displacement, string type) {
        if (isOrange) { 
            if (GameObject.FindGameObjectWithTag("Orange Portal") != null) {
                Destroy(GameObject.FindGameObjectWithTag("Orange Portal"));
            }
        } else {
            if (GameObject.FindGameObjectWithTag("Blue Portal") != null) {
                Destroy(GameObject.FindGameObjectWithTag("Blue Portal"));
            }
        }

       Vector3 pos = transform.position;


       Debug.Log("pos " + transform.position);
       Debug.Log("top " + topEdge);
       Debug.Log("bottom " + bottomEdge);
       Debug.Log("left " + leftEdge);
       Debug.Log("right " + rightEdge);


       if(type == "horizontal"){
           if(transform.position.x < leftEdge){
               pos.x = leftEdge;
           }
           else if(transform.position.x > rightEdge){
               pos.x = rightEdge;
           }
       }
       else if(type =="vertical"){
           if(transform.position.y > topEdge){
               pos.y = topEdge;
       }
            else if(transform.position.y < bottomEdge){
                pos.y = bottomEdge;
            }
       }
       
       

    //    if(transform.position.x > topEdge){
    //        pos.y = topEdge;
    //    }
    //    else if(transform.position.x < bottomEdge){
    //        pos.y = bottomEdge;
    //    }
    //    else if(transform.position.y < leftEdge){
    //        pos.x = leftEdge;
    //    }
    //    else if(transform.position.y > rightEdge){
    //        pos.x = rightEdge;
    //    }



       GameObject newPortal = Instantiate(portalEffect, pos, value);
       newPortal.GetComponent<Portal>().displacement = displacement;
       if (type == "vertical") { newPortal.GetComponent<Portal>().isVertical = true; } 
       else { newPortal.GetComponent<Portal>().isVertical = false; }

        Destroy(gameObject);
    }


    void GetWallEdges(GameObject wall){
        // Get Collision Area Width
        SpriteRenderer wallRenderer = wall.GetComponent<SpriteRenderer>();
        // float wallWidth = wallRenderer.sprite.bounds.size.x * wall.transform.lossyScale.x;
        // float wallHeight = wallRenderer.sprite.bounds.size.y * wall.transform.lossyScale.y;

        float wallWidth = wall.transform.lossyScale.x;
        float wallHeight =  wall.transform.lossyScale.y;

        // Debug.Log("x=" + wall.transform.lossyScale.x);
        // Debug.Log("y=" + wall.transform.lossyScale.y);
       

        // Debug.Log("Width " + wallWidth);
        // Debug.Log("Height " + wallHeight);


        topEdge = wall.transform.position.y + wallHeight/2 - 1.15f;
        bottomEdge = wall.transform.position.y - wallHeight/2 + 1.15f;

        leftEdge = wall.transform.position.x - wallWidth/2 + 1.15f;
        rightEdge = wall.transform.position.x + wallWidth/2 - 1.15f;


     
      
    }


}