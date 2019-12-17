using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    const float CoinsCollectedTextDuration = 4;
    const int AmountOfCoins = 5;
    int coinCount = 0;
    int respawnCount = 0;
    float timeElapsed = 0;
    public Text coinText;
    public Text timeText;
    public Text coinsCollectedText;
    public Text EndGameText;
    public Text respawnText;
    bool CoinsCollectedTextActivated = false;
    public SpriteRenderer EndGameBlind;

    bool endGame = false;

    float WhiteScreenEmergeTime = 3;

    float timeCoinCollectedTextShowed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        SetCoinText(0);
        
    }

    void ActivatePostCoinsPhase()
    {
        coinText.color = Color.green;
        coinsCollectedText.gameObject.SetActive(true);
        CoinsCollectedTextActivated = true;
        timeCoinCollectedTextShowed = timeElapsed;
        FindObjectOfType<Keeper>().CoinsCollected();
        
    }
    public void EndTheGame()
    {
        timeText.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
        EndGameText.gameObject.SetActive(true);
        EndGameText.text += timeText.text + "\n Press space to restart.";
        FindObjectOfType<Player>().gameObject.SetActive(false);
        endGame = true;

    }
    void SetCoinText(int n)
    {
        coinText.text = "Coins: " + n.ToString() + " / " + AmountOfCoins.ToString();
    }

    public void CoinCollected(string coinName)
    {
        Debug.Log(coinName);
        SetCoinText(++coinCount);
        if (coinCount == AmountOfCoins)
        {
            ActivatePostCoinsPhase();
        }
    }

    void SetTime()
    {

        int minutes =  Mathf.FloorToInt(timeElapsed / 60);
        float seconds = timeElapsed - minutes * 60;
        timeText.text = "Time: " + minutes.ToString() + ":" + seconds.ToString("00.00");
    }

    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
        SetTime();
        if (CoinsCollectedTextActivated && timeElapsed - timeCoinCollectedTextShowed > CoinsCollectedTextDuration)
        {
            CoinsCollectedTextActivated = false;
            coinsCollectedText.gameObject.SetActive(false);
        }

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Respawned()
    {
        respawnCount++;
        respawnText.text = "Respawned: " + respawnCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(endGame)
        {
            if(EndGameBlind.color.a < 1)
            {
                EndGameBlind.color = new Color(EndGameBlind.color.r, EndGameBlind.color.g, EndGameBlind.color.b, EndGameBlind.color.a + Time.deltaTime / WhiteScreenEmergeTime);
            }
            if(Input.GetKeyDown("space"))
            {
                ReloadLevel();
            }
        }
    }
}
