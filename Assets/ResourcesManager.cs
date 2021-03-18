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


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
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
        gemText.text = playerGems + " <sprite index=1>";
    }

    public bool CheckIfEnoughResource(Price price)
    {
        switch (price.currencyType)
        {
            case CurrencyType.Gold:
                return playerGold > price.amount;
            case CurrencyType.Gems:
                return playerGems > price.amount;
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
                playerGems -= price.amount;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        RefreshText();
    }

    public void GameJamDone()
    {
        int rand = UnityEngine.Random.Range(1, 4);
        playerGems += rand;
        RefreshText();
    }

    public void RewardVideo()
    {
        playerGems += 5;
        RefreshText();
    }
}
