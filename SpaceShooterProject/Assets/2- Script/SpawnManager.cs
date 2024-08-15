using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] PowerUpsPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    
    

    

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(PowerUpRoutine());
    }
    
    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        
        while (_stopSpawning == false)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, enemySpawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(3f);
        
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(5f);
            Vector3 triplePowerSpawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(PowerUpsPrefab[randomPowerUp], triplePowerSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(15f, 30f));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
