using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabExam : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            GameEvent.instance.GrabExam();
            FindObjectOfType<AudioManager>().Play("GladosFindExit");
            Destroy(gameObject);
        }
    }
}
