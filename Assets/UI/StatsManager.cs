using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;

    private int currentProgrammingTap =>
        Mathf.RoundToInt(baseProgrammingTap * permanentProgrammingTapMultiplier * temporaryProgrammingTapMultiplier * studioProductivity);
    [SerializeField]  private float baseProgrammingTap;
    private float permanentProgrammingTapMultiplier = 1f;
    private float temporaryProgrammingTapMultiplier = 1f;
    
    private int currentArtisticTap =>
        Mathf.RoundToInt(baseArtisticTap * permanentArtisticTapMultiplier * temporaryArtisticTapMultiplier * studioProductivity);
    [SerializeField]  private float baseArtisticTap;
    private float permanentArtisticTapMultiplier = 1f;
    private float temporaryArtisticTapMultiplier = 1f;
    
    private int currentSoundTap =>
        Mathf.RoundToInt(baseSoundTap * permanentSoundTapMultiplier * temporarySoundTapMultiplier * studioProductivity);
    [SerializeField]  private float baseSoundTap;
    private float permanentSoundTapMultiplier = 1f;
    private float temporarySoundTapMultiplier = 1f;
    
    private int currentGameDesignTap =>
        Mathf.RoundToInt(baseGameDesignTap * permanentGameDesignTapMultiplier * temporaryGameDesignTapMultiplier * studioProductivity);
    [SerializeField]  private float baseGameDesignTap;
    private float permanentGameDesignTapMultiplier = 1f;
    private float temporaryGameDesignTapMultiplier = 1f;
    
    
    [SerializeField] private int currentProgrammingDPS;
    [SerializeField] private int currentArtisticDPS;
    [SerializeField] private int currentSoundDPS;
    [SerializeField] private int currentGameDesignDPS;

    [SerializeField] private float studioProductivity = 1f;
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
    }

    private void Start()
    {
        OnStatsChanged?.Invoke();
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
                break;
            case UpgradeType.ArtisticDPS:
                break;
            case UpgradeType.SoundDPS:
                break;
            case UpgradeType.GameDesignDPS:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnStatsChanged?.Invoke();
    }

    public void UpgradePermanentStatsPercentage(Upgrade upgrade)
    {
        switch(upgrade.upgradeType)
        {
            case UpgradeType.StudioProductivity:
                studioProductivity *= (1 + upgrade.upgradeValue);
                break;
            case UpgradeType.ProgrammingTap:
                break;
            case UpgradeType.ArtisticTap:
                break;
            case UpgradeType.SoundTap:
                break;
            case UpgradeType.GameDesignTap:
                break;
            case UpgradeType.AllTaps:
                break;
            case UpgradeType.ProgrammingDPS:
                break;
            case UpgradeType.ArtisticDPS:
                break;
            case UpgradeType.SoundDPS:
                break;
            case UpgradeType.GameDesignDPS:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        OnStatsChanged?.Invoke();
    }
}
