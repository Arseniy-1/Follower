using UnityEngine;

public class MouseInputHandler : MonoBehaviour 
{
    private const string MouseY = "Mouse Y";
    private const string MouseX = "Mouse X";

    public float VerticalAxis { get; private set; }
    public float HorizontalAxis { get; private set; }

    private void Update()
    {
        VerticalAxis = Input.GetAxis(MouseY);
        HorizontalAxis = Input.GetAxis(MouseX);
    }
}

