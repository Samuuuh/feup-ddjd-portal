using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public bool isOrange;
    public float speed;
    public LayerMask whatIsSolid;
    public GameObject portalEffect;

    private Vector3 startPosition, endPosition;

    void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0, whatIsSolid);

        if (hitInfo.collider != null) {
            endPosition = transform.position - startPosition;
            Debug.Log(hitInfo.collider.tag);
            if (hitInfo.collider.tag == "SurfaceVer") {
                if (endPosition.x < 0f) {
                    endPosition.x = -1.5f;
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

       GameObject newPortal = Instantiate(portalEffect, transform.position, value);
       newPortal.GetComponent<Portal>().displacement = displacement;
       if (type == "vertical") { newPortal.GetComponent<Portal>().isVertical = true; } 
       else { newPortal.GetComponent<Portal>().isVertical = false; }

        Destroy(gameObject);
    }
}