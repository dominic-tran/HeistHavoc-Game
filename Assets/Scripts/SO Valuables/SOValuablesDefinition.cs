using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic, Adrian, Nick, Jacky
[CreateAssetMenu(menuName = "Heist Havoc/Valuables Definition")]
public class SOValuablesDefinition : ScriptableObject, IValuables
{
    [SerializeField] private float price;
    [SerializeField] private float weight;
    [SerializeField] public GameObject prefab;

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject instance = GameObject.Instantiate(prefab, position, rotation);
        
        return instance;
    }

    public float GetValue()
    {
        return price;
    }

    public float GetWeight()
    {
        return weight;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
}
