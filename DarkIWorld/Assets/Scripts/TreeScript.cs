using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TreeScript : MonoBehaviour
{

    Animator animator;
    Light2D light2D;


    public float cycleOffset;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        light2D = GetComponentInChildren<Light2D>();
        animatorSetDelay();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet" || collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    void animatorSetDelay()
    {
        cycleOffset = Random.Range(0f,1f);
        animator.SetFloat("Offset", cycleOffset);
        
        
    }
    
    
}
