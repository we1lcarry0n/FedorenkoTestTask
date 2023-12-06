using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesObjectPool : MonoBehaviour
{
    public static EnemiesObjectPool Instance;
    private List<GameObject> poolingList;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] eliteEnemyPrefabs;
    [SerializeField] private int enemiesToInstantiate;

    private void Awake()
    {
        Instance = this;

        poolingList = new List<GameObject>();
        GameObject enemy;

        for (int i = 0; i < enemiesToInstantiate; i++)
        {
            enemy = Instantiate(enemyPrefabs[i % 2 == 0 ? 0 : 1], transform.position, Quaternion.identity, this.transform);
            enemy.SetActive(false);
            poolingList.Add(enemy);
        }

        for (int i = 0; i < 2; i++)
        {
            enemy = Instantiate(eliteEnemyPrefabs[i], transform.position, Quaternion.identity, this.transform);
            enemy.SetActive(false);
            poolingList.Add(enemy);
        }
    }

    public GameObject GetEnemy(bool isEtite)
    {
        if (!isEtite)
        {
            foreach (GameObject enemy in poolingList)
            {
                if (!enemy.activeInHierarchy)
                {
                    return enemy;
                }
            }
            return null;
        }
        else
        {
            if (!poolingList[enemiesToInstantiate].activeInHierarchy)
            {
                return poolingList[enemiesToInstantiate];
            }
            else
            {
                return poolingList[enemiesToInstantiate+1];
            }
        }
    }

}
