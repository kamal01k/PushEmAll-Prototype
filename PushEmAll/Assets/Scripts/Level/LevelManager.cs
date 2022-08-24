using System.Collections.Generic;
using Assignment.Events;
using Assignment.Zone;
using DG.Tweening;
using UnityEngine;

namespace Assignment.Level
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField] private int _startEnemyCount = 10;
        [SerializeField] private List<LevelZone> _levelZoneList;
        [SerializeField] private int _currentZone;

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

        public void InitilizeNextZone()
        {
            GameEvents.Instance.EnterEnemyZone(10);
            _levelZoneList[_currentZone].AiGroup.SetActive(true);
        }

        public void ActivateLevelBridge()
        {
            _levelZoneList[_currentZone].Bridge.SetActive(true);
            _levelZoneList[_currentZone].Bridge.transform.DOScale(Vector3.zero,2f).From();
            _currentZone++;
            if(_currentZone == _levelZoneList.Count)
            {
                // Switcg to Next Level
            }
        }
    }
}