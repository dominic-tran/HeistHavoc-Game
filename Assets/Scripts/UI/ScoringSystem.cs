using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
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
            if(currentMoney >= 100)
            {
                currentMoney = 100;
                break;
            }
            yield return null;
            

        }
    }
    //Utilized to increment decimals every frame of the elapsed time
    void AddToScore()
    {
        scoreText.text = "Value Stolen: " + currentMoney.ToString("#.##");   
    }
    // Final Display is used to fix the precision point error that floats have 
    public void FinalDisplay()
    {
        currentMoney = Mathf.Round(currentMoney * 100) / 100;
        scoreText.text = "Value Stolen: " + currentMoney.ToString("#.##");
    }

}
