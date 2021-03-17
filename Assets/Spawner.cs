using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] projectPrefab;
    public bool wait = false;
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
            for (int i = 0; i < projectPrefab.Length; i++)
            {
                if(projectPrefab[i] is null)
                    {
                        
                    }
                else
                    {
                        Instantiate(projectPrefab[i], transform.position, Quaternion.identity);
                        wait = true;
                        break;
                    }
            }
    }
}
