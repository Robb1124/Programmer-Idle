using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ProjectData[] simpleTasks;
    [SerializeField] private ProjectData gameJam;
    [Range(0.01f, 1.00f)]
    [SerializeField] private float gameJamChances = 0.05f;
    
    [SerializeField] private ProjectHolder projectHolder;

    public static event Action OnEnemySpawned;
    
    void Start()
    {
        Spawn();
    }
    
    private void Spawn()
    {
        float rand = UnityEngine.Random.Range(0.00f, 1.00f);
        if (rand <= gameJamChances)
        {
            projectHolder.GetProjectData(gameJam, true);
        }
        else
        {
            int randIndex = UnityEngine.Random.Range(0, simpleTasks.Length);
            projectHolder.GetProjectData(simpleTasks[randIndex]);
        }
        OnEnemySpawned?.Invoke();
    }

    public void RequestNewProject()
    {
        Spawn();
    }
}
