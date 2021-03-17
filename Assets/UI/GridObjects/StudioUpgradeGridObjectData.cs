using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid Object/Studio Upgrade Object")]
public class StudioUpgradeGridObjectData : GridObjectData
{
    [SerializeField] public Sprite UpgradeImage;
    [SerializeField] public string UpgradeTitle;
    [SerializeField] public string UpgradeDescription;
    [SerializeField] public Price Price;
    [SerializeField] public Upgrade upgrade;
}
