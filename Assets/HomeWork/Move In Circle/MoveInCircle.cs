using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField]
    Vector3 origo = new Vector3(0, 1, 0);

    [SerializeField]
    float angularSpeed = 180;

    float radius;

    float currentAngle = 0;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        radius = Vector3.Distance(startingPos, origo);

        // Vector2 v = transform.position - origo;
        // currentAngle = Vector2.Angle(v, Vector2.right);
        // radius = v.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset =
            new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) *
            radius;
        transform.position = startingPos + new Vector3(offset.x, 0, offset.y);

        // Növelem a jelenlegi szöget a szögsebességnek megfeleően.
        // currentAngle += angularSpeed * Time.deltaTime;

        // Szinusz és Coszinusz függvényekből állítom elő a pozíciót
        // float angleInRadians = currentAngle * Mathf.Deg2Rad;
        // float x = Mathf.Cos(angleInRadians);
        // float y = Mathf.Sin(angleInRadians);
        // Vector3 pos = new Vector3(x, 0, y);

        // pos *= radius; // Átméretezem a kört sugár szerint
        // pos += origo; // Eltolom a pozíciót a középponttól

        // transform.position = pos;
    }
}
