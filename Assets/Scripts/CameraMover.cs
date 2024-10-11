using UnityEngine;

public partial class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalTurnSensitivity = 10;
    [SerializeField] private float _verticalTurnSensitivity = 10;
    [SerializeField] private MouseInputHandler _mouseInputHandler;

    private float _cameraCurrentAngleX;

    public Vector3 ForwardDirection { get; private set; }
    public Vector3 RightDirection { get; private set; }
    public Vector3 RotateDirection => Vector3.up * _horizontalTurnSensitivity * _mouseInputHandler.HorizontalAxis;

    private void Awake()
    {
        _cameraCurrentAngleX = _cameraTransform.localEulerAngles.x;
    }

    private void Update()
    {
        ForwardDirection = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        RightDirection = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

        _cameraCurrentAngleX -= _mouseInputHandler.VerticalAxis * _verticalTurnSensitivity;
        _cameraCurrentAngleX = Mathf.Clamp(_cameraCurrentAngleX, -89, 89);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraCurrentAngleX;
    }
}

