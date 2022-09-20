using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorPractice : MonoBehaviour
{
    void OnValidate()
    {
        Vector2 vector = new Vector2(2, 5);
        
        float xv = vector.x;
        float xy = vector.y;
        float f1 = 1.5f;

        vector.x = xv;
        vector.y = xy;

        Vector3 vector3 = new Vector3(1, 2, 4);

        Vector3 vUp = Vector3.up;

        Vector3 v1 = new Vector3(1 ,2 ,6) , v2  = new Vector3(1 ,2 ,6);
        Vector3 vSum = v1 + v2;
        Vector3 vProduct = v1 * f1;
        float vProductLength = vProduct.magnitude;
        Debug.Log("vProductLength: " + vProductLength);

        v1.Normalize();

        Vector3 v1Normalized = v1.normalized;
        Debug.Log("v1Normalized: " + v1Normalized);

        float dist1 = (v1 - v2).magnitude;
        float dist2 = Vector3.Distance(v1, v2);
        Debug.Log("dist1: " + dist1);


    }
}
