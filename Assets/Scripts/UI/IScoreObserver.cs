using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Nick
public interface IScoreObserver
{
    void IncreaseMoney(float money);
    void AddToScore();
    void FinalDisplay();
}
