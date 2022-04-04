using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public int id;

    [SerializeField] private float _displacement;    
    [SerializeField] private float _movementSpeed = 0.5f;
    private bool _isOpen;
    private float _baseYAxis;
    private Vector3 _basePosition;
    
    private void Start() {
        _isOpen = false;
        _baseYAxis = transform.position.y;
        _basePosition = transform.position;
    }

    public void FixedUpdate() {
        if (_isOpen) {
            if(transform.position.y < _baseYAxis + _displacement)
                transform.position += new Vector3(0, _movementSpeed * Time.deltaTime, 0);
        }
        else {
            if (transform.position.y >= _baseYAxis + _movementSpeed * Time.deltaTime)
                transform.position -= new Vector3(0, _movementSpeed * Time.deltaTime, 0);
            else 
                transform.position = _basePosition;
        }
    }

    public void DoorEvent(int listeningId) {
        if (id == listeningId) {
            _isOpen = !_isOpen;
        } 
    }
}
