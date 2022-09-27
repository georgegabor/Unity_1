using UnityEngine;
using TMPro;

public class Damageable : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] TMP_Text displayedText;

    void Start()
    {
        UpdateText();
    }
    public void Damage(int damage)
    {
        health -= damage;

        if (health < 0) health = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        if (displayedText != null)
            displayedText.text = "Health: " + health;
    }
}
