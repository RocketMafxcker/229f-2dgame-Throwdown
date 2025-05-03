using UnityEngine;
using UnityEngine.TextCore.Text;

public class Sword : Weapon
{
    [SerializeField] private float speed;
    private void Start()
    {
        Damage = 5;
        speed = 20 * GetShootDirection();
    }
    public void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void OnHitWith(Character character)
    {

        if (character is Enemy)
        character.TakeDamage(this.Damage);
        Destroy(this);
    }
}
