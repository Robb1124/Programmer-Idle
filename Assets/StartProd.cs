using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartProd : MonoBehaviour
{
    public Text txtProduction;
    public Image imgProduction;
    public Enemy enemy;

   
    void Start()
    {
        
        
    }

    
    void Update()
    {
        if (enemy is null)
            enemy = FindObjectOfType<Enemy>();
        else
        {
            AutoClick(Time.deltaTime);
            imgProduction.fillAmount = enemy.currentHealth / enemy.maxHealth;
            txtProduction.text = enemy.currentHealth.ToString() + " / " + enemy.maxHealth.ToString();
        }
    }

    public void AutoClick(float deltaTime)
    {       
        enemy.currentHealth += 10 * deltaTime;
    }

    public void ClickManual()
    {
        if(enemy.currentHealth < enemy.maxHealth)
        {
            enemy.currentHealth += 1;
        }
    }

    
}
