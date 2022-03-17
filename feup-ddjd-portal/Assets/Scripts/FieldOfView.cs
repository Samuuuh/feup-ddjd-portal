using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour{
   
    

    // private void Start(){
    //     Mesh mesh = new Mesh();
    //     GetComponent<MeshFilter>().mesh = mesh;


    //     Vector3[] vertices = new Vector3[3];
    //     Vector2[] uv = new Vector2[3];
    //     int[] triangles = new int[3];


    //     vertices[0] = Vector3.zero;
    //     vertices[1] = new Vector3(50,0);
    //     vertices[2] = new Vector3(0,-50);

    //     triangles[0] = 0;
    //     triangles[1] = 1;
    //     triangles[2] = 2;

    //     mesh.vertices = vertices;
    //     mesh.uv = uv;
    //     mesh.triangles = triangles;
    // }

    private Mesh mesh;
    private Vector3 origin;

    public int triangleCount;
    
    private void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        origin = gameObject.transform.position;
    }

    void Update(){
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = triangleCount;
        float angle = 0f;
        float angleIncrease = fov/rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount; i++){
            Vector3 vertex;
            // Physics2D.queriesHitTriggers = true;
            // LayerMask mask = LayerMask.GetMask("Default");
            RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(origin,GetVectorFromAngle(angle),viewDistance);
            

            vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            
            // if(raycastHit2D.collider == null){
            //     // no hit
            //     vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            // } 
            // else{
            //     //hit
            //     vertex = raycastHit2D.point;
            // }

            vertices[vertexIndex] = vertex;

            if(ContainsObjectWithName(raycastHit2D,"Collider")){
                Debug.Log("PLAYER FOUND, EXTERMINATING");
            }

            if(i > 0){
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


    }


    private Vector3 GetVectorFromAngle(float angle){
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    // private void SetOrigin(Vector3 origin){
    //     this.origin = origin;
    // }

    // private void SetDirection(Vector3 direction){

    // }

    private bool ContainsObjectWithName(RaycastHit2D[] raycastHit2D, string name){

        foreach (RaycastHit2D ray in raycastHit2D){
            Debug.Log(ray.collider.name);
            if (ray.collider.name == name) return true;
        }

        return false;

    }
}
