using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectHolder : MonoBehaviour
{
    [SerializeField] private float BASE_PTS = 200;
    [SerializeField] private float BASE_GOLD = 10;
    
    [SerializeField] private TextMeshProUGUI projectNameText;
    [SerializeField] private Image projectImage;
    [SerializeField] private GameObject programmingBarHolder;
    [SerializeField] private GameObject artisticBarHolder;
    [SerializeField] private GameObject soundBarHolder;
    [SerializeField] private GameObject gameDesignBarHolder;

    public int maxProgrammingPts;
    public float currentProgrammingPts;
    public int maxArtisticPts;
    public float currentArtisticPts;
    public int maxSoundPts;
    public float currentSoundPts;
    public int maxGameDesignPts;
    public float currentGameDesignPts;

    public bool programmingDone;
    public bool artisticDone;
    public bool soundDone;
    public bool gameDesignDone;

    private bool onGoingProject;
    private int currentGoldReward;
    private bool isGameJam = false;
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private ResourcesManager resourcesManager;
    
    private ProjectData currentProjectData;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 4 == 0 && onGoingProject)
        {
            CheckBars();
            if(AllBarsAreDone())
            {
                onGoingProject = false;
                resourcesManager.AddGold(currentGoldReward);
                if (isGameJam)
                    resourcesManager.GameJamDone();
                spawnerScript.RequestNewProject();
            }
        }
    }

    public void GetProjectData(ProjectData projectData, bool gameJam = false)
    {
        isGameJam = gameJam;
        currentProjectData = projectData;
        ResetAllCurrentsProduction();
        projectImage.sprite = currentProjectData.projectSprite;
        projectNameText.text = currentProjectData.projectName;
        
        float variation;
        if (currentProjectData.programming)
        {
            programmingDone = false;
            variation = UnityEngine.Random.Range(0.75f, 1.25f);
            programmingBarHolder.SetActive(true);
            maxProgrammingPts = Mathf.RoundToInt(BASE_PTS * variation * currentProjectData.ptsMultiplier);
        }
        else
        {
            programmingBarHolder.SetActive(false);
            maxProgrammingPts = 0;
        }
        
        if (currentProjectData.artistic)
        {
            artisticDone = false;
            variation = UnityEngine.Random.Range(0.75f, 1.25f);
            artisticBarHolder.SetActive(true);
            maxArtisticPts = Mathf.RoundToInt(BASE_PTS * variation * currentProjectData.ptsMultiplier);
        }
        else
        {
            artisticBarHolder.SetActive(false);
            maxArtisticPts = 0;
        }
        
        if (currentProjectData.sound)
        {
            soundDone = false;
            variation = UnityEngine.Random.Range(0.75f, 1.25f);
            soundBarHolder.SetActive(true);
            maxSoundPts = Mathf.RoundToInt(BASE_PTS * variation * currentProjectData.ptsMultiplier);
        }
        else
        {
            soundBarHolder.SetActive(false);
            maxSoundPts = 0;
        }
        
        if (currentProjectData.gameDesign)
        {
            gameDesignDone = false;
            variation = UnityEngine.Random.Range(0.75f, 1.25f);
            gameDesignBarHolder.SetActive(true);
            maxGameDesignPts = Mathf.RoundToInt(BASE_PTS * variation * currentProjectData.ptsMultiplier);
        }
        else
        {
            gameDesignBarHolder.SetActive(false);
            maxGameDesignPts = 0;
        }

        variation = UnityEngine.Random.Range(0.75f, 1.25f);
        currentGoldReward = Mathf.RoundToInt(BASE_GOLD * variation * currentProjectData.goldMultiplier);
        
        onGoingProject = true;
    }

    private void ResetAllCurrentsProduction()
    {
        currentArtisticPts = 0;
        currentProgrammingPts = 0;
        currentSoundPts = 0;
        currentGameDesignPts = 0;
    }

    private void CheckBars()
    {
        if (!programmingDone)
        {
            programmingDone = Mathf.RoundToInt(currentProgrammingPts) >= maxProgrammingPts;
        }

        if (!artisticDone)
        {
            artisticDone = Mathf.RoundToInt(currentArtisticPts) >= maxArtisticPts;
        }
        
        if (!soundDone)
        {
            soundDone = Mathf.RoundToInt(currentSoundPts) >= maxSoundPts;
        }
        
        if (!gameDesignDone)
        {
            gameDesignDone = Mathf.RoundToInt(currentGameDesignPts) >= maxGameDesignPts;
        }
    }

    private bool AllBarsAreDone()
    {
        return programmingDone && artisticDone &&
               soundDone && gameDesignDone;
    }

    public float GetTotalMaxProduction()
    {
        return maxProgrammingPts + maxArtisticPts + maxSoundPts + maxGameDesignPts;
    }

    public float GetTotalCurrentProduction()
    {
        return currentArtisticPts + currentProgrammingPts + currentSoundPts + currentGameDesignPts;
    }
}