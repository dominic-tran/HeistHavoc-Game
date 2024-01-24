using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuablesHandler : MonoBehaviour
{
    public SOValuablesDefinition valuables;

    private float currentPrice;

    public void Initialize(float price)
    {
        currentPrice = price;
    }

    public float GetPrice()
    {
        return currentPrice;
    }
}
