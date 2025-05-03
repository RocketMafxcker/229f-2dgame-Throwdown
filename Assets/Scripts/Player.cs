using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D ballBulletPrefab;
    [SerializeField] GameObject swordBulletPrefab;
    [SerializeField] Collider2D areaLimit;
    [SerializeField] Button ball;
    [SerializeField] Button sword;
    string chooseWeapon;

    private void Start()
    {
        Init(100);
    }
    void Update()
    {
        //Shoot
        ball.onClick.AddListener(() => chooseWeapon = "ball");
        sword.onClick.AddListener(() => chooseWeapon = "sword");
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (areaLimit.OverlapPoint(mouseWorld))
        {
            target.transform.position = mouseWorld;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider != null && chooseWeapon == "ball")
                {
                    Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                    Rigidbody2D shootBullet = Instantiate(ballBulletPrefab, shootPoint.position, Quaternion.identity);

                    shootBullet.linearVelocity = projectileVelocity;
                    Destroy(shootBullet, 5f);
                }
                if (hit.collider != null && chooseWeapon == "sword")
                {
                    GameObject obj = Instantiate(swordBulletPrefab, shootPoint.position, shootPoint.rotation);
                    Sword sword = obj.GetComponent<Sword>();
                }
            }     
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
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
