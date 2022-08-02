using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{

    public int enemyHealth = 100;
    public int xpGain;
    CameraShaker cameraShake;

    public AudioSource audioSource;
    public AudioClip[] deathSound;
    public AudioClip[] hitSound;

    public AudioClip[] explosionSound;

    public TextMeshPro damageTxt;
    Transform canvas;

    public Material flashMaterial;
    public Material originalMaterial;
    float flashTime = 0.1f;
    float flashCurrentTime;

    public ParticleSystem bloodParticle;
    public ParticleSystem deathExplodeParticles;

    [Header("Player upgrades")]
    bool hasBetrayal;
    float betryalDamageMultiplier;
    public GameObject bullet;
    
    bool hasExplosiveEnemies;
    bool exploded;
    int explosiveDamage;
    float exposionRadius = 10;
    float explosionDelay = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
        originalMaterial = GetComponentInChildren<SpriteRenderer>().material;
        audioSource = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();
        cameraShake = GameObject.Find("Camera root").GetComponent<CameraShaker>();
        canvas = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        explosiveDamage = PlayerStatMachine.instance.enemyExplodeDamage;

        hasBetrayal = PlayerStatMachine.instance.hasBetryal;
        hasExplosiveEnemies = PlayerStatMachine.instance.hasExplosiveBoodies;

        if (flashCurrentTime > 0)
        {

            flashCurrentTime -= Time.deltaTime;
            gameObject.GetComponentInChildren<SpriteRenderer>().material = flashMaterial;

            if (flashCurrentTime <= 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().material = originalMaterial;
            }
        }

        if (enemyHealth <= 0)
        {
            Die();
        }
        
    }

    public void TakeDamage(int damage)
    {
        damageTxt.text = damage.ToString();
        flashCurrentTime = flashTime;


        Instantiate(damageTxt, (Vector2)transform.position, Quaternion.Euler(0, 0, Random.Range(-40,40)));

        enemyHealth -= damage;
        
    }

    public void Die()
    {
       

        if (hasExplosiveEnemies == true && exploded == false)
        {
            explodeOnDeath();
        }
        else
        {
            if (hasBetrayal)
            {
                betryalOnDeath();
            }

            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            cameraShake.isShaking = true;
            LevelSystem.instance.AddScore(xpGain);
            audioSource.PlayOneShot(deathSound[Random.Range(0, deathSound.Length)]);
            Destroy(gameObject);

        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(hitSound[Random.Range(0, hitSound.Length)],0.5f);
        }

    }

    public void explodeOnDeath()
    {
        explosionDelay -= Time.deltaTime;
        if(explosionDelay <= 0)
        {
            Instantiate(deathExplodeParticles, transform.position, Quaternion.identity);
            cameraShake.isShaking = true;
            audioSource.PlayOneShot(explosionSound[Random.Range(0, explosionSound.Length)], 0.5f);

            foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, exposionRadius))
            {
                if (collider.gameObject.tag == "Enemy" && collider.gameObject != gameObject)
                {
                    collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(explosiveDamage);

                }

            }

            exploded = true;
        }
       

    }
    public void betryalOnDeath()
    {
        for (int i = 0; i < 12; i++)
        {
            
            float angle = i * 45;
            GameObject bullet_ = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0,angle));
            bullet_.GetComponent<StartBullet>().spawnedFromEnemy = true;

        }
        
    }
}
