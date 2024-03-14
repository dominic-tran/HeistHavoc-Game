using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Contributors: Nick, Jacky
public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button createPublicButton;
    [SerializeField] private Button createPrivateButton;
    [SerializeField] private TMP_InputField lobbyNameInputField;

    private List<string> namesList;

    private void Awake()
    {
        createPublicButton.onClick.AddListener(() =>
        {
            if (lobbyNameInputField.text == "ENTER LOBBY NAME")
            {
                HeistHavocGameLobby.Instance.CreateLobby(CreateRandomName(), false);
                
            }
            else
            {
                HeistHavocGameLobby.Instance.CreateLobby(lobbyNameInputField.text, false);
            }
        });
        createPrivateButton.onClick.AddListener(() =>
        {
            if (lobbyNameInputField.text == "ENTER LOBBY NAME")
            {
                HeistHavocGameLobby.Instance.CreateLobby(CreateRandomName(), true);

            }
            else
            {
                HeistHavocGameLobby.Instance.CreateLobby(lobbyNameInputField.text, true);
            }
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private string CreateRandomName()
    {
        namesList = new List<string>();
        int randomNumber = Random.Range(0, 102);

        namesList.Add("Usual Room ");
        namesList.Add("Funny Farm ");
        namesList.Add("Lobby ");
        namesList.Add("Game Room ");
        namesList.Add("Waiting Area ");
        namesList.Add("Lounge ");
        namesList.Add("Session ");
        namesList.Add("Common Area ");
        namesList.Add("Group Session ");
        namesList.Add("Meeting Point ");
        namesList.Add("Room ");
        namesList.Add("Universal Hub ");
        namesList.Add("Hub ");
        namesList.Add("Hangout ");
        namesList.Add("Retreat ");
        namesList.Add("Chamber ");
        namesList.Add("Torture Room ");
        namesList.Add("Dom's Basement ");
        namesList.Add("Nick's Basement ");
        namesList.Add("Adrian's Basement ");
        namesList.Add("Jacky's Basement ");
        namesList.Add("Thomas's Basement ");
        namesList.Add("Courtyard ");
        namesList.Add("Hall ");
        namesList.Add("Closet ");
        namesList.Add("Den ");
        namesList.Add("Parlor ");
        namesList.Add("Saloon ");
        namesList.Add("Secret Hideout ");
        namesList.Add("Rendezvous  ");


        return namesList[Random.Range(0, namesList.Count + 1)] + randomNumber.ToString();
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
