using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchPlayer : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)  {
        if (col.name == "Player") {
            SceneManager.LoadScene("Game Over");
        }
    }
}
