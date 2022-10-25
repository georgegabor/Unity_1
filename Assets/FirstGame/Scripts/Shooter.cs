using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    enum ShootingPattern
    {
        Random, Sequence
    }

    [Header("Inputs")]
    [SerializeField] GameObject[] projectilePrototypes;
    [SerializeField] float speed = 25;
    [SerializeField] ShootingPattern pattern = ShootingPattern.Random;

    int count = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proto;
            int randomNum = 0;

            if (pattern == ShootingPattern.Random)
            {
                randomNum = Random.Range(0, projectilePrototypes.Length);
                proto = projectilePrototypes[randomNum];

            }
            else
            {
                int index = count % projectilePrototypes.Length;
                proto = projectilePrototypes[index]; ;
            }


            GameObject projectile = Instantiate(proto);
            projectile.transform.position = transform.position;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            Vector3 direction = transform.forward;

            Vector3 v = transform.TransformVector(Vector3.up);
            Vector3 v2 = transform.InverseTransformVector(v);
            direction.Normalize();

            rb.velocity = direction * speed;

            count++;
        }
    }
}
