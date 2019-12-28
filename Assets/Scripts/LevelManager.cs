using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
public class LevelManager : MonoBehaviour
{
    public static bool ShowedLevelTitle = false;
    [SerializeField]private string LevelTitle;
    float timeElapsed = 0;
    public Text timeText;
    int respawnCount = 0;
    public Text respawnText;
    bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        if(ShowedLevelTitle)
        {
            GameObject.Find("LevelText").SetActive(false);
        }
        else
        {
            GameObject.Find("LevelText").GetComponent<Text>().text = LevelTitle;
        }
    }
    public void EndTheGame()
    {
        const string METHOD_NAME = "LoadNextLevel";
        ShowedLevelTitle = false;
        gameEnded = true;
        Invoke(METHOD_NAME, GameConstants.LEVEL_CHANGE_DELAY);
    }
    void SetTime()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = timeElapsed - minutes * 60;
        timeText.text = "TIME: " + minutes.ToString() + ":" + seconds.ToString("00.00");
    }

    void FixedUpdate()
    {
        if(gameEnded)
        {
            return;
        }
        timeElapsed += Time.fixedDeltaTime;
        SetTime();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void ReloadLevel()
    {
        ShowedLevelTitle = true;
        if(!PauseMenu.GameIsPaused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
    public void Respawned()
    {
        respawnCount++;
        respawnText.text = "RESPAWNS: " + respawnCount.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ReloadLevel();
        }
    }
}
