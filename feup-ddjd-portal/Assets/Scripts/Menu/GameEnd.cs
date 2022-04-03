using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private Text scoreValue;

    void Start() {
        scoreValue.text = "Score: " + manager.GetInstance().lastLevelScore;
    }

    public void Restart() {
        manager.LevelOne();
    }

    public void MainMenu() {
        manager.MainMenu();
    }
}
