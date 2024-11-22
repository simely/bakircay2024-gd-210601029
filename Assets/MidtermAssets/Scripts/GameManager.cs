using System;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MouseHandler m_mouseHandler;
        [SerializeField] private InteractionHandler m_interactionHandler;
        [SerializeField] private RandomObjectSpawner m_objectSpawner;
        private IInputHandler _inputHandler;

        private void Start()
        {
            Init();
        }

        private void OnDestroy()
        {
            DeInit();
        
        }

        private void Init()
        {
            _inputHandler = m_mouseHandler;

            m_interactionHandler.SetupInputHandler(_inputHandler);
            m_interactionHandler.Init();
            m_objectSpawner.SpawnObjects();
        }

        private void DeInit()
        {
            m_interactionHandler.DeInit();
        }
    }
}