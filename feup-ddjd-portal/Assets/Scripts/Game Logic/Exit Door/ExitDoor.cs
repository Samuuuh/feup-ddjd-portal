using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor: MonoBehaviour {
    [SerializeField]
    private GameManager gameManager;

    public bool canExit;

    void OnTriggerEnter2D(Collider2D col) {
        // TODO: A Level Manager would be nice, but not necessary since we only have one level
        if ((col.gameObject.tag == "Player")) {
            if (canExit) {
                gameManager.SetScore(20);
                gameManager.WinGame();
            } else {
                FindObjectOfType<AudioManager>().Play("GladosDontExit");
                Destroy(gameObject);
            }
        }
    }
}