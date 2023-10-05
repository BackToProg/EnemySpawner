using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    
    private readonly bool _isActive = true;

    private void Start()
    {
        var spawnOnRandomPointRun = StartCoroutine(SpawnOnRandomPoint());
    }

    private IEnumerator SpawnOnRandomPoint()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_seconds);

        while (_isActive)
        {
            SpawnPoint randomSpawnPoint = _spawnPoints[GetRandomSpawnPointIndex()];
            Enemy spawnPointEnemyType = randomSpawnPoint.GetEnemyTemplate();
            Transform spawnPoint = randomSpawnPoint.transform;
            
            Enemy newEnemy = Instantiate(spawnPointEnemyType, new Vector3(spawnPoint.position.x, 1,
                spawnPoint.position.z), spawnPoint.rotation);

            newEnemy.Target = randomSpawnPoint.GetTarget().transform;

            yield return waitForSeconds;
        }
    }

    private int GetRandomSpawnPointIndex()
    {
        int minSpawnPointIndex = 0;

        return Random.Range(minSpawnPointIndex, _spawnPoints.Length);
    }
    
}