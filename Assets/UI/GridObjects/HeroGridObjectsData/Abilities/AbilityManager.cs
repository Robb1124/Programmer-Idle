using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;

    [SerializeField] private GameObject ability0Holder;
    [SerializeField] private GameObject ability1Holder;
    [SerializeField] private GameObject ability2Holder;
    [SerializeField] private GameObject abilityTextHeader;
    
    [SerializeField] private AbilityButton ability0Button;
    [SerializeField] private AbilityButton ability1Button;
    [SerializeField] private AbilityButton ability2Button;

    private float goldMultiplier = 1;
    private float dpsMultiplier = 1;
    
    private bool ability0Unlocked;
    private bool ability1Unlocked;
    private bool ability2Unlocked;
    
    private bool ability0OnCooldown;
    private bool ability1OnCooldown;
    private bool ability2OnCooldown;

    private bool disabled0 = true;
    private bool disabled1 = true;
    private bool disabled2 = true;

    private float cooldownRemainingAbility0;
    private float cooldownRemainingAbility1;
    private float cooldownRemainingAbility2;

    public float GoldMultiplier => goldMultiplier;

    public float DpsMultiplier => dpsMultiplier;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (ability0OnCooldown)
        {
            cooldownRemainingAbility0 -= Time.deltaTime;
            if (cooldownRemainingAbility0 <= 0)
            {
                ability0OnCooldown = false;
                ability0Button.DeactivateCooldownPanel();
            }
            else if (!disabled0 && cooldownRemainingAbility0 <= 60)
            {
                DisableAbility(0);
            }
        }
        if (ability1OnCooldown)
        {
            cooldownRemainingAbility1 -= Time.deltaTime;
            if (cooldownRemainingAbility1 <= 0)
            {
                ability1OnCooldown = false;
                ability1Button.DeactivateCooldownPanel();
            }
            else if (!disabled1 && cooldownRemainingAbility1 <= 60)
            {
                DisableAbility(1);
            }
        }
        if (ability2OnCooldown)
        {
            cooldownRemainingAbility2 -= Time.deltaTime;
            if (cooldownRemainingAbility2 <= 0)
            {
                ability2OnCooldown = false;
                ability2Button.DeactivateCooldownPanel();
            }
            else if (!disabled2 && cooldownRemainingAbility2 <= 60)
            {
                DisableAbility(2);
            }
        }
        
    }

    public void UnlockAbility(int abilityIndex)
    {
        switch (abilityIndex)
        {
            case 0:
                if (ability0Unlocked) return;
                abilityTextHeader.SetActive(true);
                ability0Holder.SetActive(true);
                break;
            case 1:
                if (ability1Unlocked) return;
                abilityTextHeader.SetActive(true);
                ability1Holder.SetActive(true);
                break;
            case 2:
                if (ability2Unlocked) return;
                abilityTextHeader.SetActive(true);
                ability2Holder.SetActive(true);
                break;
        }
    }

    public void CastAbility(int abilityIndex)
    {
        switch (abilityIndex)
        {
            case 0:
                if (ability0OnCooldown) return;
                ability0OnCooldown = true;
                cooldownRemainingAbility0 = 90;
                disabled0 = false;
                ability0Button.ActivateGoldenPanel();
                StartProd.instance.ActivateAllTapsAbility();
                break;
            case 1:
                if (ability1OnCooldown) return;
                ability1OnCooldown = true;
                cooldownRemainingAbility1 = 90;
                disabled1 = false;
                ability1Button.ActivateGoldenPanel();
                goldMultiplier = 3f;
                break;
            case 2:
                if (ability2OnCooldown) return;
                ability2OnCooldown = true;
                cooldownRemainingAbility2 = 90;
                disabled2 = false;
                ability2Button.ActivateGoldenPanel();
                dpsMultiplier = 2f;
                StatsManager.instance.Invoke_StatsChanged();
                break;
        }
    }

    public void DisableAbility(int abilityIndex)
    {
        switch (abilityIndex)
        {
            case 0:
                disabled0 = true;
                ability0Button.ActivateCooldownPanel();
                StartProd.instance.DeactivateAllTapsAbility();
                //remove ability thing
                break;
            case 1:
                disabled1 = true;
                ability1Button.ActivateCooldownPanel();
                goldMultiplier = 1f;
                break;
            case 2:
                disabled2 = true;
                ability2Button.ActivateCooldownPanel();
                dpsMultiplier = 1f;
                StatsManager.instance.Invoke_StatsChanged();
                break;
        }
    }
}
