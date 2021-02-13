using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField] private TabInfo tabInfo;
    private SlidingPanel slidingPanel;
    
    private void Start()
    {
        slidingPanel = SlidingPanel.instance;
    }

    public void ToggleSlidingPanel()
    {
        slidingPanel.TogglePanel(tabInfo);
    }
}

[System.Serializable]
public class TabInfo
{
    public string TabHeaderText;
    public TabsType TabType;
    public Sprite headerSprite;
}