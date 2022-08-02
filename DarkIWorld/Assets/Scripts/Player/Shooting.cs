using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Shooting : MonoBehaviour
{
    public Slider granadeClooldwonSlider;

    public GameObject bulletPrefab;
    public GameObject granade;

    public Transform gunPosition;
    int bullets;

    public ParticleSystem shootParticle;

    CameraShaker cameraShake;

    AudioSource sfx;

    public AudioClip[] shotSound;
    public AudioClip[] relaodingSound;

    float shootCooldownTime;
    float currentTimer;

    public int maxAmmunition;
    int ammoInMagazine;

    [Header("Gun")]

    public Slider reloadTimerSlider;


    public float reloadCooldown;
    float currentReloadCooldown;
    bool reloding;

    float autoReloadTimer;
    float autoReloadTimerCooldown;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI ammoTextSmall;

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


        reloadCooldown = PlayerStatMachine.instance.reloadTime;
        maxAmmunition = PlayerStatMachine.instance.maxAmmunition;


        ammoInMagazine = maxAmmunition;
        currentReloadCooldown = reloadCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimerSlider.minValue = -reloadCooldown;


        autoReloadTimerCooldown = shootCooldownTime + 0.1f;
        granadeClooldwonSlider.maxValue = granadeCooldownTimer;
        granadeClooldwonSlider.value = currentGranadeTimer;

        ammoText.text = ammoInMagazine + "/" + maxAmmunition;
        ammoTextSmall.text = ammoInMagazine.ToString();

        bullets = PlayerStatMachine.instance.bullets;
        shootCooldownTime = PlayerStatMachine.instance.shootSpeed;
        reloadCooldown = PlayerStatMachine.instance.reloadTime;
        maxAmmunition = PlayerStatMachine.instance.maxAmmunition;



        if (ammoInMagazine != maxAmmunition)
        {
            autoReloadTimer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.R) || ammoInMagazine <= 0)
            {
                autoReloadTimer = 0;
            }

            if (autoReloadTimer <= 0 && !reloding)
            {

                sfx.PlayOneShot(relaodingSound[0]);
                print("faf");
                reloding = true;
            }

        }
        else
        {
            reloadTimerSlider.gameObject.SetActive(false);
        }




        if (reloding)
        {
            reloadTimerSlider.gameObject.SetActive(true);
            
            Relaod();
        }
        else
        {
            reloadTimerSlider.gameObject.SetActive(false);


        }

        if(GameManager.currentGameState == gameState.playing)
        {
            shoot();
        }
        

        if (Input.GetKeyDown(KeyCode.G) && currentGranadeTimer <= 0 && GameManager.currentGameState == gameState.playing)
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




        if (Input.GetMouseButton(0) && currentTimer <= 0 && ammoInMagazine > 0 )
        {

            autoReloadTimer = autoReloadTimerCooldown;
            currentReloadCooldown = reloadCooldown;
            ammoInMagazine--;

            
            reloding = false;

            for (int i = 0; i < bullets; i++)
            {


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
            shootParticle.Play();
            currentTimer = shootCooldownTime;
            cameraShake.isShaking = true;
            sfx.PlayOneShot(shotSound[Random.Range(0, shotSound.Length)]);

        }
    }

    public void Relaod()
    {

        if (currentReloadCooldown <= 0)
        {
            ammoInMagazine = maxAmmunition;
            currentReloadCooldown = reloadCooldown;

            reloding = false;

        }
        else
        {

            currentReloadCooldown -= Time.deltaTime;
            reloadTimerSlider.value = -currentReloadCooldown;

        }



    }






}
