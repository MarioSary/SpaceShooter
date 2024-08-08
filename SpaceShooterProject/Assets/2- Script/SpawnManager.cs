using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        yield return null;
        while (_stopSpawning == false)
        {
            float randomX = Random.Range(-9, 9);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
