using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;
    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }
    private void Start()
    {
        HHGameMultiplayer.Instance.OnFailedToJoinGame += HHGameMultiplayer_OnFailedToJoinGame;
        HeistHavocGameLobby.Instance.OnCreateLobbyStarted += HeistHavocGameLobby_OnCreateLobbyStarted;
        HeistHavocGameLobby.Instance.OnCreateLobbyFailed += HeistHavocGameLobby_OnCreateLobbyFailed;
        HeistHavocGameLobby.Instance.OnJoinStarted += HeistHavocGameLobby_OnJoinStarted;
        HeistHavocGameLobby.Instance.OnJoinFailed += HeistHavocGameLobby_OnJoinFailed;
        HeistHavocGameLobby.Instance.OnQuickJoinFailed += HeistHavocGameLobby_OnJQuickoinFailed;

        Hide();
    }

    private void HeistHavocGameLobby_OnJQuickoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Could Not Find a Lobby to Quick Join...");
    }

    private void HeistHavocGameLobby_OnJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to Join Lobby...");
    }

    private void HeistHavocGameLobby_OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining Lobby...");
    }

    private void HeistHavocGameLobby_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to Create Lobby...");
    }

    private void HeistHavocGameLobby_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating Lobby...");
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }

    private void HHGameMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        if (NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to Connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);

    }
    private void OnDestroy()
    {
        HHGameMultiplayer.Instance.OnFailedToJoinGame -= HHGameMultiplayer_OnFailedToJoinGame;
    }
}
