using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        var resumeButton = PauseMenuUI.transform.Find("ResumeButton").gameObject;
        FindObjectOfType<EventSystem>().SetSelectedGameObject(resumeButton);
        GameIsPaused = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<LevelManager>().ReloadLevel();
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
