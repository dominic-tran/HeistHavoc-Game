using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heist Havoc/Valuables Definition")]
public class SOValuablesDefinition : ScriptableObject, IValuables
{
    [SerializeField] private float price;
    [SerializeField] private float weight;
    [SerializeField] private GameObject prefab;

    public GameObject Spawn(Vector3 position)
    {
        GameObject instance = GameObject.Instantiate(prefab, position, Quaternion.identity);
        
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
