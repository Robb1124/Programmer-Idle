using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid Object/Hero Upgrade Object")]
public class HeroUpgradeGridObjectData : GridObjectData
{
    [SerializeField] public Sprite UpgradeImage;
    [SerializeField] public string UpgradeTitle;
    [SerializeField] public string UpgradeDescription;
    [SerializeField] public Price Price;
    [SerializeField] public bool StatsToShow;
    [SerializeField] public StatsQuery statsQuery;
}
