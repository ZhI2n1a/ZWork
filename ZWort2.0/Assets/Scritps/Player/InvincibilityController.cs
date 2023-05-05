using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invncibilityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invncibilityDuration);
        _healthController.IsInvincible = false;
    }
}
