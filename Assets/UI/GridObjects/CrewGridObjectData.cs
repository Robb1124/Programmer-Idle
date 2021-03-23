using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid Object/Crew Grid Object")]
public class CrewGridObjectData : GridObjectData
{
    [SerializeField] public Sprite UpgradeImage;
    [SerializeField] public string UpgradeTitle;
    [SerializeField] public string UpgradeDescription;
    [SerializeField] public IncrementalUpgrade incrementalUpgrade;
    [SerializeField] public Price Price;
    [SerializeField] public bool StatsToShow;
    [SerializeField] public StatsQuery statsQuery;
}
