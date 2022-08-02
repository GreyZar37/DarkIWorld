using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum skillStones
{
    //common skillStones
    healthSkillStone,
    damageSkillStone,
    shootSpeedSkillStone,
    relaodSpeedSkillStone,

    //unCommon skillStones
    healSkillStone,
    maxAmmunitionSkillStone,

    //Rare skillStones
    bulletPenetrationSkillStone,


    //Epic skillStones
    ekstraBulletSkillStone,
    explosiveBodies,
    betryal,

}

public class SkillStoneSystem : MonoBehaviour
{
    public static skillStones skillStoneEnum = 0;
    public static SkillStoneSystem instance;

    public GameObject skillStonePanel;
    public GameObject skillStoneItemHolder;

    public Animator levelPanelAnimator;

    
    public GameObject skillStone;
    
    int maxSkillStoneCount = 4;
    int currentCount;

    public int skillStoneTakeAmount;

    float commonDropRate = 70f, unCommonDropRate = 35f, rareDropRate = 20f , epicDropRate = 1f;
    float randomNumber;

    public List<skillStones> skillStoneList = new List<skillStones>();


    bool timeSet = false;

    private void Start()
    {
        instance = this;
        currentCount = maxSkillStoneCount;
    }

    private void Update()
    {

        if (skillStoneTakeAmount != 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            GameManager.currentGameState = gameState.paused;
          
            skillStonePanel.SetActive(true);
            levelPanelAnimator.SetBool("SelectStone", true);



            while (currentCount > 0)
            {
                randomSkillStone();               
               
                currentCount--;

            }
            timeSet = false;

        }
        else
        {

            if (timeSet == false)
            {
                Cursor.visible = false;

                Time.timeScale = 1;
                GameManager.currentGameState = gameState.playing;
                
                if(skillStonePanel.activeSelf)
                {
                    levelPanelAnimator.SetBool("SelectStone", false);
                }

                skillStonePanel.SetActive(false);

                skillStoneList.Clear();
                skillStoneCountResset();
                timeSet = true;
            }
           

        }



    }

    public void skillStoneCountResset()
    {
        currentCount = maxSkillStoneCount;
        skillStoneEnum = 0;

    }

    public void randomSkillStone()
    {
        
           
        


        randomNumber = Random.Range(0, 101);

        
        if (randomNumber >= commonDropRate)
        {
            int randomNum = Random.Range(0, 4);

            switch (randomNum)
            {
                case 0:
                    if (skillStoneList.Contains(skillStones.damageSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.damageSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;
                case 1:

                    if (skillStoneList.Contains(skillStones.shootSpeedSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.shootSpeedSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }

                    break;
                case 2:

                    if (skillStoneList.Contains(skillStones.healthSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.healthSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }

                    break;

                case 3:
                    if (skillStoneList.Contains(skillStones.relaodSpeedSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.relaodSpeedSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;

                default:
                    break;
            }


        }
        else if (randomNumber >= unCommonDropRate)
        {

            int randomNum = Random.Range(0, 2);

            switch (randomNum)
            {
     
                case 0:
                    if (skillStoneList.Contains(skillStones.healSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.healSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;
                case 1:
                    if (skillStoneList.Contains(skillStones.maxAmmunitionSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.maxAmmunitionSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;

                default:
                    break;
            }
        }

        else if (randomNumber >= rareDropRate)
        {


            int randomNum = Random.Range(0, 1);

            switch (randomNum)
            {

    
                   
                case 0:
                    if (skillStoneList.Contains(skillStones.bulletPenetrationSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.bulletPenetrationSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;

                default:
                    break;

            }
        }
        else if (randomNumber >= epicDropRate)
        {
            int randomNum = Random.Range(0, 3);

            switch (randomNum)
            {

                case 0:
                    if (skillStoneList.Contains(skillStones.ekstraBulletSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.ekstraBulletSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;
                case 1:
                    if (skillStoneList.Contains(skillStones.explosiveBodies))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.explosiveBodies;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;
                case 2:
                    if (skillStoneList.Contains(skillStones.betryal))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.betryal;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;

                default:
                    break;

            }
            
            

        }
        else
        {

            int randomNum = Random.Range(0, 4);

            switch (randomNum)
            {
                case 0:
                    if (skillStoneList.Contains(skillStones.damageSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.damageSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;
                case 1:

                    if (skillStoneList.Contains(skillStones.shootSpeedSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.shootSpeedSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }

                    break;
                case 2:

                    if (skillStoneList.Contains(skillStones.healthSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.healthSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }

                    break;

                case 3:
                    if (skillStoneList.Contains(skillStones.relaodSpeedSkillStone))
                    {
                        randomSkillStone();
                    }
                    else
                    {
                        skillStoneEnum = skillStones.relaodSpeedSkillStone;

                        Instantiate(skillStone, skillStoneItemHolder.transform);

                    }
                    break;

                default:
                    break;
            }




        }
        skillStoneList.Add(skillStoneEnum);

    }


}
