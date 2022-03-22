using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    
    private HashSet<GameObject> elementsOnTop = new HashSet<GameObject>();

    bool isPressed = false;

    //movement speed in units per second
    private float movementSpeed = 0.5f;
    private float baseYAxis;
    private Vector3 basePosition;

    public Animator buttonAnimator;
    
    // Start is called before the first frame update
    void Start(){
        baseYAxis = door.transform.position.y;
        basePosition = door.transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (isPressed && door.transform.position.y < baseYAxis + 2.0){
            if(door.transform.position.y < baseYAxis + 2.0) {
                door.transform.position += new Vector3(0, 2*movementSpeed * Time.deltaTime, 0);
            }
        }
        else if (!isPressed){
            if(door.transform.position.y - movementSpeed * Time.deltaTime >= baseYAxis)
                door.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
            else {
                door.transform.position = basePosition;
            }
        }
       
    }

    void OnTriggerExit2D(Collider2D col){



        if(elementsOnTop.Count == 1){
            if (isPressed) isPressed = false;
            buttonAnimator.SetBool("isPressed", false);
        }

        elementsOnTop.Remove(col.gameObject);

    }

    void OnTriggerEnter2D(Collider2D col){

        if(elementsOnTop.Count == 0){
            if (!isPressed) isPressed = true;
            buttonAnimator.SetBool("isPressed", true);
        }

        elementsOnTop.Add(col.gameObject);
    }

}
