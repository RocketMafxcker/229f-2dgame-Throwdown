using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    int health;
    [SerializeField] GameObject oneTrap;
    [SerializeField] GameObject twoTrap;
    private void Start()
    {
        health = 30;
        twoTrap.SetActive(false);
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(gameObject.activeSelf)
        {
            twoTrap.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= 5;
            if (health <= 0)
            {
                SceneManager.LoadScene(4);
                Destroy(gameObject);
            }
        }
    }
}
