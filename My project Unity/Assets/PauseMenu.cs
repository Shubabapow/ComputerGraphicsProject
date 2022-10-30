using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public float savedMouseSensetivity;
    public GameObject crossHier;
    public GameObject GameOverMenu;
    public static int mTime = 30;
    public bool mGameOver = false;

    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

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
            savedMouseSensetivity = PlayerController.mouseSensitivity;
            PlayerController.mouseSensitivity = 0;
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
    public void Resume (){
        pauseMenuUI.SetActive(false);
        crossHier.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused =false;

        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.mouseSensitivity = savedMouseSensetivity;
    }

    void Pause (){
        pauseMenuUI.SetActive(true);
        crossHier.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused =true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        savedMouseSensetivity = PlayerController.mouseSensitivity;
        PlayerController.mouseSensitivity = 0;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
        Time.timeScale = 1f;
        PlayerController.mouseSensitivity = savedMouseSensetivity;
        mGameOver = false;
        GameOverMenu.SetActive(false);
        
    }

    public static int fTime{
        get {return mTime;}
    }
}
