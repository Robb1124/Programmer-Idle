using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeStringMaker
{
    public static string GetUpgradeString(UpgradeType upgradeType, float upgradeValue)
    {
        upgradeValue *= 100f;
        switch (upgradeType)
        {
            case UpgradeType.StudioProductivity:
                return $"Increases Studio Productivity by {upgradeValue}%.";
            case UpgradeType.ProgrammingTap:
                return $"Increases Programming Tap by {upgradeValue}%.";
            case UpgradeType.ArtisticTap:
                return $"Increases Artistic Tap by {upgradeValue}%.";
            case UpgradeType.SoundTap:
                return $"Increases Sound Tap by {upgradeValue}%.";
            case UpgradeType.GameDesignTap:
                return $"Increases Game Design Tap by {upgradeValue}%.";
            case UpgradeType.AllTaps:
                return $"Increases All Taps by {upgradeValue}%.";
            case UpgradeType.ProgrammingDPS:
                return $"Increases Programming Productivity by {upgradeValue}%.";
            case UpgradeType.ArtisticDPS:
                return $"Increases Artistic Productivity by {upgradeValue}%.";
            case UpgradeType.SoundDPS:
                return $"Increases Sound Productivity by {upgradeValue}%.";
            case UpgradeType.GameDesignDPS:
                return $"Increases Game Design Productivity by {upgradeValue}%.";
            default:
                throw new ArgumentOutOfRangeException(nameof(upgradeType), upgradeType, null);
        }
    }
}
