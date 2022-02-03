using UnityEngine;

public class TouchInput : MonoBehaviour, IPlayerInput
{
    public Vector2 Direction { get; private set; }
    public float MoveSpeed { get; private set; }

    private void Awake()
    {
        MoveSpeed = 3f;
    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);

        Direction = touch.phase == TouchPhase.Moved
            ? new Vector2(touch.deltaPosition.x, 0f)
            : Vector2.zero;
    }
}