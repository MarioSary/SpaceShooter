using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 4.5f;
    [SerializeField] private Transform _laserPrefab;
    private Vector3 _offset;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1;
    
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _offset = new Vector3(0, 0.8f, 0);
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
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -1.9f, 7.9f), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void Shoot()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + _offset, Quaternion.identity);
    }
}
