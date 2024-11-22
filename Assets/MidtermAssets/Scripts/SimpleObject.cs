using System.Collections;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class SimpleObject : MonoBehaviour, IInteractableObject
    {
        private Rigidbody _rb;
        private Vector3 _defaultScale;

        [SerializeField] private Renderer m_renderer;
        [SerializeField] private AnimationCurve m_scaleDownCurve;
        [SerializeField] private float m_speed;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            m_renderer.material.color = Random.ColorHSV();
        }

        public void OnEnter()
        {
            _rb.isKinematic = true;
            var t = transform;
            var pos = t.position;
            pos.y = 2f;
            t.position = pos;

            _defaultScale = t.localScale;
            t.localScale *= 1.4f;
            
            t.eulerAngles = Vector3.zero;
        }
        
        public void OnMove(Vector2 sizeDelta)
        {
            var delta = new Vector3(sizeDelta.x, 0, sizeDelta.y);
            transform.position += delta * m_speed * Time.deltaTime;
        }

        public void OnExit()
        {
            transform.localScale = _defaultScale;
            _rb.isKinematic = false;
        }

        public void OnPutPlacementArea(PlacementArea placementArea)
        {
            StartCoroutine(scaleDownAnim());

            IEnumerator scaleDownAnim()
            {
                IsInteractable = false;
                var duration = .15f;
                var timer = 0f;
                var startScale = transform.localScale;
                while (timer < duration)
                {
                    timer += Time.deltaTime;
                    var scale = m_scaleDownCurve.Evaluate(Mathf.Min(1,timer / duration));
                    transform.localScale = startScale * scale;
                    yield return null;
                }

                IsInteractable = true;
                Destroy(gameObject);
            }
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public bool IsInteractable { get; private set; } = true;
    }
}