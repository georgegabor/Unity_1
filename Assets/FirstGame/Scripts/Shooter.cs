using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] GameObject projectilePrototype;
    [SerializeField] float speed = 25;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectilePrototype);

            projectile.transform.position = transform.position;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            Vector3 direction = transform.forward;

            Vector3 v = transform.TransformVector(Vector3.up);
            Vector3 v2 = transform.InverseTransformVector(v);
            direction.Normalize();

            rb.velocity = direction * speed;
        }
    }
}
