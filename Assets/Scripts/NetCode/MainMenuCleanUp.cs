using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

// Contributors: Nick
public class MainMenuCleanUp : MonoBehaviour
{
    private void Awake()
    {
        if (NetworkManager.Singleton != null)
        {
            Destroy(NetworkManager.Singleton.gameObject);
        }
        if (HHGameMultiplayer.Instance != null)
        {
            Destroy(HHGameMultiplayer.Instance.gameObject);
        }
        if (HeistHavocGameLobby.Instance != null)
        {
            Destroy(HeistHavocGameLobby.Instance.gameObject);
        }
    }
}
