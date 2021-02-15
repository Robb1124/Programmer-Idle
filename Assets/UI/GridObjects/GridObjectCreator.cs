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

    
    private List<GridObjectEntry> heroGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> studioGridObjects = new List<GridObjectEntry>();
    private List<GridObjectEntry> crewGridObjects = new List<GridObjectEntry>();

    private GameObject titleGridObjectPrefab;
    private GameObject heroUpgradeGridObjectPrefab;
    private GameObject studioUpgradeGridObjectPrefab;

    private Dictionary<Type, GameObject> GridObjectTypeToGameObject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            Destroy(this);

        titleGridObjectPrefab = Resources.Load<GameObject>("TitleGridObject");
        heroUpgradeGridObjectPrefab = Resources.Load<GameObject>("HeroUpgradeGridObject");
        studioUpgradeGridObjectPrefab =  Resources.Load<GameObject>("StudioUpgradeGridObject");

        GridObjectTypeToGameObject = new Dictionary<Type, GameObject>
        {
            {typeof(TitleGridObjectData), titleGridObjectPrefab},
            {typeof(HeroUpgradeGridObjectData), heroUpgradeGridObjectPrefab},
            {typeof(StudioUpgradeGridObjectData), studioUpgradeGridObjectPrefab}
        };
    }

    private void Start()
    {
        foreach (var heroGridObjectData in heroGridObjectsData)
        {
            GameObject newGridObject =
                Instantiate(GridObjectTypeToGameObject[heroGridObjectData.GetType()], gridTransform);
            newGridObject.GetComponent<GridObject>().LoadObjectData(heroGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            heroGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var studioGridObjectData in studioGridObjectsData)
        {
            GameObject newGridObject =
                Instantiate(GridObjectTypeToGameObject[studioGridObjectData.GetType()], gridTransform);
            newGridObject.GetComponent<GridObject>().LoadObjectData(studioGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            studioGridObjects.Add(newEntry);
            newGridObject.SetActive(false);
        }
        foreach (var crewGridObjectData in crewGridObjectsData)
        {
            GameObject newGridObject =
                Instantiate(GridObjectTypeToGameObject[crewGridObjectData.GetType()], gridTransform);
            newGridObject.GetComponent<GridObject>().LoadObjectData(crewGridObjectData);
            GridObjectEntry newEntry = new GridObjectEntry(newGridObject); //add gridobjectrequirements later
            crewGridObjects.Add(newEntry);
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
            default:
                throw new ArgumentOutOfRangeException(nameof(tabType), tabType, null);
        }

        return null;
    }
}
