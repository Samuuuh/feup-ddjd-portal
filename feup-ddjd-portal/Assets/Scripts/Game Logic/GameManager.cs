using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    [SerializeField] private GameData _data;

    public void gameOver() {
            SceneManager.LoadScene("Game Over");
    }

    public void gameEnd() {
            _data.SetScore((int) GetComponent<ScoreTimer>().currentTime);
            SceneManager.LoadScene("Game End");
    }
}