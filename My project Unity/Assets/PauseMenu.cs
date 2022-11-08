using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject crossHier;
    public GameObject GameOverMenu;
    public static int mTime = 31;
    public static bool mGameOver = false;

    PlayerController controller = new PlayerController();

    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }
    // in game timer
    void Count()
    {
        if(mTime == 0){
            mGameOver = true;
            CancelInvoke("Count");
            GameOverMenu.SetActive(true);
            crossHier.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            PlayerController.pause = true;
            //Debug.Log(savedMouseSensetivity);
        } else{
            mTime--;
        }
    }

    public bool IsGameOver
    {
        get{return mGameOver;}
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }   else
            {
                Pause();
            }
        }

    }
    // function to resume the game
    public void Resume (){
        pauseMenuUI.SetActive(false);
        crossHier.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused =false;

        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.pause = false;
    }

    // function to simulate a pause
    void Pause (){
        pauseMenuUI.SetActive(true);
        crossHier.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused =true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerController.pause = true;
    }

    // Loads the main menu when the main menu button is pressed on the pause menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
        Time.timeScale = 1f;
        PlayerController.pause = false;
        mGameOver = false;
        GameOverMenu.SetActive(false);
        RestartGame();
        
    }

    public static int fTime{
        get {return mTime;}
    }
    // Resets all game variables
    public void RestartGame(){
        mTime = 31;
        PlayerController.pause = false;
        //GameOverMenu.SetActive(false);
        //crossHier.SetActive(true);
        GameStats.targetsHit = 0;
        GameStats.accuracy = 0;
        GameStats.totalShots = 0;
        mGameOver = false;
        Debug.Log(mGameOver);
        //Cursor.visible = false;

    }
}
