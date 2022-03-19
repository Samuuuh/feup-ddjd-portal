using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public bool isOrange;
    public float distance = 0.2f;

    public bool isVertical;
    public float displacement;

    public bool isActive = true;
    private float timeDisabled = 0.3f;
    
    void Update() {
        if (timeDisabled < 0) {
            GetComponent<Collider2D>().enabled = true;
            isActive = true;
            timeDisabled = 0.3f;
        }

        if ( isActive) {
            timeDisabled -= Time.deltaTime;
        }
    }
    
    public void DisablePortal() {
        GetComponent<Collider2D>().enabled = false;
        isActive = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Orange Portal") {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Player") {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            Transform destination;
            float displacementPortal; 

             Vector2 newPosition = new Vector2(0, 0);
            Vector2 newVelocity = new Vector2(0, 0);

            if (isOrange) {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");
                bluePortal.GetComponent<Portal>().DisablePortal();

                destination = bluePortal.GetComponent<Transform>();
                displacementPortal = bluePortal.GetComponent<Portal>().displacement;
                if (bluePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x - displacementPortal, destination.position.y);
                    newVelocity = new Vector2(-Mathf.Abs(rb.velocity.y) * displacementPortal/1.5f, 0);
                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y - displacementPortal);
                     if (bluePortal.GetComponent<Portal>().displacement < 0f) {
                        newVelocity = new Vector2(0, Mathf.Abs(rb.velocity.y*1.15f));
                    } else {
                        newVelocity = new Vector2(0, -Mathf.Abs(rb.velocity.y));
                    }
                }
           }  else {
               GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");
               orangePortal.GetComponent<Portal>().DisablePortal();

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
            }

            if (Vector2.Distance(transform.position, other.transform.position) > distance) {
                other.transform.position = newPosition;

                if ( newVelocity.y != 0 ||  newVelocity.x != 0) {
                    rb.velocity = newVelocity;
                }
            }
        } 
    }
}
