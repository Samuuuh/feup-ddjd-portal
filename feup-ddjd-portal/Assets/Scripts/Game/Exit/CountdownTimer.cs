using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer: MonoBehaviour {
    float currentTime = 0f;
    float startingTime = 10f;
    float minutes = 0f;
    float seconds = 0f;
    string m = "";
    string s = "";

    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start() {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;

        if (currentTime <= 10) {
            countdownText.color = Color.red;
        }
        if (currentTime <= 0) {
            currentTime = 0;
            SceneManager.LoadScene("Game Over");
        }

        minutes = Mathf.Floor(currentTime / 60);
        seconds = Mathf.RoundToInt(currentTime % 60);

        m = minutes.ToString();
        if (minutes < 10) {
            m = "0" + minutes.ToString();
        } else {
            m = minutes.ToString();
        }
        if (seconds < 10) {
            s = "0" + seconds.ToString();
        } else {
            s = seconds.ToString();
        }

        countdownText.text = m + ":" + s;

    }
}