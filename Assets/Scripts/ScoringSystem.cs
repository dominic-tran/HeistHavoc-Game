using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float money;

    private void Start()
    {
        money = 0;
    }

    public void AddToScore(float price)
    {
        money += price;
        scoreText.text = "Money: " + money.ToString();
        collectSound.Play();
    }
}
