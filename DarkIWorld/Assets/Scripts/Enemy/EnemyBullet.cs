using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;

    public int damage = 5;


    float lifespan = 5f;

    public ParticleSystem particleSystem_;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb2D.velocity = transform.up * speed;




        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(particleSystem_, transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<PlayerMechanics>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
