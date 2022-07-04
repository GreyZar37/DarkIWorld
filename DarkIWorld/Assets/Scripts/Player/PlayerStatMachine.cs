using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatMachine : MonoBehaviour
{
    [System.NonSerialized]
    public static PlayerStatMachine instance;
   
    [System.NonSerialized]
    public int maxHealth = 100, damage = 10, bulletPenetration = 1, bullets = 1, maxAmmunition = 20, ammoPrRelaod = 2;

    [System.NonSerialized]
    public float shootSpeed = 0.5f, bulletSpeed = 50f, playerSpeed = 20f, relaodSpeed = 0.25f;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
   

}
