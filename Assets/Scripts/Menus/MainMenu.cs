using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Buttons
{
    public void PlayGame(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
