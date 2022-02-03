using UnityEngine;

namespace Pong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerInput : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private IPlayerInput _playerInput;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            if (Application.isEditor)
            {
                _playerInput = gameObject.AddComponent<KeyboardInput>();
            }
            else
            {
                _playerInput = gameObject.AddComponent<TouchInput>();
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _playerInput.Direction * (_playerInput.MoveSpeed * Time.deltaTime));
        }
    }
}