using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLost : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)  {

        if(coll.name == "Player"){
            SceneManager.LoadScene("Game Over");
        }
    }
}
