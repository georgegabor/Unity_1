using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPractice : MonoBehaviour
{
    [SerializeField] Color a, b;
    [SerializeField] Vector3 posA, posB;
    [SerializeField, Range(0, 1)] float t;
    [SerializeField] Color lerpColor;
    [SerializeField] Vector3 lerpPos;

    private void OnValidate()
    {
        lerpColor = Color.Lerp(a, b, t);
        lerpPos = Vector3.Lerp(posA, posB, t);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = b;
        Gizmos.DrawWireSphere(posA, 0.3f);

        Gizmos.color = a;
        Gizmos.DrawWireSphere(posB, 0.3f);

        Gizmos.color = lerpColor;
        Gizmos.DrawWireSphere(lerpPos, 0.3f);

    }
}
