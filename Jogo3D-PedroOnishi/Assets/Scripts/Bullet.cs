using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rig;

    public bool hitPlayer = true;
    public bool hitEnemy = true;

    public float damage = 1f;

    public GameObject hitFX;

    public float lifeTime = 5f;

    private void Start() => Invoke(nameof(AutoDestroy), lifeTime);

    private void OnTriggerEnter(Collider other)
    {
        if (hitPlayer && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GetHit(damage);
        }
        if (hitEnemy && other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetHit(damage);
        }
        
        AutoDestroy();

    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(rig.linearVelocity);
    }

    void AutoDestroy()
    {
        if (hitFX) Instantiate(hitFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
