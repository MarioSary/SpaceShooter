using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 4.5f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //transform.Translate(Vector3.right * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y >= 7.9f)
        { 
            transform.position = new Vector3(transform.position.x, 7.9f, 0);
        }
        else if (transform.position.y <= -1.9)
        {
            transform.position = new Vector3(transform.position.x, -1.9f, 0);
        }

        if (transform.position.x >= 9.15f)
        {
            transform.position = new Vector3(-9.15f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.15f)
        {
            transform.position = new Vector3(9.15f, transform.position.y, 0);
        }
    }
}
