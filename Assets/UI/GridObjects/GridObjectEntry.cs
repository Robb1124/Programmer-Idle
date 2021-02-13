using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectEntry
{
    public GameObject gridObject;
    public List<GridObjectRequirement> gridObjectRequirements;
    public bool unlocked;

    public GridObjectEntry(GameObject gridObject, List<GridObjectRequirement> requirements = null)
    {
        this.gridObject = gridObject;
        gridObjectRequirements = requirements;
    }
}
