using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YothulBossScript : MonoBehaviour
{
    public Transform[] firePoints;
    public Transform hand;
    Rigidbody2D rb2D;
    Transform player;

    public GameObject bullet;
    public GameObject[] enemies;

    float currentCooldownTime;
    public float attackCooldown;

    public float spawnCooldowntCooldownTime;
    float spawnCooldown;

    public float speed;
    public float stoopingDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb2D = GetComponent<Rigidbody2D>();

        currentCooldownTime = attackCooldown;
        spawnCooldown = spawnCooldowntCooldownTime;
    }

    void Update()
    {

       

        if(player != null)
        {
            if (spawnCooldown > 0)
            {
                spawnCooldown -= Time.deltaTime;
            }
            else
            {
                spawnCooldown = spawnCooldowntCooldownTime;
                SpawnEnemy();
            }

            flip();

            if (Vector2.Distance(transform.position, player.position) > stoopingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }
            else
            {
                if (currentCooldownTime <= 0)
                {
                    currentCooldownTime = attackCooldown;
                    Shoot();
                }
                else
                {
                    currentCooldownTime -= Time.deltaTime;
                }
            }


        }

    }

    public void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    public void SpawnEnemy()
    {
      
        Vector2 offset = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        int random = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[random], new Vector2(transform.position.x + offset.x, transform.position.y + offset.y) , Quaternion.identity);
        enemy.GetComponent<EnemyHealth>().xpGain = 0;
        

        spawnCooldown = spawnCooldowntCooldownTime;
    }

    public void flip()
    {
        Vector2 lookDir = (Vector2)player.position - rb2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        hand.rotation = Quaternion.Euler(0, 0, angle);
        
        if (hand.eulerAngles.z > 180 && hand.eulerAngles.z < 360)
        {
            transform.localScale = new Vector3(-4, 4, 1);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 1);
        }

    }
}
