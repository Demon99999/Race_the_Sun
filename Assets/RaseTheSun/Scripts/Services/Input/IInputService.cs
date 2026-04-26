using System;
using UnityEngine;

namespace RaseTheSun.Scripts.Services.Input
{
    public interface IInputService
    {
        event Action Jumped;
        Vector2 Direction { get; }
    }
}
