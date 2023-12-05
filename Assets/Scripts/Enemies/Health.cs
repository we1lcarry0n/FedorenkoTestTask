using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;

    protected float health;
    public event EventHandler OnDieEvent;

    private void OnEnable()
    {
        ResetHealth();
    }

    protected virtual void Start()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            Die();
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    protected void Die()
    {
        OnDieEvent?.Invoke(this, EventArgs.Empty);
    }
}
