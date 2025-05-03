using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField]int health = 100;
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D ballBulletPrefab;
    [SerializeField] Rigidbody2D swordBulletPrefab;
    [SerializeField] Collider2D areaLimit;

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("You Dead");
            Destroy(gameObject);
        }

        //Shoot
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (areaLimit.OverlapPoint(mouseWorld))
        {
            target.transform.position = mouseWorld;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider != null)
                {
                    Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                    Rigidbody2D shootBullet = Instantiate(ballBulletPrefab, shootPoint.position, Quaternion.identity);

                    shootBullet.linearVelocity = projectileVelocity;
                }
            }
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            Debug.Log(health);
        }
    }
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distanca = target - origin;

        float velocityX = distanca.x / time;
        float velocityY = distanca.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
        return projectileVelocity;
    }
}
