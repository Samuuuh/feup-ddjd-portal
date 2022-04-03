using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController: MonoBehaviour {
    [SerializeField]
    private GameManager manager;

    public void playGame() {
        manager.LevelOne();
    }

    public void exit() {
        Application.Quit();
    }
}