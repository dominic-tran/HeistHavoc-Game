using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Nick, Adrian
public class PauseMultiplayerUI : MonoBehaviour
{
    private void Start()
    {
        if (PauseMenu.Instance != null)
        {
            PauseMenu.Instance.OnMultiplayerGamePaused += PauseMenu_OnMultiplayerGamePaused;
            PauseMenu.Instance.OnMultiplayerGameUnpaused += PauseMenu_OnMultiplayerGameUnpaused;
            Hide();
        }
    }

    private void PauseMenu_OnMultiplayerGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void PauseMenu_OnMultiplayerGamePaused(object sender, EventArgs e)
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
}
