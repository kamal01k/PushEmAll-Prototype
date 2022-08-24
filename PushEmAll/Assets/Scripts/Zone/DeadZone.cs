using Assignment.AI;
using Assignment.Events;
using Assignment.Player;
using UnityEngine;

namespace Assignment.Zone
{
    public class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IEnemy a_enemy))
            {
                other.gameObject.SetActive(false);
                GameEvents.Instance.EnemyKill();
            }
            else if(other.TryGetComponent(out IPlayerController a_player))
            {
                other.gameObject.SetActive(false);
                GameEvents.Instance.GameOver();
            }
        }
    }
}