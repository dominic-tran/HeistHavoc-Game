using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Lobbies.Models;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;
    public void MainMenu()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Ready()
    {
        if(CharacterSelectReady.Instance != null)
    {
            CharacterSelectReady.Instance.SetPlayerReady();
        }
    }

    private void Start()
    {
        Lobby lobby = HeistHavocGameLobby.Instance.GetLobby();

        if (lobby.Name == "ENTER LOBBY NAME")
        {
            lobbyNameText.text = "Lobby Name: Lobby " + Random.Range(0,100);
        }
        else
        {
            lobbyNameText.text = "Lobby Name: " + lobby.Name;
        }
        
        lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
    }
}
