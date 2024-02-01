using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Jacky, Adrian
public class WinMenu : Buttons
{
    public void RestartGame()
    {
        GameStateManager.Restart();
    }
}
