using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Rigidbody2D enteredRigidbody;
    private float enterVelocity, exitVelocity;

    private void OnTriggerEnter2D(Collider2D collision){

        enteredRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        enterVelocity = enteredRigidbody.velocity.x;

        if(gameObject.name == "BluePortal"){
            PortalControl.portalControlInstance.DisableCollider("orange");
            PortalControl.portalControlInstance.CreateClone("atOrange");
        }
        else if (gameObject.name == "OrangePortal"){
            PortalControl.portalControlInstance.DisableCollider("blue");
            PortalControl.portalControlInstance.CreateClone("atBlue");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        exitVelocity = enteredRigidbody.velocity.x;

        if (enterVelocity != exitVelocity) {
            Destroy(GameObject.Find("Clone"));
        } else if (gameObject.name != "Clone") {
            Destroy(collision.gameObject);
            PortalControl.portalControlInstance.EnableColliders();

            //PortalControl.portalControlInstance.clone = GameObject.Find("Clone");
            GameObject.Find("Clone").name = "Character";
        }
    }

}
