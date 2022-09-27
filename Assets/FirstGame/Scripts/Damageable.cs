using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int health;

    public void Damage(int damage)
    {
        health -= damage;

        if (health < 0) health = 0;
    }
}
