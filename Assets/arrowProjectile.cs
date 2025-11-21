using UnityEngine;

public class arrowProjectile : MonoBehaviour
{
    public int damageAmount;

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

}