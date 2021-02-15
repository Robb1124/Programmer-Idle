using System.Collections;
using System.Collections.Generic;
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
    
    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        StudioUpgradeGridObjectData data = (StudioUpgradeGridObjectData)gridObjectData;
        upgradeImage.sprite = data.UpgradeImage;
        upgradeTitle.text = data.UpgradeTitle;
        upgradeDescription.text = data.UpgradeDescription;
        price = data.Price;
        priceText.text = price.GetPriceText();
        
        upgradeGainText.text = UpgradeStringMaker.GetUpgradeString(data.upgrade.upgradeType, data.upgrade.upgradeValue);
    }
}
