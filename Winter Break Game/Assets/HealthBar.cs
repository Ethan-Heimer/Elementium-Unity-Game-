using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /*
    [SerializeField] Character character;
    [SerializeField] protected Slider healthBar;

    [SerializeField] protected Gradient healthBarColor;

    protected Image fill; 

    public virtual void Start()
    {
        character = character == null ? transform.root.GetComponent<Character>() : character; 
        healthBar = healthBar == null ? GetComponent<Slider>() : healthBar;

        fill = healthBar.fillRect.GetComponent<Image>(); 

        UpdateHealthBar();

        character.damageManager.OnDamaged += UpdateHealthBar;
        
    }

    private void OnDisable()
    {
        character.damageManager.OnDamaged -= UpdateHealthBar;
    }

    protected void UpdateHealthBar()
    {
        float percent = getHealthPercent();

        healthBar.value = percent;
        fill.color = healthBarColor.Evaluate(percent);
    }

    public virtual float getHealthPercent() => character.statsHandler.GetStat("Health") / character.statsHandler.GetStat("Starting Health"); 
    */

}
