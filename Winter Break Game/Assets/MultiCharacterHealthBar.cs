using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCharacterHealthBar : HealthBar
{
    public List<Character> characters = new List<Character>();

    float startingHealth;
    float currentHealth; 

    public override void Start()
    {
        fill = healthBar.fillRect.GetComponent<Image>();

        foreach(Character o in characters)
        {
            startingHealth += o.statsHandler.GetStat("Starting Health");

            o.damageManager.OnDamaged += UpdateHealthBar;
            o.damageManager.OnDeath += removeCharacterFromList;
            o.damageManager.OnDeath += checkDisableHealthBar;
        }

        currentHealth = startingHealth; 

        UpdateHealthBar();
    }

    public void OnDisable()
    {
       
    }

    public override float getHealthPercent()
    {
        currentHealth = 0; 
        foreach (Character o in characters)
        {
            currentHealth += o.statsHandler.GetStat("Health");
        }

        return currentHealth / startingHealth; 
    }

    void removeCharacterFromList()
    {
        foreach (Character o in characters)
        {
            if (o.statsHandler.GetStat("Health") <= 0)
            {
                characters.Remove(o);
                break;
            }
        }
    }

    void checkDisableHealthBar()
    {
        if (characters.Count <= 0) gameObject.SetActive(false);
    }
}
