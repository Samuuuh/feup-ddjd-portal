using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName="Game Data")]
public class GameData: ScriptableObject {
    public class Settings : ScriptableObject {
        private static Settings _instance;
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
}