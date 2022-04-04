using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer: MonoBehaviour {
    public float currentTime;

    [SerializeField] private Text _countdownText;
    [SerializeField] private float _startingTime;
    
    void Start() {
        currentTime = _startingTime;
    }

    void Update() {
        currentTime -= Time.deltaTime;

        if (currentTime <= 300f) {
            _countdownText.color = Color.red;
        }

        currentTime = Math.Max(currentTime, 0);

        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = Mathf.RoundToInt(currentTime % 60);

        _countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}