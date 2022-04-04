using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent: ScriptableObject {
    private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke() {
        foreach (var globalEventListener in _listeners) {
            globalEventListener.RaiseEvent();
        }
    }

    public void Subscribe(GameEventListener gameEventListener) => _listeners.Add(gameEventListener);
    public void Unsubscribe(GameEventListener gameEventListener) => _listeners.Remove(gameEventListener);
}