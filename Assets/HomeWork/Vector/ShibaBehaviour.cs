using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cartoon Baby");
    }

    // Update is called once per frame
    void Update()
    {
        float maxStep = speed * Time.deltaTime;
        Vector3 targetPoint = target.transform.position;
        Vector3 selfPoint = transform.position;

        // Objects x must be -90 to stand straight up
        // Vector3 eulerRotation = transform.rotation.eulerAngles;
        // transform.rotation = Quaternion.Euler(-90, eulerRotation.y, 90);

        // transform.position =
        //     Vector3.MoveTowards(selfPoint, targetPoint, maxStep);

        // if ((targetPoint - selfPoint) != Vector3.zero)
        // {
        //     transform.rotation =
        //         Quaternion.LookRotation(targetPoint - selfPoint);
        //     // Quaternion targetRot =
        //     //     Quaternion.LookRotation(targetPoint - selfPoint);

        //     // transform.rotation =
        //     //     Quaternion
        //     //         .RotateTowards(transform.rotation, targetRot, maxStep);
        // }
    }
}
