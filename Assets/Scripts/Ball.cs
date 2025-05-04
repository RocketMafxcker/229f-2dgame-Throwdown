using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(this);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(this);
        }
    }
}
