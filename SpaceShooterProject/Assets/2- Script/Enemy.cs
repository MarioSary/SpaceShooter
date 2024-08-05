using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float _enemySpeed;


   private void Update()
   {
      EnemyMovement();
   }

   void EnemyMovement()
   {
      transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

      if (transform.position.y < -3.5f)
      {
         float randomX = Random.Range(-9f, 9f);
         transform.position = new Vector3(randomX, 10, 0);
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         Player player = other.transform.GetComponent<Player>();
         if (player != null)
         {
            player.Damage();
         }
         
         Destroy(gameObject);
      }
      if (other.tag == "Laser")
      {
         Destroy(other.gameObject);
         Destroy(gameObject);
      }
   }
}
