using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchPlayer : MonoBehaviour {
    [SerializeField] private GameEvent _gameOver;

    void OnTriggerEnter2D(Collider2D col)  {
        if (col.gameObject.tag == "Player") {
            _gameOver?.Invoke();
        }
    }
}
