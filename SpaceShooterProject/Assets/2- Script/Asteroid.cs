using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    SpawnManager _spawnManager;

    [SerializeField] private float _asteroidRotSpeed = 20f;
    [SerializeField] private float _asteroidSpeed = 2f;
    [SerializeField] private GameObject _explosionPrefab;
    
    

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
    }

    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
        if (transform.position.y <= 1.5f)
        {
            transform.Rotate(Vector3.forward * _asteroidRotSpeed * Time.deltaTime, Space.Self);
            return;
        }
        else if (transform.position.y > 1.5f)
        {
            transform.Rotate(Vector3.forward * _asteroidRotSpeed * Time.deltaTime, Space.Self);
            transform.Translate(Vector3.down * _asteroidSpeed *Time.deltaTime, Space.World);
            if (transform.position.y < -7.5f)
            {
                Vector3 randomPos = new Vector3(Random.Range(-9, 9), Random.Range(7.5f, 10f), 0);
                transform.position = randomPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Laser")
        {
            Destroy(col.gameObject);
            Instantiate(_explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
            _spawnManager.StartSpawning();
        }
    }
}
