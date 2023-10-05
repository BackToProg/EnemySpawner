using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyTemplates;
    [SerializeField] private Target _target;

    public Enemy GetEnemyTemplate()
    {
        int minRandomIndex = 0;
        Enemy enemy = _enemyTemplates[Random.Range(minRandomIndex, _enemyTemplates.Length)];

        return enemy;
    }

    public Target GetTarget() => _target;
}
