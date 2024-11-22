using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private PlacementArea m_placementArea;
        private IInputHandler _inputHandler;
        private int _interactableMask;


        private IInteractableObject _selectedInteractable;


        public void SetupInputHandler(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Init()
        {
            _interactableMask = LayerMask.GetMask("Interactable");


            _inputHandler.OnTouchBegan += OnTouchBegan;
            _inputHandler.OnTouchEnded += OnTouchEnded;
            _inputHandler.OnTouchMoved += OnTouch;
        }

        public void DeInit()
        {
            _inputHandler.OnTouchBegan -= OnTouchBegan;
            _inputHandler.OnTouchEnded -= OnTouchEnded;
            _inputHandler.OnTouchMoved -= OnTouch;
        }

        private void OnTouchBegan()
        {
            if (!TryRaycast(_interactableMask, out var hit)) return;
            var interactable = hit.collider.GetComponentInParent<IInteractableObject>();
            if (interactable == null || !interactable.IsInteractable) return;
            _selectedInteractable = interactable;
            interactable?.OnEnter();
        }

        private void OnTouch(Vector2 delta)
        {
            _selectedInteractable?.OnMove(delta);
        }

        private bool TryRaycast(LayerMask mask, out RaycastHit hit)
        {
            var cam = Camera.main;
            var ray = cam.ScreenPointToRay(_inputHandler.GetTouchPosition());
            if (Physics.Raycast(ray, out hit, 1000f, mask)) return true;
            return false;
        }

        private void OnTouchEnded()
        {
            if (_selectedInteractable == null)
            {
                return;
            }
            if (!_selectedInteractable.IsInteractable) return;

            if (m_placementArea.Contains(_selectedInteractable.GetTransform())) _selectedInteractable.OnPutPlacementArea(m_placementArea);
            else _selectedInteractable.OnExit();

            _selectedInteractable = null;
        }
    }
}