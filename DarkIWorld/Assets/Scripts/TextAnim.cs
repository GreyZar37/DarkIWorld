using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnim : MonoBehaviour
{
    float lifeSpanTimer = 3f;
    float speed;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(10, 20);
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        if (lifeSpanTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeSpanTimer -= Time.deltaTime;
        }
    }
}
