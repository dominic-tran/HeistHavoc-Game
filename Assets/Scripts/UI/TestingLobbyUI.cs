using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Contributors: Nick
public class TestingLobbyUI : MonoBehaviour
{
    [SerializeField] private Button createGameButton;
    [SerializeField] private Button joinGameButton;

    private void Awake()
    {
        if (createGameButton != null)
        {
            createGameButton.onClick.AddListener(() =>
            {
                HHGameMultiplayer.Instance.StartHost();
                Loader.LoadNetwork(Loader.Scene.CharacterSelectScene);
            });
        }
        if (joinGameButton != null)
        {
            joinGameButton.onClick.AddListener(() =>
            {
                HHGameMultiplayer.Instance.StartClient();
            });
        }
    }
}
