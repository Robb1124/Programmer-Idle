using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartProd : MonoBehaviour
{
    public static StartProd instance;
    
    public TextMeshProUGUI txtProduction;
    public Image programmingProduction;
    public Image artisticProduction;
    public Image soundProduction;
    public Image gameDesignProduction;

    [SerializeField] private Image programmingFrame;
    [SerializeField] private Image artisticFrame;
    [SerializeField] private Image soundFrame;
    [SerializeField] private Image gameDesignFrame;
    
    [SerializeField] private ProjectHolder projectHolder;

    private float totalMaxProduction;
    private float totalCurrentProduction;
    private bool allTapsActivated;
    private ClickType clickType;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
        
        Spawner.OnEnemySpawned += HandleNewEnemySpawn;
    }

    private void HandleNewEnemySpawn()
    {
        totalMaxProduction = projectHolder.GetTotalMaxProduction();
    }
    
    void Update()
    {
        AutoClick(Time.deltaTime);
        programmingProduction.fillAmount = (float)projectHolder.currentProgrammingPts / projectHolder.maxProgrammingPts;
        artisticProduction.fillAmount = (float)projectHolder.currentArtisticPts / projectHolder.maxArtisticPts;
        soundProduction.fillAmount = (float)projectHolder.currentSoundPts / projectHolder.maxSoundPts;
        gameDesignProduction.fillAmount = (float)projectHolder.currentGameDesignPts / projectHolder.maxGameDesignPts;

        totalCurrentProduction = projectHolder.GetTotalCurrentProduction();

        txtProduction.text = $"{totalCurrentProduction / totalMaxProduction * 100:F0}%";
    }

    public void AutoClick(float deltaTime)
    {       
        projectHolder.currentProgrammingPts = Mathf.Clamp(projectHolder.currentProgrammingPts + StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingDPS) * deltaTime,0, projectHolder.maxProgrammingPts);
        projectHolder.currentArtisticPts = Mathf.Clamp(projectHolder.currentArtisticPts + StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticDPS) * deltaTime,0, projectHolder.maxArtisticPts);
        projectHolder.currentSoundPts = Mathf.Clamp(projectHolder.currentSoundPts + StatsManager.instance.RequestStats(StatsQuery.CurrentSoundDPS) * deltaTime,0, projectHolder.maxSoundPts);
        projectHolder.currentGameDesignPts = Mathf.Clamp(projectHolder.currentGameDesignPts + StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignDPS) * deltaTime,0, projectHolder.maxGameDesignPts);
    }

    public void ClickManual()
    {
        switch (clickType)
        {
            case ClickType.Programming:
                projectHolder.currentProgrammingPts = Mathf.Clamp(projectHolder.currentProgrammingPts + StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingTap),0, projectHolder.maxProgrammingPts);
                break;
            case ClickType.Artistic:
                projectHolder.currentArtisticPts = Mathf.Clamp(projectHolder.currentArtisticPts + StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticTap) ,0, projectHolder.maxArtisticPts);
                break;
            case ClickType.Sound:
                projectHolder.currentSoundPts = Mathf.Clamp(projectHolder.currentSoundPts + StatsManager.instance.RequestStats(StatsQuery.CurrentSoundTap),0, projectHolder.maxSoundPts);
                break;
            case ClickType.GameDesign:
                projectHolder.currentGameDesignPts = Mathf.Clamp(projectHolder.currentGameDesignPts + StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignTap),0, projectHolder.maxGameDesignPts);
                break;
            case ClickType.All:
                projectHolder.currentProgrammingPts = Mathf.Clamp(projectHolder.currentProgrammingPts + StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingTap),0, projectHolder.maxProgrammingPts);
                projectHolder.currentArtisticPts = Mathf.Clamp(projectHolder.currentArtisticPts + StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticTap) ,0, projectHolder.maxArtisticPts);
                projectHolder.currentSoundPts = Mathf.Clamp(projectHolder.currentSoundPts + StatsManager.instance.RequestStats(StatsQuery.CurrentSoundTap),0, projectHolder.maxSoundPts);
                projectHolder.currentGameDesignPts = Mathf.Clamp(projectHolder.currentGameDesignPts + StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignTap),0, projectHolder.maxGameDesignPts);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SetClickType(int index)
    {
        if (allTapsActivated) return;
        programmingFrame.enabled = false;
        artisticFrame.enabled = false;
        soundFrame.enabled = false;
        gameDesignFrame.enabled = false;
        
        switch (index)
        {
            case 0:
                clickType = ClickType.Programming;
                programmingFrame.enabled = true;
                break;
            case 1:
                clickType = ClickType.Artistic;
                artisticFrame.enabled = true;
                break;
            case 2:
                clickType = ClickType.Sound;
                soundFrame.enabled = true;
                break;
            case 3:
                clickType = ClickType.GameDesign;
                gameDesignFrame.enabled = true;
                break;
        }
    }

    public void ActivateAllTapsAbility()
    {
        allTapsActivated = true;
        clickType = ClickType.All;
        programmingFrame.enabled = true;
        artisticFrame.enabled = true;
        soundFrame.enabled = true;
        gameDesignFrame.enabled = true;
    }

    public void DeactivateAllTapsAbility()
    {
        allTapsActivated = false;
        SetClickType(0);
    }
}
