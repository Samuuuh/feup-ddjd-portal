using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor: MonoBehaviour {
    [SerializeField] private GameManager gameManager;

    private bool unlockedDoor = false;
    private bool alreadyPlayedAudio = false;

    public void UnlockDoor() {
        unlockedDoor = true;
        GetComponentInChildren<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if ((col.gameObject.tag == "Player")) {
            if (unlockedDoor) {
                float score = 20f;

                gameManager.SetScore(score);
                gameManager.GameEnd();
            } else {
                if (!alreadyPlayedAudio) 
                    FindObjectOfType<AudioManager>()?.Play("GladosDontExit");
    
                alreadyPlayedAudio = true;
            }
        }
    }
}