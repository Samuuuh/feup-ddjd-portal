using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour {
    public void NextLevel() {
        // TODO: Again, a Level Manager would be nice
        SceneManager.LoadScene("Level One");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Level One");
    }
}
