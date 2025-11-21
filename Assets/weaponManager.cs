using UnityEngine;

public class weaponManager : MonoBehaviour
{
    [Header("General Weapon Stats")]
    public float firingSpeed;
    public int weaponType;
    public bool canShoot = true;
    public float projectileSpeed;
    public float arrowFiringSpeed;
    public float arrowFiringSpeedMax;
    
    [Header("Burst Weapon Stats")]
    public int pelletCount;         
    public float spreadAngle;
    public float burstProjectileSpeed;
    public float burstFiringSpeed;
    public float burstFiringSpeedMax;

    [Header("Snipe Weapon Stats")]
    public float snipeFiringSpeed;
    public float snipeFiringSpeedMax;

    [Header("Explode Weapon Stats")]
    public float explodeFiringSpeed;
    public float explodeFiringSpeedMax;
    public float explosiveProjectileSpeed;

    //Weapon Types
    public GameObject arrowProjectile;
    public GameObject burstProjectile;
    public GameObject explosiveProjectile;
    public GameObject snipeProjectile;

    //ButtonManager Reference
    //public buttonManager buttonManager;

    void Start()
    {
        arrowFiringSpeed = 10f;
        burstFiringSpeed = 10f;
        snipeFiringSpeed = 10f;
        explodeFiringSpeed = 10f;

        //Change weapon based on Button Pressed in Title
        weaponType = buttonManager.chosenWeaponType;
    }

    // Update is called once per frame
    void Update()
    {
        arrowFiringSpeed += Time.deltaTime;
        burstFiringSpeed += Time.deltaTime;
        snipeFiringSpeed += Time.deltaTime;
        explodeFiringSpeed += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Weapon has fired!");
            SpawnProjectile();
        }
    }

    
    void SpawnProjectile()
    {
        //Arrow
        if (weaponType == 1 && arrowFiringSpeed >= arrowFiringSpeedMax)
        {
        //Reset Firing Speed
        arrowFiringSpeed = 0;

        //Convert Mouse Pos to World Pos
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        //Instantiate Projectile at Tower
        GameObject proj = Instantiate(arrowProjectile, transform.position, Quaternion.identity);

        //Direction from tower/mouse
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        //Rotate Projectile
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Projectile Speed
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * projectileSpeed;
        }

        //Burst
        if (weaponType == 2 && burstFiringSpeed >= burstFiringSpeedMax)
        {
        //Reset Firing Speed
        burstFiringSpeed = 0;    

        //Convert Mouse Pos to World Pos
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // Base direction
        Vector2 baseDir = (mouseWorldPos - transform.position).normalized;
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg;

        for (int i = 0; i < pelletCount; i++)
        {
            //Random Spread
            float randomSpreadOffset = Random.Range(-spreadAngle, spreadAngle);
            float randomSpeedOffset = Random.Range(-spreadAngle, spreadAngle) + burstProjectileSpeed;

            if (randomSpeedOffset <= 5)
            {
                randomSpeedOffset = 5f;
            }

            //Calculate rotated direction
            float finalAngle = baseAngle + randomSpreadOffset;
            Vector2 finalDir = new Vector2(Mathf.Cos(finalAngle * Mathf.Deg2Rad),
                                    Mathf.Sin(finalAngle * Mathf.Deg2Rad));

            //Instantiate pellet
            GameObject proj = Instantiate(burstProjectile, transform.position, Quaternion.Euler(0, 0, finalAngle));

            //Randomize Speed
            //burstProjectileSpeed * randomSpeedOffset;

            //Fire pellet
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            rb.linearVelocity = finalDir * randomSpeedOffset;
        }
        }


        //Explosive
        if (weaponType == 3 && explodeFiringSpeed >= explodeFiringSpeedMax)
        {
        explodeFiringSpeed = 0;
        //Convert Mouse Pos to World Pos
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        //Instantiate Projectile at Tower
        GameObject proj = Instantiate(explosiveProjectile, transform.position, Quaternion.identity);

        //Direction from tower/mouse
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        //Rotate Projectile
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Projectile Speed
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * explosiveProjectileSpeed;
        }

        //Snipe
        if (weaponType == 4 && snipeFiringSpeed >= snipeFiringSpeedMax)
        {
        snipeFiringSpeed = 0f;
        //Convert Mouse Pos to World Pos
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        //Instantiate Projectile at Tower
        GameObject proj = Instantiate(snipeProjectile, transform.position, Quaternion.identity);

        //Direction from tower/mouse
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        //Rotate Projectile
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Projectile Speed
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * projectileSpeed;
        }
    }
}

