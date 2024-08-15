using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _powerUpSpeed;
    
    // 0 = triplePower, 1 = speedPower, 2 = shieldPower
    [SerializeField] private int _powerUpId; 
    
    [SerializeField] private AudioClip _poweUpAudioClip;


    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.transform.GetComponent<Player>();
        
        if (col.tag == "Player")
        {
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_poweUpAudioClip, transform.position);
                switch (_powerUpId)
                {
                    case 0:
                        player.ActivateTriple();
                        break;
                    case 1:
                        player.IncreasePlayerSpeed();
                        break;
                    case 2:
                        player.ActivateShield();
                        break;
                    default:
                        Debug.Log("default value");
                        break;
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
