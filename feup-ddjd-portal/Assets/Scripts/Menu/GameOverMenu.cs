using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    public void restartGame() {
        // TODO: Again, a Level Manager would be nice
        SceneManager.LoadScene("Level One");
    }
}
