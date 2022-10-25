using UnityEngine;

public class ClickExplosion : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] float maxForce = 5;
    [SerializeField] float range = 10;
    [SerializeField] float upward = 3;
    [SerializeField] LayerMask rayCastLayers;
    [SerializeField] new ParticleSystem particleSystem;

    Rigidbody[] rigidbodies;
    Vector3 lastRayHit;

    void Start()
    {
        rigidbodies = FindObjectsOfType<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            Vector3 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            bool doesHit = Physics.Raycast(ray, out RaycastHit _hit, 100, rayCastLayers);

            // e.g If using a rifle
            // Ray otherRay = new Ray(transform.position, transform.forward);

            if (doesHit)
            {
                lastRayHit = _hit.point;
                particleSystem.Play();
                transform.position = lastRayHit;
                // Debug.Log("Name: " + _hit.collider.name + " Point:  " + _lastRayHit);
                ExplodeAll(lastRayHit);
            }
        }
    }

    void ExplodeAll(Vector3 position)
    {
        foreach (Rigidbody _rigidbody in rigidbodies)
        {
            _rigidbody.AddExplosionForce(maxForce, position, range, upward, ForceMode.Impulse);
            // EplodeOne(position, _rigidbody);
        }
    }

    private void EplodeOne(Vector3 position, Rigidbody _rigidbody)
    {
        Vector3 distanceVect = _rigidbody.position - position;
        float distance = distanceVect.magnitude;
        Vector3 direction = distanceVect.normalized;

        if (distance < range)
        {
            float force = maxForce * (range - distance) / range;

            _rigidbody.AddForce(direction * force, ForceMode.Impulse);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(lastRayHit, .2f);

    }
}
