using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project Data")]
public class ProjectData : ScriptableObject
{
    public Sprite projectSprite;
    public string projectName;

    public bool programming;
    public bool artistic;
    public bool sound;
    public bool gameDesign;

    public float ptsMultiplier = 1f;
    public float goldMultiplier = 1f;

}
