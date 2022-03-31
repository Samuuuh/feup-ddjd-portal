using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabExam : MonoBehaviour {
    [SerializeField]
    private GameObject exitClosed;

    [SerializeField]
    private GameObject exitOpen;

    void Start() {
        exitOpen.SetActive(false);
        exitClosed.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            exitOpen.SetActive(true);
            exitClosed.SetActive(false);

            Destroy(gameObject);
        }
    }
}
