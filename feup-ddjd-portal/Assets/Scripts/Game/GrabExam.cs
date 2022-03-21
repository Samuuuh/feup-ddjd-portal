using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabExam : MonoBehaviour {
    public GameObject exitClosed;
    public GameObject exitOpen;

    // Start is called before the first frame update
    void Start() {
        exitOpen.SetActive(false);
        exitClosed.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);

            exitOpen.SetActive(true);
            exitClosed.SetActive(false);
        }
    }
}
