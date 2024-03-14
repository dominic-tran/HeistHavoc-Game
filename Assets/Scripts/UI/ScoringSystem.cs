using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

// Contributors: Adrian, Jacky, Nick, Dominic
public class ScoringSystem : NetworkBehaviour, IScoreObserver
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private float smoothIncreaseDuration = 0.5f;
    [SerializeField] private float gameDuration = 60f;
    [SerializeField] private float goalAmount = 45f;

    //private float currentMoney;

    // Synchronize currentMoney across the network
    /*[SyncVar(hook = nameof(OnCurrentMoneyChanged))] private float currentMoney;



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

    // SyncVar hook to handle UI updates when currentMoney changes
    private void OnCurrentMoneyChanged(float oldValue, float newValue)
    {
        AddToScore();
    }*/

    private NetworkVariable<float> currentMoney = new NetworkVariable<float>(0f);
    private float timer;

    private void Start()
    {
        goalText.text = "Goal: $" + goalAmount.ToString();
        timer = gameDuration;
        StartCoroutine(UpdateTimer());
        currentMoney.OnValueChanged += CurrentMoneyChanged;
        AddToScore();
    }

    private IEnumerator UpdateTimer()
    {
        while (timer >= 1)
        {
            timer -= Time.deltaTime;
            UpdateUITimer();
            yield return null;
        }

        GameStateManager.GameOver();
    }

    private void UpdateUITimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CurrentMoneyChanged(float oldValue, float newValue)
    {
        AddToScore();
        CheckWinCondition();
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

        while (elapsedTime < smoothIncreaseDuration)
        {
            float currentPayment = moneyPerTick * Time.deltaTime;
            currentMoney.Value += currentPayment;
            elapsedTime += Time.deltaTime;
            //Every frame that occurs, the animation increments the value
            yield return null;
        }

        FinalDisplay();
        CheckWinCondition();
    }

    //Utilized to increment decimals every frame of the elapsed time
    public void AddToScore()
    {
        scoreText.text = "Value Stolen: $" + currentMoney.Value.ToString("0.00");
    }

    // Final Display is used to fix the precision point error that floats have 
    public void FinalDisplay()
    {
        int roundedMoneyValue = (int)Mathf.Round(currentMoney.Value);
        scoreText.text = "Value Stolen: $" + roundedMoneyValue.ToString("#");
        
    }

    // Check win condition and call GameStateManager.Win() if necessary
    private void CheckWinCondition()
    {
        if (currentMoney.Value >= goalAmount)
        {
            GameStateManager.Win();
        }
    }
}
