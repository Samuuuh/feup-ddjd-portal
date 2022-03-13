using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public bool isOrange;
    public float distance = 0.2f;

    public bool isVertical;
    public float displacement;
    
    void Start() {
    }

    void OnTriggerEnter2D(Collider2D other) {
        Vector2 newVelocity, newPosition;
        
        if(other.gameObject.tag == "Player") {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            Transform destination;
            float displacementPortal; 
            if (isOrange) {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");

                destination = bluePortal.GetComponent<Transform>();
                displacementPortal = bluePortal.GetComponent<Portal>().displacement;
                if (bluePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x - displacementPortal, destination.position.y);
                    newVelocity = new Vector2(Mathf.Abs(rb.velocity.y), 0);
                    
                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y - displacementPortal);
                     if (bluePortal.GetComponent<Portal>().displacement < -1f) {
                        newVelocity = new Vector2(0, Mathf.Abs(rb.velocity.y*1.15f));
                    }
                }
           }  else {
               GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");

               destination = orangePortal.GetComponent<Transform>();
                displacementPortal = orangePortal.GetComponent<Portal>().displacement;

                if (orangePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x  - displacementPortal, destination.position.y);
                    newVelocity = new Vector2(Mathf.Abs(rb.velocity.y), 0);

                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y  - displacementPortal);
                    if (orangePortal.GetComponent<Portal>().displacement < -1f) {
                        newVelocity = new Vector2(0, Mathf.Abs(rb.velocity.y*1.15f));
                    }
                }
            }

            if (Vector2.Distance(transform.position, other.transform.position) > distance) {
                other.transform.position = newPosition;
                rb.velocity = newVelocity;
            }
        }
    }
}
