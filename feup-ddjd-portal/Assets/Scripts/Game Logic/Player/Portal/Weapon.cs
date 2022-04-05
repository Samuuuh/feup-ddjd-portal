using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] private float offset;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject projectileRight, projectileLeft;

    [SerializeField] private float startIntervalTime;
    private float intervalTime;

    private bool _canShoot;

    private void Start() {
        _canShoot = true;
    }

    private void Update() {
        if (_canShoot) {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        } else {
            transform.rotation = Quaternion.Euler(0f, 0f, offset);
        }
        

        intervalTime -= Time.deltaTime;
    }

    public void ShotBluePortal() {
        if (intervalTime <= 0) {
            if(_canShoot) {
                intervalTime = startIntervalTime;
                Instantiate(projectileRight, shotPoint.position, transform.rotation);
            }
        }
    }

    public void ShotOrangePortal() {
        if (intervalTime <= 0) {
            if(_canShoot) {
                intervalTime = startIntervalTime;
                Instantiate(projectileLeft, shotPoint.position, transform.rotation);
            }
        }
    }

    public void ToggleWeapon() {
        _canShoot = !_canShoot;
    }
}
