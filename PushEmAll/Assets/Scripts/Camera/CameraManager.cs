using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Assignment.Camera
{
    public class CameraManager : MonoBehaviour, ICameraManager
    {
        [SerializeField] private GameObject _virtualCameraObject;
        [SerializeField] private float startCameraTime = 4f;

        private CinemachineVirtualCamera m_virtualCamera;
        private CinemachineTransposer m_transposer;
        private Vector3 m_followOffset = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            m_virtualCamera = _virtualCameraObject.GetComponent<CinemachineVirtualCamera>();
            m_transposer = m_virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            m_followOffset = m_transposer.m_FollowOffset;
        }

        public void StartCamera()
        {
            Vector3 l_tweenOffset = Vector3.zero;
            l_tweenOffset = m_followOffset;
            l_tweenOffset.x = 50;

            AnimateCameraTransposer(l_tweenOffset, m_followOffset);
        }

        public void GameoverCamera()
        {
            Vector3 l_currentOffset = m_transposer.m_FollowOffset;
            Vector3 l_tweenOffset = m_transposer.m_FollowOffset;
            l_tweenOffset.y = 50;
            AnimateCameraTransposer(l_currentOffset, l_tweenOffset);
        }

        public void ResetCamera()
        {
            Vector3 l_tweenOffset = m_transposer.m_FollowOffset;
            AnimateCameraTransposer(l_tweenOffset, m_followOffset);
        }

        private void AnimateCameraTransposer(Vector3 a_to, Vector3 a_from)
        {
            DOTween.To(() => a_to, x => a_to = x, a_from, startCameraTime)
                    .OnUpdate(() =>
                    {
                        m_transposer.m_FollowOffset = a_to;
                    });
        }
    }
}