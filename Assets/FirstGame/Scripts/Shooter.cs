using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    enum ShootingPattern
    {
        Random, Sequence, Keyboard
    }

    [Header("Inputs")]
    [SerializeField] GameObject[] projectilePrototypes;
    [SerializeField] KeyCode[] keys;
    [SerializeField] float speed = 25;
    [SerializeField] ShootingPattern pattern;

    int count = 0;
    int bulletIndex = 0;

    private void Update()
    {
        BulletSelect();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void BulletSelect()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            KeyCode keyCode = keys[i];

            if (Input.GetKeyDown(keyCode))
            {
                bulletIndex = i;
            }
        }
    }

    private void Shoot()
    {
        GameObject proto;
        int randomNum = 0;

        if (pattern == ShootingPattern.Random)
        {
            randomNum = Random.Range(0, projectilePrototypes.Length);
            proto = projectilePrototypes[randomNum];

        }
        else if (pattern == ShootingPattern.Sequence)
        {
            int index = count % projectilePrototypes.Length;
            proto = projectilePrototypes[index]; ;
        }
        else
        {
            int safeIndex = Mathf.Clamp(bulletIndex, 0, projectilePrototypes.Length - 1);
            proto = projectilePrototypes[safeIndex];
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

    private void Awake()
    {

        Debug.Log("Awake");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");

    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");

    }
}
