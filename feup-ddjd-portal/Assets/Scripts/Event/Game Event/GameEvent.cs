using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent: GameEventGeneric<GameEventListener> {
    public void Invoke() {
        foreach (var globalEventListener in _listeners) {
            globalEventListener.RaiseEvent();
        }
    }
}

