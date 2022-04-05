using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float offset;
    
    public Transform shotPoint;
    public GameObject projectileRight, projectileLeft;

    private float intervalTime;
    public float startIntervalTime;

    public static bool canShoot = true;

    private void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        intervalTime -= Time.deltaTime;
    }

    public void ShotBluePortal() {
        if (intervalTime <= 0) {
            if(canShoot) {
                intervalTime = startIntervalTime;
                Instantiate(projectileRight, shotPoint.position, transform.rotation);
            }
        }
    }

    public void ShotOrangePortal() {
        if (intervalTime <= 0) {
            if(canShoot) {
                intervalTime = startIntervalTime;
                Instantiate(projectileLeft, shotPoint.position, transform.rotation);
            }
        }
    }
}
