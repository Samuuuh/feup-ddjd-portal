using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldOfView : MonoBehaviour {
    public LayerMask playerLayer;

    #region Timer
    public float initialTime;
    private float currentTime;

    [SerializeField] 
    private Text countdownText;
    private float minutes = 0f;
    private float seconds = 0f;
    private string m = "";
    private string s = "";
    #endregion

    #region FOV Angle
    [SerializeField]
    private float fov = 90f;
    [SerializeField]
    private float maxAngle = -90;
    private float initialAngle;
    private float minAngle;
    #endregion

    #region FOV Settings
    [SerializeField]
    private float viewDistance = 5f; 
    [SerializeField]
    private float rotateSpeed = 5f;
    [SerializeField]
    private int triangleCount = 25;
    private bool goingRight = true; 
    #endregion

    #region Renderer
    private Mesh mesh;
    private Renderer colorRenderer;
    private Color32 yellow;
    private Color32 redInitial, redFinal;
    #endregion

    private void Start(){
        #region FOV Angle
        initialAngle = maxAngle + fov/2;
        minAngle = maxAngle + fov;
        #endregion

        #region Timer
        currentTime = initialTime;
        #endregion 

        #region Renderer
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        colorRenderer = GetComponent<Renderer>();
        yellow = Color.yellow;
        yellow.a = 100;
        redInitial = Color.red;
        redInitial.a = 100;
        redFinal = Color.red;
        redFinal.a = 180;
        #endregion
    }

    void FixedUpdate() {
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
            LayerMask floor = LayerMask.GetMask("Floor");

            RaycastHit2D hitWall = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), viewDistance, floor);
            RaycastHit2D hitPlayer;

            if (hitWall.collider != null) {
                vertex = relativePositionVertex + GetVectorFromAngle(angle) * hitWall.distance;
                hitPlayer = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), hitWall.distance, playerLayer);
            } else {
                vertex = relativePositionVertex + GetVectorFromAngle(angle) * viewDistance;
                hitPlayer = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), viewDistance, playerLayer);
            }

            if (hitPlayer.collider != null && foundPlayer == false) {
                foundPlayer = true;
                MakeRed();
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

        if (foundPlayer) {
            Countdown();
        } else {
            MakeYellow();
            currentTime = initialTime;
        }
    }

    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    private void RotateAngle(){
        if(goingRight) {
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
        currentTime -= Time.deltaTime;

        if (currentTime <= 0) SceneManager.LoadScene("Game Over");

        minutes = Mathf.Floor(currentTime / 60);
        seconds = Mathf.RoundToInt(currentTime % 60);

        m = minutes.ToString();
        if (minutes < 10) {
            m = "0" + minutes.ToString();
        } else {
            m = minutes.ToString();
        }
        if (seconds < 10) {
            s = "0" + seconds.ToString();
        } else {
            s = seconds.ToString();
        }

        countdownText.text = m + ":" + s;

        IntensifyColor();
    }


    private void MakeRed(){
        colorRenderer.material.SetColor("_Color", redInitial);
    }

    private void MakeYellow(){
        countdownText.text = "00:03";
        colorRenderer.material.SetColor("_Color", yellow);
    }

    private void IntensifyColor(){
        float lerp = Mathf.PingPong(currentTime, initialTime) / initialTime;
        colorRenderer.material.SetColor("_Color", Color.Lerp(redFinal, redInitial, lerp));

    }
}
