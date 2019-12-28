using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameObject PauseMenuUI;
    AudioSource theme;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
        theme = GameObject.Find("Theme").GetComponent<AudioSource>();
    }

    void TurnEnvironment(bool menuOn)
    {
        GameIsPaused = menuOn;
        if(menuOn)
        {
            Time.timeScale = 0f;
            theme.volume = 0.01f;
            return;
        }
        Time.timeScale = 1f;
        theme.volume = 0.1f;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        TurnEnvironment(true);
        var resumeButton = PauseMenuUI.transform.Find("ResumeButton").gameObject;
        FindObjectOfType<EventSystem>().SetSelectedGameObject(resumeButton);
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        TurnEnvironment(false);
    }
    public void Restart()
    {
        TurnEnvironment(false);
        FindObjectOfType<LevelManager>().ReloadLevel();
    }
    public void QuitGame()
    {
        TurnEnvironment(false);
        Application.Quit();
    }
    public void MainMenu()
    {
        TurnEnvironment(false);
        PersistentObject theme = FindObjectOfType<PersistentObject>();
        theme.Destroy();
        LevelManager.ShowedLevelTitle = false;
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
