using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    // [SerializeField] float speed = 2;
    [SerializeField] Transform target;
    [SerializeField] AnimationCurve speedOverDistance;

    [SerializeField] new Rigidbody rigidbody;

    private void OnValidate()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        Vector3 targetPoint = target.position;
        Vector3 selfPoint = transform.position;

        float distance = Vector3.Distance(transform.position, target.position);
        float speed = speedOverDistance.Evaluate(distance);
        /*
        float maxStep = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(selfPoint, targetPoint, maxStep);
         */

        Vector3 directon = targetPoint - selfPoint;
        directon.Normalize();

        rigidbody.velocity = directon * speed;

        if (targetPoint != selfPoint)
            transform.rotation = Quaternion.LookRotation(targetPoint - selfPoint);
    }
}
