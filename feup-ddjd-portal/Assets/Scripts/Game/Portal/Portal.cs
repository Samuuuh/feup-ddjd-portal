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
        if(other.gameObject.tag == "Player") {
            Rigidbody2D tempRigid = other.gameObject.GetComponent<Rigidbody2D>();

            Transform destination;
            float displacementPortal; 
            Vector2 newVelocity = new Vector2(0, 0);
            Vector2 newPosition = new Vector2(0, 0);

            if (isOrange) {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");

                destination = bluePortal.GetComponent<Transform>();
                displacementPortal = bluePortal.GetComponent<Portal>().displacement;
                if (bluePortal.GetComponent<Portal>().isVertical) {
                     newPosition = new Vector2(destination.position.x - displacementPortal, destination.position.y);
                    newPosition = new Vector2(destination.position.x, destination.position.y - displacementPortal);
                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y - displacementPortal);
                }

                if (bluePortal.GetComponent<Portal>().displacement < -1f) {
                    newVelocity = new Vector2(0, Mathf.Abs(tempRigid.velocity.y*1.25f));
                }
                //else if (bluePortal.GetComponent<Portal>().isVertical) {
                //     newVelocity = new Vector2(Mathf.Abs(tempRigid.velocity.y*5f) + tempRigid.velocity.x, 0);
                // }
           }  else {
               GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");

               destination = orangePortal.GetComponent<Transform>();
                displacementPortal = orangePortal.GetComponent<Portal>().displacement;

                if (orangePortal.GetComponent<Portal>().isVertical) {
                    newPosition = new Vector2(destination.position.x  - displacementPortal, destination.position.y);
                } else {
                    newPosition = new Vector2(destination.position.x, destination.position.y  - displacementPortal);
                }

                if (orangePortal.GetComponent<Portal>().displacement < -1f) {
                    newVelocity = new Vector2(0, Mathf.Abs(tempRigid.velocity.y*1.25f));
                 }
                //else if (orangePortal.GetComponent<Portal>().isVertical) {
                //     newVelocity = new Vector2(Mathf.Abs(tempRigid.velocity.y*5f) + tempRigid.velocity.x, 0);
                // }
            }

            if (Vector2.Distance(transform.position, other.transform.position) > distance) {
                other.transform.position = newPosition;

                if (newVelocity.y != 0) {
                    tempRigid.velocity = newVelocity;
                }
            }
        }
    }
}
