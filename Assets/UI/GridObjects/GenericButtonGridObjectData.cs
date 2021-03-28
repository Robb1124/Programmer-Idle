using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid Object/Settings Object")]
public class GenericButtonGridObjectData : GridObjectData
{
    [SerializeField] public GameObject prefabToCreate;
}
