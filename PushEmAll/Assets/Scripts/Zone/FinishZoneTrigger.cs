using Assignment.Events;
using Assignment.Player;
using UnityEngine;

namespace Assignment.Zone
{
    public class FinishZoneTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IPlayerController a_player))
            {
                gameObject.SetActive(false);
                GameEvents.Instance.LevelFinish();
            }
        }
    }
}