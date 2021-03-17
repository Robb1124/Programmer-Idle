using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] projectPrefab;
    [SerializeField] private Transform spawnPoint;
    public bool wait = false;

    public static event Action<Enemy> OnEnemySpawned;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wait == false)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy newSpawn = Instantiate(projectPrefab[UnityEngine.Random.Range(0, projectPrefab.Length)], spawnPoint.transform);
        wait = true;
        OnEnemySpawned?.Invoke(newSpawn);
    }
}
