using UnityEngine;

public class ClickExplosion : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] float _maxForce = 5;
    [SerializeField] float _range = 10;
    [SerializeField] float _upward = 3;

    Rigidbody[] _rigidbodies;

    Vector3 _lastRayHit;

    void Start()
    {
        _rigidbodies = FindObjectsOfType<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera _cam = Camera.main;
            Vector3 _mousePos = Input.mousePosition;
            Ray _ray = _cam.ScreenPointToRay(_mousePos);
            bool _doesHit = Physics.Raycast(_ray, out RaycastHit _hit);

            if (_doesHit)
            {
                _lastRayHit = _hit.point;
                // Debug.Log("Name: " + _hit.collider.name + " Point:  " + _lastRayHit);
                _ExplodeAll(_lastRayHit);
            }
        }
    }

    void _ExplodeAll(Vector3 position)
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            Rigidbody _rigidbody = _rigidbodies[i];
            _rigidbody.AddExplosionForce(_maxForce, position, _range, _upward, ForceMode.Impulse);



            // _EplodeOne(position, _rigidbody);

        }
    }

    private void _EplodeOne(Vector3 position, Rigidbody _rigidbody)
    {
        Vector3 distanceVect = _rigidbody.position - position;
        float distance = distanceVect.magnitude;
        Vector3 direction = distanceVect.normalized;

        if (distance < _range)
        {
            float force = _maxForce * (_range - distance) / _range;

            _rigidbody.AddForce(direction * force, ForceMode.Impulse);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_lastRayHit, .2f);

    }
}
