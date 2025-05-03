using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }


    protected IShootable shooter;

    public abstract void OnHitWith(Character character);
    public void Init(int _damage, IShootable _owner)
    {
        Damage = _damage;
        shooter = _owner;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());

        Destroy(this.gameObject, 1f);
    }
   /*/public int GetShootDirection()
    {
        float shootDir = shooter..position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDir > 0)
            return 1;
        else return -1;
    }*/
}
