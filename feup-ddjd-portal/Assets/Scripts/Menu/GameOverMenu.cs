using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    [SerializeField]
    private GameManager manager;

    public void restart() {
        manager.LevelOne();
    }
}
