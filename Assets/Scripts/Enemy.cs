using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health;

    public virtual void Init(int newHealth)
    {
        health = newHealth;
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