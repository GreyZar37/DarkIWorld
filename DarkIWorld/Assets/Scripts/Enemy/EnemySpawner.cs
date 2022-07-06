using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemiesInScene = new List<GameObject>();

    public static EnemySpawner instance;


    public GameObject[] enemies;
    public GameObject[] bosses;

    public Transform[] spawnPoints;

    public float spawnTime = 3f;

    int enemiesToSpawn;
    
    public int wave = 1;
    
    public TextMeshProUGUI waveText;
    
    public bool bossSpawned;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        enemiesToSpawn = wave * 5;

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
        for (int i = 0; i < enemiesInScene.Count; i++)
        {
            if (enemiesInScene[i] == null)
            {
                enemiesInScene.Remove(enemiesInScene[i]);
            }
        }

        waveText.text = "Wave: " + wave;
        
        if(enemiesInScene.Count == 0 && enemiesToSpawn == 0)
        {
            wave++;

            spawnBossMechanic();

            
            if (bossSpawned == false)
            {
                enemiesToSpawn = wave * 3;


                if (spawnTime > 0.25f)
                {
                    spawnTime *= 0.85f;
                }

                StartCoroutine(SpawnEnemy());
            }
        }
        else
        {
            bossSpawned = false;
        }
           
     
    }

    IEnumerator SpawnEnemy()
    {
        int enemyIndex;
        
        while (enemiesToSpawn > 0)
        {
            

            if (spawnPoints != null)
            {
                int randomNumber = Random.Range(0, 100);

                if (wave >= 2 && wave < 5)
                {
                    if (randomNumber > 30)
                    {
                        enemyIndex = 0;
                    }
                    else
                    {
                        enemyIndex = 1;
                    }

                }
               
                else if(wave > 5)
                {
                    if (randomNumber >= 50)
                    {
                        enemyIndex = 0;
                    }
                    else if(randomNumber >= 20 && randomNumber < 50)
                    {
                        enemyIndex = 1;
                    }
                    else
                    {
                        enemyIndex = 2;
                    }
                }
                else
                {
                    enemyIndex = 0;
                }

               
                    enemiesInScene.Add(Instantiate(enemies[enemyIndex], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity));
                    yield return new WaitForSeconds(spawnTime);
                    enemiesToSpawn--;
                
           
            }
          
        }
    }

    public void spawnBossMechanic()
    {
        if(wave % 5 == 0 && bossSpawned == false)
        {

            int random = Random.Range(0, bosses.Length);
            enemiesInScene.Add(Instantiate(bosses[random], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity));
            bossSpawned = true;
        }
    }
}
