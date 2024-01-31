using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IValuables
{
    GameObject Spawn(Vector3 position);
    float GetValue();
    float GetWeight();
    GameObject GetPrefab();
}
