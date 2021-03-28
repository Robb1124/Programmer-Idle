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
    [SerializeField] private GameObject boughtPanel;
    private Upgrade upgrade;
    private ResourcesManager resourcesManager;

    private void Start()
    {
        resourcesManager = ResourcesManager.instance;
    }

    private void Update()
    {
        if (amountBought < 1 && Time.frameCount % 6 == 0)
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
        if (amountBought > 0)
        {
            OpenBoughtPanel();
            buyButton.interactable = false;
        }
        else
        {
            boughtPanel.SetActive(false);
        }
    }

    private void OpenBoughtPanel()
    {
        boughtPanel.SetActive(true);
    }

    public void BuyButton()
    {
        if (resourcesManager.CheckIfEnoughResource(price))
        {
            resourcesManager.Buy(price);
            StatsManager.instance.UpgradePermanentStatsPercentage(upgrade);
            amountBought++;
            OpenBoughtPanel();
            buyButton.interactable = false;
            ManualSave();
        }
    }
}
