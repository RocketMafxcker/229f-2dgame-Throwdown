using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    int health;
    [SerializeField] GameObject boss;

    private void Start()
    {
        health = 20;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= 5;
            if (health <= 0)
            {
                boss.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
