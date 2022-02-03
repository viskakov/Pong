using UnityEngine;

namespace Pong
{
    public interface IPlayerInput
    {
        public Vector2 Direction { get; }
        public float MoveSpeed { get; }
    }
}