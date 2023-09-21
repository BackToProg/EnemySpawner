using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
   [SerializeField] private float _seconds;
   private GameObject[] _gameObjects;
   private bool isActive = true;

   private void Start()
   {
      _gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
      var spawnOnRandomPointRun = StartCoroutine(SpawnOnRandomPoint());
   }

   private IEnumerator SpawnOnRandomPoint()
   {
      while (isActive)
      {
         int spawnIndex = GetRandomSpawnPointIndex();
      
         _gameObjects[spawnIndex].GetComponent<Spawner>().SpawnEnemy();
      
         yield return new WaitForSeconds(_seconds);
      }
   }

   private int GetRandomSpawnPointIndex()
   {
      int minSpawnPointIndex = 0;
      int maxSpawnPointIndex = _gameObjects.Length;
      Random random = new Random();
      
      return random.Next(minSpawnPointIndex, maxSpawnPointIndex);
   }
    
}
