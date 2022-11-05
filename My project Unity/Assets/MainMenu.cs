using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    public void PlayGame() {
        // Changes the scene on play
        if(SceneManager.GetActiveScene().buildIndex == 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PauseMenu pause = new PauseMenu();
            pause.RestartGame();
        } else {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // quits the game when the quit button is pressed
    public void QuitGame() {

        Application.Quit();

    }

}
