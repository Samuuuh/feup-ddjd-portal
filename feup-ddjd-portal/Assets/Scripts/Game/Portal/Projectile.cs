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
    private Vector3 wallCenter; 

    void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0, whatIsSolid);

        if (hitInfo.collider != null) {
            endPosition = transform.position - startPosition;
            
            GetWallEdges(hitInfo.collider.gameObject);

            if (hitInfo.collider.tag == "SurfaceVer") {
                if (endPosition.x < 0f) {
                    endPosition.x = -1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, 180f), endPosition.x, "vertical", rightEdge);
                } else {
                    endPosition.x = 1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, 0f), endPosition.x, "vertical", leftEdge);

                }
            } else if (hitInfo.collider.tag == "SurfaceHor") {
                 if (endPosition.y < 0f) {
                    endPosition.y = -1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, -90f), endPosition.y, "horizontal", topEdge);
                } else {
                    endPosition.y = 1.5f;
                    CreatePortal(Quaternion.Euler(0f, 0f, 90f), endPosition.y, "horizontal", bottomEdge);
                }
            } else {
                Destroy(gameObject);
            }
        }
    }

    void CreatePortal(Quaternion value, float displacement, string type, float relativePosition) {
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
        if(type == "horizontal"){
            if (transform.position.x < leftEdge){
                pos.x = leftEdge;
            }
            else if (transform.position.x > rightEdge){
                pos.x = rightEdge;
            }

            pos.y =  relativePosition;
        }
        else if(type =="vertical"){
            if (transform.position.y > topEdge){
                pos.y = topEdge;
            }
            else if (transform.position.y < bottomEdge){
                pos.y = bottomEdge;
            }

            pos.x = relativePosition;
        }

       GameObject newPortal = Instantiate(portalEffect, pos, value);
       newPortal.GetComponent<Portal>().displacement = displacement;
       if (type == "vertical") { newPortal.GetComponent<Portal>().isVertical = true; } 
       else { newPortal.GetComponent<Portal>().isVertical = false; }

        Destroy(gameObject);
    }


    void GetWallEdges(GameObject wall){
        float wallWidth = wall.transform.lossyScale.x;
        float wallHeight =  wall.transform.lossyScale.y;

        topEdge = wall.transform.position.y + wallHeight/2 +0.25f;
        bottomEdge = wall.transform.position.y - wallHeight/2 - 0.25f;

        leftEdge = wall.transform.position.x - wallWidth/2 - 0.25f;
        rightEdge = wall.transform.position.x + wallWidth/2 + 0.25f;
    }
}