using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityGridObject : GridObject
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Price price;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject boughtPanel;
    [SerializeField] private int abilityId;
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
        priceText.text = price.GetPriceText();
        if (amountBought > 0)
        {
            OpenBoughtPanel();
            buyButton.interactable = false;
            AbilityManager.instance.UnlockAbility(abilityId);
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
            amountBought++;
            OpenBoughtPanel();
            buyButton.interactable = false;
            AbilityManager.instance.UnlockAbility(abilityId);
            ManualSave();
        }
    }
}
