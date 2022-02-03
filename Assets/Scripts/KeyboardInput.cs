using UnityEngine;

namespace Pong
{
    public class KeyboardInput : MonoBehaviour, IPlayerInput
    {
        public Vector2 Direction { get; private set; }
        public float MoveSpeed { get; private set; }

        private void Awake()
        {
            MoveSpeed = 15f;
        }

        private void Update()
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
    }
}