using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{
    private void Start()
    {
        HHGameMultiplayer.Instance.OnTryingToJoinGame += HHGameMultiplayer_OnTryingToJoinGame;
        HHGameMultiplayer.Instance.OnFailedToJoinGame += HHGameManager_OnFailedToJoinGame;
        Hide();
    }

    private void HHGameManager_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Hide();
    }

    private void HHGameMultiplayer_OnTryingToJoinGame(object sender, EventArgs e)
    {
        Show();
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
        HHGameMultiplayer.Instance.OnTryingToJoinGame -= HHGameMultiplayer_OnTryingToJoinGame;
        HHGameMultiplayer.Instance.OnFailedToJoinGame -= HHGameManager_OnFailedToJoinGame;
    }
}
