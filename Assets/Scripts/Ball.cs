using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public static event Action OutOfScreenEvent;

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
            UpdateColor();
            Push();
        }

        private void UpdateColor()
        {
            _spriteRenderer.color = PlayerSettings.LoadColor();
        }

        private void Push()
        {
            var direction = Random.value < 0.5f ? Vector2.down : Vector2.up;
            direction.x = Random.insideUnitCircle.x;
            _rigidbody2D.velocity = direction * _moveSpeed;
        }

        private void ResetBall()
        {
            _rigidbody2D.position = Vector2.zero;
            _rigidbody2D.velocity = Vector2.zero;
        }

        private void RandomizeBall()
        {
            _moveSpeed = Random.Range(8f, 12f);
            _transform.localScale = Vector3.one * Mathf.Clamp(Random.value, 0.5f, 1.1f);
        }

        private void OnBecameInvisible()
        {
            OutOfScreenEvent?.Invoke();
            ResetBall();
            RandomizeBall();
            Push();
        }
    }
}