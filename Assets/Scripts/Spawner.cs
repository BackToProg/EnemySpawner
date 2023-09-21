using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    
    public void SpawnEnemy()
    {
        Vector3 position = transform.position;
        GameObject newObject = Instantiate(_template, new Vector3(position.x, 0, position.z), transform.rotation);
    }
}
