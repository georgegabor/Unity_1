using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    // [SerializeField] float speed = 2;
    [SerializeField] Transform target;
    [SerializeField] AnimationCurve speedOverDistance;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = target.position;
        Vector3 selfPoint = transform.position;

        float distance = Vector3.Distance(transform.position, target.position);
        float speed = speedOverDistance.Evaluate(distance);
        float maxStep = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(selfPoint, targetPoint, maxStep);

        if (targetPoint != selfPoint)
            transform.rotation = Quaternion.LookRotation(targetPoint - selfPoint);
    }
}
