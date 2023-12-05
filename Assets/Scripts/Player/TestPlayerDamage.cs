using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerDamage : MonoBehaviour
{
    private PlayerHealth health;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            health.TakeDamage(1);
        }
    }
}
