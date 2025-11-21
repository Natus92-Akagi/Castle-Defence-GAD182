using UnityEngine;

public class explosiveProjectile : MonoBehaviour
{
    public int damageAmount;
    public int explosionDamage;
    public float explosionRadius;

    public void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy was hit!");
            //Enemy takes damage
            enemyControl enemy = collider.gameObject.GetComponent<enemyControl>();
                if (enemy != null)
                {
                    enemy.healthCurrent -= damageAmount;
                }
            Destroy(gameObject);
        }
    }



    void Explosion()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                // Damage the enemy
                enemyControl enemy = hit.GetComponent<enemyControl>();
                if (enemy != null)
                {
                    enemy.healthCurrent -= explosionDamage;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
