using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class Damageable : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] TMP_Text displayedText;
    [SerializeField] Behaviour behaviour;
    [SerializeField] float invicibilityFrames = 5;

    bool isInvincible = false;
    void Start()
    {
        UpdateText();
    }

    public void Damage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        health -= damage;

        StartCoroutine(InvincibilityCoroutine());

        if (health < 0)
        {
            health = 0;
            behaviour.enabled = false;
        }

        UpdateText();
    }

    IEnumerator InvincibilityCoroutine()
    {
        const float flickTime = 0.1f;
        isInvincible = true;

        bool visible = false;
        for (int i = 0; i < invicibilityFrames / flickTime; i++)
        {
            SetVisibility(visible);
            visible = !visible;
            yield return new WaitForSeconds(invicibilityFrames);
        }

        SetVisibility(true);
        isInvincible = false;
    }

    private void SetVisibility(bool isVisible)
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        foreach (var renderer in renderers)
        {
            renderer.enabled = isVisible;
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    private void UpdateText()
    {
        if (displayedText != null)
            displayedText.text = "Health: " + health;
    }

}
