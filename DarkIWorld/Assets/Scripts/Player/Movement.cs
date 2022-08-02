using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    public ParticleSystem dirtSystem;
    Rigidbody2D rb;
    public Camera cam;
    public Transform hand;

    public Vector2 movement;
    Vector2 mousePos;
    Vector2 lookDir;

    public Animator animator;

    float xPosition = 100;
    float yPosition = 100;

    float velocity;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);
        animator.SetFloat("Velocity", velocity);
       
        if(velocity > 0 && !dirtSystem.isPlaying)
        {
            dirtSystem.Play();
        }
        else if (velocity <= 0 && dirtSystem.isPlaying)
        {
            dirtSystem.Stop();
        }

        movementConstraint();
        moveSpeed = PlayerStatMachine.instance.playerSpeed;

        flip();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);


        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        hand.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    public void flip()
    {
        if(lookDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
      
    }

    public void movementConstraint()
    {
        if(transform.position.x >= xPosition)
        {
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -xPosition)
        {
            transform.position = new Vector3(-xPosition, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= yPosition)
        {
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        }
        if (transform.position.y <= -yPosition)
        {
            transform.position = new Vector3(transform.position.x, -yPosition, transform.position.z);
        }

    }
}
