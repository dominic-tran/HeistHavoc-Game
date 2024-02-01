using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic
public interface IValuables
{
    GameObject Spawn(Vector3 position, Quaternion rotation);
    float GetValue();
    float GetWeight();
    GameObject GetPrefab();
}
