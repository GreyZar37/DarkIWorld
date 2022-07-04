using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Slider granadeClooldwonSlider;

    public GameObject bulletPrefab;
    public GameObject granade;

    public Transform gunPosition;
    int bullets;

    CameraShaker cameraShake;

    AudioSource sfx;

    public AudioClip[] shotSound;
    public AudioClip[] relaodingSound;
    public AudioClip gunReadySound;

    float shootCooldownTime;
    float currentTimer;

    public int maxAmmunition;
    int ammoInMagazine;

    [Header ("Gun")]
    public float relaodSpeed;
    bool reloding;
    bool startReloding;
    public int AmmoPrRelaod;
    public Slider ammoSlider;

    [Header("Granade")]
     float granadeCooldownTimer = 15f;
    float currentGranadeTimer;
    

    // Start is called before the first frame update
    void Start()
    {

        currentGranadeTimer = granadeCooldownTimer;
        currentTimer = shootCooldownTime;
        cameraShake = GameObject.Find("Camera root").GetComponent<CameraShaker>();
        sfx = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();


        relaodSpeed = PlayerStatMachine.instance.relaodSpeed;
        maxAmmunition = PlayerStatMachine.instance.maxAmmunition;
        AmmoPrRelaod = PlayerStatMachine.instance.ammoPrRelaod;


        ammoInMagazine = maxAmmunition;

    }

    // Update is called once per frame
    void Update()
    {
        granadeClooldwonSlider.maxValue = granadeCooldownTimer;
        granadeClooldwonSlider.value = currentGranadeTimer;


        bullets = PlayerStatMachine.instance.bullets;
        shootCooldownTime = PlayerStatMachine.instance.shootSpeed;
        relaodSpeed = PlayerStatMachine.instance.relaodSpeed;
        maxAmmunition = PlayerStatMachine.instance.maxAmmunition;
        AmmoPrRelaod = PlayerStatMachine.instance.ammoPrRelaod;

        ammoSlider.maxValue = maxAmmunition;
        ammoSlider.value = ammoInMagazine;


        if (ammoInMagazine <= 0 || Input.GetKeyDown(KeyCode.R) && !reloding && ammoInMagazine != maxAmmunition)
        {

            reloding = true;
        }
      

        if(reloding == true && startReloding == false)
        { 
           StartCoroutine(relaodingFc());
            startReloding = true;
        }
        else if(reloding == false)
        {
            shoot();
        }


        if (Input.GetKeyDown(KeyCode.G) && currentGranadeTimer <= 0)
        {
            Instantiate(granade, gunPosition.position, gunPosition.rotation);
            currentGranadeTimer = granadeCooldownTimer;
        }
        else
        {
            currentGranadeTimer -= Time.deltaTime;
            
        }

    }

    public void shoot()
    {
        currentTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && currentTimer <= 0 )
        {
            for (int i = 0; i < bullets; i++)
            {
                ammoInMagazine--;

                if (bullets > 1 && ammoInMagazine > 0)
                {
                    Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-10, 10));
                    Instantiate(bulletPrefab, gunPosition.position, gunPosition.rotation * rotation);
                }
                else
                {
                    Instantiate(bulletPrefab, gunPosition.position, gunPosition.rotation);

                }

            }
            currentTimer = shootCooldownTime;
            cameraShake.isShaking = true;
            sfx.PlayOneShot(shotSound[Random.Range(0, shotSound.Length)]);

        }
    }

    IEnumerator relaodingFc()
    {
        print("realoding");
        while(ammoInMagazine < maxAmmunition)
        {
            ammoInMagazine += AmmoPrRelaod;
            
            if (ammoInMagazine >= maxAmmunition)
            {
                sfx.PlayOneShot(gunReadySound, 0.3f);
                ammoInMagazine = maxAmmunition;
            }
            else
            {
                sfx.PlayOneShot(relaodingSound[Random.Range(0, relaodingSound.Length)],0.3f);

            }
            yield return new WaitForSeconds(relaodSpeed);

            

        }

        if (ammoInMagazine >= maxAmmunition)
        {
            reloding = false;
            startReloding = false;

        }



    }
}
