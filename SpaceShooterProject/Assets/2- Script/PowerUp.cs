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
    private AudioSource _poweUpAudioSource;
    private SpriteRenderer _powerUpSprite;

    private void Start()
    {
        _poweUpAudioSource = GameObject.FindWithTag("PowerUp").GetComponent<AudioSource>();
        if (_poweUpAudioSource == null)
        {
            Debug.LogError("The Powerup Audio Source is NULL.");
        }
        else
        {
            _poweUpAudioSource.clip = _poweUpAudioClip;
        }

        _powerUpSprite = GameObject.FindWithTag("PowerUp").GetComponent<SpriteRenderer>();
        if (_powerUpSprite == null)
        {
            Debug.LogError("The Powerup Sprite is NULL.");
        }
    }

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
                //AudioSource.PlayClipAtPoint(_poweUpAudioClip, transform.position);
                _poweUpAudioSource.Play();
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

            _powerUpSprite.enabled = false;
            Destroy(this.gameObject, _poweUpAudioSource.clip.length);
        }
    }
}
