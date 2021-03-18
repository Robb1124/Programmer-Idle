using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;

    private string androidGameId = "4055171";
    private string rewardVideoId = "RewardVideo";
    [SerializeField] private Button watchRewardVideoButton;
    
    public bool TestMode = true;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        
        watchRewardVideoButton.interactable = false;
    }

    private void Start()
    {
        Advertisement.Initialize(androidGameId, TestMode);
        Advertisement.AddListener(this);
    }

    public void ShowRewardVideo()
    {
        Advertisement.Show(rewardVideoId);
    }
    
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardVideoId)
        {
            watchRewardVideoButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //ad failed
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //ad started
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardVideoId)
        {
            if (showResult == ShowResult.Finished)
            {
                ResourcesManager.instance.RewardVideo();
            }
        }
    }
}
