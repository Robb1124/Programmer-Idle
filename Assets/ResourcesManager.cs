using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;
    public static float PRICE_INCREASED = 0.2f;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI gemText;

    [SerializeField] private int playerGold = 0;
    [SerializeField] private int playerGems = 0;

    public int PlayerGems => playerGems;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
        
        playerGold = PlayerPrefs.GetInt("playerGold", playerGold);
        playerGems = PlayerPrefs.GetInt("playerGems", PlayerGems);
    }

    private void Start()
    {
        RefreshText();
    }

    public void AddGold(int goldAmount)
    {
        playerGold += goldAmount;
        RefreshText();
    }

    private void RefreshText()
    {
        goldText.text = playerGold + " <sprite index=0>";
        gemText.text = PlayerGems + " <sprite index=1>";
    }

    public bool CheckIfEnoughResource(Price price)
    {
        switch (price.currencyType)
        {
            case CurrencyType.Gold:
                return playerGold > price.amount;
            case CurrencyType.Gems:
                return PlayerGems > price.amount;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Buy(Price price)
    {
        switch (price.currencyType)
        {
            case CurrencyType.Gold:
                playerGold -= price.amount;
                break;
            case CurrencyType.Gems:
                playerGems = PlayerGems - price.amount;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        RefreshText();
    }

    public void GameJamDone()
    {
        int rand = UnityEngine.Random.Range(1, 4);
        playerGems = PlayerGems + rand;
        RefreshText();
    }

    public void RewardVideo()
    {
        playerGems = PlayerGems + 5;
        RefreshText();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("playerGold", playerGold);
        PlayerPrefs.SetInt("playerGems", PlayerGems);
    }

    public void AddGems(int gemsAmount)
    {
        playerGems += gemsAmount;
        RefreshText();
    }
}
