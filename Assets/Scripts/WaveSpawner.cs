using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int totalSpawnEnemies;       
        public int numberOfRandomSpawnPoint;  
        public float delayStart;             
        public float spawnInterval;         
        public int numberOfPowerUp;         
    }

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public Transform[] allSpawnPoints;  
    public Wave[] waves;               

    void Start()
    {
        StartCoroutine(SpawnManagerRoutine());
    }

    IEnumerator SpawnManagerRoutine()
    {
        foreach (Wave currentWave in waves)
        {
            
            List<Transform> activeSpawnPoints = GetRandomSpawnPoints(currentWave.numberOfRandomSpawnPoint);

            for (int i = 0; i < currentWave.numberOfPowerUp; i++)
            {
                SpawnObject(powerUpPrefab, activeSpawnPoints);
            }

            yield return new WaitForSeconds(currentWave.delayStart);

            for (int i = 0; i < currentWave.totalSpawnEnemies; i++)
            {
                SpawnObject(enemyPrefab, activeSpawnPoints);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            yield return new WaitForSeconds(5f);

            Debug.Log("Wave Finished!");
        }
    }
    List<Transform> GetRandomSpawnPoints(int count)
    {
        List<Transform> selectedPoints = new List<Transform>();
        List<Transform> pool = new List<Transform>(allSpawnPoints);

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            selectedPoints.Add(pool[index]);
            pool.RemoveAt(index); 
        }
        return selectedPoints;
    }

    void SpawnObject(GameObject prefab, List<Transform> points)
    {
        int index = Random.Range(0, points.Count);
        Instantiate(prefab, points[index].position, Quaternion.identity);
    }
}
