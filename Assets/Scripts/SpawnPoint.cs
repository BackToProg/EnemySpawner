using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private Target _target;

    public GameObject GetEnemyTemplate() => _enemyTemplate;
    
    private void Start()
    {
        LookAtTarget();
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        transform.LookAt(_target.transform);
    }
}
