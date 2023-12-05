using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private BulletObjectPool bulletPool;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float projectileOffsetMultiplier;
    [SerializeField] private float shootTimerOffset;
    [SerializeField] private float shootCooldown;

    private float shotTimePast = 0;

    private void Start()
    {
        bulletPool = BulletObjectPool.Instance;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shotTimePast = shootCooldown;
    }

    private void Update()
    {
        shotTimePast += Time.deltaTime;
        if (shotTimePast < shootCooldown )
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot(Mathf.Sign(Input.GetAxis("Horizontal")));
        }
    }

    public void Shoot(float direction)
    {
        shotTimePast = 0;
        StartCoroutine(SetProjectileRoutine(direction));
        UpdateVisual(direction);
    }

    private void UpdateVisual(float direction)
    {
        spriteRenderer.flipX = direction > 0 ? false : true;
        animator.SetTrigger("shoot");
    }

    private IEnumerator SetProjectileRoutine(float direction)
    {
        yield return new WaitForSeconds(shootTimerOffset);
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = transform.position + Vector3.right * direction * projectileOffsetMultiplier;
        bullet.SetActive(true);
    }

}
