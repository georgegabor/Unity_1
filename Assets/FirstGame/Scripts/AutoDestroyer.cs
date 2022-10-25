using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{

    [Header("Inputs")]
    [SerializeField] float destructionTime = 1;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;

        if (currentTime - startTime > destructionTime)
        {
            Destroy(gameObject);
        }
    }
}
