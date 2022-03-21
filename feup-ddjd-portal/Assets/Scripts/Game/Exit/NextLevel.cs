using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel: MonoBehaviour {
    public bool canExit;

    void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag == "Player")) {
            if (canExit) {
                SceneManager.LoadScene("Game Over");
            } else {
                // Glados saying: "You're dumb. Go grab the exams, and after i let you leave."
            }
            
        }
    }
}