using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ValuablesSpawnManager : MonoBehaviour
{
    [SerializeField][Range(1,5)] private int numberOfValuables; // Will eventually range from 1-20 valuables
    [SerializeField] private List<GameObject> spawnLocations;
    [SerializeField] private SOValuablesDefinition[] valuablesSO;


    // Start is called before the first frame update
    void Start()
    {
        int numObjects = valuablesSO.Length;
        int spawnLocLength = spawnLocations.Count;

        // Create a list of Vectors that contains the position of each spawn location
        List<Vector3> spawnLocationVectors = new List<Vector3>();

        // Shuffles spawnPos list to randomize where valuables will spawn
        List<int> spawnPos = Enumerable.Range(0, spawnLocLength).ToList();
        spawnPos = spawnPos.OrderBy(i => Guid.NewGuid()).ToList();

        // Populates the spawnLocationVectors with the position of each spawn location
        for(int i = 0; i < spawnLocLength; ++i)
        {
            spawnLocationVectors.Insert(i, spawnLocations[spawnPos[i]].transform.position);
        }

        //float randomnum = valuablesSO[0].GetPrice();
        // Spawns the valuables
        for(int j = 0; j < numberOfValuables; ++j)
        {
            valuablesSO[UnityEngine.Random.Range(0, numObjects)].Spawn(spawnLocationVectors[j]);
        }
    }
}
