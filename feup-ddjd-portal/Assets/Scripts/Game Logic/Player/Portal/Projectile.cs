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
    private int wallID;

    void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

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

       Vector3 pos = new Vector3(transform.position.x,transform.position.y,0);
        if(type == "horizontal"){
            if (pos.x - 1.55f < leftEdge){
                pos.x = leftEdge + 1.55f;
            }
            else if (pos.x + 1.55f > rightEdge){
                pos.x = rightEdge - 1.55f;
            }

            pos.y =  relativePosition;
        }
        else if(type =="vertical"){
            if (pos.y + 1.55f > topEdge){
                pos.y = topEdge - 1.55f;
            }
            else if (pos.y - 1.55f < bottomEdge){
                pos.y = bottomEdge + 1.55f;
            }

            pos.x = relativePosition;
        }

        PortalsTooClose(pos,type);

        GameObject newPortal = Instantiate(portalEffect, pos, value);
        newPortal.GetComponent<Portal>().displacement = displacement;
        if (type == "vertical") { newPortal.GetComponent<Portal>().isVertical = true; } 
        else { newPortal.GetComponent<Portal>().isVertical = false; }

        Destroy(gameObject);
    }

    void GetWallEdges(GameObject wall){
        wallID = wall.GetInstanceID();
        float wallWidth = wall.transform.lossyScale.x;
        float wallHeight =  wall.transform.lossyScale.y;

        topEdge = wall.transform.position.y + wallHeight/2 +0.25f;
        bottomEdge = wall.transform.position.y - wallHeight/2 - 0.25f;

        leftEdge = wall.transform.position.x - wallWidth/2 - 0.25f;
        rightEdge = wall.transform.position.x + wallWidth/2 + 0.25f;
    }

    // Override the previous portal if it is too close
    void PortalsTooClose(Vector3 position, string type){
        GameObject portal = null;

        if(isOrange) portal = GameObject.FindGameObjectWithTag("Blue Portal");
        else if(!isOrange) portal = GameObject.FindGameObjectWithTag("Orange Portal");

        
        if(portal != null){
            Vector3 portalPosition = portal.transform.position;

            if(type == "vertical" && Mathf.Abs(portalPosition.y - position.y) < 1.75f && portalPosition.x == position.x){
                Destroy(portal);
            }
            else if(type == "horizontal" && Mathf.Abs(portalPosition.x - position.x) < 1.75f && portalPosition.y == position.y){
                Destroy(portal);
            }

        }        
        
    }
}