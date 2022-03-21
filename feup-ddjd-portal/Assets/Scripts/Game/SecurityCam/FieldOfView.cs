using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    // Objects
    public LayerMask whatIsSolid;
    private Mesh mesh;
    
    // Angle
    public float fov = 90f;
    public float maxAngle = -90;
    private float initialAngle;
    private float minAngle;
    private bool goingRight = true; 

    // Timer
    public float initialTime = 2f;
    private float currentTime;

    // Other Setings
    public float viewDistance = 5f; 
    public float rotateSpeed = 5f;
    public int triangleCount = 25;


    private void Start(){

        // Initialize mesh material for the field of view
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Color color = new Color(255f,255f,0f,0f);
        // color.a = 0;
        // GetComponentInChildren<MeshRenderer>().material.color = color;

        // Câmera angle intialization
        initialAngle = maxAngle + fov/2;
        minAngle = maxAngle + fov;

        // Câmera Timer initialization
        currentTime = initialTime;
    }

    void Update() {
        Vector3 relativePositionVertex = Vector3.zero;
        int rayCount = triangleCount;
        float angle = initialAngle;
        float angleIncrease = fov/rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];
        vertices[0] = relativePositionVertex;

        int vertexIndex = 1;
        int triangleIndex = 0;
        Vector3 vertex;

        bool foundPlayer = false;


        // Draw triangles and ray cast from camera
        for(int i = 0; i <= rayCount; i++) {

            LayerMask floor = LayerMask.GetMask("Default");

            RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), viewDistance, whatIsSolid);
            RaycastHit2D hitWall = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), viewDistance, floor);

            
            if (hitPlayer.collider != null) {
                foundPlayer = true;
            }

            if(hitWall.collider != null){
                vertex = relativePositionVertex + GetVectorFromAngle(angle) * hitWall.distance;
            }else{
                vertex = relativePositionVertex + GetVectorFromAngle(angle) * viewDistance;
            }
        

            vertices[vertexIndex] = vertex;


            if (i > 0) {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex +=3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        // Rotate the câmera at a certain speed
        RotateAngle();

        // Player being seen for a certain amount of time
        if(foundPlayer){
            Countdown();
        }else{
            currentTime = initialTime;
        }
    }


    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }


    private void RotateAngle(){

        if(goingRight){
            if (initialAngle + rotateSpeed/10 < minAngle) initialAngle += rotateSpeed/10;
            else if(initialAngle + rotateSpeed >= minAngle){
                initialAngle = minAngle;
                goingRight = false;
            } 
        }
        else{
            if (initialAngle - rotateSpeed/10 > maxAngle) initialAngle -= rotateSpeed/10;
            else if(initialAngle - rotateSpeed <= maxAngle){
                initialAngle = maxAngle;
                goingRight = true; 
            } 
        }

    }

    private void Countdown(){

        Debug.Log(currentTime);
        if(currentTime <= 0) Debug.Log("TIME'S UP, GAME LOSS");
        else currentTime -= 1 * Time.deltaTime;

    } 
}
