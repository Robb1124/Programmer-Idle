using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudioUpgradeGridObject : GridObject
{
    [SerializeField] private Image upgradeImage;
    [SerializeField] private TextMeshProUGUI upgradeTitle;
    [SerializeField] private TextMeshProUGUI upgradeDescription;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Price price;
    [SerializeField] private TextMeshProUGUI upgradeGainText;
    [SerializeField] private Button buyButton;
    private Upgrade upgrade;
    private bool bought = false;
    private ResourcesManager resourcesManager;

    private void Start()
    {
        resourcesManager = ResourcesManager.instance;
    }

    private void Update()
    {
        if (!bought && Time.frameCount % 6 == 0)
        {
            buyButton.interactable = resourcesManager.CheckIfEnoughResource(price);
        }
    }

    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        StudioUpgradeGridObjectData data = (StudioUpgradeGridObjectData)gridObjectData;
        upgradeImage.sprite = data.UpgradeImage;
        upgradeTitle.text = data.UpgradeTitle;
        upgradeDescription.text = data.UpgradeDescription;
        price = data.Price;
        priceText.text = price.GetPriceText();
        upgrade = data.upgrade;
        upgradeGainText.text = UpgradeStringMaker.GetUpgradeString(data.upgrade.upgradeType, data.upgrade.upgradeValue);
    }

    public void BuyButton()
    {
        UnityEngine.Debug.Log("ya"); 
        if (resourcesManager.CheckIfEnoughResource(price))
        {
            resourcesManager.Buy(price);
            StatsManager.instance.UpgradePermanentStatsPercentage(upgrade);
            bought = true;
            buyButton.interactable = false;
        }
    }
}
