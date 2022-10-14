using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{   public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> enemyType = new List<GameObject>();
    public GameObject spawnPointsContainer;
    public int EnemyCount;
    private void Start()
    {
        SpawnEnemyGo();
    }

    public void SpawnEnemyGo()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            int randomPoint = Random.Range(0, spawnPoints.Count);
            GameObject enemygenerate = EnemySpawn(spawnPoints[randomPoint]);
            spawnPoints.RemoveAt(randomPoint);
        }
        Destroy(spawnPointsContainer);
        Destroy(this);
    }
    private GameObject EnemySpawn(Transform spawnPoint)
    {
        var enemy = enemyType[Random.Range(0, enemyType.Count)];
        return Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
