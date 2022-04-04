using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event Button")]
public class GameEventButton: GameEventGeneric<GameEventListenerButton> {
    public void Invoke(int id) {
        foreach (var globalEventListener in _listeners) {
            globalEventListener.RaiseEvent(id);
        }
    }
}
