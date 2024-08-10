using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserSpeed;

    void Update()
    {
        LaserMovement();
        if (transform.position.y > 10f)
        {
            Destroy(gameObject, 1f);
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void LaserMovement()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
    }
}
