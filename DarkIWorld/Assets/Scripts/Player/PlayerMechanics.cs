using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMechanics : MonoBehaviour
{
    public static PlayerMechanics instance;

    
    public int maxPlayerHealth;
    public int currentPlayerHealth;

    float flashTime = 0.1f;
    float flashCurrentTime;

    public Material flashMaterial;
    Material originalMaterial;

    CameraShaker cameraShake;

    public AudioSource audioSource;
    
    public AudioClip[] hitSound;
    public AudioClip loseSound;

    public ParticleSystem blood;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
            
        cameraShake = GameObject.Find("Camera root").GetComponent<CameraShaker>();
        audioSource = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();


        originalMaterial = gameObject.GetComponent<SpriteRenderer>().material;
       
        maxPlayerHealth = PlayerStatMachine.instance.maxHealth;


        healthBar.maxValue = maxPlayerHealth;
        currentPlayerHealth = maxPlayerHealth;

        


    }

    // Update is called once per frame
    void Update()
    {
     

        maxPlayerHealth = PlayerStatMachine.instance.maxHealth;
        healthBar.maxValue = maxPlayerHealth;
        healthBar.value = currentPlayerHealth;


        if (currentPlayerHealth >= maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }
        if (flashCurrentTime > 0)
        {

            flashCurrentTime -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().material = flashMaterial;

            if (flashCurrentTime <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().material = originalMaterial;

            }
        }        

    }

    public void TakeDamage(int damage)
    {
        flashCurrentTime = flashTime;
        cameraShake.isShaking = true;
        audioSource.PlayOneShot(hitSound[Random.Range(0, hitSound.Length)]);

        currentPlayerHealth -= damage;
        healthBar.value = currentPlayerHealth;

        if (currentPlayerHealth <= 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Die();
        }
    }

    public void Die()
    {
        audioSource.PlayOneShot(loseSound,0.3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("HIT EM");
        }
    }
}
