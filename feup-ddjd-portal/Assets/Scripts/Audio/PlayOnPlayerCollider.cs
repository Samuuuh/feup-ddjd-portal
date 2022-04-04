using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnPlayerCollider : MonoBehaviour {
    [SerializeField] private string soundName;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            FindObjectOfType<AudioManager>()?.Play(soundName);
            Destroy(gameObject);
        }
    }
}
