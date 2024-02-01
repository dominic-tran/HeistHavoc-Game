using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreObserver
{
    void IncreaseMoney(float money);
    void AddToScore();
    void FinalDisplay();
}
