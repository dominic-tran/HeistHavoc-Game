using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using System;


// Contributors: Dominic, Nick, Adrian, Jacky
public class ValuablesHandler : NetworkBehaviour, IValuables
{
    public static event EventHandler OnAnyObjectPlacedHere;
    public SOValuablesDefinition valuables;
    private float value;
    [SerializeField] private GameObject floatingValuePrefab;

    private ObjectGrabbable objectGrabbable;

    public void Start()
    {
        ShowFloatingValue();
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject instance = GameObject.Instantiate(valuables.prefab, position, rotation);

        return instance;
    }

    public float GetValue()
    {
        return valuables.price;
    }

    public float GetWeight()
    {
        return valuables.weight;
    }

    public GameObject GetPrefab()
    {
        return valuables.prefab;
    }
    public void SetValuableObject(ObjectGrabbable objectGrabbable)
    {
        this.objectGrabbable = objectGrabbable;

        if (objectGrabbable != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool HasValuable()
    {
        return valuables != null;
    }

    public NetworkObject GetNetworkObject()
    {
        return NetworkObject;
    }

    void ShowFloatingValue()
    {
        value = valuables.price;

        //Creates a text and grabs the value of the object to display in the text 
        var fly = Instantiate(floatingValuePrefab, transform.position, Quaternion.identity, transform);
        fly.GetComponentInChildren<TextMeshProUGUI>().text = "$" + value.ToString();
    }

}
