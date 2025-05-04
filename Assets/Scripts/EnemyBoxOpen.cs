using UnityEngine;

public class EnemyBoxOpen : MonoBehaviour
{
    int health = 10;
    [SerializeField] GameObject box;
    private void Start()
    {
        box.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= 5;
            if (health <= 0)
            {
                box.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
