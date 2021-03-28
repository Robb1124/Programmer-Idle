using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlidingPanel : MonoBehaviour
{
    public static SlidingPanel instance;
    [SerializeField] private TextMeshProUGUI panelHeaderText;
    [SerializeField] private Image panelHeaderImage;
    [SerializeField] private Vector3 closedPos;
    [SerializeField] private Vector3 openPos;
    private TabsType currentOpenTabType;
    private TabInfo currentTabInfo;
    private bool panelIsOpen;
    private GridObjectCreator gridObjectCreator;
    
    public bool PanelIsOpen => panelIsOpen;

    [SerializeField] private float slidingTimer = 0.5f;
    private float currentSlidingTimer = 0;
    private bool isSliding;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        gridObjectCreator = GridObjectCreator.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSliding)
        {
            currentSlidingTimer -= Time.deltaTime;
            if (currentSlidingTimer <= 0)
            {
                currentSlidingTimer = 0;
                isSliding = false;
            }
        }
    }

    public void TogglePanel(TabInfo tabInfo)
    {
        currentTabInfo = tabInfo;
        if (currentOpenTabType == currentTabInfo.TabType && panelIsOpen)
        {
            ClosePanel();
        }
        else
        {
            if(currentOpenTabType != TabsType.None)
                DeactivateListObjects(gridObjectCreator.GetGridObjectList(currentOpenTabType));
            currentOpenTabType = currentTabInfo.TabType;
            ActivateListObjects(gridObjectCreator.GetGridObjectList(currentOpenTabType));

            //load data
            panelHeaderText.text = currentTabInfo.TabHeaderText;
            panelHeaderImage.sprite = currentTabInfo.headerSprite;
            OpenPanel();
        }
    }
    
    public void OpenPanel()
    {
        if (panelIsOpen) return;
        LeanTween.cancel(gameObject);
        currentSlidingTimer = slidingTimer - currentSlidingTimer;
        LeanTween.moveLocalY(gameObject, openPos.y, currentSlidingTimer);
        isSliding = true;
        panelIsOpen = true;
    }

    public void ClosePanel()
    {
        if (!panelIsOpen) return;
        LeanTween.cancel(gameObject);
        currentSlidingTimer = slidingTimer - currentSlidingTimer;
        LeanTween.moveLocalY(gameObject, closedPos.y, currentSlidingTimer).setOnComplete(() =>
        {
            DeactivateListObjects(gridObjectCreator.GetGridObjectList(currentOpenTabType));
            currentOpenTabType = TabsType.None;
        });
        isSliding = true;
        panelIsOpen = false;
    }

    private void DeactivateListObjects(List<GridObjectEntry> objectsToDeactivate)
    {
        foreach (var objectEntry in objectsToDeactivate)
        {
            objectEntry.gridObject.SetActive(false);
        }
    }
    
    private void ActivateListObjects(List<GridObjectEntry> objectsToActivate)
    {
        foreach (var objectEntry in objectsToActivate)
        {
            objectEntry.gridObject.SetActive(true);
        }
    }
}
