using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    public int upgradeID;
    public int amountBought;
    public abstract void LoadObjectData(GridObjectData gridObjectData);

    public void InsertIDAndBoughtAmount(int ID)
    {
        upgradeID = ID;
        CheckIfSaveExists();
    }

    protected void CheckIfSaveExists()
    {
        amountBought = PlayerPrefs.GetInt($"{upgradeID}", 0);
    }

    protected void OnApplicationQuit()
    {
        if(upgradeID > 0)
            PlayerPrefs.SetInt($"{upgradeID}", amountBought);
    }

    protected void ManualSave()
    {
        PlayerPrefs.SetInt($"{upgradeID}", amountBought);
    }
}
