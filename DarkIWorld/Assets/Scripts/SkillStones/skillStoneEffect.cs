using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class skillStoneEffect : MonoBehaviour, IPointerEnterHandler
{


    string effectText;
    TextMeshProUGUI discriptionTxt;

    public Sprite[] skillStoneFrames;
    public Sprite[] upgradeIcon;



    public Image frame;
    public Image icon;


    public Button skillStoneButton;
    
    




    private void Awake()
    {

        discriptionTxt = GameObject.Find("DiscriptionTxt").GetComponent<TextMeshProUGUI>();
        skillStoneButton = GetComponent<Button>();




        switch (SkillStoneSystem.skillStoneEnum)

        {
            case skillStones.healthSkillStone:

                healthSkillStone();
                break;

            case skillStones.ekstraBulletSkillStone:

                ekstraBulletSkillStone();

                break;
            case skillStones.bulletPenetrationSkillStone:
                bulletPenetrationSkillStone();

                break;
            case skillStones.damageSkillStone:
                damageSkillStone();

                break;
            case skillStones.shootSpeedSkillStone:
                attackSpeedSkillStone();

                break;
            case skillStones.healSkillStone:
                healSkillStone();

                break;
            case skillStones.maxAmmunitionSkillStone:
                maxAmmunitionSkillStone();

                break;
            case skillStones.relaodSpeedSkillStone:
                relaodSpeedSkillStone();

                break;

            case skillStones.explosiveBodies:
                explosiveBodiesSkillStone();

                break;
            case skillStones.betryal:
                betryalSkillStone();

                break;

        }





    }


    #region cummonSkillStones


    public void attackSpeedSkillStone()
    {
        effectText = "<color=yellow> Shoot Speed +10% </color>";
        icon.sprite = upgradeIcon[0];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.shootSpeed -= PlayerStatMachine.instance.shootSpeed * 0.10f;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });


    }

    public void healthSkillStone()
    {
        effectText = "<color=green>Max Health +20% </color>";
        icon.sprite = upgradeIcon[1];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.maxHealth += Mathf.RoundToInt(PlayerStatMachine.instance.maxHealth * 0.20f);
            PlayerMechanics.instance.currentPlayerHealth += Mathf.RoundToInt(PlayerStatMachine.instance.maxHealth * 0.20f);
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });

    }


    public void damageSkillStone()
    {
        effectText = "<color=red>Damage +25% </color>";
        icon.sprite = upgradeIcon[2];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.damage += Mathf.RoundToInt(PlayerStatMachine.instance.damage * 0.25f);
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });

    }

    public void relaodSpeedSkillStone()
    {
        effectText = "<color=yellow>Reload Speed +15% </color>";
        icon.sprite = upgradeIcon[3];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.reloadTime -= PlayerStatMachine.instance.reloadTime * 0.15f;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });
    }
    #endregion

    #region uncommonSkillStones

    public void maxAmmunitionSkillStone()
    {
        effectText = "<color=yellow>Max Ammunition +35% </color>";
        icon.sprite = upgradeIcon[4];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.maxAmmunition += Mathf.RoundToInt(PlayerStatMachine.instance.maxAmmunition * 0.35f);
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();
            destoryAllCards();
        });


    }


    public void healSkillStone()
    {
        effectText = "<color=green> Heal +50% </color>";
        icon.sprite = upgradeIcon[5];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerMechanics.instance.currentPlayerHealth += Mathf.RoundToInt(PlayerStatMachine.instance.maxHealth * 0.50f);
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });



    }
    #endregion

    #region rareSkillStones
    public void bulletPenetrationSkillStone()
    {
        effectText = "Bullet Penetration +1";
        icon.sprite = upgradeIcon[6];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.bulletPenetration += 1;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();
            destoryAllCards();
        });


    }


    #endregion

    #region epicSkillStones
    public void ekstraBulletSkillStone()
    {
        effectText = "Exstra Bullet";
        icon.sprite = upgradeIcon[7];



        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.bullets += 1;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });
    }

    public void betryalSkillStone()
    {
        icon.sprite = upgradeIcon[8];


        if (PlayerStatMachine.instance.hasBetryal == false)
        {
            effectText = "On death enemies will shatter into pieces dealing<color=red> 25% of bullet damage </color>";

            skillStoneButton.onClick.AddListener(() =>
            {
                PlayerStatMachine.instance.hasBetryal = true;
                SkillStoneSystem.instance.skillStoneCountResset();
                SkillStoneSystem.instance.skillStoneTakeAmount--;

                destoryAllCards();
            });
        }
        else
        {
            effectText = "Betrayal <color=red>damage +25%</color>";

            skillStoneButton.onClick.AddListener(() =>
            {
                PlayerStatMachine.instance.betryalDamageMultiplier += 0.25f;
                SkillStoneSystem.instance.skillStoneCountResset();
                SkillStoneSystem.instance.skillStoneTakeAmount--;

                destoryAllCards();
            });
        }



    }
    public void explosiveBodiesSkillStone()
    {
        icon.sprite = upgradeIcon[9];

        if (PlayerStatMachine.instance.hasExplosiveBoodies == false)
        {
            effectText = "Enemies will explode dealing <color=red>15 damage</color> to all nearby enemies";

            skillStoneButton.onClick.AddListener(() =>
            {
                PlayerStatMachine.instance.hasExplosiveBoodies = true;
                SkillStoneSystem.instance.skillStoneCountResset();
                SkillStoneSystem.instance.skillStoneTakeAmount--;

                destoryAllCards();
            });
        }
        else
        {
            effectText = "Explosive Bodies <color=red>damage +30%</color>";

            skillStoneButton.onClick.AddListener(() =>
            {
                PlayerStatMachine.instance.enemyExplodeDamage += Mathf.RoundToInt(PlayerStatMachine.instance.enemyExplodeDamage * 0.30f);
                SkillStoneSystem.instance.skillStoneCountResset();
                SkillStoneSystem.instance.skillStoneTakeAmount--;


                destoryAllCards();
            });

           
        }


    }

    #endregion    
    public void destoryAllCards()
    {
        SkillStoneSystem.skillStoneEnum = 0;

        foreach (Transform child in transform.parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        discriptionTxt.text = effectText;
    }
}
