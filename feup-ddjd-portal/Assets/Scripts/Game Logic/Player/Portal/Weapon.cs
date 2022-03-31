using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float offset;
    
    public Transform shotPoint;
    public GameObject projectileRight, projectileLeft;

    public static bool canShoot = true;
    private float intervalTime;
    public float startIntervalTime;

    private void Start() {

    }

    private void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (intervalTime <= 0) {
            if(canShoot) {
                if (Input.GetMouseButton(0)) {
                    Instantiate(projectileRight, shotPoint.position, transform.rotation);
                    intervalTime = startIntervalTime;
                }
                else if (Input.GetMouseButton(1)) {
                    Instantiate(projectileLeft, shotPoint.position, transform.rotation);
                    intervalTime = startIntervalTime;
                }
            }            
        }
        else {
            intervalTime -= Time.deltaTime;
        }
    }
}
