using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _angle = 0.67f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InitPush();
    }

    private void InitPush()
    {
        var direction = Random.value < 0.5f ? Vector2.left : Vector2.right;
        direction.y = Random.Range(-_angle, _angle);
        _rigidbody2D.velocity = direction * _moveSpeed;
    }
}
