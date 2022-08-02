using UnityEngine;

public enum enemyType
{
    melee,
    ranged,
    shotgun,
}

public class EnemyAi : MonoBehaviour
{

    public int closeRangeDamage;
    public float speed;
    public float stoopingDistance;
    public float retreatDistance;

    float currentCooldownTime;
    public float attackCooldown;

    public GameObject bullet;


    public Transform[] firePoints;
    public Transform hand;

    Rigidbody2D rb2D;

    Transform player;
    Movement playerMovement;
    Vector2 playerVelocity;

    public enemyType enemyType_;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<Movement>();
  

        rb2D = GetComponent<Rigidbody2D>();

        currentCooldownTime = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = playerMovement.movement;

        flip();

        if (player != null)
        {
            Vector2 lookDir = (Vector2)player.position - rb2D.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            hand.rotation = Quaternion.Euler(0, 0, angle);

            if(enemyType_ != enemyType.melee)
            {
                if (Vector2.Distance(transform.position, player.position) > stoopingDistance)
                {

                    moveToPlayer();
                }

                else if (Vector2.Distance(transform.position, player.position) < retreatDistance && enemyType_ == enemyType.ranged)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

                    if (currentCooldownTime <= 0)
                    {
                        shootGun();
                        currentCooldownTime = attackCooldown;
                    }
                    else
                    {
                        currentCooldownTime -= Time.deltaTime;
                    }
                }
                else
                {
                    if (currentCooldownTime <= 0)
                    {

                        shootGun();
                        shootShotGun();

                        currentCooldownTime = attackCooldown;
                    }
                    else
                    {
                        currentCooldownTime -= Time.deltaTime;
                    }
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, player.position) > stoopingDistance)
                {
                    moveToPlayer();
                }
                if(Vector2.Distance(transform.position, player.position) < stoopingDistance + 1f)
                {
                    hit();
                }
            }     
        }



    }
    public void flip()
    {
        if (hand.eulerAngles.z > 180 && hand.eulerAngles.z < 360)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }


    public void shootGun()
    {
        if (enemyType_.Equals(enemyType.ranged))
        {
           if(Mathf.Abs(playerVelocity.x) + Mathf.Abs(playerVelocity.y) == 0)
            {
                Instantiate(bullet, firePoints[0].position, firePoints[0].rotation * Quaternion.identity);

            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-45, 45));

                Instantiate(bullet, firePoints[0].position, firePoints[0].rotation * rotation);

            }



        }

    }

    public void hit()
    {

        if (currentCooldownTime <= 0)
        {
            player.GetComponent<PlayerMechanics>().TakeDamage(closeRangeDamage);

            currentCooldownTime = attackCooldown;
        }
        else
        {
            currentCooldownTime -= Time.deltaTime;
        }

    }


    public void shootShotGun()
    {
        if (enemyType_.Equals(enemyType.shotgun))
        {
            for (int i = 0; i < firePoints.Length; i++)
            {
                Instantiate(bullet, firePoints[i].position, firePoints[i].rotation);

            }

        }

    }

    

    
    void moveToPlayer()
    {
       
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        

    }


}





