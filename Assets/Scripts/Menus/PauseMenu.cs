using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System;

// Contributors: Jacky, Adrian
public class PauseMenu : NetworkBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static bool isLocalGamePaused;
    private NetworkVariable<bool> isGamePaused = new NetworkVariable<bool>(false);
    private Dictionary<ulong, bool> playerPausedDictionary;
    public event EventHandler OnMultiplayerGamePaused;
    public event EventHandler OnMultiplayerGameUnpaused;
    public static PauseMenu Instance { get; private set; }
    private void Start()
    {
        isLocalGamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLocalGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Awake()
    {
        playerPausedDictionary = new Dictionary<ulong, bool>();
    }
    public override void OnNetworkSpawn()
    {
        isGamePaused.OnValueChanged += IsGamePaused_OnValueChanged;
    }

    private void IsGamePaused_OnValueChanged(bool previousValue, bool newValue)
    {
        if (isGamePaused.Value)
        {
            Time.timeScale = 0f;
            OnMultiplayerGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnMultiplayerGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        UnpauseGameServerRpc();
        //Time.timeScale = 1f;
        isLocalGamePaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        PauseGameServerRpc();
        Time.timeScale = 0f;
        isLocalGamePaused = true;
    }

    [ServerRpc(RequireOwnership = false)]
    private void PauseGameServerRpc(ServerRpcParams serverRpcParams = default)
    {
        playerPausedDictionary[serverRpcParams.Receive.SenderClientId] = true;
        TestGamePausedState();
    }
    [ServerRpc(RequireOwnership = false)]
    private void UnpauseGameServerRpc(ServerRpcParams serverRpcParams = default)
    {
        playerPausedDictionary[serverRpcParams.Receive.SenderClientId] = false;
        TestGamePausedState();
    }
    private void TestGamePausedState()
    {
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (playerPausedDictionary.ContainsKey(clientId) && playerPausedDictionary[clientId])
            {
                //this player is paused
                isGamePaused.Value = true;
                return;
            }
        }
        //all players are unpaused
        isGamePaused.Value = false;
    }
}
