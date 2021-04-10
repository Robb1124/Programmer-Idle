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

    private float timer = 10f;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("LASTLEAVE"))
        {
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

    private void Update()
    {
        #if UNITY_WEBGL
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 10;
            PlayerPrefs.SetString("LASTLEAVE", DateTime.Now.ToString());
        }
        #endif
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
