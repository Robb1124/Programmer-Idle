using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IncrementalUpgrade
{
    [SerializeField] public UpgradeType upgradeType;
    
    [SerializeField] public int baseValue;
    [SerializeField]
    [Range(0.01f, 1.00f)]
    public float increasedByEachTime;
}
