using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _seconds;

    private GameObject[] _spawnPoints;
    private readonly bool _isActive = true;

    private void Start()
    {
        SpawnPoints parentSpawnPoint = FindObjectOfType<SpawnPoints>();

        _spawnPoints = new GameObject[parentSpawnPoint.transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = parentSpawnPoint.transform.GetChild(i).gameObject;
        }

        var spawnOnRandomPointRun = StartCoroutine(SpawnOnRandomPoint());
    }

    private IEnumerator SpawnOnRandomPoint()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_seconds);

        while (_isActive)
        {
            GameObject randomSpawnPoint = _spawnPoints[GetRandomSpawnPointIndex()];
            GameObject spawnPointEnemyType = randomSpawnPoint.GetComponent<SpawnPoint>().GetEnemyTemplate();
            Transform spawnPoint = randomSpawnPoint.transform;
            
            GameObject newEnemy = Instantiate(spawnPointEnemyType, new Vector3(spawnPoint.position.x, 0,
                spawnPoint.position.z), spawnPoint.rotation);

            yield return waitForSeconds;
        }
    }

    private int GetRandomSpawnPointIndex()
    {
        int minSpawnPointIndex = 0;
        int maxSpawnPointIndex = _spawnPoints.Length;

        return Random.Range(minSpawnPointIndex, maxSpawnPointIndex);
    }
    
}