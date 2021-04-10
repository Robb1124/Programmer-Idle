using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;

    private int currentProgrammingTap =>
        Mathf.RoundToInt(baseProgrammingTap * permanentProgrammingTapMultiplier * temporaryProgrammingTapMultiplier * studioProductivity * allTapsMultiplier);
    [SerializeField]  private float baseProgrammingTap;
    [SerializeField]private float permanentProgrammingTapMultiplier = 1f;
    private float temporaryProgrammingTapMultiplier = 1f;
    
    private int currentArtisticTap =>
        Mathf.RoundToInt(baseArtisticTap * permanentArtisticTapMultiplier * temporaryArtisticTapMultiplier * studioProductivity * allTapsMultiplier);
    [SerializeField]  private float baseArtisticTap;
    [SerializeField]private float permanentArtisticTapMultiplier = 1f;
    private float temporaryArtisticTapMultiplier = 1f;
    
    private int currentSoundTap =>
        Mathf.RoundToInt(baseSoundTap * permanentSoundTapMultiplier * temporarySoundTapMultiplier * studioProductivity * allTapsMultiplier);
    [SerializeField]  private float baseSoundTap;
    [SerializeField]private float permanentSoundTapMultiplier = 1f;
    private float temporarySoundTapMultiplier = 1f;
    
    private int currentGameDesignTap =>
        Mathf.RoundToInt(baseGameDesignTap * permanentGameDesignTapMultiplier * temporaryGameDesignTapMultiplier * studioProductivity * allTapsMultiplier);
    [SerializeField]  private float baseGameDesignTap;
    [SerializeField]private float permanentGameDesignTapMultiplier = 1f;
    private float temporaryGameDesignTapMultiplier = 1f;
    
    
    private int currentProgrammingDPS =>
        Mathf.RoundToInt(baseProgrammingDPS * permanentProgrammingDPSMultiplier * temporaryProgrammingDPSMultiplier * studioProductivity * AbilityManager.instance.DpsMultiplier);
    [SerializeField] private float baseProgrammingDPS;
    [SerializeField]private float permanentProgrammingDPSMultiplier = 1f;
    private float temporaryProgrammingDPSMultiplier = 1f;
    
    private int currentArtisticDPS =>
        Mathf.RoundToInt(baseArtisticDPS * permanentArtisticDPSMultiplier * temporaryArtisticDPSMultiplier * studioProductivity * AbilityManager.instance.DpsMultiplier);
    [SerializeField] private float baseArtisticDPS;
    [SerializeField]private float permanentArtisticDPSMultiplier = 1f;
    private float temporaryArtisticDPSMultiplier = 1f;
    
    private int currentSoundDPS =>
        Mathf.RoundToInt(baseSoundDPS * permanentSoundDPSMultiplier * temporarySoundDPSMultiplier * studioProductivity * AbilityManager.instance.DpsMultiplier);
    [SerializeField] private float baseSoundDPS;
    [SerializeField]private float permanentSoundDPSMultiplier = 1f;
    private float temporarySoundDPSMultiplier = 1f;
    
    
    private int currentGameDesignDPS =>
        Mathf.RoundToInt(baseGameDesignDPS * permanentGameDesignDPSMultiplier * temporaryGameDesignDPSMultiplier * studioProductivity * AbilityManager.instance.DpsMultiplier);
    [SerializeField] private float baseGameDesignDPS;
    [SerializeField]private float permanentGameDesignDPSMultiplier = 1f;
    private float temporaryGameDesignDPSMultiplier = 1f;
    
    

    [SerializeField] private float studioProductivity = 1f;
    [SerializeField] private float allTapsMultiplier = 1f;
    private string programmingColorTag = "<color=#0075db>";
    private string artisticColorTag = "<color=#00de0e>";
    private string soundColorTag = "<color=#b800df>";
    private string gameDesignColorTag = "<color=#e8ad00>";

    public static event Action OnStatsChanged;
    //dictionnaire enum -> stats
    //stats will have a calculate method that calculates its stats with different bonuses
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        
        //Screen.SetResolution(576, 1024, true);
        
        baseProgrammingTap = PlayerPrefs.GetFloat("baseProgrammingTap", baseProgrammingTap);
        permanentProgrammingTapMultiplier = PlayerPrefs.GetFloat("permanentProgrammingTapMultiplier", permanentProgrammingTapMultiplier);

        baseArtisticTap = PlayerPrefs.GetFloat("baseArtisticTap", baseArtisticTap);
        permanentArtisticTapMultiplier = PlayerPrefs.GetFloat("permanentArtisticTapMultiplier", permanentArtisticTapMultiplier);

        baseSoundTap = PlayerPrefs.GetFloat("baseSoundTap", baseSoundTap);
        permanentSoundTapMultiplier = PlayerPrefs.GetFloat("permanentSoundTapMultiplier", permanentSoundTapMultiplier);

        baseGameDesignTap = PlayerPrefs.GetFloat("baseGameDesignTap", baseGameDesignTap);
        permanentGameDesignTapMultiplier = PlayerPrefs.GetFloat("permanentGameDesignTapMultiplier", permanentGameDesignTapMultiplier);
        
        baseProgrammingDPS = PlayerPrefs.GetFloat("baseProgrammingDPS", baseProgrammingDPS);
        permanentProgrammingDPSMultiplier = PlayerPrefs.GetFloat("permanentProgrammingDPSMultiplier", permanentProgrammingDPSMultiplier);

        baseArtisticDPS = PlayerPrefs.GetFloat("baseArtisticDPS", baseArtisticDPS);
        permanentArtisticDPSMultiplier = PlayerPrefs.GetFloat("permanentArtisticDPSMultiplier", permanentArtisticDPSMultiplier);

        baseSoundDPS = PlayerPrefs.GetFloat("baseSoundDPS", baseSoundDPS);
        permanentSoundDPSMultiplier = PlayerPrefs.GetFloat("permanentSoundDPSMultiplier", permanentSoundDPSMultiplier);

        baseGameDesignDPS = PlayerPrefs.GetFloat("baseGameDesignDPS", baseGameDesignDPS);
        permanentGameDesignDPSMultiplier = PlayerPrefs.GetFloat("permanentGameDesignDPSMultiplier", permanentGameDesignDPSMultiplier);

        studioProductivity = PlayerPrefs.GetFloat("studioProductivity", studioProductivity);
        allTapsMultiplier = PlayerPrefs.GetFloat("allTapsMultiplier", allTapsMultiplier);
    }

    private void Start()
    {
        Invoke_StatsChanged();
    }

    public string RequestStatsString(StatsQuery statsQuery)
    {
        switch(statsQuery)
        {
            case StatsQuery.None:
                break;
            case StatsQuery.CurrentProgrammingTap:
                return $"{programmingColorTag}Programming Pts per Tap : {currentProgrammingTap}";
            case StatsQuery.CurrentArtisticTap:
                return $"{artisticColorTag}Artistic Pts per Tap : {currentArtisticTap}";
            case StatsQuery.CurrentSoundTap:
                return $"{soundColorTag}Sound Design Pts per Tap : {currentSoundTap}";
            case StatsQuery.CurrentGameDesignTap:
                return $"{gameDesignColorTag}Game Design Pts per Tap : {currentGameDesignTap}";
            case StatsQuery.CurrentProgrammingDPS:
                return $"{programmingColorTag}Programming Pts per Seconds : {currentProgrammingDPS}";
            case StatsQuery.CurrentArtisticDPS:
                return $"{artisticColorTag}Artistic Pts per Seconds : {currentArtisticDPS}";
            case StatsQuery.CurrentSoundDPS:
                return $"{soundColorTag}Sound Pts per Seconds : {currentSoundDPS}";
            case StatsQuery.CurrentGameDesignDPS:
                return $"{gameDesignColorTag}Game Design Pts per Seconds : {currentGameDesignDPS}";
            default:
                throw new ArgumentOutOfRangeException(nameof(statsQuery), statsQuery, null);
        }

        return "";
    }
    
    public int RequestStats(StatsQuery statsQuery)
    {
        switch(statsQuery)
        {
            case StatsQuery.None:
                break;
            case StatsQuery.CurrentProgrammingTap:
                return currentProgrammingTap;
            case StatsQuery.CurrentArtisticTap:
                return currentArtisticTap;
            case StatsQuery.CurrentSoundTap:
                return currentSoundTap;
            case StatsQuery.CurrentGameDesignTap:
                return currentGameDesignTap;
            case StatsQuery.CurrentProgrammingDPS:
                return currentProgrammingDPS;
            case StatsQuery.CurrentArtisticDPS:
                return currentArtisticDPS;
            case StatsQuery.CurrentSoundDPS:
                return currentSoundDPS;
            case StatsQuery.CurrentGameDesignDPS:
                return currentGameDesignDPS;
            default:
                throw new ArgumentOutOfRangeException(nameof(statsQuery), statsQuery, null);
        }

        return 0;
    }

    public void UpgradeBaseStats(IncrementalUpgrade incrementalUpgrade, int amountBuyed)
    {
        switch(incrementalUpgrade.upgradeType)
        {
            case UpgradeType.StudioProductivity:
                break;
            case UpgradeType.ProgrammingTap:
                baseProgrammingTap += (incrementalUpgrade.baseValue * Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.ArtisticTap:
                baseArtisticTap += (incrementalUpgrade.baseValue * Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.SoundTap:
                baseSoundTap += (incrementalUpgrade.baseValue * Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.GameDesignTap:
                baseGameDesignTap += (incrementalUpgrade.baseValue * Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.AllTaps:
                break;
            case UpgradeType.ProgrammingDPS:
                baseProgrammingDPS += (incrementalUpgrade.baseValue *
                                       Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.ArtisticDPS:
                baseArtisticDPS += (incrementalUpgrade.baseValue *
                                       Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.SoundDPS:
                baseSoundDPS += (incrementalUpgrade.baseValue *
                                       Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            case UpgradeType.GameDesignDPS:
                baseGameDesignDPS += (incrementalUpgrade.baseValue *
                                       Mathf.Pow(1f + incrementalUpgrade.increasedByEachTime, amountBuyed));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        Invoke_StatsChanged();
    }

    public void UpgradePermanentStatsPercentage(Upgrade upgrade)
    {
        switch(upgrade.upgradeType)
        {
            case UpgradeType.StudioProductivity:
                studioProductivity *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.ProgrammingTap:
                permanentProgrammingTapMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.ArtisticTap:
                permanentArtisticTapMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.SoundTap:
                permanentSoundTapMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.GameDesignTap:
                permanentGameDesignTapMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.AllTaps:
                allTapsMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.ProgrammingDPS:
                permanentProgrammingDPSMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.ArtisticDPS:
                permanentArtisticDPSMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.SoundDPS:
                permanentSoundDPSMultiplier *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.GameDesignDPS:
                permanentGameDesignDPSMultiplier *= (1 + upgrade.upgradeValue);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Invoke_StatsChanged();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("baseProgrammingTap", baseProgrammingTap);
        PlayerPrefs.SetFloat("permanentProgrammingTapMultiplier", permanentProgrammingTapMultiplier);

        PlayerPrefs.SetFloat("baseArtisticTap", baseArtisticTap);
        PlayerPrefs.SetFloat("permanentArtisticTapMultiplier", permanentArtisticTapMultiplier);

        PlayerPrefs.SetFloat("baseSoundTap", baseSoundTap);
        PlayerPrefs.SetFloat("permanentSoundTapMultiplier", permanentSoundTapMultiplier);

        PlayerPrefs.SetFloat("baseGameDesignTap", baseGameDesignTap);
        PlayerPrefs.SetFloat("permanentGameDesignTapMultiplier", permanentGameDesignTapMultiplier);
        
        PlayerPrefs.SetFloat("baseProgrammingDPS", baseProgrammingDPS);
        PlayerPrefs.SetFloat("permanentProgrammingDPSMultiplier", permanentProgrammingDPSMultiplier);

        PlayerPrefs.SetFloat("baseArtisticDPS", baseArtisticDPS);
        PlayerPrefs.SetFloat("permanentArtisticDPSMultiplier", permanentArtisticDPSMultiplier);

        PlayerPrefs.SetFloat("baseSoundDPS", baseSoundDPS);
        PlayerPrefs.SetFloat("permanentSoundDPSMultiplier", permanentSoundDPSMultiplier);

        PlayerPrefs.SetFloat("baseGameDesignDPS", baseGameDesignDPS);
        PlayerPrefs.SetFloat("permanentGameDesignDPSMultiplier", permanentGameDesignDPSMultiplier);

        PlayerPrefs.SetFloat("studioProductivity", studioProductivity);
        PlayerPrefs.SetFloat("allTapsMultiplier", allTapsMultiplier);
    }

    public int GetAverageDPS()
    {
        return (currentProgrammingDPS + currentArtisticDPS + currentSoundDPS + currentGameDesignDPS) / 4;
    }

    public void Invoke_StatsChanged()
    {
        OnStatsChanged?.Invoke();
        #if UNITY_WEBGL
        PlayerPrefs.SetFloat("baseProgrammingTap", baseProgrammingTap);
        PlayerPrefs.SetFloat("permanentProgrammingTapMultiplier", permanentProgrammingTapMultiplier);

        PlayerPrefs.SetFloat("baseArtisticTap", baseArtisticTap);
        PlayerPrefs.SetFloat("permanentArtisticTapMultiplier", permanentArtisticTapMultiplier);

        PlayerPrefs.SetFloat("baseSoundTap", baseSoundTap);
        PlayerPrefs.SetFloat("permanentSoundTapMultiplier", permanentSoundTapMultiplier);

        PlayerPrefs.SetFloat("baseGameDesignTap", baseGameDesignTap);
        PlayerPrefs.SetFloat("permanentGameDesignTapMultiplier", permanentGameDesignTapMultiplier);
        
        PlayerPrefs.SetFloat("baseProgrammingDPS", baseProgrammingDPS);
        PlayerPrefs.SetFloat("permanentProgrammingDPSMultiplier", permanentProgrammingDPSMultiplier);

        PlayerPrefs.SetFloat("baseArtisticDPS", baseArtisticDPS);
        PlayerPrefs.SetFloat("permanentArtisticDPSMultiplier", permanentArtisticDPSMultiplier);

        PlayerPrefs.SetFloat("baseSoundDPS", baseSoundDPS);
        PlayerPrefs.SetFloat("permanentSoundDPSMultiplier", permanentSoundDPSMultiplier);

        PlayerPrefs.SetFloat("baseGameDesignDPS", baseGameDesignDPS);
        PlayerPrefs.SetFloat("permanentGameDesignDPSMultiplier", permanentGameDesignDPSMultiplier);

        PlayerPrefs.SetFloat("studioProductivity", studioProductivity);
        PlayerPrefs.SetFloat("allTapsMultiplier", allTapsMultiplier);
        #endif
    }
}
