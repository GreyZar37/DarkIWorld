using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class skillStoneEffect : MonoBehaviour
{


    public TextMeshProUGUI effectText;

    public Sprite[] skillStoneFrames;
    public Image frame;


    public Button skillStoneButton;


    private void Awake()
    {


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
            case skillStones.ammoPrRelaod:
                ammoPrRelaodSkillStone();

                break;                

        }





    }


    #region cummonSkillStones


    public void attackSpeedSkillStone()
    {
        effectText.text = "Shoot Speed +10%";
        frame.sprite = skillStoneFrames[0];


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
        effectText.text = "Max Health +20%";
        frame.sprite = skillStoneFrames[0];


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
        effectText.text = "Damage +25%";
        frame.sprite = skillStoneFrames[0];


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
        effectText.text = "Relaod Speed +29%";
        frame.sprite = skillStoneFrames[0];


        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.relaodSpeed -= PlayerStatMachine.instance.relaodSpeed * 0.20f;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });
    }
    #endregion

    #region uncommonSkillStones

    public void maxAmmunitionSkillStone()
    {
        effectText.text = "Max Ammunition +35%";
        frame.sprite = skillStoneFrames[1];


        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.maxAmmunition += Mathf.RoundToInt(PlayerStatMachine.instance.maxAmmunition * 0.35f);
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();
            destoryAllCards();
        });


    }
    public void bulletPenetrationSkillStone()
    {
        effectText.text = "Bullet Penetration +1";
        frame.sprite = skillStoneFrames[1];


        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.bulletPenetration += 1;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();
            destoryAllCards();
        });


    }

    public void healSkillStone()
    {
        effectText.text = "Heal +50%";
        frame.sprite = skillStoneFrames[1];


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

    public void ammoPrRelaodSkillStone()
    {
        effectText.text = "Ammo relaod +1";
        frame.sprite = skillStoneFrames[2];


        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.ammoPrRelaod += 1;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });
    }

    #endregion

    #region epicSkillStones
    public void ekstraBulletSkillStone()
    {
        effectText.text = "Exstra Bullet";
        frame.sprite = skillStoneFrames[3];


        skillStoneButton.onClick.AddListener(() =>
        {
            PlayerStatMachine.instance.bullets += 1;
            SkillStoneSystem.instance.skillStoneTakeAmount--;
            SkillStoneSystem.instance.skillStoneCountResset();

            destoryAllCards();
        });


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
}
