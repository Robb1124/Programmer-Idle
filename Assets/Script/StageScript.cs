using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{
    public static StageScript instance;
    
    [SerializeField] private TextMeshProUGUI nbrProject;
    [SerializeField] private TextMeshProUGUI nbrStage;
    [SerializeField] private Image imgBackground;   
    [SerializeField] private Sprite[] stageBackgrounds;


    public int currentNbrProject;
    [SerializeField]public int maxNbrProject;
    [SerializeField]public int currentNbrStage = 1;

    public bool NeedBoss;

    [SerializeField]private int spriteIndex = 0;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
        
        currentNbrStage = PlayerPrefs.GetInt("currentNbrStage", currentNbrStage);
        ProjectHolder.OnTaskDone += HandleTaskDone;
        ChangeBackgroundImage();
        RefreshText();
    }
    
    private void HandleTaskDone()
    {
        if (NeedBoss)
        {
            NeedBoss = false;
            StageChange();
        }
        else
        {
            currentNbrProject++;
            if (currentNbrProject == maxNbrProject)
            {
                NeedBoss = true;
            }
        }
        RefreshText();
    }

    private void RefreshText()
    {
        nbrProject.text = $"Task: {currentNbrProject} / {maxNbrProject}";
        nbrStage.text = $"Stage # {currentNbrStage}";
    }
    
    void StageChange()
    {
        currentNbrStage++;
        ChangeBackgroundImage();
        currentNbrProject = 0;
    }
    
    private void ChangeBackgroundImage()
    {
        imgBackground.sprite = stageBackgrounds[spriteIndex];
        spriteIndex++;
        if (spriteIndex == stageBackgrounds.Length)
            spriteIndex = 0;
    }

    private void OnDestroy()
    {
        ProjectHolder.OnTaskDone -= HandleTaskDone;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("currentNbrStage", currentNbrStage);
    }
}
