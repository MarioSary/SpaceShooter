using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager _uiManager;

    [SerializeField] private float _playerSpeed = 4.5f;
    [SerializeField] private float _playerSpeedMultiplier = 2f;
    
    private SpawnManager _spawnManager;
    [SerializeField] private Transform _laserPrefab;
    [SerializeField] private Transform _tripleShotPrefab;
    [SerializeField] private GameObject _playerShield;
    [SerializeField] private GameObject _jetDamageFireR;
    [SerializeField] private GameObject _jetDamageFireL;
    
    private Vector3 _offset;
    
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1;
    
    private int _playerHealth = 3;
    private int _score;
    
    
    private bool _isTripleShotActive = false;
    private bool _isShieldActive = false;

    void Start()
    {
        transform.position = new Vector3(0, -4f, 0);
        _offset = new Vector3(0, 1.05f, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
    }

    
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0).normalized;
        transform.Translate(direction * _playerSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 0f), 0);

        if (transform.position.x >= 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }
    }

    void Shoot()
    {
        _canFire = Time.time + _fireRate;
        if (_isTripleShotActive)
        {
            Instantiate(_tripleShotPrefab, transform.position + _offset, Quaternion.identity); 
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + _offset, Quaternion.identity);
        }
        
    }

    public void Damage()
    {
        if (_isShieldActive)
        {
            _playerShield.SetActive(false);
            _isShieldActive = false;
            return;
        }
        else
        {
            _playerHealth -= 1;
            _uiManager.UpdatePlayerLives(_playerHealth);
            Debug.Log(_playerHealth);
            switch (_playerHealth)
            {
                case 2:
                    _jetDamageFireR.SetActive(true);
                    break;
                case 1:
                    _jetDamageFireL.SetActive(true);
                    break;
                case 0:
                    _spawnManager.OnPlayerDeath();
                    Destroy(gameObject);
                    break;
            }
        }
        
    }

    public void ActivateTriple()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;
    }

    public void IncreasePlayerSpeed()
    {
        _playerSpeed *= _playerSpeedMultiplier;
        StartCoroutine(DecreasePlayerSpeedRoutine());

    }

    IEnumerator DecreasePlayerSpeedRoutine()
    {
        yield return new WaitForSeconds(5f);
        _playerSpeed /= _playerSpeedMultiplier;
    }
    
    public void ActivateShield()
    {
        _playerShield.SetActive(true);
        _isShieldActive = true;
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
