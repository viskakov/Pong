using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        LoadColor();
        Push();
    }

    private void Push()
    {
        var direction = Random.value < 0.5f ? Vector2.down : Vector2.up;
        direction.x = Random.insideUnitCircle.x;
        _rigidbody2D.velocity = direction * _moveSpeed;
    }

    private void ResetPosition()
    {
        _rigidbody2D.position = Vector2.zero;
    }

    private void RandomizeBall()
    {
        _moveSpeed = Random.Range(8f, 12f);
        _transform.localScale = Vector3.one * Mathf.Clamp(Random.value, 0.5f, 1.1f);
    }

    private void LoadColor()
    {
        if (!PlayerPrefs.HasKey("BallColor")) return;

        var stringColor = "#" + PlayerPrefs.GetString("BallColor");
        if (ColorUtility.TryParseHtmlString(stringColor, out var color))
        {
            _spriteRenderer.color = color;
        }
    }

    private void OnBecameInvisible()
    {
        ResetPosition();
        RandomizeBall();
        Push();
    }
}
