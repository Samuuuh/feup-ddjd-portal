using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour {
    public Texture2D cursorEmpty, cursorBlue, cursorOrange, cursorFull;
    private Vector2 offset = new Vector2(24, 24);

    // Start is called before the first frame update
    void Start() {
        Cursor.SetCursor(cursorEmpty, offset, CursorMode.ForceSoftware);   
    }

    // Update is called once per frame
    void Update() {
        if ((GameObject.FindGameObjectWithTag("Blue Portal") != null) && (GameObject.FindGameObjectWithTag("Orange Portal") != null)) {
            Cursor.SetCursor(cursorFull, offset, CursorMode.ForceSoftware);
        } else if (GameObject.FindGameObjectWithTag("Blue Portal") != null) {
            Cursor.SetCursor(cursorBlue, offset, CursorMode.ForceSoftware);
        } else if (GameObject.FindGameObjectWithTag("Orange Portal") != null) {
            Cursor.SetCursor(cursorOrange, offset, CursorMode.ForceSoftware); 
        } else {
            Cursor.SetCursor(cursorEmpty, offset, CursorMode.ForceSoftware);
        }
    }
}
