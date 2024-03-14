using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

// Contributors: Nick
public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake()
    {
        if (startHostButton != null)
        {
            startHostButton.onClick.AddListener(() =>
        {
            HHGameMultiplayer.Instance.StartHost();
            Hide();
        });
        }
        if (startHostButton != null)
        {
            startClientButton.onClick.AddListener(() =>
        {
            HHGameMultiplayer.Instance.StartClient();
            Hide();
        });
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
