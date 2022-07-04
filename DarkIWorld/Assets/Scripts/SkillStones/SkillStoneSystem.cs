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
    bulletPenetrationSkillStone,
    maxAmmunitionSkillStone,

    //Rare skillStones
    ammoPrRelaod,
    
    //Epic skillStones
    ekstraBulletSkillStone,

}

public class SkillStoneSystem : MonoBehaviour
{
    public static skillStones skillStoneEnum = 0;
    public static SkillStoneSystem instance;

    public GameObject skillStonePanel;
    public GameObject skillStoneItemHolder;


    public GameObject skillStone;
    
    int maxSkillStoneCount = 4;
    int currentCount;

    public int skillStoneTakeAmount;

    float commonDropRate = 60f, unCommonDropRate = 25f, rareDropRate = 5f , epicDropRate = 1f, legendaryDropRate = 0;
    float randomNumber;

    public List<skillStones> skillStoneList = new List<skillStones>();

    private void Start()
    {
        instance = this;
        currentCount = maxSkillStoneCount;

    }

    private void Update()
    {

    


        if (skillStoneTakeAmount != 0)
        {
            Time.timeScale = 0;

            while (currentCount > 0)
            {
                randomSkillStone();               
               
                currentCount--;

            }
        }
        else
        {
            Time.timeScale = 1;

            skillStonePanel.SetActive(false);
            skillStoneList.Clear();
            skillStoneCountResset();

        }



    }

    public void skillStoneCountResset()
    {
        currentCount = maxSkillStoneCount;
        skillStoneEnum = 0;

    }

    public void randomSkillStone()
    {
        skillStonePanel.SetActive(true);

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

            int randomNum = Random.Range(0, 3);

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
                case 1:
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
                case 2:
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
            if (skillStoneList.Contains(skillStones.ammoPrRelaod))
            {
                randomSkillStone();
            }
            else
            {
                skillStoneEnum = skillStones.ammoPrRelaod;

                Instantiate(skillStone, skillStoneItemHolder.transform);

            }
        }
        else if (randomNumber >= epicDropRate)
        {
            if (skillStoneList.Contains(skillStones.ekstraBulletSkillStone))
            {
                randomSkillStone();
            }
            else
            {
                skillStoneEnum = skillStones.ekstraBulletSkillStone;

                Instantiate(skillStone, skillStoneItemHolder.transform);

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
