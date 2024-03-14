using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

// Contributors: Dominic
public class LobbyListSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;

    private Lobby lobby;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            HeistHavocGameLobby.Instance.JoinWithId(lobby.Id);
        });
    }

    public void SetLobby(Lobby lobby)
    {
        this.lobby = lobby;
        if (lobby.Name == "ENTER LOBBY NAME")
        {
            lobbyNameText.text = lobbyNameText.text;
        }
        else
        {
            lobbyNameText.text = lobby.Name;
        }
    }
}
