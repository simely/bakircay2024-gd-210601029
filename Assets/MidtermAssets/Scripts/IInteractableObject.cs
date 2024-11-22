using UnityEngine;

namespace MidtermAssets.Scripts
{
    public interface IInteractableObject
    {
        public void OnEnter();
        public void OnMove(Vector2 delta);
        public void OnExit();
        public void OnPutPlacementArea(PlacementArea placementArea);

        public Transform GetTransform();

        public bool IsInteractable { get; }
    }
}