using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;

    private Animator animator;
    private Collider2D enemyCollider;
    private Health health;
    private PlayerHealth player;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDamage;

    private bool isAlive;
    private float moveDirection;

    private void OnEnable()
    {
        enemyCollider.enabled = true;
        health.ResetHealth();
        isAlive = true;
        animator.SetBool("dead", false);
        moveDirection = Mathf.Sign(transform.position.x - player.transform.position.x);
        spriteRenderer.flipX = moveDirection > 0 ? true : false;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        health = GetComponent<Health>();
        health.OnDieEvent += Death;
        player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }
    }

    private void Move()
    {

    }

    private void Attack()
    {

    }

    private void Death(object sender, System.EventArgs e)
    {
        isAlive = false;
        enemyCollider.enabled = false;
        deathParticles.Play();
        animator.SetBool("dead", true);
        StartCoroutine(ReturnToPoolRoutine());
    }

    private IEnumerator ReturnToPoolRoutine()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
