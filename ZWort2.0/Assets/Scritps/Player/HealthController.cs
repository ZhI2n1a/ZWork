using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public GameObject DeathWindow;
    public SpriteRenderer playerBlood;

    private void Update()
    {
        if (_currentHealth <= 50)
        {
            playerBlood.color = Color.red;
        }
    }
    public void DeathWindowOpen()
    {
        if (DeathWindow != null)
        {
            if (_currentHealth <= 0)
            {
                bool isActive = DeathWindow.activeSelf;
                DeathWindow.SetActive(!isActive);
            }
        }
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    //private IEnumerator HealthUp(float rezitTime)
    //{
    //    playerBlood.color = Color.red;
    //    yield return new WaitForSeconds(rezitTime);
    //    _currentHealth = 100;
    //    playerBlood.color = Color.white;
    //}

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
            return;

        if (IsInvincible)
            return;

        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
            _currentHealth = 0;

        if (_currentHealth == 0)
            OnDied.Invoke();
        else OnDamaged.Invoke();
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
            return;

        _currentHealth += amountToAdd;

        if (_currentHealth > _maximumHealth)
            _currentHealth = _maximumHealth;
    }
}
