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

    public TextMeshPro damageTxt;
    Transform canvas;

    public Material flashMaterial;
    public Material originalMaterial;
    float flashTime = 0.1f;
    float flashCurrentTime;

    public ParticleSystem particleSystem_;

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
        if (flashCurrentTime > 0)
        {

            flashCurrentTime -= Time.deltaTime;
            gameObject.GetComponentInChildren<SpriteRenderer>().material = flashMaterial;

            if (flashCurrentTime <= 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().material = originalMaterial;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        damageTxt.text = damage.ToString();

        Instantiate(damageTxt, (Vector2)transform.position, Quaternion.Euler(0, 0, Random.Range(-40,40)));

        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(particleSystem_, transform.position, Quaternion.identity);
        

        cameraShake.isShaking = true;
        LevelSystem.instance.AddScore(xpGain);
        audioSource.PlayOneShot(deathSound[Random.Range(0, deathSound.Length)]);
        
        Destroy(gameObject);
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(hitSound[Random.Range(0, hitSound.Length)]);
            flashCurrentTime = flashTime;
        }

    }
}
