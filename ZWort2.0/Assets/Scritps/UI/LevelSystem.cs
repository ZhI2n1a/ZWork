using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int level = 1;
    private float currentXp;
    private float requiredXp = 100;

    private int enemyC = 0;

    [Header("UI")]
    public Image xpBar;
    public Text textLevel;

    void Start()
    {
        xpBar.fillAmount = currentXp / requiredXp;
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
            textLevel.text = level.ToString();
        }
    }

    void Update()
    {
        UpdateXpUI();
        if (enemyCount.enemy > enemyC)
        {
            GainExperienceFlatRate(10);
            enemyC = enemyCount.enemy;
        }

        if (currentXp > requiredXp)
        {
            LevelUp();
            textLevel.text = level.ToString();
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

    public void LevelUp()
    {
        level++;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
        xpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
    }
}
