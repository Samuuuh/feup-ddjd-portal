using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName="Game Manager")]
public class GameManager: ScriptableObject {
    public class Settings : ScriptableObject {
        private static Settings _instance;

        public float currentLevel;
        public float lastLevelScore;
        
        public static Settings GetInstance() {
            if (!_instance) {
                _instance = FindObjectOfType<Settings>();
            }

            if (!_instance)  {
                _instance = CreateInstance<Settings>();
            }

            return _instance;
        }
    }

    public Settings GetInstance() {
        return Settings.GetInstance();
    }

    #region Global Attributes
    public void SetScore(float value) {
        Settings.GetInstance().lastLevelScore = value;
    }
    #endregion
    
    #region Scene Change
    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("Level One");
    }

    public void GameLose() {
        SceneManager.LoadScene("Game Over");
    }

    public void GameEnd() {
        SceneManager.LoadScene("Game End");
    }
    #endregion
}