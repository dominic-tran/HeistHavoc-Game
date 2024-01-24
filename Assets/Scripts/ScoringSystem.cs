using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{

    private int Money = 0;
    public AudioSource collectSound;
    public TextMeshProUGUI scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Gold")
        {
            Money++;
            scoreText.text = "Money: " + Money.ToString();
            Debug.Log(Money);
            collectSound.Play();
            Destroy(other.gameObject);
        }
    }
}
