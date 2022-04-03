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

    public void SetScore(float value) {
        Settings.GetInstance().lastLevelScore = value;
    }

    public void LoseGame() {
        SceneManager.LoadScene("Game Over");
    }

    public void WinGame() {
        SceneManager.LoadScene("Next Level");
    }

    public void NextLevel() {
        SceneManager.LoadScene("Level One");
    }
}