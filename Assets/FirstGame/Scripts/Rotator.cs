using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float angularSpeed = 150;
    [SerializeField] Space space;

    // Update is called once per frame
    void Update()
    {
        float rotation = angularSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0, space);
    }
}
