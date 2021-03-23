using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nbrProject;
    [SerializeField] private TextMeshProUGUI nbrStage;
    [SerializeField] private Image imgBackground;   

    public int currentNbrProject;
    public int maxNbrProject;
    public int currentNbrStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nbrProject.text = $"Task: {currentNbrProject} / {maxNbrProject}";
        nbrStage.text = $"Stage # {currentNbrStage}";
        StageChange();
    }

    void StageChange()
    {
        /* if( un project is done ) { currentNbrProject++; }
          */
        if(currentNbrProject == maxNbrProject)
        {
            currentNbrStage++;
            if (currentNbrStage == 2)
            {
                currentNbrProject = 0;
                maxNbrProject++;
                // Change la difficultés des mobs
                // Change les stats du joueur?
                // Change BackgroundImage 
            }
        }
    }
}
