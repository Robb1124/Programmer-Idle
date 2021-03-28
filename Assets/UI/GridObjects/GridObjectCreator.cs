using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GridObjectCreator : MonoBehaviour
{
    public static GridObjectCreator instance;
    [SerializeField] private Transform gridTransform;
    [SerializeField] private List<GridObjectData> heroGridObjectsData = new List<GridObjectData>();
    [SerializeField] private List<GridObjectData> studioGridObjectsData = new List<GridObjectData>();
    [SerializeField] private List<GridObjectData> crewGridObjectsData = new List<GridObjectData>();
    [SerializeField] private List<GridObjectData> settingsGridObjectsData = new List<GridObjectData>();
    [SerializeField] private List<GridObjectData> prestigeGridObjectsData = new List<GridObjectData>();


    
    private List<GridObjectEntry> heroGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> studioGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> crewGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> settingsGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> prestigeGridObjects = new List<GridObjectEntry>();


    [SerializeField] private GameObject titleGridObjectPrefab;
    [SerializeField] private GameObject heroUpgradeGridObjectPrefab;
    [SerializeField] private GameObject studioUpgradeGridObjectPrefab;
    [SerializeField] private GameObject crewGridObjectPrefab;
    
    private Dictionary<Type, GameObject> GridObjectTypeToGameObject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            Destroy(this);

        GridObjectTypeToGameObject = new Dictionary<Type, GameObject>
        {
            {typeof(TitleGridObjectData), titleGridObjectPrefab},
            {typeof(HeroUpgradeGridObjectData), heroUpgradeGridObjectPrefab},
            {typeof(StudioUpgradeGridObjectData), studioUpgradeGridObjectPrefab},
            {typeof(CrewGridObjectData), crewGridObjectPrefab}
        };
    }

    private void Start()
    {
        foreach (var heroGridObjectData in heroGridObjectsData)
        {
            GameObject newGridObject;
            if (heroGridObjectData is AbilityGridobjectData abilityData)
            {
                newGridObject = Instantiate(abilityData.abilityPrefab, gridTransform);
            }
            else
            {
                newGridObject =
                    Instantiate(GridObjectTypeToGameObject[heroGridObjectData.GetType()], gridTransform);
            }
            
            GridObject gridComp = newGridObject.GetComponent<GridObject>();
            gridComp.InsertIDAndBoughtAmount(heroGridObjectData.UPGRADE_ID);
            gridComp.LoadObjectData(heroGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            heroGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var studioGridObjectData in studioGridObjectsData)
        {
            GameObject newGridObject =
                Instantiate(GridObjectTypeToGameObject[studioGridObjectData.GetType()], gridTransform);
            GridObject gridComp = newGridObject.GetComponent<GridObject>();
            gridComp.InsertIDAndBoughtAmount(studioGridObjectData.UPGRADE_ID);
            gridComp.LoadObjectData(studioGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            studioGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var crewGridObjectData in crewGridObjectsData)
        {
            GameObject newGridObject =
                Instantiate(GridObjectTypeToGameObject[crewGridObjectData.GetType()], gridTransform);
            GridObject gridComp = newGridObject.GetComponent<GridObject>();
            gridComp.InsertIDAndBoughtAmount(crewGridObjectData.UPGRADE_ID);
            gridComp.LoadObjectData(crewGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            crewGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var settingsData in settingsGridObjectsData)
        {
            GameObject newGridObject;
            if (settingsData is GenericButtonGridObjectData genericButtonData)
            {
                newGridObject = Instantiate(genericButtonData.prefabToCreate, gridTransform);
            }
            else
            {
                newGridObject = Instantiate(GridObjectTypeToGameObject[settingsData.GetType()], gridTransform);
                newGridObject.GetComponent<GridObject>().LoadObjectData(settingsData);
            }
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            settingsGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var prestigeData in prestigeGridObjectsData)
        {
            GameObject newGridObject;
            if (prestigeData is GenericButtonGridObjectData genericButtonData)
            {
                newGridObject = Instantiate(genericButtonData.prefabToCreate, gridTransform);
            }
            else
            {
                newGridObject = Instantiate(GridObjectTypeToGameObject[prestigeData.GetType()], gridTransform);
                newGridObject.GetComponent<GridObject>().LoadObjectData(prestigeData);
            }
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            prestigeGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
    }

    public List<GridObjectEntry> GetGridObjectList(TabsType tabType)
    {
        switch(tabType)
        {
            case TabsType.None:
                break;
            case TabsType.Hero:
                return heroGridObjects;
            case TabsType.Studio:
                return studioGridObjects;
            case TabsType.Crew:
                return crewGridObjects;
            case TabsType.Settings:
                return settingsGridObjects;
            case TabsType.Prestige:
                return prestigeGridObjects;
            default:
                throw new ArgumentOutOfRangeException(nameof(tabType), tabType, null);
        }

        return null;
    }
}
