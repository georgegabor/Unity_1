using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    // Update is called once per frame
    void Update()
    {
        float rotation = angularSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
