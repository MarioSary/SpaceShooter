using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserSpeed;
    void Update()
    {
        LaseMovement();
        if (transform.position.y > 10f)
        {
            Destroy(gameObject, 5f);
        }
        
    }

    void LaseMovement()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
    }
}
