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



    float lifespan = 5f;


    // Start is called before the first frame update
    void Start()
    {

        damage = PlayerStatMachine.instance.damage;
        penetration = PlayerStatMachine.instance.bulletPenetration;
        speed = PlayerStatMachine.instance.bulletSpeed;


        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        
        rb2D.velocity = transform.up * speed;




        lifespan -= Time.deltaTime;
        
        if(lifespan <= 0)
        {
            Destroy(gameObject);
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
}
