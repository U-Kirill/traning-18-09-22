using System;
using UnityEngine;

public interface IPlayerMove
{
    event Action Moved;
    Vector3 Position { get; }
    void Freeze();
}