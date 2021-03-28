using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager instance;
    [SerializeField] private int percentageBonusPerStage = 3;
    [SerializeField] private GameObject prestigePanelHolder;
    [SerializeField] private TextMeshProUGUI lastStageReachedText;
    [SerializeField] private TextMeshProUGUI oldBonusText;
    [SerializeField] private TextMeshProUGUI newBonusText;
    private bool opened = true;
    public int PrestigeBonus;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
        PrestigeBonus = PlayerPrefs.GetInt("PrestigeBonus", 0);
    }
    
    public void Prestige()
    {
        PrestigeBonus = Mathf.Max(StageScript.instance.currentNbrStage * percentageBonusPerStage, PrestigeBonus);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PrestigeBonus", PrestigeBonus);
        PlayerPrefs.SetInt("playerGems", ResourcesManager.instance.PlayerGems);
        float percentageBonus = (float)PrestigeBonus / 100;
        PlayerPrefs.SetFloat("studioProductivity", 1 + percentageBonus);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (opened)
        {
            int currentStage = StageScript.instance.currentNbrStage;
            lastStageReachedText.text = $"Last stage reached : {currentStage}";
            newBonusText.text = $"New Bonus : {Mathf.Max(currentStage * percentageBonusPerStage, PrestigeBonus)}%";
        }
    }

    public void OpenPrestigePanel()
    {
        opened = true;
        oldBonusText.text = $"Old Bonus : {PrestigeBonus}%";
        prestigePanelHolder.SetActive(true);
    }
}
