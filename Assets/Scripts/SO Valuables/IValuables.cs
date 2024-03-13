using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

// Contributors: Dominic
public interface IValuables
{
    GameObject Spawn(Vector3 position, Quaternion rotation);
    float GetValue();
    float GetWeight();
    GameObject GetPrefab();
    public NetworkObject GetNetworkObject();
    public bool HasValuable();
    public void SetValuableObject(ObjectGrabbable objectGrabbable);
}
