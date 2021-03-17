using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Spawner spawnerScript;

    void Start()
    {
        spawnerScript = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth >= maxHealth)
        {
            Debug.Log("yo");
            spawnerScript.wait = false;
            Debug.Log("yo");
            Destroy(gameObject);
        }
    }
}
