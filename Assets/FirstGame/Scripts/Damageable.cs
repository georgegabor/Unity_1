using UnityEngine;
using TMPro;
using System;

public class Damageable : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] TMP_Text displayedText;
    [SerializeField] Behaviour behaviour;

    void Start()
    {
        UpdateText();
    }

    public void Damage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            behaviour.enabled = false;
        }

        UpdateText();
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
