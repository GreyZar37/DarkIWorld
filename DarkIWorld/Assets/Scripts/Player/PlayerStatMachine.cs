using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatMachine : MonoBehaviour
{
    [System.NonSerialized]
    public static PlayerStatMachine instance;
   
    [System.NonSerialized]
    public int maxHealth = 100, damage = 10, bulletPenetration = 1, bullets = 1, maxAmmunition = 10, enemyExplodeDamage = 15 ;

    [System.NonSerialized]
    public float shootSpeed = 0.5f, bulletSpeed = 50f, playerSpeed = 20f, reloadTime = 1.5f, betryalDamageMultiplier = 1f;

    [System.NonSerialized]
    public bool hasBetryal = false, hasExplosiveBoodies = false;



    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
      
    }
   

}
