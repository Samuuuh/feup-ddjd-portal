using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam : MonoBehaviour {
    [SerializeField] private GameEvent _onUnlockDoor;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            _onUnlockDoor?.Invoke();

            FindObjectOfType<AudioManager>()?.Play("GladosFindExit");
            Destroy(gameObject);
        }
    }
}
