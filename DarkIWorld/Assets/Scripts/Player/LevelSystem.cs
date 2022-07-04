using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    
    public int level = 1;
    public int maxLevel = 10;
    public float xp = 0;
    public int targetXp;

    public ParticleSystem particleSystem_;

    public float fillSpeed = 0.75f;
    
    float xpToNextLevel = 30;
    
    public TextMeshProUGUI levelText;
    
    public Slider levelSlider;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        levelText.text = "Level " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        levelSlider.maxValue = xpToNextLevel;

        fillSpeed = Mathf.Abs(levelSlider.value - xp) + 10;

        if (levelSlider.value < xp)
        {

            levelSlider.value += fillSpeed * Time.deltaTime;
            if (!particleSystem_.isPlaying)
            {
                particleSystem_.Play();
            }
        }
        else
        {
            particleSystem_.Stop();
        }
        

        levelText.text = "Level " + level.ToString();

        if (levelSlider.value >= xpToNextLevel)
        {
            level++;
            xp -= xpToNextLevel;
            levelSlider.value = 0;

            SkillStoneSystem.instance.skillStoneTakeAmount++;
            xpToNextLevel *= 1.30f;
        }
    }

    public void AddScore(int xp)
    {
        
        this.xp += xp;
        
    }
   
}
