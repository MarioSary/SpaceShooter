using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _triplePowerUpPrefab;
    [SerializeField] private GameObject _speedPowerUpPrefab;
    [SerializeField] private GameObject _shieldPowerUpPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTriplePowerUpRoutine());
        StartCoroutine(SpawnSpeedPowerUpRoutine());
        StartCoroutine(SpawnShieldPowerUpRoutine());

    }
    
    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, enemySpawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnTriplePowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(5f);
            Vector3 triplePowerSpawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            Instantiate(_triplePowerUpPrefab, triplePowerSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(15f, 30f));
        }
    }

    IEnumerator SpawnSpeedPowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(10f);
            Vector3 speedPowerSpawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            Instantiate(_speedPowerUpPrefab, speedPowerSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(20, 35));
        }
    }
    
    IEnumerator SpawnShieldPowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(15f);
            Vector3 shieldPowerspawnPos = new Vector3(Random.Range(-9f, 9f), 10, 0);
            Instantiate(_shieldPowerUpPrefab, shieldPowerspawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(25, 40));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
