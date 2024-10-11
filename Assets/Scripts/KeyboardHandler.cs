using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float VerticalAxis { get; private set; }
    public float HorizontalAxis { get; private set; }

    private void Update()
    {
        VerticalAxis = Input.GetAxis(Vertical);
        HorizontalAxis = Input.GetAxis(Horizontal);
    }
}
