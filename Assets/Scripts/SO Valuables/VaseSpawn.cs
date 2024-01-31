using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSpawn : ISpawn
{
    [SerializeField][Range(1,23)] private int numberOfValuables; // Limits how many variables will spawn
    [SerializeField] private List<GameObject> spawnLocations;
    [SerializeField] private SOValuablesDefinition[] valuablesSO;


    // Start is called before the first frame update
    public override void Start()
    {
        _numberOfValuables = numberOfValuables;
        _spawnerLocations = spawnLocations;
        _valuablesSO = valuablesSO;
        base.Start();
    }
}
