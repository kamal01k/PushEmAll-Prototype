using Assignment.Events;
using UnityEngine;

namespace Assignment.AI
{
    public class AIManager : MonoBehaviour, IAIManager
    {
        public int AiCount
        {
            get
            {
                if(m_aiCount < 0)
                {
                    m_aiCount = 0;
                    GameEvents.Instance.ZoneComplete();
                }
                return m_aiCount;
            } 
            set 
            {
                m_aiCount = value;
            }
        }

        [SerializeField] private int m_aiCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void EnemyKill()
        {
            AiCount--;
            
        }
    }
}