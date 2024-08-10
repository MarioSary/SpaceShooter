using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float _enemySpeed;
   private Player _player;

   private void Start()
   {
      _player = GameObject.Find("Player").GetComponent<Player>();
      if (_player == null)
      {
         Debug.LogError("Player is NULL.");
      }
   }


   private void Update()
   {
      EnemyMovement();
   }

   void EnemyMovement()
   {
      transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

      if (transform.position.y < -7f)
      {
         float randomX = Random.Range(-9f, 9f);
         transform.position = new Vector3(randomX, 8, 0);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      
      if (other.tag == "Player")
      {
         
         if (_player != null)
         {
            _player.Damage();
         }
         
         Destroy(gameObject);
      }
      if (other.tag == "Laser")
      {
         Destroy(other.gameObject);
         _player.AddScore(10);
         Destroy(gameObject);
      }
   }
}
