using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartProd : MonoBehaviour
{
    public TextMeshProUGUI txtProduction;
    public Image programmingProduction;
    public Image artisticProduction;
    public Image soundProduction;
    public Image gameDesignProduction;

    public Enemy enemy;

    private float totalMaxProduction;
    private float totalCurrentProduction;
    
    private void Awake()
    {
        Spawner.OnEnemySpawned += HandleNewEnemySpawn;
    }

    private void HandleNewEnemySpawn(Enemy newEnemy)
    {
        enemy = newEnemy;
        totalMaxProduction = enemy.GetTotalMaxProduction();
    }
    
    void Update()
    {
        if (enemy == null)
            enemy = FindObjectOfType<Enemy>();
        else
        {
            AutoClick(Time.deltaTime);
            programmingProduction.fillAmount = enemy.currentProgrammingPts / enemy.maxProgrammingPts;
            artisticProduction.fillAmount = enemy.currentArtisticPts / enemy.maxArtisticPts;
            soundProduction.fillAmount = enemy.currentSoundPts / enemy.maxSoundPts;
            gameDesignProduction.fillAmount = enemy.currentGameDesignPts / enemy.maxGameDesignPts;

            totalCurrentProduction = enemy.GetTotalCurrentProduction();

            txtProduction.text = $"{totalCurrentProduction / totalMaxProduction * 100:F0}%";
        }
    }

    public void AutoClick(float deltaTime)
    {       
        enemy.currentProgrammingPts = Mathf.Clamp(enemy.currentProgrammingPts + StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingDPS) * deltaTime,0, enemy.maxProgrammingPts);
        enemy.currentArtisticPts = Mathf.Clamp(enemy.currentArtisticPts + StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticDPS) * deltaTime,0, enemy.maxArtisticPts);
        enemy.currentSoundPts = Mathf.Clamp(enemy.currentSoundPts + StatsManager.instance.RequestStats(StatsQuery.CurrentSoundDPS) * deltaTime,0, enemy.maxSoundPts);
        enemy.currentGameDesignPts = Mathf.Clamp(enemy.currentGameDesignPts + StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignDPS) * deltaTime,0, enemy.maxGameDesignPts);
    }

    public void ClickManual()
    {
        // if(enemy.currentHealth < enemy.maxHealth)
        // {
        //     enemy.currentHealth += 1;
        // }
    }

    
}
