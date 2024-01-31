using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropOffZone : MonoBehaviour
{
    private ScoringSystem scoringSystem;
    private SOValuablesDefinition valuable;
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] private AudioSource collectSound;
    private float value;


    private void Start()
    {
        scoringSystem = GameObject.Find("ScoringSystem").GetComponent<ScoringSystem>();
    }

    // Check if the object was a grabbable object
    // Destroy object if it is placed in the drop-off zone
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Grabbable"))
        {
            // Obtain the collider's Scriptable Object values through a handler
            valuable = other.gameObject.GetComponent<ValuablesHandler>().valuables;
            //Executes Value Increment Animation
            scoringSystem.IncreaseMoney(valuable.GetValue());
            //Instantiates a Text Mesh Pro object to display Increment animation
            ShowFloatingText();
            Destroy(other.gameObject);
            //Drop off SFX
            collectSound.Play();
            
        }
    }

    // Pops up the amount of money you just got
    void ShowFloatingText()
    {
        value = valuable.GetValue();
        //Creates a text and grabs the value of the object to display in the text 
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponentInChildren<TextMeshProUGUI>().text = "+" + value.ToString();
    }


}
