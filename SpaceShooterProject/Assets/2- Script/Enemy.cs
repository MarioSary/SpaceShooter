using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   private Player _player;
   
   [SerializeField] private float _enemySpeed;
   //private Animator _EnemyDeathAnim;
   [SerializeField] private GameObject _EnemyDeathAnim;
   
   

   private void Start()
   {
      _player = GameObject.Find("Player").GetComponent<Player>();
      if (_player == null)
      {
         Debug.LogError("Player is NULL.");
      }
      

      // _EnemyDeathAnim = GetComponent<Animator>();
      // if (_EnemyDeathAnim == null)
      // {
      //    Debug.LogError("The Animator is NULL.");
      // }
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
         Instantiate(_EnemyDeathAnim, this.transform.position, Quaternion.identity);
         Destroy(gameObject);
      }
      if (other.tag == "Laser")
      {
         Destroy(other.gameObject);
         _player.AddScore(10);
         Instantiate(_EnemyDeathAnim, this.transform.position, Quaternion.identity);
         Destroy(gameObject);
      }
   }
}
