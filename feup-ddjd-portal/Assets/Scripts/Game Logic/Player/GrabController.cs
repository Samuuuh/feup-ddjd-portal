using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabController : MonoBehaviour {
    [SerializeField] private GameEvent _weaponToggle;
    [SerializeField] private Transform grabDetect;
    [SerializeField] private Transform boxHolder;
    [SerializeField] private float rayDist;

    private bool holding;
    private GameObject cube;

    private void Start() {
        holding = false;
    }
    
    private void Update() {
        if (holding) {
            cube.transform.position = boxHolder.position;
        }
    }

    private RaycastHit2D[] ConcatArray(RaycastHit2D[] front, RaycastHit2D[] back){
        RaycastHit2D[] combined = new RaycastHit2D[front.Length + back.Length];
        Array.Copy(front, combined, front.Length);
        Array.Copy(back, 0, combined, front.Length, back.Length);

        return combined;
    }

    #region Grab Action
    public void Action() {
        RaycastHit2D[] grabRight1 = Physics2D.RaycastAll(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabRight2 = Physics2D.RaycastAll(grabDetect.position + new Vector3(0,1f,0), Vector2.right * transform.localScale, rayDist);
        RaycastHit2D[] grabRight3 = Physics2D.RaycastAll(grabDetect.position - new Vector3(0,1f,0), Vector2.right * transform.localScale, rayDist);
        
        RaycastHit2D[] grabLeft1 = Physics2D.RaycastAll(grabDetect.position, Vector2.left * transform.localScale, rayDist);
        RaycastHit2D[] grabLeft2 = Physics2D.RaycastAll(grabDetect.position + new Vector3(0,1f,0), Vector2.left * transform.localScale, rayDist);
        RaycastHit2D[] grabLeft3 = Physics2D.RaycastAll(grabDetect.position - new Vector3(0,1f,0), Vector2.left * transform.localScale, rayDist);

        RaycastHit2D[] grabCheckRight = ConcatArray(ConcatArray(grabRight1,grabRight2), grabRight3);
        RaycastHit2D[] grabCheckLeft = ConcatArray(ConcatArray(grabLeft1,grabLeft2), grabLeft3);
        RaycastHit2D[] grabCheck = ConcatArray(grabCheckRight, grabCheckLeft);

         if (!holding) {
            foreach (RaycastHit2D hit in grabCheck) {
                if (hit.collider.tag == "Cube") {
                    GrabCube(hit);
                    return;
                 }
            }
        } else {
            DropCube(); 
        }
    }

    private void GrabCube(RaycastHit2D grabCheck) {
        cube = grabCheck.collider.gameObject; 
        cube.transform.parent = boxHolder;
        cube.transform.position = boxHolder.position;

        cube.GetComponent<Collider2D>().enabled = false;
        cube.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cube.GetComponent<Rigidbody2D>().isKinematic = true;
        holding = true;

        _weaponToggle?.Invoke();
    }

    private void DropCube() {
        cube.transform.parent = null;

        cube.GetComponent<Collider2D>().enabled = true;
        cube.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cube.GetComponent<Rigidbody2D>().isKinematic = false;
    
        holding = false;

         _weaponToggle?.Invoke();
    }
    #endregion
}
