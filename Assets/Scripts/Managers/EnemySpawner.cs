using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemiesObjectPool enemyPool;
    private GameManager gameManager;

    [SerializeField] private float spawnCooldownSeconds;
    [SerializeField] private float spawnRandomOffset;
    [SerializeField] private int eliteEnemyFrequency;

    [SerializeField] private float spawnDifficultyMultiplier;

    private float timeSinceSpawn;
    private float currentCooldownSecons;
    private int currentEliteEnemyFrequency;

    private bool isEliteSpawned = false;


    private void Start()
    {
        currentEliteEnemyFrequency = eliteEnemyFrequency;
        enemyPool = EnemiesObjectPool.Instance;
        gameManager = GameManager.Instance;
        DetermineCooldownSeconds();
    }

    private void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= currentCooldownSecons)
        {
            SpawnEnemy();
            timeSinceSpawn = 0;
            DetermineCooldownSeconds();
        }
    }

    private void DetermineCooldownSeconds()
    {
        float spawnOffset = Random.Range(-spawnRandomOffset, spawnRandomOffset);
        currentCooldownSecons = spawnCooldownSeconds + spawnOffset;
    }

    private void SpawnEnemy()
    {
        if (!isEliteSpawned && gameManager.Killcounter >= currentEliteEnemyFrequency)
        {
            isEliteSpawned = true;
        }
        GameObject enemy = enemyPool.GetEnemy(isEliteSpawned);
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
        if (isEliteSpawned)
        {
            isEliteSpawned = false;
            currentEliteEnemyFrequency += eliteEnemyFrequency;
            spawnCooldownSeconds *= spawnDifficultyMultiplier;
        }
    }
}
