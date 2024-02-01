using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;
    private static GameStateManager _instance;


    // Start is called before the first frame update
    void Start()
    {
        // Singleton setup
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public static void Win()
    {
        GameObject winMenu = GameObject.Find("WinCanvas").transform.GetChild(0).gameObject;
        Time.timeScale = 0f;
        winMenu.SetActive(true);
    }

    public static void Restart()
    {
        Debug.Log("Restart");
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
    }
}
