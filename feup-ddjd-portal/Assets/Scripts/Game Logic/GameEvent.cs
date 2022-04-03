using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent: MonoBehaviour {
    public static GameEvent instance;

    private void Awake() {
        instance = this;
    }

    public event Action onGrabExam;
    public void GrabExam() {
        onGrabExam?.Invoke();
    }
}