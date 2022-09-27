using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    [SerializeField]
    Vector2 p1;

    [SerializeField]
    Vector2 p2;

    [SerializeField]
    float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(p1, p2);
    }
}
