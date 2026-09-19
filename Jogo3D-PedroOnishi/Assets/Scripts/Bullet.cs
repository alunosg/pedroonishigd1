using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool hitPlayer = true;
    public bool hitEnemy = true;

    public float damage = 1f;

    public GameObject hitFX;

    private void OnTriggerEnter(Collider other)
    {
        if (hitPlayer && other.CompareTag("Player"))
        {
            // other.GetComponent<PlayerController>().GetHit(damage);
        }
        if (hitEnemy && other.CompareTag("Enemy"))
        {
            //other.GetComponent<EnemyController>().GetHit(damage);        }
        }
        if (hitFX) Instantiate(hitFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
