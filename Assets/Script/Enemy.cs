using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxProgrammingPts;
    [HideInInspector]public float currentProgrammingPts;
    public float maxArtisticPts;
    [HideInInspector]public float currentArtisticPts;
    public float maxSoundPts;
    [HideInInspector]public float currentSoundPts;
    public float maxGameDesignPts;
    [HideInInspector]public float currentGameDesignPts;

    public bool programmingDone;
    public bool artisticDone;
    public bool soundDone;
    public bool gameDesignDone;
    
    public Spawner spawnerScript;

    void Start()
    {
        spawnerScript = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 4 == 0)
        {
            CheckBars();
            if(AllBarsAreDone())
            {
                spawnerScript.wait = false;
                Destroy(gameObject);
            }
        }
        
    }

    private void CheckBars()
    {
        if (!programmingDone)
        {
            programmingDone = currentProgrammingPts >= maxProgrammingPts;
        }

        if (!artisticDone)
        {
            artisticDone = currentArtisticPts >= maxArtisticPts;
        }
        
        if (!soundDone)
        {
            soundDone = currentSoundPts >= maxSoundPts;
        }
        
        if (!gameDesignDone)
        {
            gameDesignDone = currentGameDesignPts >= maxGameDesignPts;
        }
    }

    private bool AllBarsAreDone()
    {
        return programmingDone && artisticDone &&
               soundDone && gameDesignDone;
    }

    public float GetTotalMaxProduction()
    {
        return maxProgrammingPts + maxArtisticPts + maxSoundPts + maxGameDesignPts;
    }

    public float GetTotalCurrentProduction()
    {
        return currentArtisticPts + currentProgrammingPts + currentSoundPts + currentGameDesignPts;
    }
}
