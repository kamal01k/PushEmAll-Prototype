using Assignment.Events;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assignment.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI enemyText;
        [SerializeField] private GameObject startBtn;
        [SerializeField] private GameObject retryBtn;
        [SerializeField] private GameObject scoreCanvas;

        private int _score = 0;

        // Start is called before the first frame update
        void Start()
        {
            startBtn.GetComponent<UITapAction>().OnTapAction = StartGame;
            retryBtn.GetComponent<UITapAction>().OnTapAction = RetryGame;
        }

        public void ScoreCount(int a_score)
        {
            _score += a_score; 
            scoreText.text = $"Score - {_score}";
        }

        public void EnemyCount(int a_enemyCount)
        {
            enemyText.text = $"Enemy - {a_enemyCount}";
        }

        private void StartGame()
        {
            startBtn.SetActive(false);
            scoreCanvas.SetActive(true);
            GameEvents.Instance.StartGame();
        }

        private void RetryGame()
        {
            scoreCanvas.SetActive(true);
            retryBtn.SetActive(false);
        }

        public void GameOver()
        {
            retryBtn.SetActive(true);
            // temp load scene again
            SceneManager.LoadScene(0);
        }
    }
}