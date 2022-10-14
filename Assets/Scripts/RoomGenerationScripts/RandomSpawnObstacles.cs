using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class RandomSpawnObstacles : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> obstacleType;
    public GameObject obstacle;
    public int ObstaclesCount;
    private void Start()
    {
        SpawnObstaclesGo();
    }
    public void SpawnObstaclesGo()
    {
        for (int i = 0; i < ObstaclesCount; i++)
        {
            int randomPoint = Random.Range(0, spawnPoints.Count);
            GameObject obstaclesgenerate = ObstaclesSpawn(spawnPoints[randomPoint]);
            spawnPoints.RemoveAt(randomPoint);
        }
        Destroy(obstacle);
        Destroy(this);
    }
    private GameObject ObstaclesSpawn(Transform spawnPoint)
    {
        var enemy = obstacleType[Random.Range(0, obstacleType.Count)];
        return Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
