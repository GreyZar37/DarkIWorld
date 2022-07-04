using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;

    public int damage;
    public float radius;

    public ParticleSystem particleSystem_;
    public AudioSource audioSource;
    public AudioClip[] explosions;

    Vector2 target;

    
    float explodeTimer = 1.5f;
    bool exloded;

    CameraShaker cameraShake;

    private void Awake()
    {
        audioSource = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cameraShake = GameObject.Find("Camera root").GetComponent<CameraShaker>();


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target , speed * Time.deltaTime);


        explodeTimer -= Time.deltaTime;

        if (explodeTimer <= 0 && !exloded)
        {
            Instantiate(particleSystem_, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(explosions[Random.Range(0, explosions.Length)]);
            cameraShake.isShaking = true;

            foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, radius))
            {
                if (collider.gameObject.tag == "Enemy")
                {

                    collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

                }
                else if (collider.gameObject.tag == "Player")
                {
                    collider.gameObject.GetComponent<PlayerMechanics>().TakeDamage(damage/4);

                }
            }
            exloded = true;
        }

        if(exloded == true)
        {
   
            Destroy(gameObject);
        }
    }
    
}
