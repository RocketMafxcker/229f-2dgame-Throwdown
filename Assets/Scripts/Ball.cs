using UnityEngine;

public class Ball : Weapon
{
    private void Start()
    {
        Damage = 10;
    }
    public override void OnHitWith(Character character)
    {

        if (character is Enemy)
            character.TakeDamage(this.Damage);
        Destroy(this);
    }
}
