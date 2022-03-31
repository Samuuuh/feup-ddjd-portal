using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor: MonoBehaviour {
    public bool canExit;

    void OnTriggerEnter2D(Collider2D col) {
        if ((col.gameObject.tag == "Player")) {
            if (canExit) {
                // TODO: A Level Manager would be nice, but not necessary since we only have one level
                SceneManager.LoadScene("Finished");
            } else {
                FindObjectOfType<AudioManager>().Play("GladosDontExit");
                Destroy(gameObject);
            }
        }
    }
}