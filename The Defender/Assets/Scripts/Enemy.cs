using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]  
    [SerializeField] float health = 100f;
    float shotCounter;
    [SerializeField] int scoreValue = 150; 
    [Header("Projectile")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject laserPrefab;
    [Header("Explosion")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion;
    [Header("Audio")]
    [SerializeField] AudioClip enemyDeathSFX;
    [SerializeField] AudioClip enemyShootSFX;
    [SerializeField] [Range(0,1)] float enemyShootVolume = 0.7f;
    [SerializeField] [Range(0,1)] float enemyDeathVolume = 0.7f;


    GameSession gameSession;


    // Start is called before the first frame update 
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownandShoot();


    }

    private void CountDownandShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
                 laserPrefab,
                 transform.position,
                 Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyShootSFX, Camera.main.transform.position, enemyShootVolume);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);

       
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(
               deathVFX,
               transform.position, transform.rotation);
               Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, enemyDeathVolume);
        
    }

    
}
