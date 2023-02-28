using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Slider healthBar;

    [SerializeField] Gradient healthBarColor;

    Image fill; 

    private void Start()
    {
        character = character == null ? transform.root.GetComponent<Character>() : character; 
        healthBar = healthBar == null ? GetComponent<Slider>() : healthBar;

        fill = healthBar.fillRect.GetComponent<Image>(); 

        UpdateHealthBar();

        character.eventManager.OnDamaged.AddListener(UpdateHealthBar);
        
    }

    private void OnDisable()
    {
        character.eventManager.OnDamaged.RemoveListener(UpdateHealthBar);
    }

    void UpdateHealthBar()
    {
        float percent = getHealthPercent();

        healthBar.value = percent;
        fill.color = healthBarColor.Evaluate(percent);
    }

    float getHealthPercent() => character.statsHandler.GetStat("Health") / character.statsHandler.GetStat("Starting Health"); 

}
