using System;
using Assignment.AI;
using Assignment.Camera;
using Assignment.Level;
using Assignment.UI;
using UnityEngine;

namespace Assignment.Events
{
    public class GameEvents : MonoBehaviour, IGameEvents
    {
        public static IGameEvents Instance;

        [SerializeField] private GameObject _aiManagerObject;
        private IAIManager _aiManager;
        [SerializeField] private GameObject _cameraManagerObject;
        private ICameraManager _cameraManager;
        [SerializeField] private GameObject _uiManagerObject;
        private IUIManager _uiManager;
        [SerializeField] private GameObject _levelManagerObject;
        private ILevelManager _levelManager;

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            _aiManager = _aiManagerObject.GetComponent<AIManager>();
            _cameraManager = _cameraManagerObject.GetComponent<ICameraManager>();
            _uiManager = _uiManagerObject.GetComponent<IUIManager>();
            _levelManager = _levelManagerObject.GetComponent<ILevelManager>();
        }

        public void StartGame()
        {
            _cameraManager.StartCamera();
            _levelManager.InitializeAI();
        }

        public void EnterEnemyZone(int a_enemyCount)
        {
            _aiManager.AiCount = a_enemyCount;
        }

        public void EnemyKill()
        {
            _aiManager.EnemyKill();
        }

        public void ZoneComplete()
        {
            Debug.Log($"Zone Complete");
        }

        public void GameOver()
        {
            _cameraManager.GameoverCamera();
            _uiManager.GameOver();
        }
    }
}