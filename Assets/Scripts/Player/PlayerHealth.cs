using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Image healthBar;

    public override void TakeDamage(float damage)
    {
        if (health == 0)
        {
            return;
        }
        base.TakeDamage(damage);
        healthBar.fillAmount = health / maxHealth;
    }

}
