using System;
using UnityEngine;

internal interface IMessageSystem
{
    event Action AllCollected;
    void OnPlayerMoved(Vector3 position);
}