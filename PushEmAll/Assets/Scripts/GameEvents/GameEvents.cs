using Assignment.AI;
using Assignment.Camera;
using Assignment.Level;
using Assignment.Player;
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
        [SerializeField] private GameObject _playerObject;
        private IPlayerController _player;

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
            _player = _playerObject.GetComponent<IPlayerController>();
        }

        public void StartGame()
        {
            _cameraManager.StartCamera();
            _levelManager.InitializeAI();
            _player.ControllerActive = true;
        }

        public void EnterEnemyZone()
        {
            _levelManager.InitilizeNextZone();
        }

        public void EnterEnemyZone(int a_enemyCount)
        {
            _aiManager.AiCount = a_enemyCount;
            _uiManager.EnemyCount(_aiManager.AiCount);
        }

        public void EnemyKill()
        {
            _aiManager.EnemyKill();
            _uiManager.EnemyCount(_aiManager.AiCount);
            _uiManager.ScoreCount(10);
        }

        public void ZoneComplete()
        {
            _levelManager.ActivateLevelBridge();
        }

        public void GameOver()
        {
            _cameraManager.GameoverCamera();
            _uiManager.GameOver();
            _player.ControllerActive = false;
        }
        
        public void LevelFinish()
        {
            Debug.Log("Level Finish");
            _player.ControllerActive = false;
        }
    }
}