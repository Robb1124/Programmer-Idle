using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    [SerializeField] private int currentProgrammingTap;
    [SerializeField] private int currentArtisticTap;
    [SerializeField] private int currentSoundTap;
    [SerializeField] private int currentGameDesignTap;
    [SerializeField] private int currentProgrammingDPS;
    [SerializeField] private int currentArtisticDPS;
    [SerializeField] private int currentSoundDPS;
    [SerializeField] private int currentGameDesignDPS;
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
}
