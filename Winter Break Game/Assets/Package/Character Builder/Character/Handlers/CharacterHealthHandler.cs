using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthHandler : MonoBehaviour, IHealthHandler
{
    IOnCharacterHealthChanged[] onCharacterHealthChangeds;
    IOnCharacterHealthAdded[] onCharacterHealthAdded;
    IOnCharacterHealthSubtracted[] onCharacterHealthSubtracted;
    IOnCharacterHealthSet[] onCharacterHealthSets;

    IOnCharacterKilled[] onCharacterKilleds;

    [SerializeField] float maxHealth;

    float _health;
    float health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);
            CheckForKill();
        }
    }

    public void Awake()
    {
        health = maxHealth;

        onCharacterHealthChangeds = GetComponents<IOnCharacterHealthChanged>();
        onCharacterHealthAdded = GetComponents<IOnCharacterHealthAdded>();
        onCharacterHealthSubtracted = GetComponents<IOnCharacterHealthSubtracted>();
        onCharacterHealthSets = GetComponents<IOnCharacterHealthSet>();
        onCharacterKilleds = GetComponents<IOnCharacterKilled>();
    }

    public void AddHealth(float value)
    {
        health += value;

        ExecuteOnHealthChanged();
        foreach (IOnCharacterHealthAdded o in onCharacterHealthAdded)
        {
            o.OnCharacterHealthAdded(health);
        }
    }

    public void SetHealth(float value)
    {
        health = value;

        ExecuteOnHealthChanged();
        foreach (IOnCharacterHealthSet o in onCharacterHealthSets)
        {
            o.OnCharacterHealthSet(health);
        }
    }
    public void SubtractHealth(float value)
    {
        health -= value;

        ExecuteOnHealthChanged();
        foreach (IOnCharacterHealthSubtracted o in onCharacterHealthSubtracted)
        {
            o.OnCharacterHealthSubtracted(health);
        }
    }
    private void ExecuteOnHealthChanged()
    {
        foreach (IOnCharacterHealthChanged o in onCharacterHealthChangeds)
        {
            o.OnCharacterHealthChanged(health);
        }
    }

    void CheckForKill()
    {
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill() => StartCoroutine(e_Kill());

    IEnumerator e_Kill()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (IOnCharacterKilled o in onCharacterKilleds)
        {
            o.OnCharacterKilled();
        }

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    public float GetHealth() => health;
}
