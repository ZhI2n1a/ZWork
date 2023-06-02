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

    void Start()
    {
        xpBar.fillAmount = currentXp / requiredXp;
    }

    void Update()
    {
        UpdateXpUI();
        if (enemyCount.enemy > enemyC)
        {
            GainExperienceFlatRate(10);
            enemyC = enemyCount.enemy;
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
}
