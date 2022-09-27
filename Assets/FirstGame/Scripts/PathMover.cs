using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] Vector3 a, b;
    [SerializeField] float speed;

    bool toA = false;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(a, .2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(b, .2f);
        Gizmos.color = new Color(1, 0, 1, 1);
        Gizmos.DrawLine(a, b);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target;

        if (toA) target = a;
        else target = b;


        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (target == transform.position) toA = !toA;

    }

    private void OnValidate()
    {
        transform.position = (a + b) / 2f;
    }
}
