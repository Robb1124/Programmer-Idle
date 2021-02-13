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
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Price price;
    [SerializeField] private TextMeshProUGUI statsText;
    private bool statsToShow;
    
    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        HeroUpgradeGridObjectData data = (HeroUpgradeGridObjectData) gridObjectData;
        upgradeImage.sprite = data.UpgradeImage;
        upgradeTitle.text = data.UpgradeTitle;
        upgradeDescription.text = data.UpgradeDescription;
        price = data.Price;
        priceText.text = price.GetPriceText();
        statsToShow = data.StatsToShow;
        if (statsToShow)
        {
            statsText.gameObject.SetActive(true);
            statsText.text = StatsManager.instance.RequestStatsString(data.statsQuery);
        }
        else
            statsText.gameObject.SetActive(false);
    }
}
