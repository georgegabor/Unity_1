using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null)
        {
            Debug.Log("Damage " + damageable.name + "with " + damage + " unit.");
            damageable.Damage(damage);
        }
    }
}
