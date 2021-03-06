using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public bool isOrange;
    public float distance = 0.2f;

    public bool isVertical;
    public float displacement;

    public bool isActive = true;
    private float timeDisabled = 0.4f;
    
    void Update() {
        if (timeDisabled < 0) {
            GetComponent<Collider2D>().enabled = true;
            isActive = true;
            timeDisabled = 0.4f;
        }

        if (!isActive) {
            timeDisabled -= Time.deltaTime;
        }
    }
    
    public void DisablePortal() {
        GetComponent<Collider2D>().enabled = false;
        isActive = false;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Cube") {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            Transform destination;
            float displacementPortal; 

            Vector2 newPosition = new Vector2(0, 0);
            Vector2 newVelocity = new Vector2(0, 0);

            if (isOrange) {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");
                if (bluePortal == null) return;

                destination = bluePortal.GetComponent<Transform>();
                displacementPortal = bluePortal.GetComponent<Portal>().displacement;
                if (bluePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x - (displacementPortal* 1.5f), destination.position.y);
                    newVelocity = new Vector2(-Mathf.Abs(rb.velocity.y) * displacementPortal/1.5f, 0);
                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y - (displacementPortal* 1.5f));
                    if (bluePortal.GetComponent<Portal>().displacement < 0f) {
                        newVelocity = new Vector2(0, Mathf.Abs(rb.velocity.y*1.15f));
                    } else {
                        newVelocity = new Vector2(0, -Mathf.Abs(rb.velocity.y));
                    }
                }

                bluePortal.GetComponent<Portal>().DisablePortal();
            }  else {
                GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");
                if (orangePortal == null) return;

                destination = orangePortal.GetComponent<Transform>();
                displacementPortal = orangePortal.GetComponent<Portal>().displacement;

                if (orangePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x  - displacementPortal, destination.position.y);
                    newVelocity = new Vector2(-Mathf.Abs(rb.velocity.y) * displacementPortal/1.5f, 0);

                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y  - displacementPortal);
                    if (orangePortal.GetComponent<Portal>().displacement < 0f) {
                        newVelocity = new Vector2(0, Mathf.Abs(rb.velocity.y*1.15f));
                    } else {
                        newVelocity = new Vector2(0, -Mathf.Abs(rb.velocity.y));
                    }
                }

                orangePortal.GetComponent<Portal>().DisablePortal();
            }

            other.transform.position = newPosition;

            if ( newVelocity.y != 0 ||  newVelocity.x != 0) {
                rb.velocity = newVelocity;
            }
        } 
    }
}
