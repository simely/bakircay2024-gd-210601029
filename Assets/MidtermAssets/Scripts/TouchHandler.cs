using System;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class TouchHandler : MonoBehaviour, IInputHandler
    {
        public event Action OnTouchBegan;
        public event Action<Vector2> OnTouchMoved;
        public event Action OnTouchEnded;

        public Vector2 GetTouchPosition()
        {
            return Input.GetTouch(0).position;
        }

        private void Update()
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchBegan?.Invoke();
                    break;
                case TouchPhase.Moved:
                    OnTouchMoved?.Invoke(touch.deltaPosition);
                    break;
                case TouchPhase.Ended:
                    OnTouchEnded?.Invoke();
                    break;
            }
        }
    }
}