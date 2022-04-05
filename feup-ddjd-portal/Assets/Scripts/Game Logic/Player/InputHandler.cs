using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    [SerializeField] private GameEvent _actionGrab;
    [SerializeField] private GameEvent _shotBluePortal;
    [SerializeField] private GameEvent _shotOrangePortal;
    [SerializeField] private GameEvent _jump;
    
    void Update() {
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
}
