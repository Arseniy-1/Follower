using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _strafeSpeed = 3f;
    [SerializeField] private KeyboardHandler _inputHandler;
    [SerializeField] private CameraMover _cameraMover;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 playerDirection = _cameraMover.ForwardDirection * _inputHandler.VerticalAxis * _speed + _cameraMover.RightDirection * _inputHandler.HorizontalAxis * _strafeSpeed;
        playerDirection *= Time.deltaTime;

        transform.Rotate(_cameraMover.RotateDirection);

        if (_characterController.isGrounded)
        {
            _characterController.Move(playerDirection + Vector3.down);
        }
        else
        {
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
    }
}
