using UnityEngine;

public class enemyControl : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float moveSpeed;
    public int damageAmount;
    public int healthTotal;
    public int healthCurrent;
    public int enemyType;
    public int enemySpawnChance;
    public Sprite[] enemySprites;
    private SpriteRenderer SpriteRenderer;

    [Header("Footsoldier Stats")]
    public float footsoldierMoveSpeed;
    public int footsoldierDamageAmount;
    public int footsoldierHealthTotal;

    [Header("Flyer Stats")]
    public float flyerMoveSpeed;
    public int flyerDamageAmount;
    public int flyerHealthTotal;
    public float flyerEnemyHeightHigh;
    public float flyerEnemyHeightLow;

    [Header("Giant Stats")]
    public float giantMoveSpeed;
    public int giantDamageAmount;
    public int giantHealthTotal;

    //public gameManager gameManager;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        enemySpawnChance = Random.Range(1,11);
        //Spawn a Footsoldier
        if (enemySpawnChance <= 6)
        {
            enemyType = 1;
        }
                //Spawn a Flyer
                if (enemySpawnChance >= 7 && enemySpawnChance != 10)
                {
                    enemyType = 2;
                }
                    //Spawn a Giant
                    if (enemySpawnChance == 10)
                    {
                        enemyType = 3;
                    }

        //Footsoldier
        if (enemyType == 1)
        {
            moveSpeed = footsoldierMoveSpeed;
            damageAmount = footsoldierDamageAmount;
            healthTotal = footsoldierHealthTotal;
            healthCurrent = healthTotal;
        }

        //Flyer
        if (enemyType == 2)
        {
            moveSpeed = flyerMoveSpeed;
            damageAmount = flyerDamageAmount;
            healthTotal = flyerHealthTotal;
            healthCurrent = healthTotal;

            //Put it in the Air!
            float randomY = Random.Range(flyerEnemyHeightHigh, flyerEnemyHeightLow);
            Vector3 currentPosition = transform.position;
            currentPosition.y = randomY;
            transform.position = currentPosition;
            
        }

        //Giant
        if (enemyType == 3)
        {
            moveSpeed = giantMoveSpeed;
            damageAmount = giantDamageAmount;
            healthTotal = giantHealthTotal;
            healthCurrent = healthTotal;

            Vector3 currentPosition = transform.position;
            currentPosition.y = -3;
            transform.position = currentPosition;
        }
            //Set Enemy Sprite to Array Number
            if (enemyType >= 1 && enemyType < enemySprites.Length)
            {
                SpriteRenderer.sprite = enemySprites[enemyType];
            }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tower"))
        {
            Debug.Log("Tower was touched!");
            Destroy(gameObject); // Destroy the enemy

            // Tower takes damage
            towerControl tower = collider.gameObject.GetComponent<towerControl>();
            if (tower != null)
            {
                tower.towerCurrentHealth -= damageAmount;
            }
        }
    }

    void Update()
    {
        //Move to the Left
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        if (healthCurrent <= 0)
        {
            gameManager.playerCurrentScore += 100;
            Destroy(gameObject);
        }
    }
}

