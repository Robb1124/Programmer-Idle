using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject usedPanel;

    private Image panelImage;
    private bool onCooldown;
    private float totalSeconds = 60;
    private float currentSeconds = 0;
    private bool activated;
    private void Awake()
    {
        panelImage = usedPanel.GetComponent<Image>();
    }

    public void ActivateGoldenPanel()
    {
        activated = true;
        currentSeconds = 30;
        button.interactable = false;
        panelImage.fillAmount = 1;
        usedPanel.SetActive(true);
        panelImage.color = new Color32(255, 160, 0, 170);
    }

    public void ActivateCooldownPanel()
    {
        activated = false;
        panelImage.color = panelImage.color = new Color32(100, 100, 100, 170);
        currentSeconds = totalSeconds;
        onCooldown = true;
    }

    public void DeactivateCooldownPanel()
    {
        usedPanel.SetActive(false);
        button.interactable = true;
        onCooldown = false;
    }
    private void Update()
    {
        if (onCooldown)
        {
            currentSeconds -= Time.deltaTime;
            panelImage.fillAmount = currentSeconds / totalSeconds;
        }
        else if (activated)
        {
            currentSeconds -= Time.deltaTime;
            panelImage.fillAmount = currentSeconds / 30;
        }
    }
}
