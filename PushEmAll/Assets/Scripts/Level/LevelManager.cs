using Assignment.Events;
using UnityEngine;

namespace Assignment.Level
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField] private int _startEnemyCount = 10;

        // Start is called before the first frame update
        void Start()
        {
            // test
            //Invoke(nameof(InitializeAI), 1f);
        }

        public void InitializeAI()
        {
            GameEvents.Instance.EnterEnemyZone(_startEnemyCount);
        }
    }
}