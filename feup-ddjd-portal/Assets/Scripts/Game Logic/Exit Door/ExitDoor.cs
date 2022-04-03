using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor: MonoBehaviour {
    [SerializeField]
    private GameManager gameManager;

    private bool canExit;
    private bool alreadyPlayedAudio;

    private void Start() {
        canExit = false;
        alreadyPlayedAudio = false;

        GameEvent.instance.onGrabExam += UnlockDoor;
    }

    private void UnlockDoor() {
        canExit = true;

        GetComponentInChildren<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if ((col.gameObject.tag == "Player")) {
            if (canExit) {
                gameManager.SetScore(20);
                gameManager.GameEnd();
            } else {
                if (!alreadyPlayedAudio) 
                    FindObjectOfType<AudioManager>().Play("GladosDontExit");
    
                alreadyPlayedAudio = true;
            }
        }
    }
}