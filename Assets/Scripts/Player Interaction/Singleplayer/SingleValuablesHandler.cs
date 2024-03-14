using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Contributors: Dominic, Nick, Adrian, Jacky
public class SingleValuablesHandler : MonoBehaviour
{
    public SOValuablesDefinition valuables;
    private float currentPrice;
    private float value;
    [SerializeField] private GameObject floatingValuePrefab;

    public void Start()
    {
        ShowFloatingValue();
    }

    public void Initialize(float price)
    {
        currentPrice = price;
    }

    public float GetPrice()
    {
        return currentPrice;
    }

    void ShowFloatingValue()
    {
        value = valuables.price;

        //Creates a text and grabs the value of the object to display in the text 
        var fly = Instantiate(floatingValuePrefab, transform.position, Quaternion.identity, transform);
        fly.GetComponentInChildren<TextMeshProUGUI>().text = "$" + value.ToString();
    }
}
