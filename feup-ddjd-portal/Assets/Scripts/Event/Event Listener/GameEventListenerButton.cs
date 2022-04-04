using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_Button : UnityEvent<int> {}; 

public class GameEventListenerButton : MonoBehaviour {
    [SerializeField] private GameEventButton _gameEvent;
    [SerializeField] private UnityEvent_Button _unityEvent;

    private void Awake() {
        _gameEvent.Subscribe(this);

        if (_unityEvent == null)
            _unityEvent = new UnityEvent_Button();
        _unityEvent.AddListener(GetComponent<Door>().DoorEvent);
    } 
    private void OnDestroy() => _gameEvent.Unsubscribe(this);

    public void RaiseEvent(int id) {
       _unityEvent?.Invoke(id);
    }
}
