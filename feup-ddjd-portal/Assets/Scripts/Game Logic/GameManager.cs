using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    [SerializeField] private GameData _data;

    public void gameOver() {
            SceneManager.LoadScene("Game Over");
    }

    public void gameEnd() {
            SceneManager.LoadScene("Game End");
    }
}