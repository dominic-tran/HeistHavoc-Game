using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Contributors: Dominic
public abstract class ISpawn : MonoBehaviour
{
    protected int _numberOfValuables; // Limits how many variables will spawn
    protected private List<GameObject> _spawnerLocations;
    protected private SOValuablesDefinition[] _valuablesSO;

    public virtual void Start()
    {
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

        // Spawns the valuables
        for (int j = 0; j < _numberOfValuables; ++j)
        {
            _valuablesSO[UnityEngine.Random.Range(0, numObjects)].Spawn(spawnLocationVectors[j], spawnLocationRotation[j]);
        }
    }
}