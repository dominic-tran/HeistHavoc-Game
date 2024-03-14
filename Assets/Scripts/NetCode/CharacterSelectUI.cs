using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Lobbies.Models;
using static Cinemachine.DocumentationSortingAttribute;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;
    

    public void MainMenu()
    {
        if (NetworkManager.Singleton != null)
        {
            HeistHavocGameLobby.Instance.LeaveLobby();
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

        lobbyNameText.text = "Lobby Name: " + lobby.Name;

        lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
    }
    
    
}
