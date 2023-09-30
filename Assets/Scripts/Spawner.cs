using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private Enemy _template;

    private Transform[] _spawnPointsTransform;
    private readonly bool _isActive = true;

    private void Start()
    {
        SpawnPoints spawnPoints = FindObjectOfType<SpawnPoints>();
        
        _spawnPointsTransform = new Transform[spawnPoints.transform.childCount];

        for (int i = 0; i < _spawnPointsTransform.Length; i++)
        {
            _spawnPointsTransform[i] = spawnPoints.transform.GetChild(i).GetComponent<Transform>();
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
        int maxSpawnPointIndex = _spawnPointsTransform.Length;

        return Random.Range(minSpawnPointIndex, maxSpawnPointIndex);
    }
}