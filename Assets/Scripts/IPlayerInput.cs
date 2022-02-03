using UnityEngine;

public interface IPlayerInput
{
    public Vector2 Direction { get; }
    public float MoveSpeed { get; }
}