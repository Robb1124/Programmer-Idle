using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUpgradeGridObject : GridObject
{
    [SerializeField] private Image upgradeImage;
    [SerializeField] private TextMeshProUGUI upgradeTitle;
    [SerializeField] private TextMeshProUGUI upgradeDescription;
    [SerializeField] private IncrementalUpgrade incrementalUpgrade;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Price price;
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private Button buyButton;

    private Price currentPrice = new Price();
    
    private HeroUpgradeGridObjectData data;

    private bool statsToShow;
    private ResourcesManager resourcesManager;

    private void Start()
    {
        resourcesManager = ResourcesManager.instance;
        StatsManager.OnStatsChanged += HandleStatsChanged;
    }

    private void HandleStatsChanged()
    {
        if (statsToShow)
        {
            statsText.gameObject.SetActive(true);
            statsText.text = StatsManager.instance.RequestStatsString(data.statsQuery);
        }
        else
            statsText.gameObject.SetActive(false);
    }

    private void Update()    
    {
        if (Time.frameCount % 6 == 0)
        {
            buyButton.interactable = resourcesManager.CheckIfEnoughResource(currentPrice);
        }
    }

    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        data = (HeroUpgradeGridObjectData) gridObjectData;
        upgradeImage.sprite = data.UpgradeImage;
        upgradeTitle.text = data.UpgradeTitle;
        upgradeDescription.text = data.UpgradeDescription;
        price = data.Price;
        currentPrice.currencyType = price.currencyType;
        SetPrice();
        statsToShow = data.StatsToShow;
        if (statsToShow)
        {
            statsText.gameObject.SetActive(true);
            statsText.text = StatsManager.instance.RequestStatsString(data.statsQuery);
        }
        else
            statsText.gameObject.SetActive(false);

        incrementalUpgrade = data.incrementalUpgrade;
    }

    private void SetPrice()
    {
        currentPrice.amount = Mathf.RoundToInt(price.amount * (Mathf.Pow(1f + ResourcesManager.PRICE_INCREASED, amountBought)));
        priceText.text = currentPrice.GetPriceText();
    }

    public void BuyButton()
    {
        if (resourcesManager.CheckIfEnoughResource(currentPrice))
        {
            resourcesManager.Buy(currentPrice);
            StatsManager.instance.UpgradeBaseStats(incrementalUpgrade, amountBought);
            amountBought++;
            SetPrice();
            ManualSave();
        }
    }

    private void OnDestroy()
    {
        StatsManager.OnStatsChanged -= HandleStatsChanged;
    }
}
