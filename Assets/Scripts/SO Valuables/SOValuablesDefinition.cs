using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic, Adrian, Nick, Jacky
[CreateAssetMenu(menuName = "Heist Havoc/Valuables Definition")]
public class SOValuablesDefinition : ScriptableObject
{
    public float price;
    public float weight;
    public GameObject prefab;

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject instance = GameObject.Instantiate(prefab, position, rotation);

        return instance;
    }
}