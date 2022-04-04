using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    [SerializeField] private GameEvent _buttonEvent;
    [SerializeField] private Animator _buttonAnimator;
    private HashSet<GameObject> _elements = new HashSet<GameObject>();

    void OnTriggerExit2D(Collider2D col) {
        if(_elements.Count == 1) {
            _buttonEvent?.Invoke();
            _buttonAnimator.SetBool("isPressed", false);
        }

        _elements.Remove(col.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(_elements.Count == 0) {
            _buttonEvent?.Invoke();
            _buttonAnimator.SetBool("isPressed", true);
        }

        _elements.Add(col.gameObject);
    }
}
