using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Price
{
    public int amount;
    public CurrencyType currencyType;

    public string GetPriceText()
    {
        string type = "";
        switch(currencyType)
        {
            case CurrencyType.Gold:
                type = "<sprite index=0>";
                break;
            case CurrencyType.Gems:
                type = "<sprite index=1>";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return $"{amount} {type}";
    }
}
