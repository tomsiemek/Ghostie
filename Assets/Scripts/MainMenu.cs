using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void Credits() => SceneManager.LoadScene( SceneManager.sceneCountInBuildSettings - 1 );

    public void Quit() => Application.Quit();
}

