using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OfflineProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private TextMeshProUGUI timeText;
    
    [SerializeField] private GameObject offlineProgressPopupPanel;

    [SerializeField] private ProjectHolder projectHolder;
    
    private int goldReward;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("LASTLEAVE"))
        {
            //do popup
            DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LASTLEAVE"));

            TimeSpan timeElapsed = DateTime.Now - lastLogin;
            
            offlineProgressPopupPanel.SetActive(true);
            timeText.text = $"{timeElapsed.Days} days, {timeElapsed.Hours} hours, {timeElapsed.Minutes} minutes.";

            float goldPerPts = projectHolder.GetAverageGoldPerProductionPts();
            int averageDps = StatsManager.instance.GetAverageDPS();

            float goldPerSeconds = averageDps * goldPerPts;

            goldReward = Mathf.RoundToInt((float) (goldPerSeconds * timeElapsed.TotalSeconds));
            goldText.text = $"{goldReward} <sprite=0>";
        }
        else
        {
            offlineProgressPopupPanel.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LASTLEAVE", DateTime.Now.ToString());
    }

    public void ClaimReward()
    {
        ResourcesManager.instance.AddGold(goldReward);
        offlineProgressPopupPanel.SetActive(false);
    }
}
