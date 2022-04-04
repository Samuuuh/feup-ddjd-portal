using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor: MonoBehaviour {
    [SerializeField] private GameEvent _gameEnd;

    private bool _unlockedDoor = false;
    private bool _alreadyPlayedAudio = false;

    public void UnlockDoor() {
        _unlockedDoor = true;
        GetComponentInChildren<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if ((col.gameObject.tag == "Player")) {
            if (_unlockedDoor) {
                _gameEnd?.Invoke();
            } else {
                if (!_alreadyPlayedAudio) 
                    FindObjectOfType<AudioManager>()?.Play("GladosDontExit");
    
                _alreadyPlayedAudio = true;
            }
        }
    }
}