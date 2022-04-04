using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {
    [SerializeField] private GameData data;
    [SerializeField] private Text scoreValue;

    void Start() {
        scoreValue.text = "Score: " + data.GetInstance().lastLevelScore;
    }

    public void Restart() {
        SceneManager.LoadScene("Level One");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
