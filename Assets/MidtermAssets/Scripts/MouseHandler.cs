using System;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class MouseHandler : MonoBehaviour, IInputHandler
    {
        public event Action OnTouchBegan;
        public event Action<Vector2> OnTouchMoved;
        public event Action OnTouchEnded;


        private bool _isDown;

        private Vector2 _inputPos;
        private Vector2 _lastPos;

        public Vector2 GetTouchPosition()
        {
            return Input.mousePosition;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isDown)
            {
                OnTouchBegan?.Invoke();
                _isDown = true;
                _inputPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && _isDown)
            {
                var pos = GetTouchPosition();
                OnTouchMoved?.Invoke(pos - _inputPos);
                _inputPos = pos;
            }

            if (Input.GetMouseButtonUp(0) && _isDown)
            {
                OnTouchEnded?.Invoke();
                _isDown = false;
            }
        }
    }
}