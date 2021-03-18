using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public UpgradeType upgradeType;
    [Range(0.01f, 4.00f)]
    public float upgradeValue;
}
