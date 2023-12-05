using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLife;
    [SerializeField] private int projectileDamageAmount;

    [SerializeField] private TrailRenderer projectileTrail;
    [SerializeField] private Rigidbody2D rb2d;

    private void OnEnable()
    {
        projectileTrail.Clear();
        SetTarget(transform.position.x);
    }

    private void SetTarget(float xPosition)
    {
        rb2d.velocity = Vector3.right * Mathf.Sign(xPosition) * projectileSpeed;
        StartCoroutine(ProjectileLifeRoutine());
    }

    private IEnumerator ProjectileLifeRoutine()
    {
        yield return new WaitForSeconds(projectileLife);
        rb2d.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
