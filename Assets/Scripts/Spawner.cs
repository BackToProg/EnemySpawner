using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private Enemy _template;

    private readonly List<Transform> _spawnPointsTransform = new List<Transform>();
    private readonly bool _isActive = true;

    private void Start()
    {
        SpawnPoints[] spawnPoints = FindObjectsOfType<SpawnPoints>();
        
        foreach (SpawnPoints spawnPoint in spawnPoints)
        {
            _spawnPointsTransform.Add(spawnPoint.transform);
        }

        var spawnOnRandomPointRun = StartCoroutine(SpawnOnRandomPoint());
    }

    private IEnumerator SpawnOnRandomPoint()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_seconds);

        while (_isActive)
        {
            Transform spawnPoint = _spawnPointsTransform[GetRandomSpawnPointIndex()];

            Instantiate(_template, new Vector3(spawnPoint.position.x, 0,
                spawnPoint.position.z), spawnPoint.rotation);

            yield return waitForSeconds;
        }
    }

    private int GetRandomSpawnPointIndex()
    {
        int minSpawnPointIndex = 0;
        int maxSpawnPointIndex = _spawnPointsTransform.Count;

        return Random.Range(minSpawnPointIndex, maxSpawnPointIndex);
    }
}