using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelMenu : MonoBehaviour {
    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private Text scoreValue;

    void Start() {
        scoreValue.text = "Score: " + manager.GetInstance().lastLevelScore;
    }

    public void NextLevel() {
        manager.NextLevel();
    }

    public void MainMenu() {
        manager.NextLevel();
    }
}
