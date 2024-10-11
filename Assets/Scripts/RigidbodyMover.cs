using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Player _player;

    private float _targetDistance = 3f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        float gravityFactor = 0.5f;
        Vector3 direction;

        if (Vector3.Distance(_player.transform.position, transform.position) <= _targetDistance)
        {
            direction = Vector3.zero;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(_player.transform.position - transform.position, Vector3.up).normalized;
        }

        direction.y -= gravityFactor;
        _rigidbody.velocity = direction * _speed;
    }
}
