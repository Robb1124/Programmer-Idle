using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenStatsManager : MonoBehaviour
{
    public static ScreenStatsManager instance;
    [Header("DPS")] 
    [SerializeField] private Image programmingDPSImage;
    [SerializeField] private Image artisticDPSImage;
    [SerializeField] private Image soundDPSImage;
    [SerializeField] private Image gameDesignDPSImage;
    [SerializeField] private TextMeshProUGUI totalDPSText;

    [Header("Tap")]
    [SerializeField] private Image programmingTapImage;
    [SerializeField] private Image artisticTapImage;
    [SerializeField] private Image soundTapImage;
    [SerializeField] private Image gameDesignTapImage;
    [SerializeField] private TextMeshProUGUI totalTapText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            Destroy(this);

        StatsManager.OnStatsChanged += HandleStatsChanged;
    }

    private void HandleStatsChanged()
    {
        RefreshImages();
    }

    private void RefreshImages()
    {
        int programmingTap = StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingTap);
        int artisticTap = StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticTap);
        int soundTap = StatsManager.instance.RequestStats(StatsQuery.CurrentSoundTap);
        int gameDesignTap = StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignTap);

        int totalTap = programmingTap + artisticTap + soundTap + gameDesignTap;
        totalTapText.text = totalTap.ToString();
        float totalFill = (float)programmingTap / totalTap;
        programmingTapImage.fillAmount = totalFill;
        totalFill += (float)artisticTap / totalTap;
        artisticTapImage.fillAmount = totalFill;
        totalFill += (float)soundTap / totalTap;
        soundTapImage.fillAmount = totalFill;
        totalFill += (float)gameDesignTap / totalTap;
        gameDesignTapImage.fillAmount = totalFill;
        
        int programmingDPS = StatsManager.instance.RequestStats(StatsQuery.CurrentProgrammingDPS);
        int artisticDPS = StatsManager.instance.RequestStats(StatsQuery.CurrentArtisticDPS);
        int soundDPS = StatsManager.instance.RequestStats(StatsQuery.CurrentSoundDPS);
        int gameDesignDPS = StatsManager.instance.RequestStats(StatsQuery.CurrentGameDesignDPS);

        int totalDPS = programmingDPS + artisticDPS + soundDPS + gameDesignDPS;
        totalDPSText.text = totalDPS.ToString();
        totalFill = (float)programmingDPS / totalDPS;
        programmingDPSImage.fillAmount = totalFill;
        totalFill += (float)artisticDPS / totalDPS;
        artisticDPSImage.fillAmount = totalFill;
        totalFill += (float)soundDPS / totalDPS;
        soundDPSImage.fillAmount = totalFill;
        totalFill += (float)gameDesignDPS / totalDPS;
        gameDesignDPSImage.fillAmount = totalFill;
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
