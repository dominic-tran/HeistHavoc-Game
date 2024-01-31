using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : Buttons
{
    public void RestartGame()
    {
        GameStateManager.Restart();
    }
}
