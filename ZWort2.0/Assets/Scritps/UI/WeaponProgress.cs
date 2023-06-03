using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponProgress : MonoBehaviour
{
    private float currentXp;
    private float requiredXp = 100;

    private int enemyC = 0;

    [Header("UI")]
    public Image xpBar;
    public GameObject weapon;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
    

    void Start()
    {
        xpBar.fillAmount = currentXp / requiredXp;
    }

    void Update()
    {
        UpdateXpUI();
        if (enemyCount.enemy > enemyC)
        {
            if (enemyC < 13)
            {
                GainExperienceFlatRate(3);
                enemyC = enemyCount.enemy;
                if(enemyC == 6)
                    ButtonActive(weapon);
                if (enemyC == 12)
                    ButtonActive(weapon1);
            }
            else if (enemyC >= 12 && enemyC < 22)
            {
                GainExperienceFlatRate(2);
                enemyC = enemyCount.enemy;
                if (enemyC == 21)
                    ButtonActive(weapon2);
            }
            else if (enemyC >= 21 && enemyC < 56)
            {
                GainExperienceFlatRate(1);
                enemyC = enemyCount.enemy;
                if(enemyC == 37)
                    ButtonActive(weapon3);
                if (enemyC == 55)
                    ButtonActive(weapon4);
            }
            else if (enemyC >= 55)
            {
                GainExperienceFlatRate(0.5f);
                enemyC = enemyCount.enemy;
                if(xpBar.fillAmount == 1f)
                    ButtonActive(weapon5);
            }
        }
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requiredXp;
        xpBar.fillAmount = xpFraction;
    }

    public void GainExperienceFlatRate(float xpGrained)
    {
        currentXp += xpGrained;
    }

    public void ButtonActive(GameObject weaponUp)
    {
        weaponUp.SetActive(true);
    }
}
