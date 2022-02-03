using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            KeyboardInput();
        }
        else
        {
            SwipeInput();
        }
    }

    private void KeyboardInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
    }

    private void SwipeInput()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);

        _direction = touch.phase == TouchPhase.Moved
            ? new Vector2(touch.deltaPosition.x, 0f)
            : Vector2.zero;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * (_moveSpeed * Time.deltaTime));
    }
}