using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;

    public int damage;
    public int penetration;

    public ParticleSystem particleSystem_;
    SpriteRenderer spriteRenderer;

    public bool spawnedFromEnemy;

    float lifespan = 3f;

    float betryalDamageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        betryalDamageMultiplier = PlayerStatMachine.instance.betryalDamageMultiplier;
        speed = PlayerStatMachine.instance.bulletSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();



        if (!spawnedFromEnemy)
        {
            damage = PlayerStatMachine.instance.damage;
            penetration = PlayerStatMachine.instance.bulletPenetration;


        }
        else
        {
            damage = Mathf.RoundToInt(PlayerStatMachine.instance.damage / 2 * betryalDamageMultiplier);
            transform.localScale /= 1.5f;
            spriteRenderer.color = new Color(1,1,1,0.5f);
            
            penetration = 0;
            lifespan /= 3f;
            speed /= 2f;
            gameObject.GetComponent<TrailRenderer>().emitting = false;
        }





        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

      
        rb2D.velocity = transform.up * speed;
        lifespan -= Time.deltaTime;





        if (lifespan <= 0)
        {
            dissolve();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(particleSystem_, transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

            penetration--;
            
            if(penetration <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void dissolve()
    {
        gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        if (gameObject.transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }


}
