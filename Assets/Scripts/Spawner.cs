using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private Enemy _template;
   
    private GameObject[] _spawnPoints;
    private readonly bool _isActive = true;

    private void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        var spawnOnRandomPointRun = StartCoroutine(SpawnOnRandomPoint());
    }

    private IEnumerator SpawnOnRandomPoint()
    {
        while (_isActive)
        {
            int spawnIndex = GetRandomSpawnPointIndex();

            GameObject spawnPoint = _spawnPoints[spawnIndex];
            Vector3 spawnPointPosition = spawnPoint.transform.position;
         
            Instantiate(_template, new Vector3(spawnPointPosition.x, 0, 
                spawnPointPosition.z), spawnPoint.transform.rotation);
      
            yield return new WaitForSeconds(_seconds);
        }
    }

    private int GetRandomSpawnPointIndex()
    {
        int minSpawnPointIndex = 0;
        int maxSpawnPointIndex = _spawnPoints.Length;
        Random random = new Random();
      
        return random.Next(minSpawnPointIndex, maxSpawnPointIndex);
    }

}
