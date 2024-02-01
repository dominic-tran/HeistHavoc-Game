using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Contributors: Adrian, Jacky, Nick, Dominic
public class ScoringSystem : MonoBehaviour, IScoreObserver
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float smoothIncreaseDuration = 0.5f;

    private float currentMoney;



    private void Start()
    {
        currentMoney = 0;
        AddToScore();
    }
    
    //UI Incrementation Animation
    public void IncreaseMoney(float money)
    {
        StartCoroutine(SmoothIncreaseMoney(money));
    }
    private IEnumerator SmoothIncreaseMoney(float money)
    {
        
        float moneyPerTick = money / smoothIncreaseDuration;
        float elapsedTime = 0f;

        while(elapsedTime < smoothIncreaseDuration)
        {
            float currentPayment = moneyPerTick * Time.deltaTime;
            currentMoney += currentPayment;
            elapsedTime += Time.deltaTime;
            //Every frame that occurs, the animation increments the value
            AddToScore();
            
            //If player reaches a certain monetary value the game ends basically
            if(currentMoney >= 15)
            {
                GameStateManager.Win();
                break;
            }
            yield return null;
            

        }

        FinalDisplay();
    }
    //Utilized to increment decimals every frame of the elapsed time
    public void AddToScore()
    {
        scoreText.text = "Value Stolen: $" + currentMoney.ToString("#.##");
    }
    // Final Display is used to fix the precision point error that floats have 
    public void FinalDisplay()
    {
        int roundedMoneyValue = (int)Mathf.Round(currentMoney);
        scoreText.text = "Value Stolen: $" + roundedMoneyValue.ToString("#");
    }

}
