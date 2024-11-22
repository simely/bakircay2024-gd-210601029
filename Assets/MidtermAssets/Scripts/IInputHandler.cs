using System;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public interface IInputHandler
    {
        public event Action OnTouchBegan;
        public event Action<Vector2> OnTouchMoved;
        public event Action OnTouchEnded;

        public Vector2 GetTouchPosition();
    }
}