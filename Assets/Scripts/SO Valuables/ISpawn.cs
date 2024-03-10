using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Netcode;
// Contributors: Dominic
public abstract class ISpawn : NetworkBehaviour
{
    protected int _numberOfValuables; // Limits how many variables will spawn
    protected private List<GameObject> _spawnerLocations;
    protected private SOValuablesDefinition[] _valuablesSO;

    public bool DestroyWithSpawner;
    private GameObject m_PrefabInstance;
    private NetworkObject m_SpawnedNetworkObject;

    public virtual void Start()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        // Only the server spawns, clients will disable this component on their side
        enabled = IsServer;
        if (!enabled || _valuablesSO == null)
        {
            return;
        }

        int numObjects = _valuablesSO.Length;
        int spawnLocLength = _spawnerLocations.Count;

        // Create a list of Vectors that contains the position of each spawn location
        List<Vector3> spawnLocationVectors = new List<Vector3>();

        // Createa a list of Quaternions that contains the rotation of each spawn location
        List<Quaternion> spawnLocationRotation = new List<Quaternion>();

        // Shuffles spawnPos list to randomize where valuables will spawn
        List<int> spawnPos = Enumerable.Range(0, spawnLocLength).ToList();
        spawnPos = spawnPos.OrderBy(i => Guid.NewGuid()).ToList();

        // Populates the spawnLocationVectors with the position of each spawn location
        for (int i = 0; i < spawnLocLength; ++i)
        {
            spawnLocationVectors.Insert(i, _spawnerLocations[spawnPos[i]].transform.position);
            spawnLocationRotation.Insert(i, _spawnerLocations[spawnPos[i]].transform.rotation);
        }

        //float randomnum = valuablesSO[0].GetPrice();
        // Spawns the valuables
        for (int j = 0; j < _numberOfValuables; ++j)
        {
            m_PrefabInstance = Instantiate(_valuablesSO[UnityEngine.Random.Range(0, numObjects)].GetPrefab());

            m_PrefabInstance.transform.position = spawnLocationVectors[j];
            m_PrefabInstance.transform.rotation = spawnLocationRotation[j];

            m_SpawnedNetworkObject = m_PrefabInstance.GetComponent<NetworkObject>();
            m_SpawnedNetworkObject.Spawn();
        }
    }

    public override void OnNetworkDespawn()
    {
        if (IsServer && DestroyWithSpawner && m_SpawnedNetworkObject != null && m_SpawnedNetworkObject.IsSpawned)
        {
            m_SpawnedNetworkObject.Despawn();
        }
        base.OnNetworkDespawn();
    }
}
