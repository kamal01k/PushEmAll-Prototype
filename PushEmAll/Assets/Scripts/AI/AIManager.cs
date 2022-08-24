using Assignment.Events;
using Assignment.UI;
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
                }
                return m_aiCount;
            } 
            set 
            {
                m_aiCount = value;
            }
        }

        private int m_aiCount = 0;

        public void EnemyKill()
        {
            AiCount--;
            //Debug.Log($"ai count {m_aiCount}");
            if(m_aiCount <= 0)
            {
                m_aiCount = 0;
                GameEvents.Instance.ZoneComplete();
            }
        }
    }
}