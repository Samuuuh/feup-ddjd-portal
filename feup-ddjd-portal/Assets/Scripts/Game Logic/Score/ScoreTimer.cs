using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer: MonoBehaviour {
    [SerializeField] private Text _countdownText;
    
    [SerializeField] private float _startingTime;
    private float _currentTime;
    
    void Start() {
        _currentTime = _startingTime;
    }

    void Update() {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 300f) {
            _countdownText.color = Color.red;
        }

        _currentTime = Math.Max(_currentTime, 0);

        float minutes = Mathf.Floor(_currentTime / 60);
        float seconds = Mathf.RoundToInt(_currentTime % 60);

        _countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}