using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    [SerializeField] private PauseMenu pauseStatus;

    [SerializeField] private GameEvent _actionGrab;
    [SerializeField] private GameEvent _shotBluePortal;
    [SerializeField] private GameEvent _shotOrangePortal;
    [SerializeField] private GameEvent _jump;
    [SerializeField] private GameEvent _pause;

    void Update() {
        if (!pauseStatus.isPaused) {
            if (Input.GetKeyDown(KeyCode.E)) {
                _actionGrab?.Invoke();
            }

            if (Input.GetMouseButton(0)) {
                _shotBluePortal?.Invoke();
            }

            if (Input.GetMouseButton(1)) {
                _shotOrangePortal?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                _jump?.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            _pause?.Invoke();
        }
    }
}
