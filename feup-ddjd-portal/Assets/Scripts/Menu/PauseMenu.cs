using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu: MonoBehaviour {
    [SerializeField] private GameObject _gameObject;
    public bool isPaused;

    private void Start() {
        isPaused = false;
    }

    public void togglePause() {
        if (Time.timeScale == 0f) {
            isPaused = false;
            _gameObject.SetActive(false);
            Time.timeScale = 1f;
        } else {
            isPaused = true;
            _gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}