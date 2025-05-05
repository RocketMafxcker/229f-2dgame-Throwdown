using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class EnemyOne : MonoBehaviour
{
    int health;
    private void Start()
    {
        health = 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= 5;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
