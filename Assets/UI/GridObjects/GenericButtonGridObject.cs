using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericButtonGridObject : GridObject
{
    public void ClearAllSaveFiles()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Prestige()
    {
        PrestigeManager.instance.OpenPrestigePanel();
    }
    
    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        
    }
}
